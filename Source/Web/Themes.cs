using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebPx.Web
{
    public static class Themes
    {
        private static Theme[] _themes;

        public static Theme[] Items
        {
            get
            {
                if (_themes == null)
                {
                    var server = HttpContext.Current?.Server;
                    var themes = new List<Theme>();
                    if (server != null)
                    {
                        string appBasePath = "~/App_Themes";
                        string physicalBasePath = server.MapPath(appBasePath);
                        string[] themeFolders = Directory.GetDirectories(physicalBasePath);
                        foreach (string t in themeFolders)
                        {
                            string name = Path.GetDirectoryName(t);
                            string themePath = Path.Combine(physicalBasePath, name);
                            var cssFiles = Directory.GetFiles(themePath, "*.css", SearchOption.TopDirectoryOnly);
                            var skinFiles = Directory.GetFiles(themePath, "*.skin", SearchOption.TopDirectoryOnly);
                            string iconUrl = null;
                            bool hasStyleSheets = cssFiles?.Length > 0;
                            bool hasSkins = skinFiles?.Length > 0;
                            themes.Add(new Theme(name, iconUrl, hasStyleSheets, hasSkins));
                        }
                    }
                    _themes = themes.ToArray();
                }
                return _themes;
            }
        }
    }
}
