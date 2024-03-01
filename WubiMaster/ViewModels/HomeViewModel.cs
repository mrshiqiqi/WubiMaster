using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private int shiciInterval = 25;

        [ObservableProperty]
        private string spellTextShow86;

        [ObservableProperty]
        private string spellTextShow98;

        [ObservableProperty]
        private string spellTextShow06;

        [ObservableProperty]
        private string spellingText;

        [ObservableProperty]
        private string spellingKeytText = "钱";

        public HomeViewModel()
        {
            WeakReferenceMessenger.Default.Register<string, string>(this, "ChangeShiciInterval", ChangeShiciInterval);

            LoadSpellTextShow();
        }

        private void LoadSpellTextShow()
        {
            try
            {
                string keyWord = SpellingKeytText;
                var result86 = SpellingWorker.ZingenSearch(keyWord, "86");
                SpellTextShow86 = result86.Spelling + "・" + result86.Code;
                var result98 = SpellingWorker.ZingenSearch(keyWord, "98");
                SpellTextShow98 = result98.Spelling + "・" + result98.Code;
                var result06 = SpellingWorker.ZingenSearch(keyWord, "06");
                SpellTextShow06 = result06.Spelling + "・" + result06.Code;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                this.ShowMessage("无法加载字根版本示例", DialogType.Error);
            }
        }

        [RelayCommand]
        public void CopyInfo(object obj)
        {
            Clipboard.SetDataObject(obj);
            this.ShowMessage("已复制到剪贴板");
        }

        [RelayCommand]
        public void ToWebPage(object obj)
        {
            try
            {
                string url = obj?.ToString();
                Process.Start("explorer.exe", url);
            }
            catch (Exception ex)
            {
                this.ShowMessage("无法打开网址", DialogType.Error);
                LogHelper.Error(ex.Message);
            }
        }

        [RelayCommand]
        public void ZingenSearch(object obj)
        {
            if (obj == null)
            {
                SpellingText = "";
                return;
            }

            try
            {
                string keyWord = obj.ToString().Trim();
                string type = ConfigHelper.ReadConfigByString("quick_search_type");
                var result = SpellingWorker.ZingenSearch(keyWord, type);
                if (result == null)
                {
                    SpellingText = "";
                    return;
                }
                else
                {
                    SpellingText = result.Spelling + "・" + result.Code;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }

        private void ChangeShiciInterval(object recipient, string message)
        {
            try
            {
                int newInterval = int.Parse(message);

                if (newInterval < 5)
                {
                    ShiciInterval = 25;
                    return;
                }
                ShiciInterval = newInterval;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }
    }
}