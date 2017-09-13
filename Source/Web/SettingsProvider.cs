using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    public abstract class SettingsProvider
    {
        public abstract string GetPagePath(string pageKey);
        public abstract object GetValue(string key);
        public virtual T GetValue<T>(string key)
        {
            return (T)Convert.ChangeType(this.GetValue(key), typeof(T));
        }

        public abstract bool HasKey(string key);
    }
}
