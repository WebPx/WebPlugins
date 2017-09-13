using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebPx.Web
{
    public class PictureProvider
    {
        public PictureProvider()
        {

        }

        private static readonly Guid defaultPictureId = Guid.Empty;

        private static Picture _defaultPicture;

        private static Picture CreateDefaultPicture(HttpContext context)
        {
            var defaultFilename = GetDefaultFilename(context);
            Picture picture = GetPictureFromFile(defaultFilename);
            return picture;
        }

        private static Picture GetPictureFromFile(string defaultFilename)
        {
            var fileTime = File.GetLastWriteTime(defaultFilename);
            var picture = new Picture();
            picture.Id = defaultPictureId;
            picture.Name = "DefaultPicture";
            picture.ETag = GetHashCode(fileTime);
            picture.LastUpdate = fileTime;
            return picture;
        }

        protected static string GetHashCode(object tag)
        {
            return $"{Convert.ToBase64String(BitConverter.GetBytes(tag.GetHashCode()))},0";
        }

        public Picture GetPicture(HttpContext context)
        {
            var picturePath = UserProfile.Current?.PicturePath;
            Picture result = null;
            if (!string.IsNullOrEmpty(picturePath))
                result = GetPictureFromFile(GetFromVirtualPath(context, picturePath));
            return result ?? _defaultPicture;
        }

        private static string _defaultFilename;

        private static string GetDefaultFilename(HttpContext context = null)
        {
            if (_defaultFilename == null)
            {
                _defaultFilename = ConfigurationManager.AppSettings["portal:defaultUserPic"] ?? "~/assets/images/user-1.png";
                _defaultFilename = GetFromVirtualPath(context, _defaultFilename); 
            }
            return _defaultFilename;
        }

        private static string GetFromVirtualPath(HttpContext context, string _defaultFilename)
        {
            return context.Request.MapPath(_defaultFilename);
        }

        public Byte[] GetPictureBytes(Picture picture)
        {
            string defaultResource = GetDefaultFilename();
            string filename = defaultResource;
            var result = File.ReadAllBytes(filename);
            return result;
        }

        internal void Init(HttpContext context)
        {
            _defaultPicture = CreateDefaultPicture(context);
        }
    }
}
