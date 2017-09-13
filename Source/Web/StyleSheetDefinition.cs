namespace WebPx.Web
{
    public class StyleSheetDefinition
    {
        public StyleSheetDefinition()
        {

        }

        private string _name;
        private string _cdnDebugPath;
        private string _cdnPath;
        private string _debugPath;
        private string _path;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string CdnDebugPath
        {
            get
            {
                return (this._cdnDebugPath ?? string.Empty);
            }
            set
            {
                this._cdnDebugPath = value;
            }
        }

        public string CdnPath
        {
            get
            {
                return (this._cdnPath ?? string.Empty);
            }
            set
            {
                this._cdnPath = value;
            }
        }

        public string DebugPath
        {
            get
            {
                return (this._debugPath ?? string.Empty);
            }
            set
            {
                this._debugPath = value;
            }
        }

        public string Path
        {
            get
            {
                return (this._path ?? string.Empty);
            }
            set
            {
                this._path = value;
            }
        }
    }
}