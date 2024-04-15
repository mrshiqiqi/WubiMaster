using Newtonsoft.Json;
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
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.Controls
{
    public partial class WeatherControl : UserControl
    {
        private static string BaseUrl = "https://v1.jinrishici.com";
        private static HttpRequestHelper httpRequestHelper = new HttpRequestHelper();
        private static string TargetUrl = "";
        private string uri = "https://api.seniverse.com/v3/weather/now.json?key=S3gp-3yaJby6FUUbR&location=beijing&language=zh-Hans&unit=c";

        public WeatherControl()
        {
            InitializeComponent();
            Test();
        }

        private void Test()
        {
            string jsonString = httpRequestHelper.HttpGet(uri, "");
            WeatherDataModel model = JsonConvert.DeserializeObject<WeatherDataModel>(jsonString);

            Console.WriteLine();
        }
    }
}