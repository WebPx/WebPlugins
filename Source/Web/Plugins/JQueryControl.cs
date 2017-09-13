using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPx.Web.Controls;

namespace WebPx.Web.Plugins
{
    public abstract class JQueryControl : ScriptControl, ICallbackEventHandler, IJQueryControl
        //, ICallbackContainer
    {
        public JQueryControl()
        {
            //this.ClientSide = true;
            this.ClientObject = true;
        }

        public JQueryControl(HtmlTextWriterTag tagKey) : this()
        {
            this._tagKey = tagKey;
        }

        private HtmlTextWriterTag? _tagKey;

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return this._tagKey ?? base.TagKey;
            }
        }

        #region Script Control Code

        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            if (this.ClientObject)
            {
                var sd = new jQueryScriptDescriptor(this);
                yield return sd;
            }
        }

        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            yield return new ScriptReference() { Name = "jquery" };
            if (this.RequiresBootStrap)
                yield return new ScriptReference() { Name="bootstrap"/*, Path = "~/assets/global/plugins/bootstrap/js/bootstrap.min.js"*/ };
            var jqueryScriptReference = this.GetJQueryScriptReference();
            if (jqueryScriptReference != null)
                yield return jqueryScriptReference;
        }
        #endregion

        #region Control Implementation
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            AddCallBack(writer);
        }

        protected override void OnInit(EventArgs e)
        {
            StyleSheetManager.RegisterControl(this);
            this.scriptNameDefaultValue = this.ScriptName;
            this.scriptPathDefaultValue = this.ScriptPath;
            base.OnInit(e);
        }

        #endregion

        #region JQuery Client Scripting
        [Category("JQuery Client Script")]
        [DefaultValue(true)]
        public bool ClientObject { get; set; }

        [Category("JQuery Client Script")]
        [DefaultValue(null)]
        [Description("The client Id for the scripting object ")]
        [IDReferenceProperty]
        [TypeConverter(typeof(AssociatedControlConverter))]
        [Themeable(false)]
        public string ClientObjectId { get; set; }
        #endregion

        #region IJQueryControl Implementation
        public virtual string GetJQueryScript()
        {
            return null;
        }

        protected virtual IEnumerable<StyleSheetReference> GetStyleSheets()
        {
            return null;
        }

        string IJQueryControl.GetJQueryScript()
        {
            return this.GetJQueryScript();
        }

        IEnumerable<StyleSheetReference> IJQueryControl.GetStyleSheets()
        {
            return this.GetStyleSheets();
        }

        #endregion

        #region ICallbackEventHandler Implementation
        private string _callbackResult;

        public event CallBackEventHandler Callback;

        void ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
        {
            //this.RaiseCallbackEvent(eventArgument);
            var args = new CallBackEventArgs(eventArgument);
            Callback?.Invoke(this, args);
            _callbackResult = args.Result;
        }

        string ICallbackEventHandler.GetCallbackResult()
        {
            //return this.GetCallbackResult();
            return _callbackResult;
        }

        #endregion

        #region Callback Client Scripts

        protected virtual void AddCallBack(HtmlTextWriter writer)
        {
            if (CallbackRequired())
                writer.AddAttribute(HtmlTextWriterAttribute.Onchange, GetCallbackFunction(), false);
        }

        protected bool CallbackRequired()
        {
            return this.Callback?.GetInvocationList().Length > 0;
        }

        protected string GetCallbackFunction()
        {
            var callbackFunction = "callbackContext()";
            var argument = this.GetClientArgumentScript();
            var script = this.Page.ClientScript.GetCallbackEventReference(this, argument, this.ClientCallback, callbackFunction, this.ClientErrorCallback, false);
            return script;
        }

        protected virtual string GetClientArgumentScript()
        {
            return $"$('#{this.ClientID}')[0].value";
        }

        [Category("Client Script")]
        public string ClientCallback { get; set; }

        [Category("Client Script")]
        public string ClientErrorCallback { get; set; }
        #endregion

        #region JQuery Control Implementation

        private string scriptNameDefaultValue;
        private string scriptPathDefaultValue;

        public ControlMode ControlMode { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RequiresBootStrap { get; set; }

        protected virtual ScriptReference GetJQueryScriptReference()
        {
            string filePath = $"{this.ScriptPath}/{this.ScriptName}";
            string url = Page.ResolveClientUrl(filePath);
            return new ScriptReference(url);
        }

        [Category("Behavior")]
        public string ScriptName { get; set; }

        [Category("Behavior")]
        public string ScriptPath { get; set; }

        #endregion

        #region Design Time support
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScriptNameSpecified
        {
            get
            {
                return !string.Equals(this.ScriptName, this.scriptNameDefaultValue);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScriptPathSpecified
        {
            get
            {
                return !string.Equals(this.ScriptPath, this.scriptPathDefaultValue);
            }
        }
        #endregion

        //protected void RaiseCallbackEvent(string eventArgument)
        //{
        //}

        //protected string GetCallbackResult()
        //{
        //}

        //[Category("Server")]
        //public virtual bool ClientSide { get; protected set; }
    }
}
