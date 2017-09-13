using System;
using System.Configuration;

namespace WebPx.Web.Configuration
{
    [ConfigurationCollection(typeof(StyleSheet))]
    public sealed class StyleSheetCollection : ConfigElementCollection<StyleSheet>
    {
        public StyleSheetCollection()
        {

        }
    }
}