using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Concurrent;

namespace WubiMaster.ViewModels
{
    public partial class EtymonViewModel : ObservableObject
    {
        ConcurrentQueue<SpellingModel> QuickSpellingQueue86 = new ConcurrentQueue<SpellingModel>();
        ConcurrentQueue<SpellingModel> QuickSpellingQueue98 = new ConcurrentQueue<SpellingModel>();
        ConcurrentQueue<SpellingModel> QuickSpellingQueue06 = new ConcurrentQueue<SpellingModel>();

        [ObservableProperty]
        private ObservableCollection<ZigenModel> spellingList;

        [ObservableProperty]
        private string wubiType;

        [ObservableProperty]
        private string searchType = "全部";

        public EtymonViewModel()
        {
            SpellingList = new ObservableCollection<ZigenModel>();

            GetSpellingData();
        }

        private void GetSpellingData()
        {
            QuickSpellingQueue86 = SpellingWorker.SpellingQueue86;
            QuickSpellingQueue98 = SpellingWorker.SpellingQueue98;
            QuickSpellingQueue06 = SpellingWorker.SpellingQueue06;
        }


        [RelayCommand]
        public void ZigenSearch(object obj)
        {
            string searchText = obj?.ToString().Trim();
            if (string.IsNullOrEmpty(searchText)) return;

            Search(searchText, SearchType);
        }

        private void Search(string content, string type)
        {
            switch (type)
            {
                case "86":
                    WubiType = "86";
                    break;
                case "98":
                    WubiType = "98";
                    break;
                case "新世纪":
                    WubiType = "06";
                    break;
                default:
                    WubiType = "全部";
                    break;
            }
            content = content.Trim();
            SpellingList.Clear();
            ObservableCollection<ZigenModel> spellings = new ObservableCollection<ZigenModel>();

            char[] texts = content.ToCharArray().Distinct().ToArray();

            foreach (var text in texts)
            {
                string key = text.ToString();
                var model = QuickSpellingQueue86.FirstOrDefault(s => s.Text == key);
                if (model == null) continue;

                char[] spellingChars = model.Spelling.ToCharArray();
                string[] spellingArray = new string[4] { "", "", "", "" };
                List<string> spellingStrs = new List<string>();
                for (int i = 0; i < spellingChars.Length; i++)
                {
                    var s = spellingChars[i].ToString().Trim();
                    if (!string.IsNullOrEmpty(s))
                    {
                        spellingStrs.Add(s);
                    }
                }

                for (int i = 0; i < spellingStrs.Count; i++)
                {
                    spellingArray[i] = spellingStrs[i].ToString().Trim();
                }

                ZigenModel zModel = new ZigenModel()
                {
                    Text = model.Text,
                    Type = "字",
                    SpellingText1 = spellingArray[0],
                    SpellingText2 = spellingArray[1],
                    SpellingText3 = spellingArray[2],
                    SpellingText4 = spellingArray[3],
                    CodeText = model.Code,
                    GBKText = model.GBType,
                    WubiType = WubiType,
                };
                spellings.Add(zModel);
            }

            SpellingList = spellings;
        }
    }
}
