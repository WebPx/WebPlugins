using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebPx.Web.Configuration
{
    [ConfigurationCollection(typeof(SitePage), CollectionType = ConfigurationElementCollectionType.BasicMap, AddItemName = "page")]
    public class SitePageCollection : ConfigElementCollection<SitePage>
    {
        public SitePageCollection()
        {

        }
    }
}
