using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace WebPx.Web
{
    public sealed class SitePage : Setting<string>
    {
        public SitePage(string key) : base(key)
        {

        }

        protected override string LoadValue()
        {
            return Pages.GetPath(this.Key);
        }
    }
}
