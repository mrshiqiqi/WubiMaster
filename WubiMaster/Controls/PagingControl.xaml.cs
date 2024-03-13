using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class PagingControl : UserControl
    {
        public static readonly DependencyProperty CountChangedCommandProperty =
            DependencyProperty.Register("CountChangedCommand", typeof(RelayCommand<object>), typeof(PagingControl));

        public static readonly DependencyProperty CountOfPageProperty =
                    DependencyProperty.Register("CountOfPage", typeof(int), typeof(PagingControl));

        public static readonly DependencyProperty FirstPageCommandProperty =
            DependencyProperty.Register("FirstPageCommand", typeof(RelayCommand<object>), typeof(PagingControl));

        public static readonly DependencyProperty LastPageCommandProperty =
            DependencyProperty.Register("LastPageCommand", typeof(RelayCommand<object>), typeof(PagingControl));

        public static readonly DependencyProperty NextPageCommandProperty =
            DependencyProperty.Register("NextPageCommand", typeof(RelayCommand<object>), typeof(PagingControl));

        public static readonly DependencyProperty PageIndexProperty =
                                    DependencyProperty.Register("PageIndex", typeof(int), typeof(PagingControl));

        public static readonly DependencyProperty PreviousPageCommandProperty =
            DependencyProperty.Register("PreviousPageCommand", typeof(RelayCommand<object>), typeof(PagingControl));

        public static readonly DependencyProperty SelectedIndexOfCountProperty =
            DependencyProperty.Register("SelectedIndexOfCount", typeof(int), typeof(PagingControl), new PropertyMetadata(0));

        public static readonly DependencyProperty TotalPageCountProperty =
                            DependencyProperty.Register("TotalPageCount", typeof(int), typeof(PagingControl));

        public PagingControl()
        {
            InitializeComponent();
        }

        public RelayCommand<object> CountChangedCommand
        {
            get { return (RelayCommand<object>)GetValue(CountChangedCommandProperty); }
            set { SetValue(CountChangedCommandProperty, value); }
        }

        public int CountOfPage
        {
            get { return (int)GetValue(CountOfPageProperty); }
            set { SetValue(CountOfPageProperty, value); }
        }

        public RelayCommand<object> FirstPageCommand
        {
            get { return (RelayCommand<object>)GetValue(FirstPageCommandProperty); }
            set { SetValue(FirstPageCommandProperty, value); }
        }

        public RelayCommand<object> LastPageCommand
        {
            get { return (RelayCommand<object>)GetValue(LastPageCommandProperty); }
            set { SetValue(LastPageCommandProperty, value); }
        }

        public RelayCommand<object> NextPageCommand
        {
            get { return (RelayCommand<object>)GetValue(NextPageCommandProperty); }
            set { SetValue(NextPageCommandProperty, value); }
        }

        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        public RelayCommand<object> PreviousPageCommand
        {
            get { return (RelayCommand<object>)GetValue(PreviousPageCommandProperty); }
            set { SetValue(PreviousPageCommandProperty, value); }
        }

        public int SelectedIndexOfCount
        {
            get { return (int)GetValue(SelectedIndexOfCountProperty); }
            set { SetValue(SelectedIndexOfCountProperty, value); }
        }

        public int TotalPageCount
        {
            get { return (int)GetValue(TotalPageCountProperty); }
            set { SetValue(TotalPageCountProperty, value); }
        }
    }
}