using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WubiMaster.Models
{
    public class Location
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 城市名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 北京,北京,中国
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 时间标准
        /// </summary>
        public string timezone { get; set; }

        /// <summary>
        /// 时间偏差
        /// </summary>
        public string timezone_offset { get; set; }
    }

    public class Now
    {
        /// <summary>
        /// 气象代码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        public string temperature { get; set; }

        /// <summary>
        /// 气象
        /// </summary>
        public string text { get; set; }
    }

    public class ResultsItem
    {
        /// <summary>
        /// 更新时间
        /// </summary>
        public string last_update { get; set; }

        /// <summary>
        /// 位置信息
        /// </summary>
        public Location location { get; set; }

        /// <summary>
        /// 当前气象信息
        /// </summary>
        public Now now { get; set; }
    }

    public class WeatherDataModel
    {
        public List<ResultsItem> results { get; set; }
    }
}