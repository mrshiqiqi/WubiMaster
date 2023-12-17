using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WubiMaster.Controls
{
    public partial class CancelButton : UserControl
    {
        public CancelButton()
        {
            InitializeComponent();
        }

        public Brush CBBorderBrush
        {
            get { return (Brush)GetValue(CBBorderBrushProperty); }
            set { SetValue(CBBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty CBBorderBrushProperty =
            DependencyProperty.Register("CBBorderBrush", typeof(Brush), typeof(CancelButton));

        public Thickness CBBorderThinckness
        {
            get { return (Thickness)GetValue(CBBorderThincknessProperty); }
            set { SetValue(CBBorderThincknessProperty, value); }
        }

        public static readonly DependencyProperty CBBorderThincknessProperty =
            DependencyProperty.Register("CBBorderThinckness", typeof(Thickness), typeof(CancelButton));

        public Brush CBBackground
        {
            get { return (Brush)GetValue(CBBackgroundProperty); }
            set { SetValue(CBBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CBBackgroundProperty =
            DependencyProperty.Register("CBBackground", typeof(Brush), typeof(CancelButton));

        public Brush CBForeground
        {
            get { return (Brush)GetValue(CBForegroundProperty); }
            set { SetValue(CBForegroundProperty, value); }
        }

        public static readonly DependencyProperty CBForegroundProperty =
            DependencyProperty.Register("CBForeground", typeof(Brush), typeof(CancelButton));

        public RelayCommand<object> CBCommand
        {
            get { return (RelayCommand<object>)GetValue(CBCommandProperty); }
            set { SetValue(CBCommandProperty, value); }
        }

        public static readonly DependencyProperty CBCommandProperty =
            DependencyProperty.Register("CBCommand", typeof(RelayCommand<object>), typeof(CancelButton));

        public object CBCommandParameter
        {
            get { return (object)GetValue(CBCommandParameterProperty); }
            set { SetValue(CBCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CBCommandParameterProperty =
            DependencyProperty.Register("CBCommandParameter", typeof(object), typeof(CancelButton));
    }
}