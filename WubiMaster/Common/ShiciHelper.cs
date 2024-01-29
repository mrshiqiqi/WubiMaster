using Newtonsoft.Json;
using WubiMaster.Models;

namespace WubiMaster.Common
{
    public enum ShiciType
    {
        Chun,
        Xia,
        Qiu,
        Dong,

        Chunjie,
        Yuanxiaojie,
        Hanshijie,
        Qingmingjie,
        Duanwujie,
        Qixijie,
        Zhongqiujie,
        Chongyangjie,

        Defualt,
    }

    public class ShiciHelper
    {
        private static string BaseUrl = "https://v1.jinrishici.com";
        private static HttpRequestHelper httpRequestHelper = new HttpRequestHelper();
        private static string TargetUrl = "";

        public static ShiciContentModel GetShiciAll()
        {
            TargetUrl = BaseUrl + @"/all";
            string jsonString = httpRequestHelper.HttpGet(TargetUrl, "");
            ShiciContentModel model = JsonConvert.DeserializeObject<ShiciContentModel>(jsonString);

            return model;
        }

        public static ShiciContentModel GetShiciByType(ShiciType type = ShiciType.Defualt)
        {
            TargetUrl = "";
            switch (type)
            {
                case ShiciType.Chun:
                    TargetUrl = BaseUrl + @"/siji/chuntian";
                    break;

                case ShiciType.Xia:
                    TargetUrl = BaseUrl + @"/siji/xiatian";
                    break;

                case ShiciType.Qiu:
                    TargetUrl = BaseUrl + @"/siji/qiutian";
                    break;

                case ShiciType.Dong:
                    TargetUrl = BaseUrl + @"/siji/dongtian";
                    break;

                case ShiciType.Chunjie:
                    TargetUrl = BaseUrl + @"/jieri/chunjie";
                    break;

                case ShiciType.Yuanxiaojie:
                    TargetUrl = BaseUrl + @"/jieri/yuanxiaojie";
                    break;

                case ShiciType.Hanshijie:
                    TargetUrl = BaseUrl + @"/jieri/hanshijie";
                    break;

                case ShiciType.Qingmingjie:
                    TargetUrl = BaseUrl + @"/jieri/qingmingjie";
                    break;

                case ShiciType.Duanwujie:
                    TargetUrl = BaseUrl + @"/jieri/duanwujie";
                    break;

                case ShiciType.Qixijie:
                    TargetUrl = BaseUrl + @"/jieri/qixijie";
                    break;

                case ShiciType.Zhongqiujie:
                    TargetUrl = BaseUrl + @"/jieri/zhongqiujie";
                    break;

                case ShiciType.Chongyangjie:
                    TargetUrl = BaseUrl + @"/jieri/chongyangjie";
                    break;

                default:
                    TargetUrl = BaseUrl + @"/all";
                    break;
            }

            string jsonString = httpRequestHelper.HttpGet(TargetUrl, "");
            ShiciContentModel model = JsonConvert.DeserializeObject<ShiciContentModel>(jsonString);

            return model;
        }
    }
}