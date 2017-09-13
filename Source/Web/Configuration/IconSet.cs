using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebPx.Web.Configuration
{
    public class IconSet : NamedConfigElement
    {
        public IconSet()
        {

        }

        //[StringValidator(MinLength = 1)]
        [ConfigurationProperty("path", IsRequired = false, IsKey = false)]
        public string Path
        {
            get { return (string)base["path"]; }
            set { base["path"] = value; }
        }
    }
}
