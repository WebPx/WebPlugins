using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebPx.Web.Configuration;

namespace WebPx.Web
{
    public static class Pages
    {
        public static string GetPath(string pageKey)
        {
            return Settings.Provider.GetPagePath(pageKey);
        }
    }
}
