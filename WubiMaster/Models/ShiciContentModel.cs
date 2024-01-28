using System.Collections.Generic;

namespace WubiMaster.Models
{
    public class ShiciContentInfo
    {
        /// <summary>
        /// 春江花月夜
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 唐代
        /// </summary>
        public string dynasty { get; set; }

        /// <summary>
        /// 张若虚
        /// </summary>
        public string author { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> translate { get; set; }

    }



    public class ShiciContentData
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 江畔何人初见月，江月何年初照人？
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int popularity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ShiciContentInfo origin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> matchTags { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string recommendedReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string cacheAt { get; set; }

    }



    public class ShiciContentModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ShiciContentData data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ipAddress { get; set; }

        /// <summary>
        /// 接口侦测到来自您 IP 的异常流量，已主动下调推荐效果，请正确配置接口，携带 Token 并正常发送请求。一小时内自动恢复。
        /// </summary>
        public string warning { get; set; }

    }


}