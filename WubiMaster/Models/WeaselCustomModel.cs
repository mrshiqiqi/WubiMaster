using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WubiMaster.Models;

namespace WubiMaster.Models
{
    public class WeaselCustomCustomization
    {
        public string distribution_code_name { get; set; }
        public string distribution_version { get; set; }
        public string generator { get; set; }
        public string modified_time { get; set; }
        public string rime_version { get; set; }
    }

    public class WeaselCustomModel
    {
        public WeaselCustomCustomization customization { get; set; }
        public WeaselCustomPatch patch { get; set; }
    }

    public class WeaselCustomPatch
    {
        public string __include { get; set; }
        public WeaselCustomStyle style { get; set; }
    }

    public class WeaselCustomStyle
    {
        public string color_scheme { get; set; }
        public string font_face { get; set; }
    }
}