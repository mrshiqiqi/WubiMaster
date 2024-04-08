using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class StateToggleButton : UserControl
    {
        public static readonly DependencyProperty CheckedStateProperty =
            DependencyProperty.Register("CheckedState", typeof(string), typeof(StateToggleButton), new PropertyMetadata(""));

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(StateToggleButton));

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(RelayCommand<object>), typeof(StateToggleButton));

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(StateToggleButton), new PropertyMetadata(false));

        public static readonly DependencyProperty UnCheckedStateProperty =
                                    DependencyProperty.Register("UnCheckedState", typeof(string), typeof(StateToggleButton), new PropertyMetadata(""));

        public StateToggleButton()
        {
            InitializeComponent();
        }

        public string CheckedState
        {
            get { return (string)GetValue(CheckedStateProperty); }
            set { SetValue(CheckedStateProperty, value); }
        }

        public RelayCommand<object> Command
        {
            get { return (RelayCommand<object>)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public string UnCheckedState
        {
            get { return (string)GetValue(UnCheckedStateProperty); }
            set { SetValue(UnCheckedStateProperty, value); }
        }
    }
}