using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web.Plugins.Design
{
    sealed class DesignTimeResourceProvider : ResourceProvider, IConfiguration
    {
        public DesignTimeResourceProvider()
        {
            this.Name = "DesignTime Resource Provider";
        }

        public string ConnectionString { get; set; }

        public ConfigurationDependency Dependencies { get { return ConfigurationDependency.StyleSheets; } }

        public override IEnumerable<ScriptDefinition> GetScripts()
        {
            return null;
        }

        public override IEnumerable<StyleSheetDefinition> GetStyleSheets()
        {
            return StyleSheets; 
        }

        public IEnumerable<StyleSheetDefinition> StyleSheets { get; set;  }

        public override void Init()
        {
            var configRequest = new ConfigurationRequest(DesignScope.Current?.ServiceProvider);
            DesignerExtensions.LoadConfiguration(this, configRequest);
        }
    }
}
