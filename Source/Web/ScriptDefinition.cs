using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace WebPx.Web
{
    public sealed class ScriptDefinition
    {
        public ScriptDefinition()
        {

        }

        public string Name { get; set; }

        public ScriptResourceDefinition Definition { get; set; }
    }
}
