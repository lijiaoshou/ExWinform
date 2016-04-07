using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using WinformCommon;

namespace WinformCommon
{
    public partial class ScopeEditorDialog : Form
    {
        private Scope _scope = null;

        public ScopeEditorDialog(Scope scope)
        {
            InitializeComponent();
            _scope = scope;

            textBox1.Text = _scope.Min.ToString();
            textBox2.Text = _scope.Max.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _scope.Min = Convert.ToInt32(textBox1.Text);
            _scope.Max = Convert.ToInt32(textBox2.Text);
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

        [Browsable(true)]
        [Editor(typeof(ScopeEditor), typeof(UITypeEditor))]
        public Scope Scope
        {
            get
            {
                return _scope;
            }
            set
            {
                _scope = value;
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
    }
}