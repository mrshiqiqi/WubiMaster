using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class SettingPanel : UserControl
    {
        public static readonly DependencyProperty IconTextProperty =
            DependencyProperty.Register("IconText", typeof(string), typeof(SettingPanel));

        public static readonly DependencyProperty SettingContentProperty =
            DependencyProperty.Register("SettingContent", typeof(UIElement), typeof(SettingPanel));

        public static readonly DependencyProperty SubTitleProperty =
            DependencyProperty.Register("SubTitle", typeof(string), typeof(SettingPanel));

        public static readonly DependencyProperty TitleProperty =
                            DependencyProperty.Register("Title", typeof(string), typeof(SettingPanel));

        public SettingPanel()
        {
            InitializeComponent();
        }

        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }

        public UIElement SettingContent
        {
            get { return (UIElement)GetValue(SettingContentProperty); }
            set { SetValue(SettingContentProperty, value); }
        }

        public string SubTitle
        {
            get { return (string)GetValue(SubTitleProperty); }
            set { SetValue(SubTitleProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}