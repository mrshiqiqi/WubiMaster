using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace WubiMaster.Models
{
    public class WeaselColorScheme
    {
        public string author { get; set; }
        public string back_color { get; set; }
        public string border_color { get; set; }
        public string candidate_text_color { get; set; }
        public string comment_text_color { get; set; }
        public string hilited_back_color { get; set; }
        public string hilited_candidate_back_color { get; set; }
        public string hilited_candidate_label_color { get; set; }
        public string hilited_candidate_text_color { get; set; }
        public string hilited_comment_text_color { get; set; }
        public string hilited_label_color { get; set; }
        public string hilited_text_color { get; set; }
        public string label_color { get; set; }
        public string name { get; set; }
        public string text_color { get; set; }
    }

    public class WeaselLayout
    {
        public string border_width { get; set; }
        public string candidate_spacing { get; set; }
        public string hilite_padding { get; set; }
        public string hilite_spacing { get; set; }
        public string margin_x { get; set; }
        public string margin_y { get; set; }
        public string min_height { get; set; }
        public string min_width { get; set; }
        public string round_corner { get; set; }
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
        public string click_to_capture { get; set; }
        public string color_scheme { get; set; }
        public string comment_font_face { get; set; }
        public string comment_font_point { get; set; }
        public string display_tray_icon { get; set; }
        public string enable_mouse { get; set; }
        public string font_face { get; set; }
        public string font_point { get; set; }
        public string fullscreen { get; set; }
        public string horizontal { get; set; }
        public string inline_preedit { get; set; }
        public string label_font_face { get; set; }
        public string label_font_point { get; set; }
        public string label_format { get; set; }
        public WeaselLayout layout { get; set; }
        public string preedit_type { get; set; }
    }
}