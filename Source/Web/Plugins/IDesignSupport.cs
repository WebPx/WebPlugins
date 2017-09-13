using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web.Plugins
{
    interface IDesignSupport
    {
        IServiceProvider ServiceProvider { get; set; }

        bool GetDesignMode();
    }
}
