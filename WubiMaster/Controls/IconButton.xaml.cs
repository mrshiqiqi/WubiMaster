using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WubiMaster.Controls
{
    public partial class IconButton : UserControl
    {
        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("ButtonBackground", typeof(SolidColorBrush), typeof(IconButton));

        public static readonly DependencyProperty ButtonCommandParameterProperty =
            DependencyProperty.Register("ButtonCommandParameter", typeof(object), typeof(IconButton));

        public static readonly DependencyProperty ButtonCommandProperty =
                    DependencyProperty.Register("ButtonCommand", typeof(RelayCommand<object>), typeof(IconButton));

        public static readonly DependencyProperty ButtonForegroundProperty =
                    DependencyProperty.Register("ButtonForeground", typeof(Brush), typeof(IconButton));

        public static readonly DependencyProperty ButtonHeightProperty =
            DependencyProperty.Register("ButtonHeight", typeof(double), typeof(IconButton));

        public static readonly DependencyProperty ButtonPaddingProperty =
            DependencyProperty.Register("ButtonPadding", typeof(Thickness), typeof(IconButton));

        public static readonly DependencyProperty ButtonWidthProperty =
                    DependencyProperty.Register("ButtonWidth", typeof(double), typeof(IconButton));

        public static readonly DependencyProperty IconTextProperty =
                                            DependencyProperty.Register("IconText", typeof(string), typeof(IconButton));

        public IconButton()
        {
            InitializeComponent();
        }

        public SolidColorBrush ButtonBackground
        {
            get { return (SolidColorBrush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }

        public RelayCommand<object> ButtonCommand
        {
            get { return (RelayCommand<object>)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public object ButtonCommandParameter
        {
            get { return (object)GetValue(ButtonCommandParameterProperty); }
            set { SetValue(ButtonCommandParameterProperty, value); }
        }

        public Brush ButtonForeground
        {
            get { return (Brush)GetValue(ButtonForegroundProperty); }
            set { SetValue(ButtonForegroundProperty, value); }
        }

        public double ButtonHeight
        {
            get { return (double)GetValue(ButtonHeightProperty); }
            set { SetValue(ButtonHeightProperty, value); }
        }

        public Thickness ButtonPadding
        {
            get { return (Thickness)GetValue(ButtonPaddingProperty); }
            set { SetValue(ButtonPaddingProperty, value); }
        }

        public double ButtonWidth
        {
            get { return (double)GetValue(ButtonWidthProperty); }
            set { SetValue(ButtonWidthProperty, value); }
        }

        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }
    }
}