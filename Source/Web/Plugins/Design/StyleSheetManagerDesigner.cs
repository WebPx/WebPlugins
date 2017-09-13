using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI.Design;

namespace WebPx.Web.Plugins.Design
{
    class StyleSheetManagerDesigner : ControlDesigner, IServiceProvider
    {
        public StyleSheetManagerDesigner()
        {
            
        }

        object IServiceProvider.GetService(Type serviceType)
        {
            var result = this.GetService(serviceType);
            return result;
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            ((IDesignSupport)component).ServiceProvider = this;
        }

        internal static readonly string ErrorDesignTimeHtmlTemplate = "<table cellpadding=\"4\" cellspacing=\"0\" style=\"font: messagebox; color: buttontext; background-color: buttonface; border: solid 1px; border-top-color: buttonhighlight; border-left-color: buttonhighlight; border-bottom-color: buttonshadow; border-right-color: buttonshadow\">\r\n                <tr><td nowrap><span style=\"font-weight: bold; color: red\">{0}</span> - {1}</td></tr>\r\n                <tr><td>{2}</td></tr>\r\n              </table>";

        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            var sb = new StringBuilder();
            sb.Append($"{e.GetType().Name}: {e.Message}<br />Stack Trace: <pre style='color:red'>{e.StackTrace}</pre>");
            return string.Format(ErrorDesignTimeHtmlTemplate, this.ViewControl.GetType().Name, this.ViewControl.ID, sb.ToString());
        }
    }
}
