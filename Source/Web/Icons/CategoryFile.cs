using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WebPx.Web.Icons
{
    [Serializable]
    [XmlRoot("icons")]
    public sealed class CategoryFile
    {
        public CategoryFile()
        {

        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        private CategoryCollection _categories;

        [XmlElement("category")]
        public CategoryCollection Categories
        {
            get
            {
                if (_categories == null)
                    _categories = new CategoryCollection();
                return _categories;
            }
        }
    }
}
