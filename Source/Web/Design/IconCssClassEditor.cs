using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;

namespace WebPx.Web.Design
{
    internal sealed class IconCssClassEditor : UITypeEditor
    {
        public IconCssClassEditor()
        {

        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        private ITypeDescriptorContext _context;

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _context = context;

            var form = new IconCssClassForm() { IconCssClass = (string)value, ServiceProvider = provider };
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _context.OnComponentChanging();
                _context.PropertyDescriptor.SetValue(_context.Instance, form.IconCssClass);
                _context.OnComponentChanged();
            }

            return base.EditValue(context, provider, value);
        }
    }
}
