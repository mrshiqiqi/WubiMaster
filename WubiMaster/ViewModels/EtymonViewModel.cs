using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WubiMaster.Common;
using WubiMaster.Models;
using static System.Net.WebRequestMethods;

namespace WubiMaster.ViewModels
{
    public partial class EtymonViewModel : ObservableObject
    {
        private ConcurrentQueue<SpellingModel> QuickSpellingQueue06 = new ConcurrentQueue<SpellingModel>();
        private ConcurrentQueue<SpellingModel> QuickSpellingQueue86 = new ConcurrentQueue<SpellingModel>();
        private ConcurrentQueue<SpellingModel> QuickSpellingQueue98 = new ConcurrentQueue<SpellingModel>();

        [ObservableProperty]
        private string searchType = "全部";

        [ObservableProperty]
        private ObservableCollection<ZigenModel> spellingList;

        [ObservableProperty]
        private string wubiType;

        public EtymonViewModel()
        {
            SpellingList = new ObservableCollection<ZigenModel>();

            GetSpellingData();
        }

        [RelayCommand]
        public void ZigenSearch(object obj)
        {
            try
            {
                string searchText = obj?.ToString().Trim();
                if (string.IsNullOrEmpty(searchText)) return;

                string type = "";
                var content = searchText.Trim();
                SpellingList.Clear();
                ObservableCollection<ZigenModel> spellings = new ObservableCollection<ZigenModel>();
                char[] texts = content.ToCharArray().Distinct().ToArray();

                switch (SearchType)
                {
                    case "86":
                        type = "86";
                        break;

                    case "98":
                        type = "98";
                        break;

                    case "新世纪":
                        type = "06";
                        break;

                    default:
                        type = "全部";
                        break;
                }

                foreach (var text in texts)
                {
                    string key = text.ToString();

                    // get spelling text array
                    List<SpellingKeyModel> sList86 = GetSpellingKeyList(key, "86");
                    List<SpellingKeyModel> sList98 = GetSpellingKeyList(key, "98");
                    List<SpellingKeyModel> sList06 = GetSpellingKeyList(key, "06");
                    if (sList86 == null && sList98 == null && sList06 == null) continue;

                    // get code and pinyin text
                    List<CodeKeyModel> cList86 = GetCodeKeyList(key, "86");
                    List<CodeKeyModel> cList98 = GetCodeKeyList(key, "98");
                    List<CodeKeyModel> cList06 = GetCodeKeyList(key, "06");

                    // add the dataModel to list
                    ZigenModel zModel = new ZigenModel()
                    {
                        Text = key,
                        Type = "字",
                        SpellingKeyList86 = sList86,
                        SpellingKeyList98 = sList98,
                        SpellingKeyList06 = sList06,
                        CodeKeyList86 = cList86,
                        CodeKeyList98 = cList98,
                        CodeKeyList06 = cList06,
                        WubiType = type,
                    };
                    spellings.Add(zModel);
                }

                // update
                SpellingList = spellings;
            }
            catch (Exception ex)
            {
                this.ShowMessage("查询时出现异常，无法完成指定操作", DialogType.Error);
                LogHelper.Error(ex.Message);
            }
        }

        private List<CodeKeyModel> GetCodeKeyList(string textKey, string type)
        {
            ConcurrentQueue<SpellingModel> currentSpellingData = null;
            if (type == "86") currentSpellingData = QuickSpellingQueue86;
            else if (type == "98") currentSpellingData = QuickSpellingQueue98;
            else currentSpellingData = QuickSpellingQueue06;

            var dataModel = currentSpellingData?.FirstOrDefault(s => s.Text == textKey);
            if (dataModel == null) return null;
            List<CodeKeyModel> cList = new List<CodeKeyModel>();
            cList.Add(new CodeKeyModel() { CodeKey = dataModel.Code });
            for (int i = 0; i < dataModel.Pinyin.Length; i++)
            {
                var cModel = new CodeKeyModel()
                {
                    CodeKey = dataModel.Pinyin[i],
                };
                cList.Add(cModel);
            }

            return cList;
        }

        private void GetSpellingData()
        {
            QuickSpellingQueue86 = SpellingWorker.SpellingQueue86;
            QuickSpellingQueue98 = SpellingWorker.SpellingQueue98;
            QuickSpellingQueue06 = SpellingWorker.SpellingQueue06;
        }

        private List<SpellingKeyModel> GetSpellingKeyList(string textKey, string type)
        {
            ConcurrentQueue<SpellingModel> currentSpellingData = null;
            if (type == "86") currentSpellingData = QuickSpellingQueue86;
            else if (type == "98") currentSpellingData = QuickSpellingQueue98;
            else currentSpellingData = QuickSpellingQueue06;

            var dataModel = currentSpellingData?.FirstOrDefault(s => s.Text == textKey);
            if (dataModel == null) return null;
            char[] spellingChars = dataModel.Spelling.ToCharArray();

            List<SpellingKeyModel> sList = new List<SpellingKeyModel>();
            for (int i = 0; i < spellingChars.Length; i++)
            {
                var s = spellingChars[i].ToString().Trim();
                if (!string.IsNullOrEmpty(s))
                {
                    var sModel = new SpellingKeyModel()
                    {
                        SpellingKey = s,
                    };
                    sList.Add(sModel);
                }
            }

            return sList;
        }
    }
}