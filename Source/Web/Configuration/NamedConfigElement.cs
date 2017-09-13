using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebPx.Web.Configuration
{
    public abstract class NamedConfigElement : ConfigurationElement, INamedConfigElement
    {
        public NamedConfigElement()
        {

        }

        //[StringValidator(MinLength = 1)]
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
    }
}
