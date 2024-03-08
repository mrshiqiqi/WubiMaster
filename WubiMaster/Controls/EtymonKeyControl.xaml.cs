using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class EtymonKeyControl : UserControl
    {
        public static readonly DependencyProperty IsShowFanKeyProperty =
            DependencyProperty.Register("IsShowFanKey", typeof(bool), typeof(EtymonKeyControl), new PropertyMetadata(false));

        public EtymonKeyControl()
        {
            InitializeComponent();
        }

        public bool IsShowFanKey
        {
            get { return (bool)GetValue(IsShowFanKeyProperty); }
            set { SetValue(IsShowFanKeyProperty, value); }
        }
    }
}