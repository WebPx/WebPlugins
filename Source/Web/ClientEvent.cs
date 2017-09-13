using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    [Serializable]
    public sealed class ClientEvent
    {
        public ClientEvent()
        {
                
        }

        public ClientEvent(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
