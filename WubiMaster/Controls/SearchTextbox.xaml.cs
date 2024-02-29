using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class SearchTextbox : UserControl
    {
        public static readonly DependencyProperty BorderCornerRadiusProperty =
            DependencyProperty.Register("BorderCornerRadius", typeof(CornerRadius), typeof(SearchTextbox));

        public static readonly DependencyProperty CombCornerRadiusProperty =
            DependencyProperty.Register("CombCornerRadius", typeof(CornerRadius), typeof(SearchTextbox));

        public static readonly DependencyProperty SearchButtonCommandProperty =
            DependencyProperty.Register("SearchButtonCommand", typeof(RelayCommand<object>), typeof(SearchTextbox));

        public static readonly DependencyProperty SearchButtonParameterProperty =
            DependencyProperty.Register("SearchButtonParameter", typeof(object), typeof(SearchTextbox));

        public static readonly DependencyProperty SecrchContentProperty =
                                            DependencyProperty.Register("SecrchContent", typeof(string), typeof(SearchTextbox));

        public static readonly DependencyProperty ShowComboBoxProperty =
            DependencyProperty.Register("ShowComboBox", typeof(Visibility), typeof(SearchTextbox));

        public static readonly DependencyProperty ShowSearchButtonProperty =
            DependencyProperty.Register("ShowSearchButton", typeof(Visibility), typeof(SearchTextbox));

        public static readonly DependencyProperty TextFontSizeProperty =
            DependencyProperty.Register("TextFontSize", typeof(double), typeof(SearchTextbox));

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(SearchTextbox));

        public static readonly DependencyProperty TextMaxLengthProperty =
            DependencyProperty.Register("TextMaxLength", typeof(int), typeof(SearchTextbox), new PropertyMetadata(10));

        public static readonly DependencyProperty WaterMarkTextProperty =
                                                    DependencyProperty.Register("WaterMarkText", typeof(string), typeof(SearchTextbox));

        public SearchTextbox()
        {
            InitializeComponent();
        }

        public CornerRadius BorderCornerRadius
        {
            get { return (CornerRadius)GetValue(BorderCornerRadiusProperty); }
            set { SetValue(BorderCornerRadiusProperty, value); }
        }

        public CornerRadius CombCornerRadius
        {
            get { return (CornerRadius)GetValue(CombCornerRadiusProperty); }
            set { SetValue(CombCornerRadiusProperty, value); }
        }

        public RelayCommand<object> SearchButtonCommand
        {
            get { return (RelayCommand<object>)GetValue(SearchButtonCommandProperty); }
            set { SetValue(SearchButtonCommandProperty, value); }
        }

        public object SearchButtonParameter
        {
            get { return (object)GetValue(SearchButtonParameterProperty); }
            set { SetValue(SearchButtonParameterProperty, value); }
        }

        public string SecrchContent
        {
            get { return (string)GetValue(SecrchContentProperty); }
            set { SetValue(SecrchContentProperty, value); }
        }

        public Visibility ShowComboBox
        {
            get { return (Visibility)GetValue(ShowComboBoxProperty); }
            set { SetValue(ShowComboBoxProperty, value); }
        }

        public Visibility ShowSearchButton
        {
            get { return (Visibility)GetValue(ShowSearchButtonProperty); }
            set { SetValue(ShowSearchButtonProperty, value); }
        }

        public double TextFontSize
        {
            get { return (double)GetValue(TextFontSizeProperty); }
            set { SetValue(TextFontSizeProperty, value); }
        }

        public Thickness TextMargin
        {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }

        public int TextMaxLength
        {
            get { return (int)GetValue(TextMaxLengthProperty); }
            set { SetValue(TextMaxLengthProperty, value); }
        }

        public string WaterMarkText
        {
            get { return (string)GetValue(WaterMarkTextProperty); }
            set { SetValue(WaterMarkTextProperty, value); }
        }
    }
}