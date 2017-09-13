using System.Configuration;

namespace WebPx.Web.Configuration
{
    public sealed class Script : NamedConfigElement
    {
        public Script()
        {

        }

        //[StringValidator(MinLength = 1)]
        [ConfigurationProperty("path", IsRequired = false, IsKey = false)]
        public string Path
        {
            get { return (string)base["path"]; }
            set { base["path"] = value; }
        }

        //[StringValidator(MinLength = 1)]
        [ConfigurationProperty("debugPath", IsRequired = false, IsKey = false)]
        public string DebugPath
        {
            get { return (string)base["debugPath"]; }
            set { base["debugPath"] = value; }
        }

        //[StringValidator(MinLength = 1)]
        [ConfigurationProperty("cdnPath", IsRequired = false, IsKey = false)]
        public string CdnPath
        {
            get { return (string)base["cdnPath"]; }
            set { base["cdnPath"] = value; }
        }

        //[StringValidator(MinLength = 1)]
        [ConfigurationProperty("cdnDebugPath", IsRequired = false, IsKey = false)]
        public string CdnDebugPath
        {
            get { return (string)base["cdnDebugPath"]; }
            set { base["cdnDebugPath"] = value; }
        }
    }
}