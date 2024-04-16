using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WubiMaster.Models
{
    //var person = new Person
    //{
    //    Name = "Abe Lincoln",
    //    Age = 25,
    //    HeightInInches = 6f + 4f / 12f,
    //    Addresses = new Dictionary<string, Address>{
    //    { "home", new  Address() {
    //            Street = "2720  Sundown Lane",
    //            City = "Kentucketsville",
    //            State = "Calousiyorkida",
    //            Zip = "99978",
    //        }},
    //    { "work", new  Address() {
    //            Street = "1600 Pennsylvania Avenue NW",
    //            City = "Washington",
    //            State = "District of Columbia",
    //            Zip = "20500",
    //        }},
    //}
    //};

    public class Layout
    {
        /// <summary>
        ///
        /// </summary>
        public string border_width { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string candidate_spacing { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string hilite_padding { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string hilite_spacing { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string margin_x { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string margin_y { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string min_height { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string min_width { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string round_corner { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string spacing { get; set; }
    }

    public class Preset_color_schemes
    {
        /// <summary>
        ///
        /// </summary>
        public Dictionary<string, ThemeDetail> ThemeDetailDict { get; set; }
    }

    public class RimeThemeModel
    {
    }

    public class Root
    {
        /// <summary>
        ///
        /// </summary>
        public string config_version { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Preset_color_schemes preset_color_schemes { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Style style { get; set; }
    }

    public class Style
    {
        /// <summary>
        ///
        /// </summary>
        public string click_to_capture { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string color_scheme { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string display_tray_icon { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string enable_mouse { get; set; }

        /// <summary>
        /// 黑体字根
        /// </summary>
        public string font_face { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string font_point { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string fullscreen { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string horizontal { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string inline_preedit { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string label_format { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Layout layout { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string preedit_type { get; set; }
    }

    public class ThemeDetail
    {
        /// <summary>
        /// 空山明月
        /// </summary>
        public string author { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string back_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string border_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string candidate_text_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string comment_text_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string hilited_back_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string hilited_candidate_back_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string hilited_candidate_text_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string hilited_comment_text_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string hilited_label_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string hilited_text_color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string label_color { get; set; }

        /// <summary>
        /// 86默认／default_86
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string text_color { get; set; }
    }
}