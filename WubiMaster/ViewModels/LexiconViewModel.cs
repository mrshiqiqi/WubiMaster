using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class LexiconViewModel:ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<CikuModel> cikuList;

        public LexiconViewModel()
        {
            ObservableCollection<CikuModel> temp = new ObservableCollection<CikuModel>();
            for (int i = 0; i < 100; i++)
            {
                CikuModel ckModel = new CikuModel();
                ckModel.Id = i;
                ckModel.Code = "hello";
                ckModel.Worlds = "五笔大师";
                ckModel.Group = "默认";
                temp.Add(ckModel);
            }

            cikuList = temp;
        }
    }
}
