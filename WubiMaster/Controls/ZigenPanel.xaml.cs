using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class ZigenPanel : UserControl
    {
        public static readonly DependencyProperty CategoryProperty =
            DependencyProperty.Register("Category", typeof(string), typeof(ZigenPanel));

        public static readonly DependencyProperty VisibilityFor06Property =
                    DependencyProperty.Register("VisibilityFor06", typeof(Visibility), typeof(ZigenPanel));

        public static readonly DependencyProperty VisibilityFor86Property =
            DependencyProperty.Register("VisibilityFor86", typeof(Visibility), typeof(ZigenPanel));

        public static readonly DependencyProperty VisibilityFor98Property =
            DependencyProperty.Register("VisibilityFor98", typeof(Visibility), typeof(ZigenPanel));

        public static readonly DependencyProperty WorldsProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ZigenPanel));

        public ZigenPanel()
        {
            InitializeComponent();
        }

        // 分类
        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }

        public Visibility VisibilityFor06
        {
            get { return (Visibility)GetValue(VisibilityFor06Property); }
            set { SetValue(VisibilityFor06Property, value); }
        }


        public Visibility VisibilityFor86
        {
            get { return (Visibility)GetValue(VisibilityFor86Property); }
            set { SetValue(VisibilityFor86Property, value); }
        }

        public Visibility VisibilityFor98
        {
            get { return (Visibility)GetValue(VisibilityFor98Property); }
            set { SetValue(VisibilityFor98Property, value); }
        }

        public string Worlds
        {
            get { return (string)GetValue(WorldsProperty); }
            set { SetValue(WorldsProperty, value); }
        }
    }
}