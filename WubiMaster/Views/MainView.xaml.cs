using System;
using System.Windows;
using System.Windows.Input;

namespace WubiMaster.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            Application.Current.Resources.MergedDictionaries[0].Source = new Uri("pack://application:,,,/Themes/DarkYellowTheme.xaml");
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool isMaximized = false;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (isMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1000;
                    this.Height = 618;

                    isMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    isMaximized = true;
                }
            }
        }

        private void btn_theme_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resource = new ResourceDictionary();
            string darkYellowThemePack = "pack://application:,,,/Themes/DarkYellowTheme.xaml";
            string darkBlueThemePack = "pack://application:,,,/Themes/DarkBlueTheme.xaml";
            if (Application.Current.Resources.MergedDictionaries[0].Source.ToString() == darkYellowThemePack)
            {
                resource.Source = new Uri(darkBlueThemePack);
            }
            else
            {
                resource.Source = new Uri(darkYellowThemePack);
            }
            Application.Current.Resources.MergedDictionaries[0].Source = resource.Source;
        }

        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}