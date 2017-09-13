using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WebPx.Web.Plugins.Design
{
    internal class DesignScope : IDisposable
    {
        public DesignScope(IDesignSupport designSupport)
        {
            this.Parent = DesignScope.Current;
            DesignScope.Current = this;
            this.designSupport = designSupport;
        }

        private IDesignSupport designSupport;

        public bool DesignMode { get { return designSupport.GetDesignMode(); } }

        public IServiceProvider ServiceProvider { get { return designSupport.ServiceProvider; } }

        public void Dispose()
        {
            if (this == DesignScope.Current)
                DesignScope.Current = this.Parent;
        }

        public static DesignScope Current { get; private set;  }

        public DesignScope Parent { get; private set;  }
    }
}
