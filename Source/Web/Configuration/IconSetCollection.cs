using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebPx.Web.Configuration
{
    [ConfigurationCollection(typeof(StyleSheet))]
    public sealed class IconSetCollection : ConfigElementCollection<StyleSheet>
    {
        public IconSetCollection()
        {

        }
    }
}
