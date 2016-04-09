using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformCommon
{
    #region 第一个控件
    public class FirstControl : Control
    {
        private string _displayText = "Hello World!";
        private Color _textColor = Color.Red;

        [Browsable(true)]
        [DefaultValue("Hello World")]
        public string DisplayText
        {
            get
            {
                return _displayText;
            }
            set
            {
                _displayText = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        public Color TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                _textColor = value;
                Invalidate();
            }
        }

        public void ResetTextColor()
        {
            TextColor = Color.Red;
        }

        public bool ShouldSerializeTextColor()
        {
            return TextColor != Color.Red;
        }

        public FirstControl()
        { }

        private ContentAlignment alignmentValue = ContentAlignment.MiddleRight;

        #region 关于标签
       // 在这个属性之上有两个Attribute，这两个attribute描述了控件在设计时所表现出来的特征。我们来看看在控件设计中有哪些主要用到的设计时Attribute。
       //BrowsableAttribute：描述是否一个属性或事件应该被显示在属性浏览器里。
       //CategoryAttribute：描述一个属性或事件的类别，当使用类别的时候，属性浏览器按类别将属性分组。
       //DescriptionAttribute：当用户在属性浏览器里选择属性的时候，description里指定的文本会显示在属性浏览器的下边，向用户显示属性的功能。
       //BindableAttribute：描述是否一个属性倾向于被绑定。
       //DefaultPropertyAttribute：为组件指定一个默认的属性，当用户在Form设计器上选择一个控件的时候，默认属性会在属性浏览器里被选中。
       //DefaultValueAttribute：为一个简单类型的属性设置一个默认值。
       //EditorAttribute：为属性指定一个特殊的编辑器。
       //LocalizableAttribute：指示一个属性是否能被本地化，任何有这个Attribute的属性将会被持久化到资源文件里。
       //DesignerSerializationVisibilityAttribute：指示一个属性是否或者如何持久化到代码里。
       //TypeConverterAttribute：为属性指定一个类型转换器，类型转换器能将属性的值转化成其它的数据类型。
       //DefaultEventAttribute：为组件指定一个默认的事件，当用户在form设计其中选择一个控件的时候，在属性浏览器中这个事件被选中。
        #endregion
        [Category("Alignment"),Description("Specifies the alignment of text")]
        public ContentAlignment TextAlignment
        {
            get
            {

                return alignmentValue;

            }
            set
            {
                alignmentValue = value;

                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            StringFormat style = new StringFormat();
            style.Alignment = StringAlignment.Near;
            switch (alignmentValue)
            {
                case ContentAlignment.MiddleLeft:
                    style.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    style.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                    style.Alignment = StringAlignment.Center;
                    break;
            }

            e.Graphics.DrawString(
                Text,
                Font,
                new SolidBrush(ForeColor),
                ClientRectangle,style
                );
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FirstControl
            // 
            this.Click += new System.EventHandler(this.FirstControl_Click);
            this.ResumeLayout(false);

        }

        private void FirstControl_Click(object sender, EventArgs e)
        {

        }
    }
    #endregion

    #region 对item内容是写到资源文件还是designer文件中的研究
    public class MyListControl:System.Windows.Forms.Control
    {
        private List<Int32> _list = new List<Int32>();

        #region 添加一个scope属性
        [Browsable(true)]
        //[Editor(typeof(ScopeEditor), typeof(UITypeEditor))]
        //隐藏上边的弹框，改用下变得下拉显示
        [Editor(typeof(ScopeDropDownEditor), typeof(UITypeEditor))]
        public Scope Scope
        {
            get; set;
        }
        #endregion

        public MyListControl()
        {

        }

        [Browsable(true)]
        //下边这个标签将Item的内容不再串行化到资源文件里，而是直接在designer文件里显示
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Int32> Item
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            //绘制控件的边框
            g.DrawRectangle(Pens.Black, new Rectangle(Point.Empty, new Size(Size.Width - 1, Size.Height - 1)));


            for (int i = 0; i < _list.Count; i++)
            {
                g.DrawString(_list[i].ToString(),Font,Brushes.Black,1,i*FontHeight);
            }

        }
    }
    #endregion

    #region 为控件添加类型转化器
    [TypeConverter(typeof(ScopeConverter))]
    public class Scope
    {
        private int _min;
        private int _max;

        public Scope()
        {

        }

        public Scope(int min, int max)
        {
            _min = min;
            _max = max;
        }

        [Browsable(true)]
        public int Min
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;
            }
        }

        [Browsable(true)]
        public int Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
            }
        }
    }

    public class ScopeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string)) return true;
            if (destinationType == typeof(InstanceDescriptor)) return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            string result = "";
            if (destinationType == typeof(string))
            {
                Scope scope = (Scope)value;
                result = scope.Min.ToString() + "," + scope.Max.ToString();
                return result;
             }

            if (destinationType == typeof(InstanceDescriptor))
            {
                ConstructorInfo ci = typeof(Scope).GetConstructor(new Type[] { typeof(Int32), typeof(Int32) });
                Scope scope = (Scope)value;
                return new InstanceDescriptor(ci, new object[] {scope.Min,scope.Max });
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                string[] v = ((string)value).Split(',');
                if (v.GetLength(0) != 2)
                {
                    throw new ArgumentException("Invalid parameter format");
                }

                Scope csf = new Scope();
                csf.Min = Convert.ToInt32(v[0]);
                csf.Max = Convert.ToInt32(v[1]);
                return csf;
            }
            return base.ConvertFrom(context, culture, value);
        }

        #region 实现scope框的分别编辑
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(Scope), attributes);
        }
        #endregion
    }
    #endregion
}
