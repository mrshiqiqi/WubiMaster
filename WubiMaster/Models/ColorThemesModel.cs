using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace WubiMaster.Models
{
    public class ColorThemesModel
    {
        public Dictionary<string, ColorTheme> color_themes { get; set; }
    }

    public class ColorTheme
    {
        public string name { get; set; }
        public string template { get; set; }
        public ColorStyle style { get; set; }
        public ColorScheme color_scheme { get; set; }
    }
}
