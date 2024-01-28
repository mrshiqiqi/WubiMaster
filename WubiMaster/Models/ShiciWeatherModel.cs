using System.Collections.Generic;

namespace WubiMaster.Models
{
    public class ShiciWeatherData
    {
        public string beijingTime { get; set; }
        public string ip { get; set; }
        public string region { get; set; }
        public List<string> tags { get; set; }
        public string token { get; set; }
        public ShiciWeatherInfo weatherData { get; set; }
    }

    public class ShiciWeatherInfo
    {
        public int humidity { get; set; }
        public int pm25 { get; set; }
        public int rainfall { get; set; }
        public double temperature { get; set; }
        public string updateTime { get; set; }
        public string visibility { get; set; }
        public string weather { get; set; }
                public string windDirection { get; set; }
        public int windPower { get; set; }
    }

    public class ShiciWeatherModel
    {
        public ShiciWeatherData data { get; set; }
        public string status { get; set; }
    }
}