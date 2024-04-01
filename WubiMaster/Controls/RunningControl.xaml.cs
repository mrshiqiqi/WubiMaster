using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class RunningControl : UserControl
    {
        public static readonly DependencyProperty CheckStateProperty =
            DependencyProperty.Register("CheckState", typeof(bool), typeof(RunningControl), new PropertyMetadata(false));

        public static readonly DependencyProperty CommandParameterProperty =
                    DependencyProperty.Register("CommandParameter", typeof(object), typeof(RunningControl));

        public static readonly DependencyProperty RunningCommandProperty =
            DependencyProperty.Register("RunningCommand", typeof(RelayCommand<object>), typeof(RunningControl));

        public RunningControl()
        {
            InitializeComponent();
        }

        public bool CheckState
        {
            get { return (bool)GetValue(CheckStateProperty); }
            set { SetValue(CheckStateProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public RelayCommand<object> RunningCommand
        {
            get { return (RelayCommand<object>)GetValue(RunningCommandProperty); }
            set { SetValue(RunningCommandProperty, value); }
        }
    }
}