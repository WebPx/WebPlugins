using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebPx.Web.Configuration
{
    public class ResourceProvider : NamedConfigElement
    {
        public ResourceProvider()
        {

        }

        //[StringValidator(MinLength = 1)]
        [ConfigurationProperty("type", IsRequired = true, IsKey = true)]
        public string Type
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

    }
}
