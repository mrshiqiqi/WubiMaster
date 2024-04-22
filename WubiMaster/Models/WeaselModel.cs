using log4net.Layout;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace WubiMaster.Models
{
    public class WeaselColorScheme
    {
        public string author { get; set; }
        public string back_color { get; set; }
        public string border_color { get; set; }
        public string candidate_back_color { get; set; }
        public string candidate_border_color { get; set; }
        public string candidate_shadow_color { get; set; }
        public string candidate_text_color { get; set; }
        public string color_format { get; set; }
        public string comment_text_color { get; set; }
        public string hilited_back_color { get; set; }
        public string hilited_candidate_back_color { get; set; }
        public string hilited_candidate_border_color { get; set; }
        public string hilited_candidate_shadow_color { get; set; }
        public string hilited_candidate_text_color { get; set; }
        public string hilited_comment_text_color { get; set; }
        public string hilited_label_color { get; set; }
        public string hilited_mark_color { get; set; }
        public string hilited_shadow_color { get; set; }
        public string hilited_text_color { get; set; }
        public string label_color { get; set; }
        public string name { get; set; }
        public string nextpage_color { get; set; }
        public string prevpage_color { get; set; }
        public string shadow_color { get; set; }
        public string text_color { get; set; }
    }

    public class WeaselLayout
    {
        public string align_type { get; set; }
        public string border_width { get; set; }
        public string candidate_spacing { get; set; }
        public string corner_radius { get; set; }
        public string hilite_padding { get; set; }
        public string hilite_spacing { get; set; }
        public string margin_x { get; set; }
        public string margin_y { get; set; }
        public string max_height { get; set; }
        public string max_width { get; set; }
        public string min_height { get; set; }
        public string min_width { get; set; }
        public string round_corner { get; set; }
        public string shadow_offset_x { get; set; }
        public string shadow_offset_y { get; set; }
        public string shadow_radius { get; set; }
        public string spacing { get; set; }
    }

    public class WeaselModel
    {
        [YamlMember(Alias = "config_version")]
        public string ConfigVersion { get; set; }

        [YamlMember(Alias = "preset_color_schemes")]
        public Dictionary<string, WeaselColorScheme> preset_color_schemes { get; set; }

        [YamlMember(Alias = "style")]
        public WeaselStyle style { get; set; }
    }

    public class WeaselStyle
    {
        public string antialias_mode { get; set; }
        public string ascii_tip_follow_cursor { get; set; }
        public string candidate_abbreviate_length { get; set; }
        public string click_to_capture { get; set; }
        public string color_scheme { get; set; }
        public string color_theme_dark { get; set; }
        public string comment_font_face { get; set; }
        public string comment_font_point { get; set; }
        public string display_tray_icon { get; set; }
        public string enable_mouse { get; set; }
        public string enhanced_position { get; set; }
        public string font_face { get; set; }
        public string font_point { get; set; }
        public string fullscreen { get; set; }
        public string horizontal { get; set; }
        public string inline_preedit { get; set; }
        public string label_font_face { get; set; }
        public string label_font_point { get; set; }
        public string label_format { get; set; }
        public WeaselLayout layout { get; set; }
        public string mark_text { get; set; }
        public string mouse_hover_ms { get; set; }
        public string paging_on_scroll { get; set; }
        public string preedit_type { get; set; }
        public string vertical_auto_reverse { get; set; }
        public string vertical_text { get; set; }
        public string vertical_text_left_to_right { get; set; }
        public string vertical_text_with_wrap { get; set; }
    }

    /**
    ### 样式
    style:
        # ...样式...
        color_scheme: ink  # 配色方案
        color_theme_dark: pizza_hub  # 设置系统为深色模式时的配色方案
        # ...字体...
        font_face: 微软雅黑  # 全局字体
        label_font_face: 微软雅黑  # 标签字体
        comment_font_face: 黑体字根  # 注释字体
        font_point: 15  # 全局字号
        label_font_point: 12  # 标签字号
        comment_font_point: 12  # 注释字号
        # ... 窗口...
        fullscreen: false  # 是否全屏模式
        horizontal: false  # 是否横向布局
        vertical_text: true  # 是否启用竖排文本
        # text_orientation: horizontal
        vertical_text_left_to_right: true  # 竖排方向是否从左到右
        vertical_text_with_wrap: false  # 文本竖排模式下是否自动换行
        vertical_auto_reverse: false  # 文本竖排模式下，候选窗口位于光标上方时倒序排序
        # ...预编辑区...
        inline_preedit: true  # 是否在行内显示预编辑区
        preedit_type: preview  # 预编辑区显示内容 composition（编码）；preview（高亮候选）；preview_all（全部候选）
        # ...其他选项...
        label_format: "%s."  # 标签字符号
        mark_text: ""  # 候选项前的标记符号？？？？？？？？？？？？
        ascii_tip_follow_cursor: false  # 切换 ASCII 模式时，提示跟随鼠标，而非输入光标？？？？？？？？？？？
        enhanced_position: false  # 无法定位候选框时，在窗口左上角显示候选框
        display_tray_icon: true  # 托盘显示独立于语言栏的额外图标
        antialias_mode: default  # antialias_mode (default；force_dword；cleartype；grayscale；aliased)
        candidate_abbreviate_length: 10  # 候选项略写，超过此数字则用省略号代替。设置为 0 则不启用此功能
        # mouse_hover_ms: 1000  # 鼠标悬停选词响应时间（ms），设置为 0 时禁用该功能(已经不再生效)
        paging_on_scroll: false  # 在候选窗口上滑动滚轮的行为：true（翻页）；false（选中下一个候选） ？？
        click_to_capture: true  # 鼠标点击候选项，创建截图
        # enable_mouse: true  # 是否启动鼠标双击截图功能（已经不再生效）
        ### 布局
        layout:
            align_type: center  # 标签、候选文字、注解文字之间的相对对齐方式 (top ; center ; bottom)
            max_height: 0  # 候选框最大高度，0 不启用此功能
            max_width: 0  # 候选框最大宽度，0 不启用此功能
            min_height: 0  # 候选框最小高度
            min_width: 80  # 候选框最小宽度
            # type: horizontal  # 布局类型；功能近似 style 下的窗口控制选项 (horizontal（横向）；vertical（竖直）; vertical_text（文本竖直）; vertical+fullscreen（竖向全屏）; horizontal+fullscreen（横向全拼）)
            border_width: 2  # 边框宽度
            margin_x: 0  # 主体元素和候选框的左右、上下边距，为负值时，不显示候选框
            margin_y: 0  # 主体元素和候选框的左右、上下边距，为负值时，不显示候选框
            spacing: 5  # inline_preedit 为 false 时，编码区域和候选区域的间距
            candidate_spacing: 5  # 候选项之间的间距
            hilite_spacing: 8  # 候选项和相应标签的间距，候选项与注解文字之间的距离
            hilite_padding: 5 # 高亮区域和内部文字的间距，影响高亮区域大小
            # hilite_padding_x: 0  # 高亮区域和内部文字的左右、上下间距，如无特殊指定则依 hilite_padding 设置
            # hilite_padding_y: 0  # 高亮区域和内部文字的左右、上下间距，如无特殊指定则依 hilite_padding 设置
            shadow_radius: 5  # 阴影区域半径，为 0 不显示阴影；需要同时在配色方案中指定非透明的阴影颜色
            shadow_offset_x: 5  # 阴影绘制的偏离距离
            shadow_offset_y: 5  # 阴影绘制的偏离距离
            corner_radius: 5  # 候选窗口圆角半径
            round_corner: 5  # 候选背景色块圆角半径，别名 hilited_corner_radius
     * **/
}