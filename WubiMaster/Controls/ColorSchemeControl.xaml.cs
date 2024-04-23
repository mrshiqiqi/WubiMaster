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
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.Controls
{
    public partial class ColorSchemeControl : UserControl
    {
        public static readonly DependencyProperty AuthorProperty =
            DependencyProperty.Register("Author", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CandidateBackColorProperty =
            DependencyProperty.Register("CandidateBackColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CandidateBorderColorProperty =
            DependencyProperty.Register("CandidateBorderColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CandidateShadowColorProperty =
                    DependencyProperty.Register("CandidateShadowColor", typeof(Color), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CandidateTextColorProperty =
                            DependencyProperty.Register("CandidateTextColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty ColorFormatProperty =
                                    DependencyProperty.Register("ColorFormat", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty ColorNameProperty =
                    DependencyProperty.Register("ColorName", typeof(string), typeof(ColorSchemeControl));

        public static readonly DependencyProperty CommentTextColorProperty =
            DependencyProperty.Register("CommentTextColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedBackColorProperty =
            DependencyProperty.Register("HilitedBackColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateBackColorProperty =
            DependencyProperty.Register("HilitedCandidateBackColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateBorderColorProperty =
            DependencyProperty.Register("HilitedCandidateBorderColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateShadowColorProperty =
                    DependencyProperty.Register("HilitedCandidateShadowColor", typeof(Color), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCandidateTextColorProperty =
                            DependencyProperty.Register("HilitedCandidateTextColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedCommentTextColorProperty =
            DependencyProperty.Register("HilitedCommentTextColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedLabelColorProperty =
                    DependencyProperty.Register("HilitedLabelColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedMarkColorProperty =
            DependencyProperty.Register("HilitedMarkColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedShadowColorProperty =
                                    DependencyProperty.Register("HilitedShadowColor", typeof(Color), typeof(ColorSchemeControl));

        public static readonly DependencyProperty HilitedTextColorProperty =
                            DependencyProperty.Register("HilitedTextColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty LabelColorProperty =
                    DependencyProperty.Register("LabelColor", typeof(Brush), typeof(ColorSchemeControl));

        public static readonly DependencyProperty NextPageColorProperty =
            DependencyProperty.Register("NextPageColor", typeof(string), typeof(ColorSchemeControl), new PropertyMetadata("#00000000"));

        public static readonly DependencyProperty PrevpageColorProperty =
            DependencyProperty.Register("PrevpageColor", typeof(string), typeof(ColorSchemeControl), new PropertyMetadata("#00000000"));

        public static readonly DependencyProperty ShadowColorProperty =
                            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(ColorSchemeControl));


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
        public Brush BackColor
        {
            get { return (Brush)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }

        /// <summary>
        /// 候选窗边框颜色
        /// </summary>
        public Brush BorderColor
        {
            get { return (Brush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// 非高亮候选背景颜色
        /// </summary>
        public Brush CandidateBackColor
        {
            get { return (Brush)GetValue(CandidateBackColorProperty); }
            set { SetValue(CandidateBackColorProperty, value); }
        }

        /// <summary>
        /// 非高亮候选的边框颜色
        /// </summary>
        public Brush CandidateBorderColor
        {
            get { return (Brush)GetValue(CandidateBorderColorProperty); }
            set { SetValue(CandidateBorderColorProperty, value); }
        }

        /// <summary>
        /// 非高亮候选背景块阴影颜色
        /// </summary>
        public Color CandidateShadowColor
        {
            get { return (Color)GetValue(CandidateShadowColorProperty); }
            set { SetValue(CandidateShadowColorProperty, value); }
        }

        /// <summary>
        /// 非高亮候选文字颜色
        /// </summary>
        public Brush CandidateTextColor
        {
            get { return (Brush)GetValue(CandidateTextColorProperty); }
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
        public Brush CommentTextColor
        {
            get { return (Brush)GetValue(CommentTextColorProperty); }
            set { SetValue(CommentTextColorProperty, value); }
        }

        /// <summary>
        /// 编码背景颜色
        /// </summary>
        public Brush HilitedBackColor
        {
            get { return (Brush)GetValue(HilitedBackColorProperty); }
            set { SetValue(HilitedBackColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选背景颜色
        /// </summary>
        public Brush HilitedCandidateBackColor
        {
            get { return (Brush)GetValue(HilitedCandidateBackColorProperty); }
            set { SetValue(HilitedCandidateBackColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选边框颜色
        /// </summary>
        public Brush HilitedCandidateBorderColor
        {
            get { return (Brush)GetValue(HilitedCandidateBorderColorProperty); }
            set { SetValue(HilitedCandidateBorderColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选背景块阴影颜色
        /// </summary>
        public Color HilitedCandidateShadowColor
        {
            get { return (Color)GetValue(HilitedCandidateShadowColorProperty); }
            set { SetValue(HilitedCandidateShadowColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选文字颜色
        /// </summary>
        public Brush HilitedCandidateTextColor
        {
            get { return (Brush)GetValue(HilitedCandidateTextColorProperty); }
            set { SetValue(HilitedCandidateTextColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选的注释颜色
        /// </summary>
        public Brush HilitedCommentTextColor
        {
            get { return (Brush)GetValue(HilitedCommentTextColorProperty); }
            set { SetValue(HilitedCommentTextColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选的标签颜色
        /// </summary>
        public Brush HilitedLabelColor
        {
            get { return (Brush)GetValue(HilitedLabelColorProperty); }
            set { SetValue(HilitedLabelColorProperty, value); }
        }

        /// <summary>
        /// 高亮候选前的标记颜色
        /// </summary>
        public Brush HilitedMarkColor
        {
            get { return (Brush)GetValue(HilitedMarkColorProperty); }
            set { SetValue(HilitedMarkColorProperty, value); }
        }

        /// <summary>
        /// 编码背景块阴影颜色
        /// </summary>
        public Color HilitedShadowColor
        {
            get { return (Color)GetValue(HilitedShadowColorProperty); }
            set { SetValue(HilitedShadowColorProperty, value); }
        }

        /// <summary>
        /// 编码文字颜色
        /// </summary>
        public Brush HilitedTextColor
        {
            get { return (Brush)GetValue(HilitedTextColorProperty); }
            set { SetValue(HilitedTextColorProperty, value); }
        }

        /// <summary>
        /// 标签文字颜色
        /// </summary>
        public Brush LabelColor
        {
            get { return (Brush)GetValue(LabelColorProperty); }
            set { SetValue(LabelColorProperty, value); }
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
        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        /// <summary>
        /// 默认文字颜色
        /// </summary>
        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(ColorSchemeControl));



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
        public FontFamily FontFace
        {
            get { return (FontFamily)GetValue(FontFaceProperty); }
            set { SetValue(FontFaceProperty, value); }
        }

        public static readonly DependencyProperty FontFaceProperty =
            DependencyProperty.Register("FontFace", typeof(FontFamily), typeof(ColorSchemeControl));



        /// <summary>
        /// 标签字体
        /// </summary>
        public FontFamily LabelFontFace
        {
            get { return (FontFamily)GetValue(LabelFontFaceProperty); }
            set { SetValue(LabelFontFaceProperty, value); }
        }

        public static readonly DependencyProperty LabelFontFaceProperty =
            DependencyProperty.Register("LabelFontFace", typeof(FontFamily), typeof(ColorSchemeControl));


        /// <summary>
        ///  注释字体
        /// </summary>
        public FontFamily CommentFontFace
        {
            get { return (FontFamily)GetValue(CommentFontFaceProperty); }
            set { SetValue(CommentFontFaceProperty, value); }
        }

        public static readonly DependencyProperty CommentFontFaceProperty =
            DependencyProperty.Register("CommentFontFace", typeof(FontFamily), typeof(ColorSchemeControl));


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
            DependencyProperty.Register("AntialiasMode", typeof(string), typeof(ColorSchemeControl), new PropertyMetadata("default"));



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



        /// <summary>
        /// 外观Model
        /// </summary>
        public ColorSchemeModel ColorModel
        {
            get { return (ColorSchemeModel)GetValue(ColorModelProperty); }
            set { SetValue(ColorModelProperty, value); }
        }

        public static readonly DependencyProperty ColorModelProperty =
            DependencyProperty.Register("ColorModel", typeof(ColorSchemeModel), typeof(ColorSchemeControl), new PropertyMetadata(new PropertyChangedCallback(OnColorChanged)));

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorSchemeControl c = (ColorSchemeControl)d;
            c.ColorModel = e.NewValue as ColorSchemeModel;

            ColorStyle styleModel = c.ColorModel.Style;
            ColorScheme schemeModel = c.ColorModel.UsedColor;
            string color_format = schemeModel.color_format;

            // 公共
            c.TextColor = c.BrushConvter(schemeModel.text_color, colorFormat: color_format);
            c.FontPoint = double.Parse(styleModel.font_point);
            c.LabelFontPoint = string.IsNullOrEmpty(styleModel.label_font_point) ? c.FontPoint : double.Parse(styleModel.label_font_point);
            c.LabelColor = c.BrushConvter(schemeModel.label_color, schemeModel.text_color, colorFormat: color_format);
            c.CommentFontPoint = string.IsNullOrEmpty(styleModel.comment_font_point) ? c.FontPoint : double.Parse(styleModel.comment_font_point);
            c.FontFace = new FontFamily(styleModel.font_face);
            c.LabelFontFace = string.IsNullOrEmpty(styleModel.label_font_face) ? c.FontFace : new FontFamily(styleModel.label_font_face);
            c.CommentFontFace = string.IsNullOrEmpty(styleModel.comment_font_face) ? c.FontFace : new FontFamily(styleModel.comment_font_face);
            c.CommentTextColor = c.BrushConvter(schemeModel.comment_text_color, schemeModel.text_color, colorFormat: color_format);

            // 边框/候选窗口
            c.BackColor = c.BrushConvter(schemeModel.back_color, colorFormat: color_format);
            c.BorderColor = c.BrushConvter(schemeModel.border_color, colorFormat: color_format);
            c.BorderWidth = double.Parse(styleModel.layout.border_width);
            c.CornerRadius = double.Parse(styleModel.layout.corner_radius);
            c.ShadowColor = c.ColorConvter(schemeModel.shadow_color, colorFormat: color_format);

            // 编码区
            c.HilitedTextColor = c.BrushConvter(schemeModel.hilited_text_color, schemeModel.text_color, colorFormat: color_format);
            c.HilitedBackColor = c.BrushConvter(schemeModel.hilited_back_color, schemeModel.back_color, colorFormat: color_format);
            c.HilitedShadowColor = c.ColorConvter(schemeModel.hilited_shadow_color, colorFormat: color_format);

            // 高亮候选
            c.HilitedCandidateBackColor = c.BrushConvter(schemeModel.hilited_candidate_back_color, schemeModel.back_color, colorFormat: color_format);
            c.HilitedCandidateTextColor = c.BrushConvter(schemeModel.hilited_candidate_text_color, schemeModel.text_color, colorFormat: color_format);
            c.HilitedCandidateBorderColor = c.BrushConvter(schemeModel.hilited_candidate_border_color, schemeModel.hilited_candidate_back_color, colorFormat: color_format);
            c.RoundCorner = c.CornerRadius;
            c.HilitedLabelColor = c.BrushConvter(schemeModel.hilited_label_color, schemeModel.text_color, colorFormat: color_format);
            c.MarkText = styleModel.mark_text;
            c.HilitedMarkColor = c.BrushConvter(schemeModel.hilited_mark_color, schemeModel.text_color, colorFormat: color_format);
            c.HilitedCandidateShadowColor = c.ColorConvter(schemeModel.hilited_candidate_shadow_color, colorFormat: color_format);
            c.HilitedCommentTextColor = c.BrushConvter(schemeModel.hilited_comment_text_color, schemeModel.text_color, colorFormat: color_format);

            // 非高亮区
            c.CandidateTextColor = c.BrushConvter(schemeModel.candidate_text_color, schemeModel.text_color, colorFormat: color_format);
            c.CandidateBackColor = c.BrushConvter(schemeModel.candidate_back_color, schemeModel.back_color, colorFormat: color_format);
            c.CandidateShadowColor = c.ColorConvter(schemeModel.candidate_shadow_color, colorFormat: color_format);
            c.CandidateBorderColor = c.BrushConvter(schemeModel.candidate_border_color, schemeModel.back_color, colorFormat: color_format);

            // 布局控件
            c.HilitePadding = double.Parse(styleModel.layout.hilite_padding) - (c.BorderWidth * 2);
            c.HiliteSpacing = double.Parse(styleModel.layout.hilite_spacing);  // rime中不生效
            c.MarginX = double.Parse(styleModel.layout.margin_x) - (c.BorderWidth * 2);
            c.MarginY = double.Parse(styleModel.layout.margin_y) - (c.BorderWidth * 2);
            c.BorderPadding = new Thickness(c.MarginX, c.MarginY, c.MarginX, c.MarginY);
            c.Spacing = double.Parse(styleModel.layout.spacing) - (c.BorderWidth * 2);
            c.SpacingMargin = new Thickness(0, 0, 0, c.Spacing);
            c.CandidateSpacing = double.Parse(styleModel.layout.candidate_spacing) - (c.BorderWidth * 4);
            c.CandidateMargin = new Thickness(0, 0, 0, c.CandidateSpacing);
            // 阴影
            //c.BorderWidth = double.Parse(styleModel.layout.border_width);

            Console.WriteLine();
        }


        /// <summary>
        /// 编码区与候选项的距离
        /// </summary>
        public Thickness SpacingMargin
        {
            get { return (Thickness)GetValue(SpacingMarginProperty); }
            set { SetValue(SpacingMarginProperty, value); }
        }

        public static readonly DependencyProperty SpacingMarginProperty =
            DependencyProperty.Register("SpacingMargin", typeof(Thickness), typeof(ColorSchemeControl));



        /// <summary>
        /// 候选项间的距离
        /// </summary>
        public Thickness CandidateMargin
        {
            get { return (Thickness)GetValue(CandidateMarginProperty); }
            set { SetValue(CandidateMarginProperty, value); }
        }

        public static readonly DependencyProperty CandidateMarginProperty =
            DependencyProperty.Register("CandidateMargin", typeof(Thickness), typeof(ColorSchemeControl));



        /// <summary>
        /// 边框与主体间的内边距
        /// </summary>
        public Thickness BorderPadding
        {
            get { return (Thickness)GetValue(BorderPaddingProperty); }
            set { SetValue(BorderPaddingProperty, value); }
        }

        public static readonly DependencyProperty BorderPaddingProperty =
            DependencyProperty.Register("BorderPadding", typeof(Thickness), typeof(ColorSchemeControl));



        private Brush BrushConvter(string colorTxt, string defaultColor = "0x00000000", string colorFormat = "abgr")
        {
            Color targetColor = ColorConvter(colorTxt, defaultColor, colorFormat);
            SolidColorBrush targetBrush = new SolidColorBrush(targetColor);
            return targetBrush;
        }

        private Color ColorConvter(string colorTxt, string defaultColor = "0x00000000", string colorFormat = "abgr")
        {
            try
            {
                if (string.IsNullOrEmpty(colorTxt))
                    colorTxt = defaultColor;

                string colorStr = "";
                Color targetColor = Colors.Black;
                char[] _cArray = null;

                switch (colorFormat)
                {
                    case "argb":
                        string _color1 = colorTxt.Substring(2, colorTxt.Length - 2);
                        if (_color1.Length <= 6) _color1 = "FF" + _color1;
                        _cArray = _color1.ToArray();
                        colorStr = "#" + _cArray.ToString();
                        targetColor = (Color)ColorConverter.ConvertFromString(colorStr);
                        break;

                    case "rgba":
                        string _color2 = colorTxt.Substring(2, colorTxt.Length - 2);
                        if (_color2.Length <= 6) _color2 = _color2 + "FF";
                        _cArray = _color2.ToArray();
                        colorStr = "#" + $"{_cArray[6]}{_cArray[7]}{_cArray[0]}{_cArray[1]}{_cArray[2]}{_cArray[3]}{_cArray[4]}{_cArray[5]}";
                        targetColor = (Color)ColorConverter.ConvertFromString(colorStr);
                        break;

                    default:
                        // 默认是 abgr
                        string _color3 = colorTxt.Substring(2, colorTxt.Length - 2);
                        if (_color3.Length <= 6) _color3 = "FF" + _color3;
                        _cArray = _color3.ToArray();
                        colorStr = "#" + $"{_cArray[0]}{_cArray[1]}{_cArray[6]}{_cArray[7]}{_cArray[4]}{_cArray[5]}{_cArray[2]}{_cArray[3]}";
                        targetColor = (Color)ColorConverter.ConvertFromString(colorStr);
                        break;
                }

                return targetColor;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                return Colors.Black;
            }
        }
    }
}