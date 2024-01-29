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

        public static readonly DependencyProperty ShiciTitleProperty =
            DependencyProperty.Register("ShiciTitle", typeof(string), typeof(ShiciControl));

        public static readonly DependencyProperty Tag1Property =
                    DependencyProperty.Register("Tag1", typeof(string), typeof(ShiciControl));

        public static readonly DependencyProperty Tag2Property =
            DependencyProperty.Register("Tag2", typeof(string), typeof(ShiciControl));

        public static readonly DependencyProperty Tag3Property =
            DependencyProperty.Register("Tag3", typeof(string), typeof(ShiciControl));

        public ShiciControl()
        {
            InitializeComponent();
            InitImages();
            ShiciImage = ChangeImage();
            GetJinrishici();
        }



        public string ShiciAuthor
        {
            get { return (string)GetValue(ShiciAuthorProperty); }
            set { SetValue(ShiciAuthorProperty, value); }
        }

        public static readonly DependencyProperty ShiciAuthorProperty =
            DependencyProperty.Register("ShiciAuthor", typeof(string), typeof(ShiciControl));



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

        public string ShiciTitle
        {
            get { return (string)GetValue(ShiciTitleProperty); }
            set { SetValue(ShiciTitleProperty, value); }
        }

        public string Tag1
        {
            get { return (string)GetValue(Tag1Property); }
            set { SetValue(Tag1Property, value); }
        }

        public string Tag2
        {
            get { return (string)GetValue(Tag2Property); }
            set { SetValue(Tag2Property, value); }
        }

        public string Tag3
        {
            get { return (string)GetValue(Tag3Property); }
            set { SetValue(Tag3Property, value); }
        }

        public string Token { get; set; }

        private HttpRequestHelper httpRequestHelper { get; set; }

        private ImageSource ChangeImage()
        {
            Random random = new Random();
            int index = random.Next(0, Images.Count);
            return Images[index];
        }

        private void GetJinrishici()
        {
            try
            {
                DateTime todayTime = DateTime.Now;// Convert.ToDateTime("2024/02/24");
                ShiciType type = ShiciType.Defualt;
                string tag = "";

                string jieriToday = NongliHelper.GetChinaHoliday(todayTime);
                string jieqiLast = NongliHelper.GetSolarTermLast(todayTime);
                string jijieToday = NongliHelper.GetJijie(todayTime);
                string monthToday = NongliHelper.GetMonth(todayTime);
                string dayToday = NongliHelper.GetDay(todayTime);
                tag = jijieToday;

                if (!string.IsNullOrEmpty(jieriToday))
                {
                    tag = jieriToday;
                    switch (jieriToday)
                    {
                        case "春节":
                            type = ShiciType.Chunjie;
                            break;

                        case "元宵节":
                            type = ShiciType.Yuanxiaojie;
                            break;

                        case "寒食节":
                            type = ShiciType.Hanshijie;
                            break;

                        case "清明节":
                            type = ShiciType.Qingmingjie;
                            break;

                        case "端午节":
                            type = ShiciType.Duanwujie;
                            break;

                        case "七夕节":
                            type = ShiciType.Qixijie;
                            break;

                        case "中秋节":
                            type = ShiciType.Zhongqiujie;
                            break;

                        case "重阳节":
                            type = ShiciType.Chongyangjie;
                            break;

                        default:
                            type = ShiciType.Defualt;
                            break;
                    }
                }
                else
                {
                    Random random = new Random();
                    int value = random.Next(0, 3);
                    if (value % 2 == 0)
                    {
                        type = ShiciType.Defualt;
                    }
                    else
                    {
                        switch (jijieToday)
                        {
                            case "春":
                                type = ShiciType.Chun;
                                break;

                            case "夏":
                                type = ShiciType.Xia;
                                break;

                            case "秋":
                                type = ShiciType.Qiu;
                                break;

                            case "冬":
                                type = ShiciType.Dong;
                                break;

                            default:
                                type = ShiciType.Defualt;
                                break;
                        }
                    }
                }

                ShiciContentModel model = ShiciHelper.GetShiciByType(type);

                JinriShici = model.content;
                ShiciTitle = model.origin; //model.origin + "·" + model.author;
                ShiciAuthor = model.author;
                Tag1 = tag;
                Tag2 = monthToday;
                Tag3 = dayToday;
            }
            catch (Exception ex)
            {
                JinriShici = "明月几时有，把酒问青天。";
                ShiciTitle = "水调歌头·苏轼";
                Tag1 = "酒";
                Tag2 = "夜";
                Tag3 = "明月";
            }
        }

        //private bool GetToken()
        //{
        //    try
        //    {
        //        string jsonString = httpRequestHelper.HttpGet("https://v2.jinrishici.com/token", "");
        //        ShiciRootModel model = JsonConvert.DeserializeObject<ShiciRootModel>(jsonString);
        //        if (model.status == "success")
        //        {
        //            Token = model.data;
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    return false;
        //}

        //private void GetWeather()
        //{
        //    try
        //    {
        //        string jsonString = httpRequestHelper.HttpGet("https://v2.jinrishici.com/info", "");
        //        ShiciWeatherModel model = JsonConvert.DeserializeObject<ShiciWeatherModel>(jsonString);

        //        Tag1 = model.data.tags[0];
        //        Tag2 = model.data.tags[^3];
        //        Tag3 = model.data.tags[^1];
        //    }
        //    catch (Exception)
        //    {
        //        Tag1 = "酒";
        //        Tag2 = "夜";
        //        Tag3 = "明月";
        //    }

        //}

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