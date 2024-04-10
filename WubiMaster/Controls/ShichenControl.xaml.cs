using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WubiMaster.Common;

namespace WubiMaster.Controls
{
    public partial class ShichenControl : UserControl
    {
        public static readonly DependencyProperty ShichenTextProperty =
            DependencyProperty.Register("ShichenText", typeof(string), typeof(ShichenControl), new PropertyMetadata(""));

        private double angle = 360;

        private DateTime CurrTime = DateTime.Now;

        private double last_angle;

        private Dictionary<int, string> shichenDict;

        private string[] ShichenStrs = new string[]
                                                                                                {
            "子","丑","寅","卯",
            "辰","巳","午","未",
            "申","酉","戌","亥",
        };

        private DispatcherTimer timer = new DispatcherTimer();

        public ShichenControl()
        {
            InitializeComponent();

            shichenDict = new Dictionary<int, string>();
            timer.Interval = TimeSpan.FromMilliseconds(1000*5);
            timer.Tick += Timer_Tick;

            InitShichenDict();
            StartMinutesAnimation();

            timer.Start();
        }

        public string ShichenText
        {
            get { return (string)GetValue(ShichenTextProperty); }
            set { SetValue(ShichenTextProperty, value); }
        }

        private void ChangeShichenText()
        {
            var hour = CurrTime.Hour;
            ShichenText = shichenDict[hour] + "时";
        }

        // 计时器
        /// <summary>
        /// 将角度转为弧度
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        private double ConvertDegreesToRadians(double degrees)
        {
            double radians = (Math.PI / 180) * degrees;

            return radians;
        }

        /// <summary>
        /// 画时针圆
        /// </summary>
        private void DrawHour()
        {
            try
            {
                int hour = CurrTime.Hour;
                int minu = CurrTime.Minute;
                double dminu = minu / 60.0; // 根据分钟数增加时针偏移
                double dhour = hour + dminu;

                double hour_angle = WrapAngle(dhour * (360.0 / 12.0));

                RotateTransform rtf1 = new RotateTransform();
                HourGrid.RenderTransform = rtf1;
                DoubleAnimation dbAscending1 = new DoubleAnimation(last_angle, hour_angle, new Duration(TimeSpan.FromSeconds(0.5)));
                dbAscending1.RepeatBehavior = RepeatBehavior.Forever;
                rtf1.BeginAnimation(RotateTransform.AngleProperty, dbAscending1);
                last_angle = hour_angle;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

        private void InitShichenDict()
        {
            for (int i = 0; i < 24; i++)
            {
                if (i == 0 || i == 23)
                {
                    shichenDict.Add(i, ShichenStrs[0]);
                    continue;
                }

                int shichenIndex = (i / 2) + (i % 2);
                shichenDict.Add(i, ShichenStrs[shichenIndex]);
            }
        }

        private void StartMinutesAnimation()
        {
            RotateTransform rtf = new RotateTransform();
            MinutesGrid.RenderTransform = rtf;
            DoubleAnimation dbAscending = new DoubleAnimation(0, 360, new Duration(TimeSpan.FromMinutes(1)));
            dbAscending.RepeatBehavior = RepeatBehavior.Forever;
            rtf.BeginAnimation(RotateTransform.AngleProperty, dbAscending);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // 更新当前时间
            CurrTime = DateTime.Now;
            Update();
        }

        private void Update()
        {
            DrawHour();
            ChangeShichenText();
        }

        /// <summary>
        /// 角度360度进制
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private double WrapAngle(double angle)
        {
            return angle % 360;
        }
    }
}