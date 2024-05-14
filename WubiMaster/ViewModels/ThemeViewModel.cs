using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Media;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class ThemeViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private int colorIndex;

        [ObservableProperty]
        private List<ColorsModel> colorsList;

        [ObservableProperty]
        private ColorSchemeModel currentColor;

        [ObservableProperty]
        private WeaselCustomModel weaselCustomDetails;

        private string weaselCustomPath = "";

        [ObservableProperty]
        private WeaselModel weaselDetails;

        private string weaselPath = "";

        public ThemeViewModel()
        {
            WeakReferenceMessenger.Default.Register<string, string>(this, "ChangeColorScheme", ChangeColorScheme);

            LoadColorShemes();
            LoadConfig();
        }

        [RelayCommand]
        public void ChangeHorizontal(object obj)
        {
            var tempColor = CurrentColor;
            CurrentColor = null;
            CurrentColor = tempColor;
        }

        [RelayCommand]
        public void ChangeTheme(object obj)
        {
            if (obj == null) return;

            try
            {
                var cModel = ColorsList.First(c => c.description.color_name == obj.ToString());
                if (cModel == null) throw new NullReferenceException($"找不到皮肤对象: {obj.ToString()}");

                ColorSchemeModel _colorModel = new ColorSchemeModel();
                _colorModel.Style = cModel.style;
                _colorModel.UsedColor = cModel.preset_color_schemes.FirstOrDefault().Value;

                CurrentColor = _colorModel;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                this.ShowMessage("选中的样式在外观文件中不存在！", DialogType.Error);
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
            WriteWeaselCustonDetails();

            string colorScheme = ColorsList[ColorIndex].description.color_name;
            ConfigHelper.WriteConfigByString("color_scheme", colorScheme);

            this.ShowMessage("应用成功，部署生效", DialogType.Success);
        }

        private Brush BrushConvter(string colorTxt, string defaultColor = "0x000000", string colorFormat = "abgr")
        {
            Color targetColor = ColorConvter(colorTxt, defaultColor, colorFormat);
            SolidColorBrush targetBrush = new SolidColorBrush(targetColor);
            return targetBrush;
        }

        private void ChangeColorScheme(object recipient, string message)
        {
            LoadColorShemes();
            LoadCustomColor();
        }

        private Color ColorConvter(string colorTxt, string defaultColor = "0x000000", string colorFormat = "abgr")
        {
            try
            {
                if (string.IsNullOrEmpty(colorTxt))
                    colorTxt = defaultColor;

                string colorStr = "";
                Color targetColor = Colors.Black;
                string _color = colorTxt.Substring(2, colorTxt.Length - 2);
                if (_color.Length <= 6) _color = "FF" + _color;
                var _cArray = _color.ToArray();

                switch (colorFormat)
                {
                    case "argb":
                        colorStr = "#" + _cArray.ToString();
                        targetColor = (Color)ColorConverter.ConvertFromString(colorStr);
                        break;

                    case "rgba":
                        colorStr = "#" + $"{_cArray[6]}{_cArray[7]}{_cArray[0]}{_cArray[1]}{_cArray[2]}{_cArray[3]}{_cArray[4]}{_cArray[5]}";
                        targetColor = (Color)ColorConverter.ConvertFromString(colorStr);
                        break;

                    default:
                        // 默认是 abgr
                        colorStr = "#" + $"{_cArray[0]}{_cArray[1]}{_cArray[6]}{_cArray[7]}{_cArray[4]}{_cArray[5]}{_cArray[2]}{_cArray[3]}";
                        targetColor = (Color)ColorConverter.ConvertFromString(colorStr);
                        break;
                }

                return targetColor;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                return Colors.Black;
            }
        }

        private void LoadColorShemes()
        {
            if (!File.Exists(GlobalValues.UserPath + "\\" + GlobalValues.SchemaKey))
                return;

            if (string.IsNullOrEmpty(GlobalValues.UserPath)) return;
            weaselPath = @$"{GlobalValues.UserPath}\weasel.yaml";
            weaselCustomPath = @$"{GlobalValues.UserPath}\weasel.custom.yaml";
            //string colorThemesPath = @$"{GlobalValues.UserPath}\color_themes.yaml";
            string colorsDirectory = @$"{GlobalValues.UserPath}\colors";

            // 加载colors文件夹下的所有外观文件
            try
            {
                if (!Directory.Exists(colorsDirectory))
                    throw new NullReferenceException("方案中未包括皮肤文件目录");

                DirectoryInfo dInfo = new DirectoryInfo(colorsDirectory);
                FileInfo[] files = dInfo.GetFiles();

                ColorsList = new List<ColorsModel>();
                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        FileInfo file = files[i];
                        string colorTxt = File.ReadAllText(file.FullName);
                        ColorsModel cModel = YamlHelper.Deserizlize<ColorsModel>(colorTxt);
                        ColorsList.Add(cModel);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error($"外观文件[{files[i].Name}]格式异常，未能正确加载\n" + ex.ToString());
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                this.ShowMessage("加载皮肤文件出错！", DialogType.Error);
            }

            // 加载 weasel.custom 中的外观
            try
            {
                //if (!File.Exists(weaselCustomPath))
                //    throw new NullReferenceException("方案中未包含 weasel.custom 文件");

                //string weaselCustomTxt = File.ReadAllText(weaselCustomPath);
                //WeaselCustomDetails = YamlHelper.Deserizlize<WeaselCustomModel>(weaselCustomTxt);
                //ConfigHelper.WriteConfigByString("color_scheme", WeaselCustomDetails.patch.style.color_scheme);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                this.ShowMessage("加载 weasel.custom 文件出错！", DialogType.Error);
            }

            // 加载 weasel 中的外观
            try
            {
                string weaselTxt = File.ReadAllText(weaselPath);
                WeaselDetails = YamlHelper.Deserizlize<WeaselModel>(weaselTxt);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

        private void LoadConfig()
        {
            if (WeaselDetails != null)
            {
                if (WeaselCustomDetails == null)
                {
                    ColorIndex = 0;
                    string shemeName = ColorsList[0].description.color_name;
                    ChangeTheme(shemeName);
                }
                else
                {
                    LoadCustomColor();
                }
            }
        }
        private void LoadCustomColor()
        {
            if (!File.Exists(GlobalValues.UserPath + "\\" + GlobalValues.SchemaKey))
                return;

            try
            {
                string shemeName = WeaselCustomDetails.patch.style.color_scheme;
                ColorSchemeModel _colorModel = new ColorSchemeModel();
                _colorModel.Style = WeaselCustomDetails.patch.style;
                _colorModel.UsedColor = WeaselCustomDetails.patch.preset_color_schemes[shemeName];
                CurrentColor = _colorModel;
                ColorIndex = ColorsList.Select(c => c.description.color_name).ToList().IndexOf(shemeName);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                this.ShowAskMessage("加载 weasel.custom 异常");
            }

        }

        private void WriteWeaselCustonDetails()
        {
            try
            {
                WeaselCustomDetails.patch.preset_color_schemes.Clear();
                WeaselCustomDetails.patch.style = CurrentColor.Style;
                string name = ColorsList[ColorIndex].description.color_name;
                WeaselCustomDetails.patch.preset_color_schemes.Add(name, CurrentColor.UsedColor);

                YamlHelper.WriteYaml(WeaselCustomDetails, weaselCustomPath);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }
    }
}