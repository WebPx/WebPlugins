using System;
using System.Configuration;
using System.Linq;
using WebPx.Web.Configuration;

namespace WebPx.Web
{
    public sealed class ConfigurationSettingsProvider : SettingsProvider
    {
        public ConfigurationSettingsProvider()
        {
        }

        public override string GetPagePath(string pageKey)
        {
            var pages = WebSection.Instance.Pages;
            if (pages != null)
                foreach (Configuration.SitePage item in pages)
                    if (string.Equals(item.Name, pageKey))
                        return item.Path;
            return null;
        }

        public override object GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public override bool HasKey(string key)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(key);
        }
    }
}