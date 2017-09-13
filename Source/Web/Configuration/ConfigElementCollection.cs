using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebPx.Web.Configuration
{
    public abstract class ConfigElementCollection<TElement> : ConfigurationElementCollection
        where TElement : ConfigurationElement, INamedConfigElement, new()
    {
        public ConfigElementCollection()
        {

        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TElement)element).Name;
        }

        public new TElement this[string name]
        {
            get { return (TElement)BaseGet(name); }

        }
    }
}
