using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web.Plugins
{
    internal class StyleSheetContext
    {
        public StyleSheetContext()
        {

        }

        private List<IJQueryControl> controls = new List<IJQueryControl>();

        public void Add(IJQueryControl control)
        {
            controls.Add(control);
        }

        public IEnumerable<IJQueryControl> GetAll()
        {
            return controls?.ToArray();
        }
    }
}
