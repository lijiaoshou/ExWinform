using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using WinformCommon;

namespace WinformCommon
{
    public class ScopeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.Modal;
            }

            return base.GetEditStyle(context);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService = null;

            if (context != null && context.Instance != null && provider != null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    MyListControl control = (MyListControl)context.Instance;
                    ScopeEditorDialog dlg = new ScopeEditorDialog(control.Scope);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        value = dlg.Scope;
                        return value;
                    }
                }
            }

            return value;
        }
    }
}