using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class LexiconViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<CikuModel> cikuList;

        public LexiconViewModel()
        {
            ReadWubiDictData();
        }

        private void ReadWubiDictData()
        {
            string defaultCikuFile = ConfigHelper.ReadConfigByString("default_ciku_file");
            if (string.IsNullOrEmpty(defaultCikuFile))
                return;

            try
            {
                string defaultCikuPath = ConfigHelper.ReadConfigByString("user_file_path") + "\\" + defaultCikuFile;

                // 按行读，找到 yaml 的结尾符 ...
                string yamlText = "";
                int yamlEndLine = -1;
                ConcurrentQueue<CikuModel> wubiDictList = new ConcurrentQueue<CikuModel>();

                string[] wubiDictStrs = File.ReadAllLines(defaultCikuPath);

                for (int i = 0; i < wubiDictStrs.Length; i++)
                {
                    yamlEndLine = i + 1;
                    if (wubiDictStrs[i] == "...")
                        break;
                    yamlText += wubiDictStrs[i] + "\r\n";
                }

                Parallel.For(yamlEndLine, wubiDictStrs.Length, (j) =>
                {
                    string dataStr = wubiDictStrs[j];
                    string[] dataInfoArrsy = dataStr.Split("\t").Where(d => d != "").ToArray();

                    string[] values = new string[] { "", "", "", "", "默认" };
                    for (int i = 0; i < dataInfoArrsy.Length; i++)
                        values[i] = dataInfoArrsy[i];
                    CikuModel model = new CikuModel();
                    model.Id = j - yamlEndLine;
                    model.Text = values[0];
                    model.Code = values[1];
                    model.Weight = values[2];
                    model.Stem = values[3];
                    model.Group = values[4];

                    wubiDictList.Enqueue(model);
                });

                var _list = wubiDictList.OrderBy(d => d.Id).ToList();

                ObservableCollection<CikuModel> temp_list = new ObservableCollection<CikuModel>();
                for (int i = 0; i < 20; i++)
                {
                    CikuModel c = _list[i];
                    temp_list.Add(c);
                }

                CikuList = temp_list;
            }
            catch (Exception ex)
            {
                this.ShowMessage($"无法加载词库信息，请检查配置信息是否正确！", DialogType.Warring);
                LogHelper.Error(ex.Message);
            }
        }
    }
}