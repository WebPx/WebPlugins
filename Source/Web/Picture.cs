using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Web
{
    public class Picture
    {
        public Picture()
        {

        }

        public Guid Id { get; set; }

        public string ETag { get; set; }

        public DateTime LastUpdate { get; set; }

        public string Name { get; set; }
    }
}
