using System;
using System.Configuration;

namespace WebPx.Web.Configuration
{
    [ConfigurationCollection(typeof(Script))]
    public sealed class ScriptCollection : ConfigElementCollection<Script>
    {
        public ScriptCollection()
        {

        }
    }
}