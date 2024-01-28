using Newtonsoft.Json;
using System;
using System.Windows;
using System.Windows.Controls;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.Controls
{
    public partial class ShiciControl : UserControl
    {
        public static readonly DependencyProperty JinriShiciProperty =
            DependencyProperty.Register("JinriShici", typeof(string), typeof(ShiciControl));

        public static readonly DependencyProperty WeatherProperty =
            DependencyProperty.Register("Weather", typeof(string), typeof(ShiciControl));

        public ShiciControl()
        {
            InitializeComponent();
            httpRequestHelper = new HttpRequestHelper();
            GetToken();
            //GetWeather();
            GetJinrishici();
        }

        public string JinriShici
        {
            get { return (string)GetValue(JinriShiciProperty); }
            set { SetValue(JinriShiciProperty, value); }
        }

        public string Token { get; set; }

        public string Weather
        {
            get { return (string)GetValue(WeatherProperty); }
            set { SetValue(WeatherProperty, value); }
        }

        private HttpRequestHelper httpRequestHelper { get; set; }

        private void GetJinrishici()
        {
            if (string.IsNullOrEmpty(Token))
                if (!GetToken()) return;

            try
            {
                string jsonString = httpRequestHelper.HttpGetByHeader("https://v2.jinrishici.com/sentence", Token);
                ShiciContentModel model = JsonConvert.DeserializeObject<ShiciContentModel>(jsonString);

                JinriShici = model.data.content;
            }
            catch (Exception ex)
            {
                JinriShici = ex.Message;
            }
        }

        private bool GetToken()
        {
            try
            {
                string jsonString = httpRequestHelper.HttpGet("https://v2.jinrishici.com/token", "");
                ShiciRootModel model = JsonConvert.DeserializeObject<ShiciRootModel>(jsonString);
                if (model.status == "success")
                {
                    Token = model.data;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        private void GetWeather()
        {
            //if (string.IsNullOrEmpty(Token))
            //    if (!GetToken()) return;

            //string jsonString = httpRequestHelper.HttpGet("https://v2.jinrishici.com/info", $"X-User-Token:{Token}");
            //Root model = JsonConvert.DeserializeObject<Root>(jsonString);

            //Weather = model.data.weatherData.weather;
        }
    }
}