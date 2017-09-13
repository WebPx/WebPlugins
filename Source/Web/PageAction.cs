using System;
using System.ComponentModel;

namespace WebPx.Web
{
    [Serializable]
    public class PageAction
    {
        public PageAction()
        {
            this.Enabled = true;
        }

        [Category("Appearance")]
        public string Title { get; set; }

        [Category("Appearance")]
        public string Name { get; set; }

        [Category("Appearance")]
        public string Icon { get; set; }

        [Category("Appearance")]
        public string Url { get; set; }

        [Category("Appearance")]
        [DefaultValue(false)]
        public bool BeginGroup { get; set; }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool Enabled { get; set; }

        internal IPageActions Source { get; set; }
    }
}