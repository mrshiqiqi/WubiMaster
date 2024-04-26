using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class MyColorsViewModel:ObservableRecipient
    {
        [ObservableProperty]
        private string hello;

        [ObservableProperty]
        private ObservableCollection<ColorSchemeModel> myColors;

        public MyColorsViewModel()
        {
            //LoadAllColors();
        }

        [RelayCommand]
        public void ViewLoaded()
        {
            LoadAllColors();
        }

        private void LoadAllColors()
        {
            MyColors = new ObservableCollection<ColorSchemeModel>();
            string colorsDirectory = @$"{GlobalValues.UserPath}\colors";

            // 加载colors文件夹下的所有外观文件
            try
            {
                if (!Directory.Exists(colorsDirectory))
                    throw new NullReferenceException("方案中未包括皮肤文件目录");

                DirectoryInfo dInfo = new DirectoryInfo(colorsDirectory);
                FileInfo[] files = dInfo.GetFiles();

                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        FileInfo file = files[i];
                        string colorTxt = File.ReadAllText(file.FullName);
                        ColorsModel cModel = YamlHelper.Deserizlize<ColorsModel>(colorTxt);

                        ColorSchemeModel sModel = new ColorSchemeModel();
                        sModel.Style = cModel.style;
                        sModel.UsedColor = cModel.preset_color_schemes.FirstOrDefault().Value;
                        MyColors.Add(sModel);
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
        }
    }
}
