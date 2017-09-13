using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Windows;
using WebPx.Web.Configuration;
using WebPx.Web.Plugins.Design;

[assembly: PreApplicationStartMethod(typeof(WebPx.Web.WebResourceManagement), "AutoInit")]

namespace WebPx.Web
{
    public sealed class WebResourceManagement
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AutoInit()
        {
            var instance = Configuration.WebSection.Instance;
            if (instance!=null && instance.AutoInit)
            {
                Init();
            }
        }

        private static bool _inited = false;

        public static void Init()
        {
            if (_inited)
                return;
            LoadProviders();
            StyleSheets = new StyleSheetDefinitionCollection();
            if (ResourcesProvider != null)
            {
                var scripts = ResourcesProvider?.GetScripts();
                if (scripts!=null)
                    foreach (var item in scripts)
                        ScriptManager.ScriptResourceMapping.AddDefinition(item.Name, item.Definition);
                var styleSheetDefs = ResourcesProvider.GetStyleSheets();
                //throw new System.Exception($"{styleSheetDefs.Count()} StyleSheets loaded from provider");
                if (styleSheetDefs!=null)
                    foreach (StyleSheetDefinition item in styleSheetDefs)
                    WebResourceManagement.StyleSheets.Add(item);
            }
            _inited = true;
        }

        internal static IEnumerable<StyleSheetDefinition> GetStyleSheets(WebSection instance)
        {
            var styleSheets = instance?.StyleSheets;
            if (styleSheets != null)
            {
                //throw new Exception($"{styleSheets.Count} Stylesheets configured");
                foreach (Configuration.StyleSheet styleSheet in styleSheets)
                {
                    //throw new Exception($"StyleSheet {styleSheet.Name}");
                    var styleSheetDefinition = new StyleSheetDefinition()
                    {
                        Name = styleSheet.Name,
                        Path = styleSheet.Path,
                        DebugPath = styleSheet.DebugPath,
                        CdnPath = styleSheet.CdnPath,
                        CdnDebugPath = styleSheet.CdnDebugPath,
                        //CdnSupportsSecureConnection = true
                    };
                    yield return styleSheetDefinition;
                }
            }
        }

        private static void LoadProviders()
        {
            var instance = Configuration.WebSection.Instance;
            var providers = instance?.ResourceManagement;
            if (DesignScope.Current?.DesignMode ?? false)
                ResourcesProvider = new DesignTimeResourceProvider();
            else if (providers != null && providers.Count > 0)
            {

            }
            else
            {
                ResourcesProvider = new ConfigurationResourceProvider();
            }
            ResourcesProvider?.Init();
        }

        public static ResourceProvider ResourcesProvider { get; private set; }

        public static StyleSheetDefinitionCollection StyleSheets { get; private set; }
    }
}
