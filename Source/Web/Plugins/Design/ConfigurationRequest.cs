using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WebPx.Web.Plugins.Design
{
    class ConfigurationRequest
    {
        public ConfigurationRequest(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; private set; }

        public string ConnectionStringName { get; set; }
    }
}
