using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Web;

namespace WebPx.Web
{
    public class PictureHandler : IHttpHandler
    {
        private const string ifNoneMatchHeader = "If-None-Match";
        private const string ifModifiedSinceHeader = "If-Modified-Since";
        private const string eTagHeader = "ETag";
        private const string dateHeader = "Date";
        private const string lastModifiedHeader = "Last-Modified";
        //private const string cacheControlHeader = "Cache-Control";
        //private const string contentLocationHeader = "Content-Location";
        //private const string expireseHeader = "Expires";
        //private const string varyHeader = "Vary";

        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        protected virtual PictureProvider GetProvider()
        {
            return new PictureProvider();
        }

        private PictureProvider _provider;

        internal virtual PictureProvider Provider
        {
            get
            {
                if (_provider == null)
                    _provider = new PictureProvider();
                return _provider;
            }
            set
            {
                _provider = value;
            }
        }

        private bool providerInited = false;

        private void InitProvider(HttpContext context)
        {
            if (providerInited)
                return;
            this.Provider.Init(context);
            providerInited = true;
        }

        public void ProcessRequest(HttpContext context)
        {
            this.InitProvider(context);

            var ifNoneMatch = context.Request.Headers[ifNoneMatchHeader];
            var ifModifiedSince = context.Request.Headers[ifModifiedSinceHeader];
            var ifNoneMatchWildCard = ifNoneMatch == "*";
            var eTag = ifNoneMatchWildCard ? null : ifNoneMatch;

            var picture = this.Provider.GetPicture(context);

            string defaultResource = ConfigurationManager.AppSettings["portal:defaultUserPic"] ?? "~/assets/images/user-1.png";
            string filename = context.Request.MapPath(defaultResource);
            string contentType = MimeMapping.GetMimeMapping(filename);

            DateTime? cachedDate = null;

            if (!string.IsNullOrEmpty(ifModifiedSince))
            {
                DateTime ifModifiedSinceDate;
                if (DateTime.TryParseExact(ifModifiedSince, CultureInfo.CurrentCulture.DateTimeFormat.RFC1123Pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out ifModifiedSinceDate))
                    cachedDate = ifModifiedSinceDate;
            }

            int statusCode = 200;

            //var fileDate = DateTime.Now;

            //if (File.Exists(filename))
            //    fileDate = File.GetLastWriteTime(filename);
            var fileDate = picture.LastUpdate;

            string currentETag = picture.ETag;
            bool cached = cachedDate.HasValue;
            bool eTagPresent = string.IsNullOrEmpty(eTag);

            bool ifNoneMatchPresent = !string.IsNullOrEmpty(ifNoneMatch);
            //Cache-Control, Content-Location, Date, ETag, Expires, and Vary
            bool noneMatch = true;
            if (ifNoneMatchPresent)
                switch (context.Request.HttpMethod)
                {
                    case "GET":
                    case "HEAD":
                        noneMatch = cached && eTagPresent && !string.Equals(eTag, currentETag, StringComparison.OrdinalIgnoreCase);
                        break;
                    case "POST":
                    case "OPTIONS":
                    case "PUT":
                    case "TRACE":
                    case "DELETE":
                        noneMatch = false;
                        statusCode = 412;
                        break;
                    default:
                        break;
                }

            if (statusCode == 200)
                if (ifNoneMatchPresent || cached)
                {
                    bool changed = noneMatch || fileDate > cachedDate.Value;

                    if (!changed)
                        statusCode = 304;
                }

            bool emit = statusCode == 200;

            context.Response.AddHeader(eTagHeader, currentETag);
            context.Response.Cache.SetLastModified(fileDate);
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = contentType;
            if (emit)
            {
                var bytes = this.Provider.GetPictureBytes(picture);
                context.Response.BinaryWrite(bytes);
                //context.Response.WriteFile(filename);
            }
        }

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        #endregion
    }
}
