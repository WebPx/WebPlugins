using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPx.Network;

namespace WebPx.Web.Plugins
{
    [DefaultProperty("Value")]
    [ToolboxData("<{0}:StyleSheetManager runat=server></{0}:StyleSheetManager>")]
    [ParseChildren(true), PersistChildren(false)]
    [Designer(typeof(Design.StyleSheetManagerDesigner))]
    public class StyleSheetManager : SmartControl
    {
        public StyleSheetManager()
        {
            this.EnableCDN = true;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Items.Add(this.GetType(), this);
            _manager = true;
        }

        public static bool _manager = false;

        public static StyleSheetManager Current
        {
            get
            {
                var page = HttpContext.Current?.CurrentHandler as Page;
                var current = page?.Items[typeof(StyleSheetManager)] as StyleSheetManager;
                return current;
            }
        }

        internal static StyleSheetManager GetCurrent(Page page)
        {
            var thePage = HttpContext.Current?.CurrentHandler as Page ?? page;
            var current = thePage?.Items[typeof(StyleSheetManager)] as StyleSheetManager;
            return current;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            var context = StyleSheetManager.GetCurrentContext(this.Page);
            var controls = context?.GetAll();
            if (controls != null)
                foreach (var control in controls)
                {
                    var styleSheets = control.GetStyleSheets();
                    if (styleSheets != null)
                    {
                        //StyleSheetManager styleSheetManager = GetStyleSheetManager();
                        //if (styleSheetManager != null)
                        {
                            foreach (var styleSheet in styleSheets)
                                this.Add(styleSheet);
                        }
                    }
                }
            //writer.Write($"controls: {controls!=null} {controls?.Count()??-1}");

            int c = 0;
            //writer.Write($"<!-- Use CDN {NetworkSegmentation.GetIPSegmentType(this.GetIPAddress())} -->\r\n");
            using (var designScope = new Design.DesignScope(this))
            {
                if (this.DesignMode)
                    WebResourceManagement.Init();
                foreach (var styleSheet in this.References)
                {
                    string name = styleSheet.Name;
                    bool isDebug = HttpContext.Current?.IsDebuggingEnabled ?? false;
                    bool isCDN = EnableCDN && ShouldUseCDN();
                    string url = styleSheet.Url;
                    if (!string.IsNullOrEmpty(name))
                    {
                        var reference = WebResourceManagement.StyleSheets?[name];
                        if (reference != null)
                        {
                            if (isCDN)
                            {
                                url = isDebug ? reference.CdnDebugPath : reference.CdnPath;
                                if (isDebug && string.IsNullOrEmpty(url))
                                    url = reference.CdnPath;
                            }
                            else
                            {
                                url = isDebug ? reference.DebugPath : reference.Path;
                                if (isDebug && string.IsNullOrEmpty(url))
                                    url = reference.Path;
                            }
                            if (string.IsNullOrEmpty(url))
                                url = reference.Path;

                            //if (reference!=null)
                            //{
                            //    throw new System.Exception($"{name} Path: {reference.Path} url '{url}' isCDN: {isCDN} isDebug: {isDebug}");
                            //}
                        }
                        else
                            if (!DesignMode)
                            throw new StyleSheetReferenceException($"The StyleSheet Definition for '{name}' has not been configured!");
                    }
                    else
                        url = isCDN ? (isDebug ? styleSheet.CdnDebugUrl : styleSheet.CdnUrl) : (isDebug ? styleSheet.DebugUrl : styleSheet.Url);
                    if (!string.IsNullOrEmpty(url))
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, this.Page.ResolveClientUrl(url));
                        writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
                        writer.RenderBeginTag(HtmlTextWriterTag.Link);
                        writer.RenderEndTag();
                        c++;
                    }
                    //else
                    //{
                    //    writer.Write($"<!-- Not found Url from {name} -->\r\n");
                    //}
                }
            }
            //if (DesignMode)
            //    writer.Write($"{{{this.GetType().Name}: {this.ID}. StyleSheets:{c} of {this.References.Count}}} in {WebResourceManagement.ResourcesProvider?.Name??"Not Loaded"}");
        }

        internal static bool RegisterControl(Control control)
        {
            if (control is IJQueryControl)
            {
                StyleSheetContext context = GetOrCreateCurrentContext(control);
                context.Add((IJQueryControl)control);
                return true;
            }
            return false;
        }

        private static StyleSheetContext GetOrCreateCurrentContext(Control control)
        {
            StyleSheetContext context = GetCurrentContext(control.Page);
            bool create = context == null;
            if (create)
            {
                context = new StyleSheetContext();
                control.Page.Items.Add(typeof(StyleSheetContext), context);
            }

            return context;
        }

        private static StyleSheetContext GetCurrentContext(Page page)
        {
            return page.Items[typeof(StyleSheetContext)] as StyleSheetContext;
        }

        private bool ShouldUseCDN()
        {
            var segmentType = NetworkSegmentation.GetIPSegmentType(this.GetIPAddress());
            return segmentType == NetworkSegmentType.Internet;
        }

        private IPAddress GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            var request = context?.Request;
            string ipAddress = request?.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string userIpAddress = null;
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length > 0)
                    userIpAddress = addresses[0];
            }
            IPAddress result = null;
            return IPAddress.TryParse(userIpAddress ?? request?.ServerVariables["REMOTE_ADDR"], out result) ? result : null;
        }

        private StyleSheetReferenceCollection _references = new StyleSheetReferenceCollection();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Themeable(true)]
        public StyleSheetReferenceCollection References
        {
            get
            {
                //if (_references == null)
                //    _references = new StyleSheetReferenceCollection();
                return _references;
            }
        }

        public void Add(StyleSheetReference reference)
        {
            var exists = (from ref1 in _references where ref1.Name == reference.Name select true).SingleOrDefault();
            if (!exists)
                this._references.Add(reference);
        }

        [DefaultValue(true)]
        public bool EnableCDN { get; set; }
    }
}
