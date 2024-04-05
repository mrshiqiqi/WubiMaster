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

namespace WubiMaster.Views
{
    /// <summary>
    /// TestView.xaml 的交互逻辑
    /// </summary>
    public partial class TestView : UserControl
    {
        public TestView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string txtSource = this.tbMultiLine1.Text;
            if (txtSource == "") return;

            string[] txtSources = txtSource.Split("\n");
            Dictionary<string, string> colorDict = new Dictionary<string, string>();
            foreach (string s in txtSources)
            {
                var _str = s.Trim();
                if (_str == "") continue;
                string[] _strs = _str.Replace("--", "").Replace("#", "").Replace(";", "").Split(":");
                colorDict.Add(_strs[0], _strs[1]);
            }



            //--primary - 100:#0085ff;
            //--primary - 200:#69b4ff;
            //--primary - 300:#e0ffff;
            //--accent - 100:#006fff;
            //--accent - 200:#e1ffff;
            //--text - 100:#FFFFFF;
            //--text - 200:#9e9e9e;
            //--bg - 100:#1E1E1E;
            //--bg - 200:#2d2d2d;
            //--bg - 300:#454545;


            //back_color: 0xFFFFFF
            //border_color: 0xCCCCCC
            //label_color: 0x5C5C5C
            //text_color: 0x8F3F00
            //hilited_text_color: 0xF5F5F5
            //hilited_back_color: 0xF39621
            //hilited_candidate_text_color: 0xFFFFFF
            //hilited_candidate_back_color: 0xB5513F
            //hilited_label_color: 0xF5F5F5
            //hilited_comment_text_color: 0xF5F5F5
            //candidate_text_color: 0x333333
            //comment_text_color: 0x5C5C5C

            Dictionary<string, string> themeDict = new Dictionary<string, string>();
            themeDict.Add("back_color", ColorConvert(colorDict["bg-100"]));
            themeDict.Add("border_color", ColorConvert(colorDict["bg-300"]));
            themeDict.Add("label_color", ColorConvert(colorDict["text-200"]));
            themeDict.Add("text_color", ColorConvert(colorDict["accent-200"]));
            themeDict.Add("hilited_text_color", ColorConvert(colorDict["bg-200"]));
            themeDict.Add("hilited_back_color", ColorConvert(colorDict["accent-100"]));
            themeDict.Add("hilited_candidate_text_color", ColorConvert(colorDict["bg-100"]));
            themeDict.Add("hilited_candidate_back_color", ColorConvert(colorDict["primary-100"]));
            themeDict.Add("hilited_label_color", ColorConvert(colorDict["bg-200"]));
            themeDict.Add("hilited_comment_text_color", ColorConvert(colorDict["bg-200"]));
            themeDict.Add("candidate_text_color", ColorConvert(colorDict["text-100"]));
            themeDict.Add("comment_text_color", ColorConvert(colorDict["text-200"]));

            string themeStrs = "";
            foreach (var k in themeDict.Keys)
            {
                themeStrs += $"{k}: {themeDict[k]}\n";
            }
            this.tbMultiLine2.Text = themeStrs;
            Console.WriteLine();
        }

        private string ColorConvert(string sourceColor)
        {
            var colorValus = sourceColor.ToCharArray();
            string color = $"{colorValus[4]}{colorValus[5]}{colorValus[2]}{colorValus[3]}{colorValus[0]}{colorValus[1]}";
            return "0x" + color.ToUpper();
        }
    }
}
