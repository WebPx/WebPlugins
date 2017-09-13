using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace WebPx.Web
{
    public sealed class ConfigurationResourceProvider : ResourceProvider
    {
        public ConfigurationResourceProvider()
        {
            this.Name = "Configuration Resource Provider";
        }

        public override IEnumerable<ScriptDefinition> GetScripts()
        {
            var instance = Configuration.WebSection.Instance;
            var scripts = instance?.Scripts;
            if (scripts != null)
                foreach (Configuration.Script script in scripts)
                {
                    var resource = new ScriptResourceDefinition()
                    {
                        Path = script.Path,
                        DebugPath = script.DebugPath,
                        CdnPath = script.CdnPath,
                        CdnDebugPath = script.CdnDebugPath,
                        CdnSupportsSecureConnection = true
                    };
                    yield return new Web.ScriptDefinition() { Name = script.Name, Definition = resource };
                }
        }

        public override IEnumerable<StyleSheetDefinition> GetStyleSheets()
        {
            var instance = Configuration.WebSection.Instance;
            return WebResourceManagement.GetStyleSheets(instance);
            //throw new Exception("No Stylesheets configured");
        }

        public override void Init()
        {
        }
    }
}
