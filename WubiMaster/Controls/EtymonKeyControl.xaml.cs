using System;
using System.Windows;
using System.Windows.Controls;

namespace WubiMaster.Controls
{
    public partial class EtymonKeyControl : UserControl
    {
        public static readonly DependencyProperty EtymonKeyTypeProperty =
            DependencyProperty.Register("EtymonKeyType", typeof(string), typeof(EtymonKeyControl), new PropertyMetadata("86", new PropertyChangedCallback(OnEtymonKeyTypeChanged)));

        public static readonly DependencyProperty IsShowFanKeyProperty =
                    DependencyProperty.Register("IsShowFanKey", typeof(bool), typeof(EtymonKeyControl), new PropertyMetadata(false));

        public static readonly DependencyProperty IsShowVersion06Property =
            DependencyProperty.Register("IsShowVersion06", typeof(Visibility), typeof(EtymonKeyControl), new PropertyMetadata(Visibility.Collapsed));

        public static readonly DependencyProperty IsShowVersion86Property =
            DependencyProperty.Register("IsShowVersion86", typeof(Visibility), typeof(EtymonKeyControl), new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty IsShowVersion98Property =
            DependencyProperty.Register("IsShowVersion98", typeof(Visibility), typeof(EtymonKeyControl), new PropertyMetadata(Visibility.Collapsed));

        public EtymonKeyControl()
        {
            InitializeComponent();
        }

        public string EtymonKeyType
        {
            get { return (string)GetValue(EtymonKeyTypeProperty); }
            set { SetValue(EtymonKeyTypeProperty, value); }
        }

        public bool IsShowFanKey
        {
            get { return (bool)GetValue(IsShowFanKeyProperty); }
            set { SetValue(IsShowFanKeyProperty, value); }
        }

        public Visibility IsShowVersion06
        {
            get { return (Visibility)GetValue(IsShowVersion06Property); }
            set { SetValue(IsShowVersion06Property, value); }
        }

        public Visibility IsShowVersion86
        {
            get { return (Visibility)GetValue(IsShowVersion86Property); }
            set { SetValue(IsShowVersion86Property, value); }
        }

        public Visibility IsShowVersion98
        {
            get { return (Visibility)GetValue(IsShowVersion98Property); }
            set { SetValue(IsShowVersion98Property, value); }
        }

        private static void OnEtymonKeyTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;

            EtymonKeyControl etymonKeyControl = (EtymonKeyControl)d;
            if (e.NewValue.ToString() == "86")
            {
                etymonKeyControl.IsShowVersion86 = Visibility.Visible;
                etymonKeyControl.IsShowVersion98 = Visibility.Collapsed;
                etymonKeyControl.IsShowVersion06 = Visibility.Collapsed;
            }
            else if (e.NewValue.ToString() == "98")
            {
                etymonKeyControl.IsShowVersion86 = Visibility.Collapsed;
                etymonKeyControl.IsShowVersion98 = Visibility.Visible;
                etymonKeyControl.IsShowVersion06 = Visibility.Collapsed;
            }
            else if (e.NewValue.ToString() == "06")
            {
                etymonKeyControl.IsShowVersion86 = Visibility.Collapsed;
                etymonKeyControl.IsShowVersion98 = Visibility.Collapsed;
                etymonKeyControl.IsShowVersion06 = Visibility.Visible;
            }
            else
            {
                throw new ArgumentException("参数错误：字根控件的类型参数只能是【86、98 和 06 的字符串类型】");
            }
        }
    }
}