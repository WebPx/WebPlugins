using System.Web.UI;

namespace WebPx.Web.Plugins
{
    class jQueryScriptDescriptor : ScriptDescriptor
    {
        public jQueryScriptDescriptor(IJQueryControl jQueryControl)
        {
            _jQueryControl = jQueryControl;
        }

        private IJQueryControl _jQueryControl;

        protected override string GetScript()
        {
            return _jQueryControl.GetJQueryScript();
        }
    }
}
