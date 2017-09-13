using System.ComponentModel;

namespace WebPx.Web.Plugins
{
    public sealed class StyleSheetReference
    {
        public StyleSheetReference()
        {

        }

        public StyleSheetReference(string name, string url) 
        {
            this.Name = name;
            this.Url = url;
        }

        [NotifyParentProperty(true)]
        public string Name { get; set; }

        [NotifyParentProperty(true)]
        public string Url { get; set; }

        [NotifyParentProperty(true)]
        public string DebugUrl { get; set; }

        [NotifyParentProperty(true)]
        public string CdnUrl { get; set; }

        [NotifyParentProperty(true)]
        public string CdnDebugUrl { get; set; }

        public string SRIKey { get; set; }
    }
}