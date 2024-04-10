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

        public static readonly DependencyProperty ShichenTipProperty =
            DependencyProperty.Register("ShichenTip", typeof(string), typeof(ShichenControl), new PropertyMetadata(""));

        private double angle = 360;

        private DateTime CurrTime = DateTime.Now;

        private bool IsFirstOpen = true;
        private double last_angle;

        private Dictionary<int, string> shichenDict;

        private string[] ShichenStrs = new string[]
                                                                                                {
            "子","丑","寅","卯",
            "辰","巳","午","未",
            "申","酉","戌","亥",
        };

        private string[] ShichenTips = new string[]
                                                                                                {
            "睡觉","熟睡","熟睡","排便",
            "早餐","创造","午休","喝水",
            "活动","少食","散步","泡脚",
        };

        private DispatcherTimer timer = new DispatcherTimer();
        private Dictionary<int, string> tipDict;

        public ShichenControl()
        {
            InitializeComponent();

            shichenDict = new Dictionary<int, string>();
            tipDict = new Dictionary<int, string>();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;

            InitShichenDict();
            ChangeShichenText();
            StartSecondAnimation();
            StartHourAnimation();

            timer.Start();
        }

        public string ShichenText
        {
            get { return (string)GetValue(ShichenTextProperty); }
            set { SetValue(ShichenTextProperty, value); }
        }

        public string ShichenTip
        {
            get { return (string)GetValue(ShichenTipProperty); }
            set { SetValue(ShichenTipProperty, value); }
        }

        private void ChangeShichenText()
        {
            var hour = DateTime.Now.Hour;
            ShichenText = shichenDict[hour] + "时";
            ShichenTip = tipDict[hour];
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

        private void InitShichenDict()
        {
            for (int i = 0; i < 24; i++)
            {
                if (i == 0 || i == 23)
                {
                    shichenDict.Add(i, ShichenStrs[0]);
                    tipDict.Add(i, ShichenTips[0]);
                    continue;
                }

                int shichenIndex = (i / 2) + (i % 2);
                shichenDict.Add(i, ShichenStrs[shichenIndex]);
                tipDict.Add(i, ShichenTips[shichenIndex]);
            }
        }

        /// <summary>
        /// 画时针圆
        /// </summary>
        private void StartHourAnimation()
        {
            try
            {
                int hour = CurrTime.Hour;
                int minu = CurrTime.Minute;
                double dminu = minu / 60.0; // 根据分钟数增加时针偏移
                double dhour = hour + dminu;

                double hour_angle = WrapAngle(dhour * (360.0 / 12.0));
                if (IsFirstOpen)
                {
                    last_angle = hour_angle;
                    IsFirstOpen = false;
                }
                RotateTransform hour_trans = new RotateTransform();
                HourGrid.RenderTransform = hour_trans;
                DoubleAnimation hour_animation = new DoubleAnimation(last_angle, hour_angle, new Duration(TimeSpan.FromSeconds(0.5)));
                hour_animation.RepeatBehavior = RepeatBehavior.Forever;
                hour_trans.BeginAnimation(RotateTransform.AngleProperty, hour_animation);
                last_angle = hour_angle;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

        private void StartSecondAnimation()
        {
            double dsec = DateTime.Now.Second / 60.0;
            double sec_angle = dsec * 360;
            RotateTransform sec_trans = new RotateTransform();
            MinutesGrid.RenderTransform = sec_trans;
            DoubleAnimation sec_animation = new DoubleAnimation(sec_angle, 360 + sec_angle, new Duration(TimeSpan.FromMinutes(1)));
            sec_animation.RepeatBehavior = RepeatBehavior.Forever;
            sec_trans.BeginAnimation(RotateTransform.AngleProperty, sec_animation);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // 更新当前时间
            CurrTime = DateTime.Now;
            Update();
        }

        private void Update()
        {
            StartHourAnimation();
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