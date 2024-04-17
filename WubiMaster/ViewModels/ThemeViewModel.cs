using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Runtime.InteropServices;

namespace WubiMaster.ViewModels
{
    public partial class ThemeViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private WeaselCustomModel weaselCustomDetails;

        [ObservableProperty]
        private WeaselModel weaselDetails;

        public ThemeViewModel()
        {
            LoadRimeThemeDetails();
        }

        [RelayCommand]
        public void ChangeTheme(object obj)
        {
            WeaselCustomDetails.patch.style.color_scheme = obj.ToString();
            WriteRimeThemeDetails();
        }

        [RelayCommand]
        public void DeleteColor()
        {
            MessageBox.Show(WeaselCustomDetails.patch.style.color_scheme);
        }

        private void LoadRimeThemeDetails()
        {
            string weaselPath = @"D:\Rime\weasel.yaml";
            string weaselCustomPath = @"D:\Rime\weasel.custom.yaml";
            string weaselTxt = File.ReadAllText(weaselPath);
            string weaselCustomTxt = File.ReadAllText(weaselCustomPath);

            WeaselDetails = YamlHelper.Deserizlize<WeaselModel>(weaselTxt);
            WeaselCustomDetails = YamlHelper.Deserizlize<WeaselCustomModel>(weaselCustomTxt);
        }

        private void WriteRimeThemeDetails()
        {
            string weaselCustomPath = @"D:\Rime\weasel.custom.yaml";
            YamlHelper.WriteYaml(WeaselCustomDetails, weaselCustomPath);
        }
    }
}