using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformCommon
{
    public partial class ScopeEditorControl : UserControl
    {
        public ScopeEditorControl()
        {
            InitializeComponent();
        }

        private Scope _oldScope;
        private Scope _newScope;
        private Boolean canceling;

        public ScopeEditorControl(Scope scope)
        {
            _oldScope = scope;
            _newScope = scope;
            InitializeComponent();
        }

        public Scope Scope
        {
            get
            {
                return _newScope;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(textBox1.Text);

            }
            catch (FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("无效的值", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(textBox2.Text);
            }
            catch (FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("无效的值", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                _oldScope = _newScope;
                canceling = true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ScopeEditorControl_Leave(object sender, EventArgs e)
        {
            if (!canceling)
            {
                _newScope.Max = Convert.ToInt32(textBox1.Text);
                _newScope.Min = Convert.ToInt32(textBox2.Text);
            }
        }

        private void ScopeEditorControl_Load(object sender, EventArgs e)
        {
            textBox1.Text = _oldScope.Max.ToString();
            textBox2.Text = _oldScope.Min.ToString();
        }
    }
}
