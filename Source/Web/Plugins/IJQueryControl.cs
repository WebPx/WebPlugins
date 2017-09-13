using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web.Plugins
{
    interface IJQueryControl
    {
        string GetJQueryScript();
        IEnumerable<StyleSheetReference> GetStyleSheets();
    }
}
