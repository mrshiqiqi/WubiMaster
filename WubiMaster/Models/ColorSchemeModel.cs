using CommunityToolkit.Mvvm.ComponentModel;

namespace WubiMaster.Models
{
    public partial class ColorSchemeModel : ObservableRecipient
    {
        [ObservableProperty]
        private ColorStyle style;

        [ObservableProperty]
        private ColorScheme usedColor;
    }
}