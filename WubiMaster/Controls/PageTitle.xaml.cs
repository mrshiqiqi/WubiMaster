using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class PageTitle : UserControl
    {
        public PageTitle()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PageTitle));
    }
}