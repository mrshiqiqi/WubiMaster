using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WubiMaster.Models;

namespace WubiMaster.Controls
{
    public partial class ZigenPanel : UserControl
    {
        public static readonly DependencyProperty CodeKeyList06Property =
            DependencyProperty.Register("CodeKeyList06", typeof(List<CodeKeyModel>), typeof(ZigenPanel));

        public static readonly DependencyProperty CodeKeyList86Property =
            DependencyProperty.Register("CodeKeyList86", typeof(List<CodeKeyModel>), typeof(ZigenPanel));

        public static readonly DependencyProperty CodeKeyList98Property =
            DependencyProperty.Register("CodeKeyList98", typeof(List<CodeKeyModel>), typeof(ZigenPanel));

        public static readonly DependencyProperty SpellingKeyList06Property =
            DependencyProperty.Register("SpellingKeyList06", typeof(List<SpellingKeyModel>), typeof(ZigenPanel));

        public static readonly DependencyProperty SpellingKeyList86Property =
            DependencyProperty.Register("SpellingKeyList86", typeof(List<SpellingKeyModel>), typeof(ZigenPanel));

        public static readonly DependencyProperty SpellingKeyList98Property =
            DependencyProperty.Register("SpellingKeyList98", typeof(List<SpellingKeyModel>), typeof(ZigenPanel));

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

        public List<CodeKeyModel> CodeKeyList06
        {
            get { return (List<CodeKeyModel>)GetValue(CodeKeyList06Property); }
            set { SetValue(CodeKeyList06Property, value); }
        }

        public List<CodeKeyModel> CodeKeyList86
        {
            get { return (List<CodeKeyModel>)GetValue(CodeKeyList86Property); }
            set { SetValue(CodeKeyList86Property, value); }
        }

        public List<CodeKeyModel> CodeKeyList98
        {
            get { return (List<CodeKeyModel>)GetValue(CodeKeyList98Property); }
            set { SetValue(CodeKeyList98Property, value); }
        }

        public List<SpellingKeyModel> SpellingKeyList06
        {
            get { return (List<SpellingKeyModel>)GetValue(SpellingKeyList06Property); }
            set { SetValue(SpellingKeyList06Property, value); }
        }

        public List<SpellingKeyModel> SpellingKeyList86
        {
            get { return (List<SpellingKeyModel>)GetValue(SpellingKeyList86Property); }
            set { SetValue(SpellingKeyList86Property, value); }
        }

        public List<SpellingKeyModel> SpellingKeyList98
        {
            get { return (List<SpellingKeyModel>)GetValue(SpellingKeyList98Property); }
            set { SetValue(SpellingKeyList98Property, value); }
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