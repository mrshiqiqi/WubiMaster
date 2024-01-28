using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.Controls
{
    public partial class ShiciControl : UserControl
    {
        public static readonly DependencyProperty JinriShiciProperty =
            DependencyProperty.Register("JinriShici", typeof(string), typeof(ShiciControl));

        public static readonly DependencyProperty ShiciImageProperty =
            DependencyProperty.Register("ShiciImage", typeof(ImageSource), typeof(ShiciControl));

        public static readonly DependencyProperty WeatherProperty =
                    DependencyProperty.Register("Weather", typeof(string), typeof(ShiciControl));

        public ShiciControl()
        {
            InitializeComponent();
            httpRequestHelper = new HttpRequestHelper();
            InitImages();
            GetToken();
            //GetWeather();
            GetJinrishici();

            ShiciImage = ChangeImage();
        }

        public List<ImageSource> Images { get; set; }

        public string JinriShici
        {
            get { return (string)GetValue(JinriShiciProperty); }
            set { SetValue(JinriShiciProperty, value); }
        }

        public ImageSource ShiciImage
        {
            get { return (ImageSource)GetValue(ShiciImageProperty); }
            set { SetValue(ShiciImageProperty, value); }
        }

        public string Token { get; set; }

        public string Weather
        {
            get { return (string)GetValue(WeatherProperty); }
            set { SetValue(WeatherProperty, value); }
        }

        private HttpRequestHelper httpRequestHelper { get; set; }

        private ImageSource ChangeImage()
        {
            Random random = new Random();
            int index = random.Next(0, Images.Count);
            return Images[index];
        }

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

        private void InitImages()
        {
            Images = new List<ImageSource>();
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/侧脸.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/侧身微笑.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/低头.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/低头的人.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/翘二郎腿的女人.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/青花瓷少女.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/青花瓷衣服.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/手托头.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/思考.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/长发女人.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/正面.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/坐椅子的女人.png", UriKind.Relative)));
            Images.Add(new BitmapImage(new Uri("../Images/JinriShici/坐着的女人.png", UriKind.Relative)));
        }
    }
}