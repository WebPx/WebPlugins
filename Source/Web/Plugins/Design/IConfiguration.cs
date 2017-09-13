using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web.Plugins.Design
{
    interface IConfiguration
    {
        string ConnectionString { get; set; }

        ConfigurationDependency Dependencies { get; }

        IEnumerable<StyleSheetDefinition> StyleSheets { get; set; }
    }
}
