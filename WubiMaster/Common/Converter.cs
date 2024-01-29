using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WubiMaster.Common
{
    public class SearchTextToVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Visible;
            else if (value.ToString().Length == 0) return Visibility.Visible;
            else return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Visible;
            else if (value.ToString().Length == 0) return Visibility.Visible;
            else return Visibility.Collapsed;

        }
    }

    public class ShiciTextToFirst : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            try
            {
                string shici_text = (string)value;
                string[] shici_texts = shici_text.Split(new char[4] { '，', '。', '！', '？'});
                string result_text = shici_texts[0];
                return result_text;
            }
            catch (Exception)
            {
                return "";
            }
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class ShiciTextToSecond : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            try
            {
                string shici_text = (string)value;
                string[] shici_texts = shici_text.Split(new char[4] { '，', '。', '！', '？' });
                string result_text = shici_texts[1];
                return result_text;
            }
            catch (Exception)
            {
                return "";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class ShiciTextToThrid : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            try
            {
                string shici_text = (string)value;
                string[] shici_texts = shici_text.Split(new char[4] { '，', '。', '！', '？' });
                string result_text = shici_texts[2];
                return result_text;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
