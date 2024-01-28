using System.Collections.Generic;

namespace WubiMaster.Models
{
    public class ShiciWeatherInfo
    {
        /// <summary>
        ///
        /// </summary>
        public double temperature { get; set; }

        /// <summary>
        /// 西南风
        /// </summary>
        public string windDirection { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double windPower { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double humidity { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string updateTime { get; set; }

        /// <summary>
        /// 晴
        /// </summary>
        public string weather { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string visibility { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double rainfall { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double pm25 { get; set; }
    }

    public class ShiciWeatherData
    {
        /// <summary>
        ///
        /// </summary>
        public string token { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// 北京|北京
        /// </summary>
        public string region { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ShiciWeatherInfo weatherData { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<string> tags { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string beijingTime { get; set; }
    }

    public class ShiciWeatherModel
    {
        /// <summary>
        ///
        /// </summary>
        public string status { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ShiciWeatherData data { get; set; }
    }
}