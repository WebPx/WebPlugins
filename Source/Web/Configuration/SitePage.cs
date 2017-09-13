using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebPx.Web.Configuration
{
    public class SitePage : NamedConfigElement
    {
        public SitePage()
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
