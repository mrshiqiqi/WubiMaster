using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WubiMaster.Controls;
using WubiMaster.ViewModels;
using WubiMaster.Views.PopViews;

namespace WubiMaster.Common
{
    public enum DialogType
    {
        Normal,
        Warring,
        Error,
        Fail,
        Success,
    }

    public static class ObjectExtend
    {
        public static void Cancel(this object obj, object msgView)
        {
            if (msgView == null) return;
            WeakReferenceMessenger.Default.Send<string, string>("false", "ShowMaskLayer");

            try
            {
                MessageView view = (MessageView)msgView;
                view.DialogResult = false ;
            }
            catch (System.Exception ex)
            {
                MessageView view = (MessageView)msgView;
                view.Close();

                LogHelper.Warn("提示窗口未正常关闭");
                LogHelper.Error(ex.Message);
            }
        }

        public static void Confirm(this object obj, object msgView)
        {
            if (msgView == null) return;
            WeakReferenceMessenger.Default.Send<string, string>("false", "ShowMaskLayer");

            try
            {
                MessageView view = (MessageView)msgView;
                view.DialogResult = true;
            }
            catch (System.Exception ex)
            {
                MessageView view = (MessageView)msgView;
                view.Close();

                LogHelper.Warn("提示窗口未正常关闭");
                LogHelper.Error(ex.Message);
            }
        }

        public static void ShowMessage(this object obj, string message, DialogType type = DialogType.Normal)
        {
            Window mainWindow = App.Current.MainWindow;

            WeakReferenceMessenger.Default.Send<string, string>("true", "ShowMaskLayer");

            App.Current.Dispatcher.BeginInvoke(() =>
            {
                switch (type)
                {
                    case DialogType.Normal:
                        NewMessageBox(message, mainWindow, "Normal");
                        break;

                    case DialogType.Warring:
                        NewMessageBox(message, mainWindow, "Warn");
                        break;

                    case DialogType.Error:
                        NewMessageBox(message, mainWindow, "Error");
                        break;

                    case DialogType.Fail:
                        NewMessageBox(message, mainWindow, "Fail");
                        break;

                    case DialogType.Success:
                        NewMessageBox(message, mainWindow, "Succeed");
                        break;

                    default:
                        break;
                }
            });
        }

        public static bool? ShowAskMessage(this object obj, string message, DialogType type = DialogType.Normal)
        {
            bool? optionValue = null;
            Window mainWindow = App.Current.MainWindow;

            WeakReferenceMessenger.Default.Send<string, string>("true", "ShowMaskLayer");

            App.Current.Dispatcher.Invoke(() =>
            {
                switch (type)
                {
                    case DialogType.Normal:
                        optionValue = NewMessageBox(message, mainWindow, "Normal", true);
                        break;

                    case DialogType.Warring:
                        optionValue = NewMessageBox(message, mainWindow, "Warn", true);
                        break;

                    case DialogType.Error:
                        optionValue = NewMessageBox(message, mainWindow, "Error", true);
                        break;

                    case DialogType.Fail:
                        optionValue = NewMessageBox(message, mainWindow, "Fail", true);
                        break;

                    case DialogType.Success:
                        optionValue = NewMessageBox(message, mainWindow, "Succeed", true);
                        break;

                    default:
                        break;
                }
            });

            return optionValue;
        }

        private static bool? NewMessageBox(string message, Window owner, string type, bool isAsk = false)
        {
            MessageView msgView = new MessageView();
            MessageBoxControl msgControl = new MessageBoxControl();
            PopViewModel dataContent = (PopViewModel)msgView.DataContext;

            dataContent.MessageBox = msgControl;

            if (isAsk) msgControl.CancelButtonVisibility = Visibility.Visible;
            msgControl.Message = message;
            msgControl.Type = type;
            msgControl.IconColor = Brushes.Orange;
            msgControl.CancelCommand = (RelayCommand<object>)dataContent.CancelPopCommand;
            msgControl.ConfirmCommand = (RelayCommand<object>)dataContent.ConfirmPopCommand;
            msgControl.CommandParameter = msgView;

            msgView.Owner = owner;
            msgView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            msgView.DataContext = dataContent;

            return msgView.ShowPop();
        }
    }
}