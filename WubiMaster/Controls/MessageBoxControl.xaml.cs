using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WubiMaster.Controls
{
    public partial class MessageBoxControl : UserControl
    {
        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(RelayCommand<object>), typeof(MessageBoxControl));

        public static readonly DependencyProperty IconColorProperty =
            DependencyProperty.Register("IconColor", typeof(Brush), typeof(MessageBoxControl));

        public static readonly DependencyProperty IconTextProperty =
                    DependencyProperty.Register("IconText", typeof(string), typeof(MessageBoxControl));

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MessageBoxControl));

        public MessageBoxControl()
        {
            InitializeComponent();
        }

        public RelayCommand<object> CloseCommand
        {
            get { return (RelayCommand<object>)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        public Brush IconColor
        {
            get { return (Brush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
    }
}