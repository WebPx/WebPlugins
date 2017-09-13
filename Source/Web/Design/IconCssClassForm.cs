using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebPx.Web.Plugins;

namespace WebPx.Web.Design
{
    partial class IconCssClassForm : Form, IDesignSupport
    {
        public IconCssClassForm()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        public string IconCssClass { get; set; }

        public IServiceProvider ServiceProvider { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.UXIconClassName.Text = this.IconCssClass;
            using (var designScope = new Plugins.Design.DesignScope(this))
            {
                var instance = Configuration.WebSection.Instance;
                //if (instance==null)
                    MessageBox.Show($"No Instance {instance==null}");
                var iconSets = instance?.IconSets;
                if (iconSets != null)
                    foreach (Configuration.IconSet iconSet in iconSets)
                    {
                        var path = iconSet.Path;
                        var node = this.treeView1.Nodes.Add(iconSet.Name);
                    }
            }
        }

        public bool GetDesignMode()
        {
            return true;
        }
    }
}
