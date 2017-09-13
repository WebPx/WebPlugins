using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace WebPx.Web.Plugins
{
    public abstract class SmartControl : WebControl, IDesignSupport
    {
        private IServiceProvider _serviceProvider;

        IServiceProvider IDesignSupport.ServiceProvider
        {
            get
            {
                return this._serviceProvider;
            }
            set
            {
                _serviceProvider = value;
            }
        }


        bool IDesignSupport.GetDesignMode()
        {
            return this.DesignMode;
        }
    }
}
