using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace WubiMaster.Common
{
    public class NongliHelper
    {
        private static ChineseLunisolarCalendar china = new ChineseLunisolarCalendar();
        private static Hashtable gHoliday = new Hashtable();
        private static string[] JQ = { "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至" };
        private static int[] JQData = { 0, 21208, 43467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
        private static string[] JQMonth = {
            "季冬", "孟春", "仲春",
            "季春", "孟夏", "仲夏",
            "季夏", "孟秋", "仲秋",
            "季秋", "孟冬", "仲冬", };
        private static string[] JQHou = {
            "雁北乡", "鹊始巢", "雉始鸲",
            "鸡始乳", "征鸟厉疾", "水泽腹坚",
            "东风解冻", "蛰虫始振", "鱼陟负冰",
            "獭祭鱼", "鸿雁来", "草木萌动",
            "桃始华", "仓庚鸣", "鹰化为鸠",
            "玄鸟至", "雷乃发声", "始电",
            "桐始华", "田鼠化为鴽", "虹始见",
            "萍始生", "鸣鸠拂其羽", "戴胜降于桑",
            "蝼蝈鸣", "蚯蚓出", "王瓜出",
            "苦菜秀", "靡草死", "麦秋至",
            "螳螂生", "鵙始鸣", "反舌无声",
            "鹿角解", "蜩始鸣", "半夏生",
            "温风至", "蟋蟀居壁", "鹰始击",
            "腐草为萤", "土润溽暑", "大雨时行",
            "凉风至", "白露降", "寒蝉鸣",
            "鹰乃祭鸟", "天地始肃", "禾乃登",
            "鸿雁来", "玄鸟归", "群鸟养羞",
            "雷始收声", "蛰虫坯户", "水始涸",
            "鸿雁来宾", "雀入大水为蛤", "菊有黄华",
            "豺祭兽", "草木黄落", "蛰虫咸俯",
            "水始冰", "地始冻", "雉入大水为蜃",
            "虹藏不见", "天气上升，地气下降", "闭塞而成冬",
            "鹖鴠不鸣", "虎始交", "荔挺出",
            "蚯蚓结", "麋角解", "水泉动",
        };

        private static Hashtable nHoliday = new Hashtable();

        static NongliHelper()
        {
            //公历节日
            gHoliday.Add("0101", "元旦");
            gHoliday.Add("0214", "情人节");
            gHoliday.Add("0305", "雷锋日");
            gHoliday.Add("0308", "妇女节");
            gHoliday.Add("0312", "植树节");
            gHoliday.Add("0315", "消费者权益日");
            gHoliday.Add("0401", "愚人节");
            gHoliday.Add("0501", "劳动节");
            gHoliday.Add("0504", "青年节");
            gHoliday.Add("0601", "儿童节");
            gHoliday.Add("0701", "建党节");
            gHoliday.Add("0801", "建军节");
            gHoliday.Add("0910", "教师节");
            gHoliday.Add("0918", "九一八纪念日");
            gHoliday.Add("0930", "烈士纪念日");
            gHoliday.Add("1001", "国庆节");
            gHoliday.Add("1213", "国家公祭日");
            gHoliday.Add("1224", "平安夜");
            gHoliday.Add("1225", "圣诞节");

            //农历节日
            nHoliday.Add("0101", "春节");
            nHoliday.Add("0115", "元宵节");
            nHoliday.Add("0505", "端午节");
            nHoliday.Add("0707", "七夕节"); // 后加
            nHoliday.Add("0715", "中元节"); // 后加
            nHoliday.Add("0815", "中秋节");
            nHoliday.Add("0909", "重阳节");
            nHoliday.Add("1208", "腊八节");
            nHoliday.Add("1223", "北方小年"); // 后加
            nHoliday.Add("1224", "南方小年"); // 后加
            //需要特殊计算的节日
            //寒食节
            //清明节
            //除夕节
        }

        /// <summary>
        /// 获取农历
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetChinaDate(DateTime dt)
        {
            if (dt > china.MaxSupportedDateTime || dt < china.MinSupportedDateTime)
            {
                //日期范围：1901 年 2 月 19 日 - 2101 年 1 月 28 日
                throw new Exception(string.Format("日期超出范围！必须在{0}到{1}之间！", china.MinSupportedDateTime.ToString("yyyy-MM-dd"), china.MaxSupportedDateTime.ToString("yyyy-MM-dd")));
            }
            string str = string.Format("{0} {1}{2}", GetYear(dt), GetMonth(dt), GetDay(dt));
            string strJQ = GetSolarTerm(dt);
            if (strJQ != "")
            {
                str += " (" + strJQ + ")";
            }
            string strHoliday = GetHoliday(dt);
            if (strHoliday != "")
            {
                str += " " + strHoliday;
            }
            string strChinaHoliday = GetChinaHoliday(dt);
            if (strChinaHoliday != "")
            {
                str += " " + strChinaHoliday;
            }

            return str;
        }

        /// <summary>
        /// 获取农历节日
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetChinaHoliday(DateTime dt)
        {
            string strReturn = "";
            int year = china.GetYear(dt);
            int iMonth = china.GetMonth(dt);
            int leapMonth = china.GetLeapMonth(year);
            int iDay = china.GetDayOfMonth(dt);
            if (china.GetDayOfYear(dt) == china.GetDaysInYear(year))
            {
                strReturn = "除夕";
            }
            else if (NongliHelper.GetSolarTerm(dt) == "清明")
            {
                strReturn = "清明节";
            }
            else if (NongliHelper.GetSolarTerm((dt.AddDays(-105))) == "冬至")
            {
                // 清明节前一二日 寒食节，中国传统节日， 在夏历冬至后105日，清明节前一二日 。
                strReturn = "寒食节";
            }
            else if (leapMonth != iMonth)
            {
                if (leapMonth != 0 && iMonth == leapMonth)
                {
                    iMonth--;
                }
                object n = nHoliday[iMonth.ToString("00") + iDay.ToString("00")];
                if (n != null)
                {
                    if (strReturn == "")
                    {
                        strReturn = n.ToString();
                    }
                    else
                    {
                        strReturn += " " + n.ToString();
                    }
                }
            }

            return strReturn;
        }

        /// <summary>
        /// 获取农历日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetDay(DateTime dt)
        {
            int iDay = china.GetDayOfMonth(dt);
            string szText1 = "初十廿三";
            string szText2 = "一二三四五六七八九十";
            string strDay;
            if (iDay == 20)
            {
                strDay = "二十";
            }
            else if (iDay == 30)
            {
                strDay = "三十";
            }
            else
            {
                strDay = szText1.Substring((iDay - 1) / 10, 1);
                strDay = strDay + szText2.Substring((iDay - 1) % 10, 1);
            }
            return strDay;
        }

        /// <summary>
        /// 获取公历节日
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetHoliday(DateTime dt)
        {
            string strReturn = "";
            object g = gHoliday[dt.Month.ToString("00") + dt.Day.ToString("00")];
            if (g != null)
            {
                strReturn = g.ToString();
            }

            return strReturn;
        }

        /// <summary>
        /// 获取农历月份
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetMonth(DateTime dt)
        {
            int year = china.GetYear(dt);
            int iMonth = china.GetMonth(dt);
            int leapMonth = china.GetLeapMonth(year);
            bool isLeapMonth = iMonth == leapMonth;
            if (leapMonth != 0 && iMonth == leapMonth)
            {
                iMonth--;
            }

            string szText = "正二三四五六七八九十";
            string strMonth = isLeapMonth ? "闰" : "";
            if (iMonth <= 10)
            {
                strMonth += szText.Substring(iMonth - 1, 1);
            }
            else if (iMonth == 11)
            {
                strMonth += "十一";
            }
            else
            {
                strMonth += "腊";
            }
            return strMonth + "月";
        }

        /// <summary>
        /// 获取节气
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetSolarTerm(DateTime dt)
        {
            DateTime dtBase = new DateTime(1900, 1, 6, 2, 5, 0);
            DateTime dtNew;
            double num;
            int y;
            string strReturn = "";

            y = dt.Year;
            for (int i = 1; i <= 24; i++)
            {
                num = 525948.76 * (y - 1900) + JQData[i - 1];
                dtNew = dtBase.AddMinutes(num);
                if (dtNew.DayOfYear == dt.DayOfYear)
                {
                    strReturn = JQ[i - 1];
                }
            }

            return strReturn;
        }

        /// <summary>
        /// 获取节气（按节气阶段，即最近一个节气）
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetSolarTermLast(DateTime dt)
        {
            DateTime dtBase = new DateTime(1900, 1, 6, 2, 5, 0);
            DateTime dtNew;
            double num;
            int y;
            string strReturn = "";

            y = dt.Year;
            for (int i = 1; i <= 24; i++)
            {
                num = 525948.76 * (y - 1900) + JQData[i - 1];
                dtNew = dtBase.AddMinutes(num);
                if (dtNew.DayOfYear <= dt.DayOfYear)
                {
                    strReturn = JQ[i - 1];
                }
            }

            return strReturn;
        }

        /// <summary>
        /// 获取农历年份
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetYear(DateTime dt)
        {
            int yearIndex = china.GetSexagenaryYear(dt);
            string yearTG = " 甲乙丙丁戊己庚辛壬癸";
            string yearDZ = " 子丑寅卯辰巳午未申酉戌亥";
            string yearSX = " 鼠牛虎兔龙蛇马羊猴鸡狗猪";
            int year = china.GetYear(dt);
            int yTG = china.GetCelestialStem(yearIndex);
            int yDZ = china.GetTerrestrialBranch(yearIndex);

            string str = string.Format("[{1}]{2}{3}{0}", year, yearSX[yDZ], yearTG[yTG], yearDZ[yDZ]);
            return str;
        }

        /// <summary>
        /// 获取农历季节（春、夏、秋、冬）
        /// </summary>
        /// <returns></returns>
        public static string GetJijie(DateTime dt)
        {
            string jijieStr = "";

            string jieqiLast = NongliHelper.GetSolarTermLast(dt);
            List<string> jieqiList = new List<string>();
            for (int i = 0; i < JQ.Length; i++)
            {
                jieqiList.Add(JQ[i]);
            }
            int jieqiIndex = jieqiList.IndexOf(jieqiLast);

            if (jieqiIndex >= 2 && jieqiIndex <= 7)
            {
                jijieStr = "春";
            }
            else if (jieqiIndex >= 8 && jieqiIndex <= 13)
            {
                jijieStr = "夏";
            }
            else if (jieqiIndex >= 14 && jieqiIndex <= 19)
            {
                jijieStr = "秋";
            }
            else
            {
                jijieStr = "冬";
            }

            return jijieStr;
        }

        /// <summary>
        /// 获取农历季节对应的月名称（孟春、仲春、季春）
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetJiejieMonth(DateTime dt)
        {
            string monthName = "";
            int jieqiHouIndex = -1;

            string jieqiLast = NongliHelper.GetSolarTermLast(dt);

            List<string> jieqiList = new List<string>();
            for (int i = 0; i < JQ.Length; i++)
                jieqiList.Add(JQ[i]);
            int jieqiIndex = jieqiList.IndexOf(jieqiLast);

            int mouthIndex = jieqiIndex / 2;

            monthName = JQMonth[mouthIndex];
            return monthName;
        }

        /// <summary>
        /// 获取节气对应的七十二候
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetJieqiHou(DateTime dt)
        {
            string jieqiHouStr = "";
            int jieqiHouIndex = -1;

            string jieqiLast = NongliHelper.GetSolarTermLast(dt);

            List<string> jieqiList = new List<string>();
            for (int i = 0; i < JQ.Length; i++)
                jieqiList.Add(JQ[i]);
            int jieqiIndex = jieqiList.IndexOf(jieqiLast);

            DateTime dtBase = new DateTime(1900, 1, 6, 2, 5, 0);
            int y = dt.Year;
            double num = 525948.76 * (y - 1900) + JQData[jieqiIndex];
            DateTime dtJieqi = dtBase.AddMinutes(num);

            int dateSpan = dt.DayOfYear - dtJieqi.DayOfYear;
            int value = dateSpan / 5;
            jieqiHouIndex = jieqiIndex * 3 + value;

            jieqiHouStr = JQHou[jieqiHouIndex];
            return jieqiHouStr;
        }
    }
}