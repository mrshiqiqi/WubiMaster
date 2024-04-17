using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WubiMaster.Controls
{
    public partial class ColorSchemeControl : UserControl
    {
        public static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty BorderCornerRadiusProperty =
                            DependencyProperty.Register("BorderCornerRadius", typeof(CornerRadius), typeof(ColorSchemeControl));

        public static readonly DependencyProperty BorderWidthProperty =
            DependencyProperty.Register("BorderWidth", typeof(Thickness), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CandidateTextColorProperty =
            DependencyProperty.Register("CandidateTextColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedBackColorProperty =
                    DependencyProperty.Register("HilitedBackColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateBackColorProperty =
            DependencyProperty.Register("HilitedCandidateBackColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateTextColorProperty =
                    DependencyProperty.Register("HilitedCandidateTextColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedLabelColorProperty =
                    DependencyProperty.Register("HilitedLabelColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty StyleOrientationProperty =
                                                    DependencyProperty.Register("StyleOrientation", typeof(Orientation), typeof(ColorSchemeControl), new PropertyMetadata(Orientation.Horizontal));

        public ColorSchemeControl()
        {
            InitializeComponent();
        }

        public Brush BackColor
        {
            get { return (Brush)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }

        public Brush BorderColor
        {
            get { return (Brush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public CornerRadius BorderCornerRadius
        {
            get { return (CornerRadius)GetValue(BorderCornerRadiusProperty); }
            set { SetValue(BorderCornerRadiusProperty, value); }
        }

        public Thickness BorderWidth
        {
            get { return (Thickness)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public Brush CandidateTextColor
        {
            get { return (Brush)GetValue(CandidateTextColorProperty); }
            set { SetValue(CandidateTextColorProperty, value); }
        }

        public Brush HilitedBackColor
        {
            get { return (Brush)GetValue(HilitedBackColorProperty); }
            set { SetValue(HilitedBackColorProperty, value); }
        }

        public Brush HilitedCandidateBackColor
        {
            get { return (Brush)GetValue(HilitedCandidateBackColorProperty); }
            set { SetValue(HilitedCandidateBackColorProperty, value); }
        }

        public Brush HilitedCandidateTextColor
        {
            get { return (Brush)GetValue(HilitedCandidateTextColorProperty); }
            set { SetValue(HilitedCandidateTextColorProperty, value); }
        }

        public Brush HilitedLabelColor
        {
            get { return (Brush)GetValue(HilitedLabelColorProperty); }
            set { SetValue(HilitedLabelColorProperty, value); }
        }

        public Orientation StyleOrientation
        {
            get { return (Orientation)GetValue(StyleOrientationProperty); }
            set { SetValue(StyleOrientationProperty, value); }
        }
    }
}