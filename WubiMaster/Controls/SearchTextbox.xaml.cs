using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class SearchTextbox : UserControl
    {
        public static readonly DependencyProperty SecrchContentProperty =
            DependencyProperty.Register("SecrchContent", typeof(string), typeof(SearchTextbox));

        public static readonly DependencyProperty WaterMarkTextProperty =
            DependencyProperty.Register("WaterMarkText", typeof(string), typeof(SearchTextbox));

        public SearchTextbox()
        {
            InitializeComponent();
        }

        public string SecrchContent
        {
            get { return (string)GetValue(SecrchContentProperty); }
            set { SetValue(SecrchContentProperty, value); }
        }

        public string WaterMarkText
        {
            get { return (string)GetValue(WaterMarkTextProperty); }
            set { SetValue(WaterMarkTextProperty, value); }
        }
    }
}