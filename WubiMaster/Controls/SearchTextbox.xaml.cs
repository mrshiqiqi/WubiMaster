using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class SearchTextbox : UserControl
    {
        public static readonly DependencyProperty SecrchContentProperty =
            DependencyProperty.Register("SecrchContent", typeof(string), typeof(SearchTextbox));

        public static readonly DependencyProperty WaterMarkTextProperty =
            DependencyProperty.Register("WaterMarkText", typeof(string), typeof(SearchTextbox));

        public SearchTextbox()
        {
            InitializeComponent();
        }




        public Thickness TextMargin
        {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(SearchTextbox));



        public CornerRadius BorderCornerRadius
        {
            get { return (CornerRadius)GetValue(BorderCornerRadiusProperty); }
            set { SetValue(BorderCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty BorderCornerRadiusProperty =
            DependencyProperty.Register("BorderCornerRadius", typeof(CornerRadius), typeof(SearchTextbox));




        public double TextFontSize
        {
            get { return (double)GetValue(TextFontSizeProperty); }
            set { SetValue(TextFontSizeProperty, value); }
        }

        public static readonly DependencyProperty TextFontSizeProperty =
            DependencyProperty.Register("TextFontSize", typeof(double), typeof(SearchTextbox));



        public Visibility ShowSearchButton
        {
            get { return (Visibility)GetValue(ShowSearchButtonProperty); }
            set { SetValue(ShowSearchButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowSearchButtonProperty =
            DependencyProperty.Register("ShowSearchButton", typeof(Visibility), typeof(SearchTextbox));


        public CornerRadius CombCornerRadius
        {
            get { return (CornerRadius)GetValue(CombCornerRadiusProperty); }
            set { SetValue(CombCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CombCornerRadiusProperty =
            DependencyProperty.Register("CombCornerRadius", typeof(CornerRadius), typeof(SearchTextbox));



        public Visibility ShowComboBox
        {
            get { return (Visibility)GetValue(ShowComboBoxProperty); }
            set { SetValue(ShowComboBoxProperty, value); }
        }

        public static readonly DependencyProperty ShowComboBoxProperty =
            DependencyProperty.Register("ShowComboBox", typeof(Visibility), typeof(SearchTextbox));


        public string SecrchContent
        {
            get { return (string)GetValue(SecrchContentProperty); }
            set { SetValue(SecrchContentProperty, value); }
        }

        public string WaterMarkText
        {
            get { return (string)GetValue(WaterMarkTextProperty); }
            set { SetValue(WaterMarkTextProperty, value); }
        }
    }
}