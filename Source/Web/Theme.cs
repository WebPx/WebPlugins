using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    public sealed class Theme
    {
        internal Theme(string name, string iconUrl, bool hasStyleSheets, bool hasSkins)
        {
            this.Name = name;
            this.IconUrl = iconUrl;
            this.HasStyleSheets = HasStyleSheets;
            this.HasSkins = hasSkins;
        }

        public string Name { get; private set; }

        public string IconUrl { get; private set; }

        public bool HasStyleSheets { get; private set; }

        public bool HasSkins { get; private set; }
    }
}
