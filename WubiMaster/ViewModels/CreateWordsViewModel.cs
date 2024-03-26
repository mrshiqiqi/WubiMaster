using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WubiMaster.ViewModels
{
    public partial class CreateWordsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> cikuList;

        [ObservableProperty]
        private string newWord;

        [ObservableProperty]
        private ObservableCollection<string> containsWords;

        [ObservableProperty]
        private string newCode;

        public CreateWordsViewModel()
        {

        }

        [RelayCommand]
        public void AddNewWord()
        {

        }

        [RelayCommand]
        public void AddNextNewWord()
        {

        }

        [RelayCommand]
        public void CloseWindow(object obj)
        {

        }

        private void GetCiKuList()
        {

        }

        private void CreateNewCode()
        {

        }

        private void GetContainsWords()
        {

        }
    }
}
