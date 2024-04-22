using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
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
        public static readonly DependencyProperty AuthorProperty =
            DependencyProperty.Register("Author", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CandidateBackColorProperty =
            DependencyProperty.Register("CandidateBackColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CandidateCorderColorProperty =
            DependencyProperty.Register("CandidateCorderColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CandidateShadowColorProperty =
                    DependencyProperty.Register("CandidateShadowColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CandidateTextColorProperty =
                            DependencyProperty.Register("CandidateTextColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty ColorFormatProperty =
                                    DependencyProperty.Register("ColorFormat", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty ColorNameProperty =
                    DependencyProperty.Register("ColorName", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CommentTextColorProperty =
            DependencyProperty.Register("CommentTextColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedBackColorProperty =
            DependencyProperty.Register("HilitedBackColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateBackColorProperty =
            DependencyProperty.Register("HilitedCandidateBackColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateBorderColorProperty =
            DependencyProperty.Register("HilitedCandidateBorderColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateShadowColorProperty =
                    DependencyProperty.Register("HilitedCandidateShadowColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateTextColorProperty =
                            DependencyProperty.Register("HilitedCandidateTextColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCommentTextColorProperty =
            DependencyProperty.Register("HilitedCommentTextColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedLabelColorProperty =
                    DependencyProperty.Register("HilitedLabelColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedMarkColorProperty =
            DependencyProperty.Register("HilitedMarkColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedShadowColorProperty =
                                    DependencyProperty.Register("HilitedShadowColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedTextColorProperty =
                            DependencyProperty.Register("HilitedTextColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty labelColorProperty =
                    DependencyProperty.Register("labelColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty NextPageColorProperty =
            DependencyProperty.Register("NextPageColor", typeof(string), typeof(ColorSchemeControl), new PropertyMetadata("#00000000"));

        public static readonly DependencyProperty PrevpageColorProperty =
            DependencyProperty.Register("PrevpageColor", typeof(string), typeof(ColorSchemeControl), new PropertyMetadata("#00000000"));

        public static readonly DependencyProperty ShadowColorProperty =
                            DependencyProperty.Register("ShadowColor", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty TextColorProperty =
                                    DependencyProperty.Register("TextColor", typeof(string), typeof(ColorSchemeControl), new PropertyMetadata( new PropertyChangedCallback(OnTextColorPropertyChanged)));

        private static void OnTextColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorSchemeControl control = (ColorSchemeControl)d;
        }

        public ColorSchemeControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 配色作者名称
        /// </summary>
        public string Author
        {
            get { return (string)GetValue(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }

        /// <summary>
        /// 候选窗背景色
        /// </summary>
        public string BackColor
        {
            get { return (string)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }

        /// <summary>
        /// 候选窗边框颜色
        /// </summary>
        public string BorderColor
        {
            get { return (string)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// 非高亮候选背景颜色
        /// </summary>
        public string CandidateBackColor
        {
            get { return (string)GetValue(CandidateBackColorProperty); }
            set { SetValue(CandidateBackColorProperty, value); }
        }

        /// <summary>
        /// 非高亮候选的边框颜色
        /// </summary>
        public string CandidateCorderColor
        {
            get { return (string)GetValue(CandidateCorderColorProperty); }
            set { SetValue(CandidateCorderColorProperty, value); }
        }

        /// <summary>
        /// 非高亮候选背景块阴影颜色
        /// </summary>
        public string CandidateShadowColor
        {
            get { return (string)GetValue(CandidateShadowColorProperty); }
            set { SetValue(CandidateShadowColorProperty, value); }
        }

        /// <summary>
        /// 非高亮候选文字颜色
        /// </summary>
        public string CandidateTextColor
        {
            get { return (string)GetValue(CandidateTextColorProperty); }
            set { SetValue(CandidateTextColorProperty, value); }
        }

        /// <summary>
        /// 颜色格式：argb；rgba；abgr（默认）
        /// </summary>
        public string ColorFormat
        {
            get { return (string)GetValue(ColorFormatProperty); }
            set { SetValue(ColorFormatProperty, value); }
        }

        /// <summary>
        /// 方案设置中显示的配色名称
        /// </summary>
        public string ColorName
        {
            get { return (string)GetValue(ColorNameProperty); }
            set { SetValue(ColorNameProperty, value); }
        }

        /// <summary>
        /// 注释文字颜色
        /// </summary>
        public string CommentTextColor
        {
            get { return (string)GetValue(CommentTextColorProperty); }
            set { SetValue(CommentTextColorProperty, value); }
        }

        /// <summary>
        /// 编码背景颜色
        /// </summary>
        public string HilitedBackColor
        {
            get { return (string)GetValue(HilitedBackColorProperty); }
            set { SetValue(HilitedBackColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选背景颜色
        /// </summary>
        public string HilitedCandidateBackColor
        {
            get { return (string)GetValue(HilitedCandidateBackColorProperty); }
            set { SetValue(HilitedCandidateBackColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选边框颜色
        /// </summary>
        public string HilitedCandidateBorderColor
        {
            get { return (string)GetValue(HilitedCandidateBorderColorProperty); }
            set { SetValue(HilitedCandidateBorderColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选背景块阴影颜色
        /// </summary>
        public string HilitedCandidateShadowColor
        {
            get { return (string)GetValue(HilitedCandidateShadowColorProperty); }
            set { SetValue(HilitedCandidateShadowColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选文字颜色
        /// </summary>
        public string HilitedCandidateTextColor
        {
            get { return (string)GetValue(HilitedCandidateTextColorProperty); }
            set { SetValue(HilitedCandidateTextColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选的注释颜色
        /// </summary>
        public string HilitedCommentTextColor
        {
            get { return (string)GetValue(HilitedCommentTextColorProperty); }
            set { SetValue(HilitedCommentTextColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选的标签颜色
        /// </summary>
        public string HilitedLabelColor
        {
            get { return (string)GetValue(HilitedLabelColorProperty); }
            set { SetValue(HilitedLabelColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选前的标记颜色
        /// </summary>
        public string HilitedMarkColor
        {
            get { return (string)GetValue(HilitedMarkColorProperty); }
            set { SetValue(HilitedMarkColorProperty, value); }
        }

        /// <summary>
        /// 编码背景块阴影颜色
        /// </summary>
        public string HilitedShadowColor
        {
            get { return (string)GetValue(HilitedShadowColorProperty); }
            set { SetValue(HilitedShadowColorProperty, value); }
        }

        /// <summary>
        /// 编码文字颜色
        /// </summary>
        public string HilitedTextColor
        {
            get { return (string)GetValue(HilitedTextColorProperty); }
            set { SetValue(HilitedTextColorProperty, value); }
        }

        /// <summary>
        /// 标签文字颜色
        /// </summary>
        public string labelColor
        {
            get { return (string)GetValue(labelColorProperty); }
            set { SetValue(labelColorProperty, value); }
        }

        /// <summary>
        /// 翻页箭头颜色：下一页；不设置则不显示箭头
        /// inline_preedit: false
        /// </summary>
        public string NextPageColor
        {
            get { return (string)GetValue(NextPageColorProperty); }
            set { SetValue(NextPageColorProperty, value); }
        }

        /// <summary>
        /// 翻页箭头颜色：上一页；不设置则不显示箭头
        /// inline_preedit: false
        /// </summary>
        public string PrevpageColor
        {
            get { return (string)GetValue(PrevpageColorProperty); }
            set { SetValue(PrevpageColorProperty, value); }
        }

        /// <summary>
        /// 候选窗阴影色
        /// </summary>
        public string ShadowColor
        {
            get { return (string)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        /// <summary>
        /// 默认文字颜色
        /// </summary>
        public string TextColor
        {
            get { return (string)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }


        /// <summary>
        /// 标签、候选文字、注解文字之间的相对对齐方式 (top ; center ; bottom)
        /// </summary>
        public string AlignType
        {
            get { return (string)GetValue(AlignTypeProperty); }
            set { SetValue(AlignTypeProperty, value); }
        }

        public static readonly DependencyProperty AlignTypeProperty =
            DependencyProperty.Register("AlignType", typeof(string), typeof(ColorSchemeControl), new PropertyMetadata("center"));


        /// <summary>
        /// 候选框最大高度，0 不启用此功能
        /// </summary>
        public double ColorMaxHeight
        {
            get { return (double)GetValue(MaxHeightColorMaxHeightProperty); }
            set { SetValue(MaxHeightColorMaxHeightProperty, value); }
        }

        public static readonly DependencyProperty MaxHeightColorMaxHeightProperty =
            DependencyProperty.Register("ColorMaxHeight", typeof(double), typeof(ColorSchemeControl));


        /// <summary>
        /// 候选框最大宽度，0 不启用此功能
        /// </summary>
        public double ColorMaxWidth
        {
            get { return (double)GetValue(ColorMaxWidthProperty); }
            set { SetValue(ColorMaxWidthProperty, value); }
        }

        public static readonly DependencyProperty ColorMaxWidthProperty =
            DependencyProperty.Register("ColorMaxWidth", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 候选框最小高度
        /// </summary>
        public double ColorMinHeight
        {
            get { return (double)GetValue(ColorMinHeightProperty); }
            set { SetValue(ColorMinHeightProperty, value); }
        }

        public static readonly DependencyProperty ColorMinHeightProperty =
            DependencyProperty.Register("ColorMinHeight", typeof(double), typeof(ColorSchemeControl));


        /// <summary>
        /// 候选框最小宽度
        /// </summary>
        public double ColorMinWidth
        {
            get { return (double)GetValue(ColorMinWidthProperty); }
            set { SetValue(ColorMinWidthProperty, value); }
        }

        public static readonly DependencyProperty ColorMinWidthProperty =
            DependencyProperty.Register("ColorMinWidth", typeof(double), typeof(ColorSchemeControl));


        /// <summary>
        /// 边框宽度
        /// </summary>
        public double BorderWidth
        {
            get { return (double)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly DependencyProperty BorderWidthProperty =
            DependencyProperty.Register("BorderWidth", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 主体元素和候选框的左右、上下边距，为负值时，不显示候选框
        /// </summary>
        public double MarginX
        {
            get { return (double)GetValue(MarginXProperty); }
            set { SetValue(MarginXProperty, value); }
        }

        public static readonly DependencyProperty MarginXProperty =
            DependencyProperty.Register("MarginX", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 主体元素和候选框的左右、上下边距，为负值时，不显示候选框
        /// </summary>
        public double MarginY
        {
            get { return (double)GetValue(MarginYProperty); }
            set { SetValue(MarginYProperty, value); }
        }

        public static readonly DependencyProperty MarginYProperty =
            DependencyProperty.Register("MarginY", typeof(double), typeof(ColorSchemeControl));


        /// <summary>
        /// inline_preedit 为 false 时，编码区域和候选区域的间距
        /// </summary>
        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public static readonly DependencyProperty SpacingProperty =
            DependencyProperty.Register("Spacing", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 候选项之间的间距
        /// </summary>
        public double CandidateSpacing
        {
            get { return (double)GetValue(CandidateSpacingProperty); }
            set { SetValue(CandidateSpacingProperty, value); }
        }

        public static readonly DependencyProperty CandidateSpacingProperty =
            DependencyProperty.Register("CandidateSpacing", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 候选项和相应标签的间距，候选项与注解文字之间的距离
        /// </summary>
        public double HiliteSpacing
        {
            get { return (double)GetValue(HiliteSpacingProperty); }
            set { SetValue(HiliteSpacingProperty, value); }
        }

        public static readonly DependencyProperty HiliteSpacingProperty =
            DependencyProperty.Register("HiliteSpacing", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 高亮区域和内部文字的间距，影响高亮区域大小
        /// </summary>
        public double HilitePadding
        {
            get { return (double)GetValue(HilitePaddingProperty); }
            set { SetValue(HilitePaddingProperty, value); }
        }

        public static readonly DependencyProperty HilitePaddingProperty =
            DependencyProperty.Register("HilitePadding", typeof(double), typeof(ColorSchemeControl));


        /// <summary>
        /// 阴影区域半径，为 0 不显示阴影；需要同时在配色方案中指定非透明的阴影颜色
        /// </summary>
        public double ShadowRadius
        {
            get { return (double)GetValue(ShadowRadiusProperty); }
            set { SetValue(ShadowRadiusProperty, value); }
        }

        public static readonly DependencyProperty ShadowRadiusProperty =
            DependencyProperty.Register("ShadowRadius", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 阴影绘制的偏离距离
        /// </summary>
        public double ShadowOffsetX
        {
            get { return (double)GetValue(ShadowOffsetXProperty); }
            set { SetValue(ShadowOffsetXProperty, value); }
        }

        public static readonly DependencyProperty ShadowOffsetXProperty =
            DependencyProperty.Register("ShadowOffsetX", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 阴影绘制的偏离距离
        /// </summary>
        public double ShadowOffsetY
        {
            get { return (double)GetValue(ShadowOffsetYProperty); }
            set { SetValue(ShadowOffsetYProperty, value); }
        }

        public static readonly DependencyProperty ShadowOffsetYProperty =
            DependencyProperty.Register("ShadowOffsetY", typeof(double), typeof(ColorSchemeControl));


        /// <summary>
        /// 候选窗口圆角半径
        /// </summary>
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(ColorSchemeControl));


        /// <summary>
        /// 候选背景色块圆角半径，别名 hilited_corner_radius
        /// </summary>
        public double RoundCorner
        {
            get { return (double)GetValue(RoundCornerProperty); }
            set { SetValue(RoundCornerProperty, value); }
        }

        public static readonly DependencyProperty RoundCornerProperty =
            DependencyProperty.Register("RoundCorner", typeof(double), typeof(ColorSchemeControl));


        /// <summary>
        /// 配色方案
        /// </summary>
        public string ColorScheme
        {
            get { return (string)GetValue(ColorSchemeProperty); }
            set { SetValue(ColorSchemeProperty, value); }
        }

        public static readonly DependencyProperty ColorSchemeProperty =
            DependencyProperty.Register("ColorScheme", typeof(string), typeof(ColorSchemeControl));


        /// <summary>
        /// 设置系统为深色模式时的配色方案
        /// </summary>
        public string ColorThemeDark
        {
            get { return (string)GetValue(ColorThemeDarkProperty); }
            set { SetValue(ColorThemeDarkProperty, value); }
        }

        public static readonly DependencyProperty ColorThemeDarkProperty =
            DependencyProperty.Register("ColorThemeDark", typeof(string), typeof(ColorSchemeControl));


        /// <summary>
        /// 全局字体
        /// </summary>
        public string FontFace
        {
            get { return (string)GetValue(FontFaceProperty); }
            set { SetValue(FontFaceProperty, value); }
        }

        public static readonly DependencyProperty FontFaceProperty =
            DependencyProperty.Register("FontFace", typeof(string), typeof(ColorSchemeControl));



        /// <summary>
        /// 标签字体
        /// </summary>
        public string LabelFontFace
        {
            get { return (string)GetValue(LabelFontFaceProperty); }
            set { SetValue(LabelFontFaceProperty, value); }
        }

        public static readonly DependencyProperty LabelFontFaceProperty =
            DependencyProperty.Register("LabelFontFace", typeof(string), typeof(ColorSchemeControl));


        /// <summary>
        ///  注释字体
        /// </summary>
        public string CommentFontFace
        {
            get { return (string)GetValue(CommentFontFaceProperty); }
            set { SetValue(CommentFontFaceProperty, value); }
        }

        public static readonly DependencyProperty CommentFontFaceProperty =
            DependencyProperty.Register("CommentFontFace", typeof(string), typeof(ColorSchemeControl));


        /// <summary>
        /// 全局字号
        /// </summary>
        public double FontPoint
        {
            get { return (double)GetValue(FontPointProperty); }
            set { SetValue(FontPointProperty, value); }
        }

        public static readonly DependencyProperty FontPointProperty =
            DependencyProperty.Register("FontPoint", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 标签字号
        /// </summary>
        public double LabelFontPoint
        {
            get { return (double)GetValue(LabelFontPointProperty); }
            set { SetValue(LabelFontPointProperty, value); }
        }

        public static readonly DependencyProperty LabelFontPointProperty =
            DependencyProperty.Register("LabelFontPoint", typeof(double), typeof(ColorSchemeControl));


        /// <summary>
        /// 注释字号
        /// </summary>
        public double CommentFontPoint
        {
            get { return (double)GetValue(CommentFontPointProperty); }
            set { SetValue(CommentFontPointProperty, value); }
        }

        public static readonly DependencyProperty CommentFontPointProperty =
            DependencyProperty.Register("CommentFontPoint", typeof(double), typeof(ColorSchemeControl));



        /// <summary>
        /// 是否全屏模式
        /// </summary>
        public bool FullScreen
        {
            get { return (bool)GetValue(FullScreenProperty); }
            set { SetValue(FullScreenProperty, value); }
        }

        public static readonly DependencyProperty FullScreenProperty =
            DependencyProperty.Register("FullScreen", typeof(bool), typeof(ColorSchemeControl));



        /// <summary>
        /// 是否横向布局
        /// </summary>
        public bool Horizontal
        {
            get { return (bool)GetValue(HorizontalProperty); }
            set { SetValue(HorizontalProperty, value); }
        }

        public static readonly DependencyProperty HorizontalProperty =
            DependencyProperty.Register("Horizontal", typeof(bool), typeof(ColorSchemeControl));




        /// <summary>
        /// 是否启用竖排文本
        /// </summary>
        public bool VerticalText
        {
            get { return (bool)GetValue(VerticalTextProperty); }
            set { SetValue(VerticalTextProperty, value); }
        }

        public static readonly DependencyProperty VerticalTextProperty =
            DependencyProperty.Register("VerticalText", typeof(bool), typeof(ColorSchemeControl));



        /// <summary>
        /// 竖排方向是否从左到右
        /// </summary>
        public bool VerticalTextLeftToRight
        {
            get { return (bool)GetValue(VerticalTextLeftToRightProperty); }
            set { SetValue(VerticalTextLeftToRightProperty, value); }
        }

        public static readonly DependencyProperty VerticalTextLeftToRightProperty =
            DependencyProperty.Register("VerticalTextLeftToRight", typeof(bool), typeof(ColorSchemeControl));



        /// <summary>
        /// 文本竖排模式下是否自动换行
        /// </summary>
        public bool VerticalTextWithWrap
        {
            get { return (bool)GetValue(VerticalTextWithWrapProperty); }
            set { SetValue(VerticalTextWithWrapProperty, value); }
        }

        public static readonly DependencyProperty VerticalTextWithWrapProperty =
            DependencyProperty.Register("VerticalTextWithWrap", typeof(bool), typeof(ColorSchemeControl));


        /// <summary>
        /// 文本竖排模式下，候选窗口位于光标上方时倒序排序
        /// </summary>
        public bool VerticalAutoReverse
        {
            get { return (bool)GetValue(VerticalAutoReverseProperty); }
            set { SetValue(VerticalAutoReverseProperty, value); }
        }

        public static readonly DependencyProperty VerticalAutoReverseProperty =
            DependencyProperty.Register("VerticalAutoReverse", typeof(bool), typeof(ColorSchemeControl));



        /// <summary>
        /// 是否在行内显示预编辑区
        /// </summary>
        public bool InlinePreedit
        {
            get { return (bool)GetValue(InlinePreeditProperty); }
            set { SetValue(InlinePreeditProperty, value); }
        }

        public static readonly DependencyProperty InlinePreeditProperty =
            DependencyProperty.Register("InlinePreedit", typeof(bool), typeof(ColorSchemeControl));



        /// <summary>
        /// 预编辑区显示内容 composition（编码）；preview（高亮候选）；preview_all（全部候选）
        /// </summary>
        public string PreeditType
        {
            get { return (string)GetValue(PreeditTypeProperty); }
            set { SetValue(PreeditTypeProperty, value); }
        }

        public static readonly DependencyProperty PreeditTypeProperty =
            DependencyProperty.Register("PreeditType", typeof(string), typeof(ColorSchemeControl));



        /// <summary>
        /// 标签字符号
        /// </summary>
        public string LabelFormat
        {
            get { return (string)GetValue(LabelFormatProperty); }
            set { SetValue(LabelFormatProperty, value); }
        }

        public static readonly DependencyProperty LabelFormatProperty =
            DependencyProperty.Register("LabelFormat", typeof(string), typeof(ColorSchemeControl));


        /// <summary>
        /// 候选项前的标记符号
        /// </summary>
        public string MarkText
        {
            get { return (string)GetValue(MarkTextProperty); }
            set { SetValue(MarkTextProperty, value); }
        }

        public static readonly DependencyProperty MarkTextProperty =
            DependencyProperty.Register("MarkText", typeof(string), typeof(ColorSchemeControl));



        /// <summary>
        /// 切换 ASCII 模式时，提示跟随鼠标，而非输入光标
        /// </summary>
        public bool AsciiTipFollowCursor
        {
            get { return (bool)GetValue(AsciiTipFollowCursorProperty); }
            set { SetValue(AsciiTipFollowCursorProperty, value); }
        }

        public static readonly DependencyProperty AsciiTipFollowCursorProperty =
            DependencyProperty.Register("AsciiTipFollowCursor", typeof(bool), typeof(ColorSchemeControl));




        /// <summary>
        /// 无法定位候选框时，在窗口左上角显示候选框
        /// </summary>
        public bool EnhancedPosition
        {
            get { return (bool)GetValue(EnhancedPositionProperty); }
            set { SetValue(EnhancedPositionProperty, value); }
        }

        public static readonly DependencyProperty EnhancedPositionProperty =
            DependencyProperty.Register("EnhancedPosition", typeof(bool), typeof(ColorSchemeControl));



        /// <summary>
        /// 托盘显示独立于语言栏的额外图标
        /// </summary>
        public bool DisplayTrayIcon
        {
            get { return (bool)GetValue(DisplayTrayIconProperty); }
            set { SetValue(DisplayTrayIconProperty, value); }
        }

        public static readonly DependencyProperty DisplayTrayIconProperty =
            DependencyProperty.Register("DisplayTrayIcon", typeof(bool), typeof(ColorSchemeControl));



        /// <summary>
        /// antialias_mode (default；force_dword；cleartype；grayscale；aliased)
        /// </summary>
        public string AntialiasMode
        {
            get { return (string)GetValue(AntialiasModeProperty); }
            set { SetValue(AntialiasModeProperty, value); }
        }

        public static readonly DependencyProperty AntialiasModeProperty =
            DependencyProperty.Register("AntialiasMode", typeof(string), typeof(ColorSchemeControl), new  PropertyMetadata("default"));



        /// <summary>
        /// 候选项略写，超过此数字则用省略号代替。设置为 0 则不启用此功能
        /// </summary>
        public string CandidateAbbreviateLength
        {
            get { return (string)GetValue(CandidateAbbreviateLengthProperty); }
            set { SetValue(CandidateAbbreviateLengthProperty, value); }
        }

        public static readonly DependencyProperty CandidateAbbreviateLengthProperty =
            DependencyProperty.Register("CandidateAbbreviateLength", typeof(string), typeof(ColorSchemeControl));


        /// <summary>
        /// 在候选窗口上滑动滚轮的行为：true（翻页）；false（选中下一个候选）
        /// </summary>
        public bool PagingOnScroll
        {
            get { return (bool)GetValue(PagingOnScrollProperty); }
            set { SetValue(PagingOnScrollProperty, value); }
        }

        public static readonly DependencyProperty PagingOnScrollProperty =
            DependencyProperty.Register("PagingOnScroll", typeof(bool), typeof(ColorSchemeControl));



        /// <summary>
        /// 鼠标点击候选项，创建截图
        /// </summary>
        public bool ClickToCapture
        {
            get { return (bool)GetValue(ClickToCaptureProperty); }
            set { SetValue(ClickToCaptureProperty, value); }
        }

        public static readonly DependencyProperty ClickToCaptureProperty =
            DependencyProperty.Register("ClickToCapture", typeof(bool), typeof(ColorSchemeControl));



    }
}