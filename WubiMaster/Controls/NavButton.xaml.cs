using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WubiMaster.Controls
{
    public partial class NavButton : UserControl
    {
        public NavButton()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NavButton));

        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }

        public static readonly DependencyProperty IconTextProperty =
            DependencyProperty.Register("IconText", typeof(string), typeof(NavButton));

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(NavButton));

        public Brush IconColor
        {
            get { return (Brush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        public static readonly DependencyProperty IconColorProperty =
            DependencyProperty.Register("IconColor", typeof(Brush), typeof(NavButton));

        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(NavButton));

        public double TextFontSize
        {
            get { return (double)GetValue(TextFontSizeProperty); }
            set { SetValue(TextFontSizeProperty, value); }
        }

        public static readonly DependencyProperty TextFontSizeProperty =
            DependencyProperty.Register("TextFontSize", typeof(double), typeof(NavButton));

        public double IcontFontSize
        {
            get { return (double)GetValue(IcontFontSizeProperty); }
            set { SetValue(IcontFontSizeProperty, value); }
        }

        public static readonly DependencyProperty IcontFontSizeProperty =
            DependencyProperty.Register("IcontFontSize", typeof(double), typeof(NavButton));

        public RelayCommand<object> NavCommand
        {
            get { return (RelayCommand<object>)GetValue(NavCommandProperty); }
            set { SetValue(NavCommandProperty, value); }
        }

        public static readonly DependencyProperty NavCommandProperty =
            DependencyProperty.Register("NavCommand", typeof(RelayCommand<object>), typeof(NavButton));

        public string NavName
        {
            get { return (string)GetValue(NavNameProperty); }
            set { SetValue(NavNameProperty, value); }
        }

        public static readonly DependencyProperty NavNameProperty =
            DependencyProperty.Register("NavName", typeof(string), typeof(NavButton));
    }
}