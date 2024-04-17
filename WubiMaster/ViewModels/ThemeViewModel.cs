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
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Messaging;

namespace WubiMaster.ViewModels
{
    public partial class ThemeViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private int colorIndex;

        [ObservableProperty]
        private ColorSchemeModel currentSchmemeMd;

        [ObservableProperty]
        private WeaselCustomModel weaselCustomDetails;

        private string weaselCustomPath = "";

        [ObservableProperty]
        private WeaselModel weaselDetails;

        private string weaselPath = "";

        public ThemeViewModel()
        {
            WeakReferenceMessenger.Default.Register<string, string>(this, "ChangeColorScheme", ChangeColorScheme);

            LoadRimeThemeDetails();
            LoadConfig();
        }

        [RelayCommand]
        public void ChangeTheme(object obj)
        {
            if (obj == null) return;

            try
            {
                WeaselColorScheme colorScheme = weaselDetails.preset_color_schemes[obj.ToString()];
                if (colorScheme == null) throw new NullReferenceException($"找不到皮肤对象: {obj.ToString()}");

                CurrentSchmemeMd ??= new ColorSchemeModel();
                CurrentSchmemeMd.BackColor = new SolidColorBrush(ColorConvter(colorScheme.back_color));
                CurrentSchmemeMd.BorderColor = new SolidColorBrush(ColorConvter(colorScheme.border_color));
                CurrentSchmemeMd.HilitedBackColor = new SolidColorBrush(ColorConvter(string.IsNullOrEmpty(colorScheme.hilited_back_color) ? colorScheme.back_color : colorScheme.hilited_back_color));
                CurrentSchmemeMd.HilitedCandidateBackColor = new SolidColorBrush(ColorConvter(colorScheme.hilited_candidate_back_color));
                CurrentSchmemeMd.CandidateTextColor = new SolidColorBrush(ColorConvter(string.IsNullOrEmpty(colorScheme.candidate_text_color) ? colorScheme.text_color : colorScheme.candidate_text_color));
                CurrentSchmemeMd.HilitedCandidateTextColor = new SolidColorBrush(ColorConvter(colorScheme.hilited_candidate_text_color));
                CurrentSchmemeMd.HilitedLabelColor = new SolidColorBrush(ColorConvter(string.IsNullOrEmpty(colorScheme.hilited_label_color) ? colorScheme.hilited_candidate_text_color : colorScheme.hilited_label_color));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                //this.ShowMessage("无法查看该皮肤样式！");
            }
        }

        [RelayCommand]
        public void DeleteColor()
        {
        }

        [RelayCommand]
        public void SetColor()
        {
            if (WeaselCustomDetails == null)
            {
                this.ShowMessage("请先配置码表版本！", DialogType.Warring);
                return;
            }
            WriteRimeThemeDetails();

            string colorScheme = WeaselDetails.preset_color_schemes.Keys.ToList()[ColorIndex];
            ConfigHelper.WriteConfigByString("color_scheme", colorScheme);

            this.ShowMessage("应用成功，部署生效", DialogType.Success);
        }

        private static Color ColorConvter(string colorTxt)
        {
            if (string.IsNullOrEmpty(colorTxt))
                colorTxt = "0x000000";
            string _color = colorTxt.Substring(2, colorTxt.Length - 2);
            var _cArray = _color.ToArray();
            string _the_color = $"#{_cArray[4]}{_cArray[5]}{_cArray[2]}{_cArray[3]}{_cArray[0]}{_cArray[1]}";
            Color back_color = (Color)ColorConverter.ConvertFromString(_the_color);
            return back_color;
        }

        private void ChangeColorScheme(object recipient, string message)
        {
            LoadRimeThemeDetails();
            string colorName = WeaselCustomDetails.patch.style.color_scheme;
            int index = WeaselDetails.preset_color_schemes.Keys.ToList().IndexOf(colorName);
            ColorIndex = index;
            ChangeTheme(colorName);
        }

        private void LoadConfig()
        {
            if (WeaselDetails != null)
            {
                if (WeaselCustomDetails == null)
                {
                    ColorIndex = 0;
                    string shemeName = WeaselDetails.preset_color_schemes.Keys.ToList()[ColorIndex];
                    ChangeTheme(shemeName);
                }
                else
                {
                    string shemeName = WeaselCustomDetails.patch.style.color_scheme;
                    ChangeTheme(shemeName);
                    ColorIndex = WeaselDetails.preset_color_schemes.Keys.ToList().IndexOf(shemeName); ;
                }
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
                WeaselDetails = YamlHelper.Deserizlize<WeaselModel>(weaselTxt);

                if (File.Exists(weaselCustomPath))
                {
                    string weaselCustomTxt = File.ReadAllText(weaselCustomPath);
                    WeaselCustomDetails = YamlHelper.Deserizlize<WeaselCustomModel>(weaselCustomTxt);
                    ConfigHelper.WriteConfigByString("color_scheme", WeaselCustomDetails.patch.style.color_scheme);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

        private void WriteRimeThemeDetails()
        {
            try
            {
                WeaselCustomDetails.patch.style.color_scheme = WeaselDetails.preset_color_schemes.Keys.ToList()[ColorIndex];
                YamlHelper.WriteYaml(WeaselCustomDetails, weaselCustomPath);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }
    }
}