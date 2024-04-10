using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WubiMaster.Controls
{
    public partial class RimeLogo : UserControl
    {
        public static readonly DependencyProperty IconColorProperty =
            DependencyProperty.Register("IconColor", typeof(Brush), typeof(RimeLogo));

        public RimeLogo()
        {
            InitializeComponent();
        }

        public Brush IconColor
        {
            get { return (Brush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }
    }
}