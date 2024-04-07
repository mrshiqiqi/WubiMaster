using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WubiMaster.ViewModels
{
    public partial class TestViewModel : ObservableRecipient
    {
        public TestViewModel()
        {
            //GetAiColorString();
        }

        private void GetAiColorString()
        {
            // 创建一个WebRequest实例(默认get方式)
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://aicolors.co");
            //可以指定请求的类型
            //request.Method = "POST";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
            // 接收数据
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            // 关闭stream和response
            reader.Close();
            dataStream.Close();
            response.Close();

        }
    }
}
