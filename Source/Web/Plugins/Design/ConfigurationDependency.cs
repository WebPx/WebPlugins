using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web.Plugins.Design
{
    [Flags]
    enum ConfigurationDependency
    {
        None = 0,
        ConnectionString = 1,
        StyleSheets = 2,
        All = 3
    }
}
