using log4net.Layout;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace WubiMaster.Models
{
    public class ColorScheme
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

    public class ColorLayout
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

    public class ColorModel
    {
        [YamlMember(Alias = "config_version")]
        public string ConfigVersion { get; set; }

        [YamlMember(Alias = "preset_color_schemes")]
        public Dictionary<string, ColorScheme> preset_color_schemes { get; set; }

        [YamlMember(Alias = "style")]
        public ColorStyle style { get; set; }
    }

    public class ColorStyle
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
        public ColorLayout layout { get; set; }
        public string mark_text { get; set; }
        public string mouse_hover_ms { get; set; }
        public string paging_on_scroll { get; set; }
        public string preedit_type { get; set; }
        public string vertical_auto_reverse { get; set; }
        public string vertical_text { get; set; }
        public string vertical_text_left_to_right { get; set; }
        public string vertical_text_with_wrap { get; set; }
    }
}