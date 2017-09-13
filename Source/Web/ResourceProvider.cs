using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    public abstract class ResourceProvider
    {
        public ResourceProvider()
        {
            this.Name = "Abstract Resource Provider";
        }

        public string Name { get; set; }

        public abstract IEnumerable<ScriptDefinition> GetScripts();

        public abstract IEnumerable<StyleSheetDefinition> GetStyleSheets();

        public abstract void Init();
    }
}
