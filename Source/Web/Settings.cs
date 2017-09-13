using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    public static class Settings
    {
        static Settings()
        {
            Load();
        }

        private static void Load()
        {
        }

        private static SettingsProvider _provider;

        public static SettingsProvider Provider
        {
            get
            {
                if (_provider == null)
                    _provider = new ConfigurationSettingsProvider();
                return _provider;
            }
        }

        public static string GetPagePath(string pageKey)
        {
            return Provider.GetPagePath(pageKey);
        }

        public static object GetValue(string key)
        {
            return Provider.GetValue(key);
        }

        public static T GetValue<T>(string key)
        {
            return Provider.GetValue<T>(key);
        }

        public static bool HasKey(string key)
        {
            return Provider.HasKey(key);
        }
    }
}
