using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Models;
using WubiMaster.ViewModels;
using WubiMaster.Views.PopViews;

namespace WubiMaster.Common
{
    public enum DialogType
    {
        Normal,
        Warring,
        Success,
        Error,
    }

    public static class ObjectExtend
    {
        public static void ShowMessage(this object obj, string title, string message, DialogType type = DialogType.Normal)
        {
            Window mainWindow = App.Current.MainWindow;

            switch (type)
            {
                case DialogType.Normal:
                    NormaDialog(message, mainWindow);
                    break;
                case DialogType.Warring:
                    WarringDialog(message, mainWindow);
                    break;
                case DialogType.Success:
                    SuccessDialog(message, mainWindow);
                    break;
                case DialogType.Error:
                    ErrorDialog(message, mainWindow);
                    break;
                default:
                    break;
            }
        }

        private static void NormaDialog(string message, Window owner)
        {
            MessageView messageView = new MessageView();
            PopViewModel messageDataContent = messageView.DataContext as PopViewModel;
            MessageDialogModel dialogModel = new MessageDialogModel();
            dialogModel.Title = "提示";
            dialogModel.Message = message;
            messageDataContent.MessageDialogModel = dialogModel;
            messageView.ShowPop();

        }

        private static void WarringDialog(string message, Window owner)
        {
            MessageView messageView = new MessageView();
            messageView.Owner = owner;
            messageView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            PopViewModel messageDataContent = messageView.DataContext as PopViewModel;
            MessageDialogModel dialogModel = new MessageDialogModel();
            dialogModel.Title = "警告";
            dialogModel.Message = message;
            messageDataContent.MessageDialogModel = dialogModel;
            messageView.ShowPop();
        }

        private static void SuccessDialog(string message, Window owner) { }

        private static void ErrorDialog(string message, Window owner) { }
    }
}
