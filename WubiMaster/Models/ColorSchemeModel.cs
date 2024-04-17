using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WubiMaster.Models
{
    public partial class ColorSchemeModel : ObservableRecipient
    {
        [ObservableProperty]
        private Brush backColor;

        [ObservableProperty]
        private Brush borderColor;

        [ObservableProperty]
        private Brush candidateTextColor;

        [ObservableProperty]
        private Brush commentTextColor;

        [ObservableProperty]
        private Brush hilitedBackColor;

        [ObservableProperty]
        private Brush hilitedCandidateBackColor;

        [ObservableProperty]
        private Brush hilitedCandidateLabelColor;

        [ObservableProperty]
        private Brush hilitedCandidateTextColor;

        [ObservableProperty]
        private Brush hilitedCommentTextColor;

        [ObservableProperty]
        private Brush hilitedLabelColor;

        [ObservableProperty]
        private Brush hilitedTextColor;

        [ObservableProperty]
        private Brush labelColor;
    }
}