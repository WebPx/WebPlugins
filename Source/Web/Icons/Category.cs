using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WebPx.Web.Icons
{
    [Serializable]
    public sealed class Category
    {
        public Category()
        {

        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        private IconCollection _icons;

        [XmlElement("icon")]
        public IconCollection Icons
        {
            get
            {
                if (_icons == null)
                    _icons = new IconCollection();
                return _icons;
            }
        }

    }
}
