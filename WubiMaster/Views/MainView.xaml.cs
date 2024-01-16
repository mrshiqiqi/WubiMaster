using System.Windows;
using System.Windows.Input;

namespace WubiMaster.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (App.IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1000;
                    this.Height = 700;

                    App.IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    App.IsMaximized = true;
                }
            }
        }
    }
}