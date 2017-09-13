using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    public class Setting<TEntity>
    {
        public Setting(string key, TEntity value = default(TEntity))
        {
            this.Key = key;
            this.Value = value;
        }

        public bool HasValue { get; set; }

        public string Key { get; set; }

        private TEntity _value;

        public TEntity Value
        {
            get
            {
                if (!HasValue)
                {
                    _value = LoadValue();
                    HasValue = true;
                }
                return _value;
            }
            set
            {
                if (!Object.Equals(_value, value))
                {
                    _value = value;
                    HasValue = !Object.Equals(_value, default(TEntity));
                }
            }
        }

        protected virtual TEntity LoadValue()
        {
            return default(TEntity);
        }
    }
}
