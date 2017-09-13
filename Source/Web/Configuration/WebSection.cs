using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebPx.Web.Configuration
{
    public sealed class WebSection : ConfigurationSection
    {
        [ConfigurationProperty("autoInit", IsRequired = false, IsKey = false)]
        public bool AutoInit
        {
            get { return (bool?)base["autoInit"] ?? true; }
            set { base["autoInit"] = value; }
        }

        [ConfigurationProperty("resources")]
        [ConfigurationCollection(typeof(Script), AddItemName = "add", CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public ResourceProviderCollection ResourceManagement
        {
            get { return (ResourceProviderCollection)base["resources"]; }
        }

        [ConfigurationProperty("scripts")]
        [ConfigurationCollection(typeof(Script), AddItemName = "add", CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public ScriptCollection Scripts
        {
            get { return (ScriptCollection)base["scripts"]; }
        }

        [ConfigurationProperty("styleSheets")]
        [ConfigurationCollection(typeof(StyleSheet), AddItemName = "add", CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public StyleSheetCollection StyleSheets
        {
            get { return (StyleSheetCollection)base["styleSheets"]; }
        }

        [ConfigurationProperty("iconSets")]
        [ConfigurationCollection(typeof(StyleSheet), AddItemName = "add", CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public IconSetCollection IconSets
        {
            get { return (IconSetCollection)base["iconSets"]; }
        }

        [ConfigurationProperty("pages")]
        [ConfigurationCollection(typeof(SitePage), AddItemName = "page", CollectionType = ConfigurationElementCollectionType.BasicMap)]
        public SitePageCollection Pages
        {
            get { return (SitePageCollection)base["pages"]; }
        }

        private static WebSection _section = null;

        public static WebSection Instance
        {
            get
            {
                if (_section == null)
                {
                    var r = (Configuration.WebSection)ConfigurationManager.GetSection("webpx/web");
                    _section = r;
                }
                return _section;
            }
        }
    }
}
