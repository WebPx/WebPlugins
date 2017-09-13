using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebPx.Web.Configuration
{
    [ConfigurationCollection(typeof(ResourceProvider))]
    public sealed class ResourceProviderCollection : ConfigElementCollection<ResourceProvider>
    {
        public ResourceProviderCollection()
        {

        }
    }
}
