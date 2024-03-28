using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class ZigenPanel : UserControl
    {
        public static readonly DependencyProperty CodeTextProperty =
            DependencyProperty.Register("CodeText", typeof(string), typeof(ZigenPanel), new PropertyMetadata(""));

        public static readonly DependencyProperty GBKTextProperty =
            DependencyProperty.Register("GBKText", typeof(string), typeof(ZigenPanel), new PropertyMetadata(""));

        public static readonly DependencyProperty SpellingText1Property =
            DependencyProperty.Register("SpellingText1", typeof(string), typeof(ZigenPanel), new PropertyMetadata(""));

        public static readonly DependencyProperty SpellingText2Property =
            DependencyProperty.Register("SpellingText2", typeof(string), typeof(ZigenPanel), new PropertyMetadata(""));

        public static readonly DependencyProperty SpellingText3Property =
            DependencyProperty.Register("SpellingText3", typeof(string), typeof(ZigenPanel), new PropertyMetadata(""));

        public static readonly DependencyProperty SpellingText4Property =
            DependencyProperty.Register("SpellingText4", typeof(string), typeof(ZigenPanel), new PropertyMetadata(""));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ZigenPanel));

        public static readonly DependencyProperty TypeTextProperty =
            DependencyProperty.Register("TypeText", typeof(string), typeof(ZigenPanel), new PropertyMetadata(""));

        public static readonly DependencyProperty VisibilityFor06Property =
                                                                                    DependencyProperty.Register("VisibilityFor06", typeof(Visibility), typeof(ZigenPanel));

        public static readonly DependencyProperty VisibilityFor86Property =
            DependencyProperty.Register("VisibilityFor86", typeof(Visibility), typeof(ZigenPanel));

        public static readonly DependencyProperty VisibilityFor98Property =
            DependencyProperty.Register("VisibilityFor98", typeof(Visibility), typeof(ZigenPanel));

        public static readonly DependencyProperty WubiTypeProperty =
            DependencyProperty.Register("WubiType", typeof(string), typeof(ZigenPanel), new PropertyMetadata("全部"));

        public ZigenPanel()
        {
            InitializeComponent();
        }

        public string CodeText
        {
            get { return (string)GetValue(CodeTextProperty); }
            set { SetValue(CodeTextProperty, value); }
        }

        public string GBKText
        {
            get { return (string)GetValue(GBKTextProperty); }
            set { SetValue(GBKTextProperty, value); }
        }

        public string SpellingText1
        {
            get { return (string)GetValue(SpellingText1Property); }
            set { SetValue(SpellingText1Property, value); }
        }

        public string SpellingText2
        {
            get { return (string)GetValue(SpellingText2Property); }
            set { SetValue(SpellingText2Property, value); }
        }

        public string SpellingText3
        {
            get { return (string)GetValue(SpellingText3Property); }
            set { SetValue(SpellingText3Property, value); }
        }

        public string SpellingText4
        {
            get { return (string)GetValue(SpellingText4Property); }
            set { SetValue(SpellingText4Property, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string TypeText
        {
            get { return (string)GetValue(TypeTextProperty); }
            set { SetValue(TypeTextProperty, value); }
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

        public string WubiType
        {
            get { return (string)GetValue(WubiTypeProperty); }
            set { SetValue(WubiTypeProperty, value); }
        }
    }
}