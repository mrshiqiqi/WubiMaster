using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WubiMaster.Controls
{
    public partial class WinowStateButton : UserControl
    {
        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("ButtonBackground", typeof(SolidColorBrush), typeof(WinowStateButton));

        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register("ButtonCommand", typeof(RelayCommand<object>), typeof(WinowStateButton));

        public static readonly DependencyProperty IconColorProperty =
                            DependencyProperty.Register("IconColor", typeof(SolidColorBrush), typeof(WinowStateButton));

        public static readonly DependencyProperty IconContentProperty =
                    DependencyProperty.Register("IconContent", typeof(string), typeof(WinowStateButton));

        public WinowStateButton()
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

        public SolidColorBrush IconColor
        {
            get { return (SolidColorBrush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        public string IconContent
        {
            get { return (string)GetValue(IconContentProperty); }
            set { SetValue(IconContentProperty, value); }
        }
    }
}