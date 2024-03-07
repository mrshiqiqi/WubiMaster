using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.IO;
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

        public EtymonKeyViewModel()
        {
            EKeyControl = new EtymonKeyControl();
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
                    this.ShowMessage("保存失败",DialogType.Fail);
                }
            });
        }
    }
}