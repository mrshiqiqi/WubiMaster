using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WubiMaster.Common;
using WubiMaster.Controls;

namespace WubiMaster.ViewModels
{
    public partial class EtymonKeyViewModel : ObservableObject
    {
        [ObservableProperty]
        private EtymonKeyControl eKeyControl;

        private Dictionary<string, EtymonKeyControl> EtymonKeyControlDict;

        [ObservableProperty]
        private bool showFanKey = true;

        public EtymonKeyViewModel()
        {
            EtymonKeyControlDict = new Dictionary<string, EtymonKeyControl>();

            LoadEtymonKeyControls();
            ChangeEtymonKeyVersion(null);
        }

        [RelayCommand]
        public void ChangeEtymonKeyVersion(object obj)
        {
            App.Current.Dispatcher.BeginInvoke(() => {
                string[] types = new string[] { "86", "98", "06" };
                int index = int.Parse((obj?.ToString() ?? "0"));

                if (EtymonKeyControlDict.ContainsKey(types[index]))
                {
                    EKeyControl = EtymonKeyControlDict[types[index]];
                }
                else
                {
                    var eControl = new EtymonKeyControl() { EtymonKeyType = types[index] };
                    Binding eKeyBinding = new Binding();
                    eKeyBinding.Source = this;
                    eKeyBinding.Path = new System.Windows.PropertyPath("ShowFanKey");
                    eControl.SetBinding(EtymonKeyControl.IsShowFanKeyProperty, eKeyBinding);

                    EKeyControl = eControl;
                    EtymonKeyControlDict.Add(types[index], eControl);
                }
            });
        }

        [RelayCommand]
        public void SaveToImage()
        {
            App.Current.Dispatcher.BeginInvoke(() =>
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PNG文件(*.png)|*.png|JPG文件(*.jpg)|*.jpg|BMP文件(*.bmp)|*.bmp|GIF文件(*.gif)|*.gif|TIF文件(*.tif)|*.tif";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string strPath = saveFileDialog.FileName;
                        FileStream fs = new FileStream(strPath, FileMode.Create);
                        RenderTargetBitmap bmp = new RenderTargetBitmap((int)EKeyControl.ActualWidth, (int)EKeyControl.ActualHeight, 1 / 96, 1 / 96, PixelFormats.Default);
                        bmp.Render(EKeyControl);
                        BitmapEncoder encoder = new TiffBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(bmp));
                        encoder.Save(fs);
                        fs.Close();

                        this.ShowMessage("保存成功", DialogType.Success);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    this.ShowMessage("保存失败", DialogType.Fail);
                }
            });
        }

        private void LoadEtymonKeyControls()
        {
            string[] types = new string[] { "86", "98", "06" };
            for (int i = 0; i < types.Length; i++)
            {
                var eControl = new EtymonKeyControl() { EtymonKeyType = types[i] };
                Binding eKeyBinding = new Binding();
                eKeyBinding.Source = this;
                eKeyBinding.Path = new System.Windows.PropertyPath("ShowFanKey");
                eControl.SetBinding(EtymonKeyControl.IsShowFanKeyProperty, eKeyBinding);
                EtymonKeyControlDict.Add(types[i], eControl);
            }
        }
    }
}