using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WubiMaster.Controls
{
    public partial class MessageBoxControl : UserControl
    {
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(RelayCommand<object>), typeof(MessageBoxControl));

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(MessageBoxControl));

        public static readonly DependencyProperty ErrorVisibleProperty =
            DependencyProperty.Register("ErrorVisible", typeof(Visibility), typeof(MessageBoxControl));

        public static readonly DependencyProperty FailVisibleProperty =
            DependencyProperty.Register("FailVisible", typeof(Visibility), typeof(MessageBoxControl));

        public static readonly DependencyProperty IconColorProperty =
                                    DependencyProperty.Register("IconColor", typeof(Brush), typeof(MessageBoxControl));

        public static readonly DependencyProperty IconTextProperty =
                    DependencyProperty.Register("IconText", typeof(string), typeof(MessageBoxControl));

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MessageBoxControl));

        public static readonly DependencyProperty NormalVisibleProperty =
            DependencyProperty.Register("NormalVisible", typeof(Visibility), typeof(MessageBoxControl));

        public static readonly DependencyProperty SucceedVisibleProperty =
            DependencyProperty.Register("SucceedVisible", typeof(Visibility), typeof(MessageBoxControl));

        public static readonly DependencyProperty TypeProperty =
                            DependencyProperty.Register("Type", typeof(string), typeof(MessageBoxControl), new PropertyMetadata(OnTypeChanged));

        public static readonly DependencyProperty WarnVisibleProperty =
            DependencyProperty.Register("WarnVisible", typeof(Visibility), typeof(MessageBoxControl));

        public MessageBoxControl()
        {
            InitializeComponent();
        }

        public RelayCommand<object> CancelCommand
        {
            get { return (RelayCommand<object>)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public Visibility ErrorVisible
        {
            get { return (Visibility)GetValue(ErrorVisibleProperty); }
            set { SetValue(ErrorVisibleProperty, value); }
        }

        public Visibility FailVisible
        {
            get { return (Visibility)GetValue(FailVisibleProperty); }
            set { SetValue(FailVisibleProperty, value); }
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

        public Visibility NormalVisible
        {
            get { return (Visibility)GetValue(NormalVisibleProperty); }
            set { SetValue(NormalVisibleProperty, value); }
        }

        public Visibility SucceedVisible
        {
            get { return (Visibility)GetValue(SucceedVisibleProperty); }
            set { SetValue(SucceedVisibleProperty, value); }
        }

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public Visibility WarnVisible
        {
            get { return (Visibility)GetValue(WarnVisibleProperty); }
            set { SetValue(WarnVisibleProperty, value); }
        }

        private static void OnTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageBoxControl control = (MessageBoxControl)d;
            switch (e.NewValue.ToString())
            {
                case "Normal":
                    control.NormalVisible = Visibility.Visible;
                    control.WarnVisible = Visibility.Collapsed;
                    control.ErrorVisible = Visibility.Collapsed;
                    control.FailVisible = Visibility.Collapsed;
                    control.SucceedVisible = Visibility.Collapsed;
                    break;

                case "Warn":
                    control.NormalVisible = Visibility.Collapsed;
                    control.WarnVisible = Visibility.Visible;
                    control.ErrorVisible = Visibility.Collapsed;
                    control.FailVisible = Visibility.Collapsed;
                    control.SucceedVisible = Visibility.Collapsed;
                    break;

                case "Error":
                    control.NormalVisible = Visibility.Collapsed;
                    control.WarnVisible = Visibility.Collapsed;
                    control.ErrorVisible = Visibility.Visible;
                    control.FailVisible = Visibility.Collapsed;
                    control.SucceedVisible = Visibility.Collapsed;
                    break;

                case "Fail":
                    control.NormalVisible = Visibility.Collapsed;
                    control.WarnVisible = Visibility.Collapsed;
                    control.ErrorVisible = Visibility.Collapsed;
                    control.FailVisible = Visibility.Visible;
                    control.SucceedVisible = Visibility.Collapsed;
                    break;

                case "Succeed":
                    control.NormalVisible = Visibility.Collapsed;
                    control.WarnVisible = Visibility.Collapsed;
                    control.ErrorVisible = Visibility.Collapsed;
                    control.FailVisible = Visibility.Collapsed;
                    control.SucceedVisible = Visibility.Visible;
                    break;

                default:
                    control.NormalVisible = Visibility.Visible;
                    control.WarnVisible = Visibility.Collapsed;
                    control.ErrorVisible = Visibility.Collapsed;
                    control.FailVisible = Visibility.Collapsed;
                    control.SucceedVisible = Visibility.Collapsed;
                    break;
            }
        }

        public RelayCommand<object> ConfirmCommand
        {
            get { return (RelayCommand<object>)GetValue(ConfirmCommandProperty); }
            set { SetValue(ConfirmCommandProperty, value); }
        }

        public static readonly DependencyProperty ConfirmCommandProperty =
            DependencyProperty.Register("ConfirmCommand", typeof(RelayCommand<object>), typeof(MessageBoxControl));



        public Visibility CancelButtonVisibility
        {
            get { return (Visibility)GetValue(CancelButtonVisibilityProperty); }
            set { SetValue(CancelButtonVisibilityProperty, value); }
        }

        public static readonly DependencyProperty CancelButtonVisibilityProperty =
            DependencyProperty.Register("CancelButtonVisibility", typeof(Visibility), typeof(MessageBoxControl), new PropertyMetadata(Visibility.Collapsed));


    }
}