using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class SeparatorControl : UserControl
    {
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(SeparatorControl), new PropertyMetadata(""));

        public SeparatorControl()
        {
            InitializeComponent();
        }

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
    }
}