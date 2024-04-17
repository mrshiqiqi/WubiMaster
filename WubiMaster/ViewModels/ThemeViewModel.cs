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
using System.ComponentModel.DataAnnotations;

namespace WubiMaster.ViewModels
{
    public partial class ThemeViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private int colorIndex;

        [ObservableProperty]
        private WeaselCustomModel weaselCustomDetails;

        private string weaselCustomPath = "";

        [ObservableProperty]
        private WeaselModel weaselDetails;

        private string weaselPath = "";

        public ThemeViewModel()
        {
            LoadRimeThemeDetails();
            LoadConfig();
        }

        //[RelayCommand]
        //public void ChangeTheme(object obj)
        //{
        //    if (obj == null) return;
        //    string colorName = obj.ToString();
        //}

        [RelayCommand]
        public void DeleteColor()
        {
            MessageBox.Show(WeaselCustomDetails.patch.style.color_scheme);
        }

        [RelayCommand]
        public void SetColor()
        {
            WriteRimeThemeDetails();

            string colorScheme = WeaselDetails.preset_color_schemes.Keys.ToList()[ColorIndex];
            ConfigHelper.WriteConfigByString("color_scheme", colorScheme);
        }

        private void LoadConfig()
        {
            string colorScheme = ConfigHelper.ReadConfigByString("color_scheme");
            if (string.IsNullOrEmpty(colorScheme))
                ColorIndex = -1;
            else
            {
                int index = WeaselDetails.preset_color_schemes.Keys.ToList().IndexOf(colorScheme);
                ColorIndex = index;
            }
        }

        private void LoadRimeThemeDetails()
        {
            if (string.IsNullOrEmpty(GlobalValues.UserPath)) return;
            weaselPath = @$"{GlobalValues.UserPath}\weasel.yaml";
            weaselCustomPath = @$"{GlobalValues.UserPath}\weasel.custom.yaml";

            try
            {
                string weaselTxt = File.ReadAllText(weaselPath);
                string weaselCustomTxt = File.ReadAllText(weaselCustomPath);

                WeaselDetails = YamlHelper.Deserizlize<WeaselModel>(weaselTxt);
                WeaselCustomDetails = YamlHelper.Deserizlize<WeaselCustomModel>(weaselCustomTxt);

                ConfigHelper.WriteConfigByString("color_scheme", WeaselCustomDetails.patch.style.color_scheme);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

        private void WriteRimeThemeDetails()
        {
            WeaselCustomDetails.patch.style.color_scheme = WeaselDetails.preset_color_schemes.Keys.ToList()[ColorIndex];
            YamlHelper.WriteYaml(WeaselCustomDetails, weaselCustomPath);
        }
    }
}