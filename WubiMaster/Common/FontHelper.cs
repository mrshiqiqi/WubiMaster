using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace WubiMaster.Common
{
    public class FontHelper
    {
        [DllImport("gdi32")]
        public static extern int AddFontResource(string lpFileName);

        /// <summary>
        /// 检查字体是否存在
        /// </summary>
        /// <param name="familyName">字体名称</param>
        /// <returns></returns>
        public static bool CheckFont(string familyName)
        {
            string FontPath = Path.Combine(System.Environment.GetEnvironmentVariable("WINDIR"), "fonts", Path.GetFileName(familyName));
            //检测系统是否已安装该字体
            return File.Exists(FontPath);
        }

        /// <summary>
        /// 检测某种字体样式是否可用
        /// </summary>
        /// <param name="familyName">字体名称</param>
        /// <param name="fontStyle">字体样式</param>
        /// <returns></returns>
        public static bool CheckFont(string familyName, FontStyle fontStyle = FontStyle.Regular)
        {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFontCollection.Families;
            foreach (var item in fontFamilies)
            {
                if (item.Name.Equals(familyName))
                {
                    return item.IsStyleAvailable(fontStyle);
                }
            }
            return false;
        }

        /// <summary>
        /// 通过文件获取字体
        /// </summary>
        /// <param name="filePath">文件全路径</param>
        /// <returns>字体</returns>
        public static Font GetFontByFile(string filePath)
        {
            //程序直接调用字体文件，不用安装到系统字库中。
            System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();
            pfc.AddFontFile(filePath);//字体文件的路径
            Font font = new Font(pfc.Families[0], 24, FontStyle.Regular, GraphicsUnit.Point, 0);//font就是通过文件创建的字体对象
            return font;
        }

        /// <summary>
        /// 如何使用资源文件中的字体，无安装无释放
        /// </summary>
        /// <param name="bytes">资源文件中的字体文件</param>
        /// <returns></returns>
        public static Font GetResoruceFont(byte[] bytes)
        {
            System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();
            IntPtr MeAdd = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, MeAdd, bytes.Length);
            pfc.AddMemoryFont(MeAdd, bytes.Length);
            return new Font(pfc.Families[0], 15, FontStyle.Regular);
        }

        /// <summary>
        /// 安装字体
        /// </summary>
        /// <param name="fontFilePath">字体文件全路径</param>
        /// <returns>是否成功安装字体</returns>
        /// <exception cref="UnauthorizedAccessException">不是管理员运行程序</exception>
        /// <exception cref="Exception">字体安装失败</exception>
        public static bool InstallFont(string fontFilePath)
        {
            try
            {
                System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();

                System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                //判断当前登录用户是否为管理员
                if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator) == false)
                {
                    throw new UnauthorizedAccessException("当前用户无管理员权限，无法安装字体。");
                }
                //获取Windows字体文件夹路径
                string fontPath = Path.Combine(System.Environment.GetEnvironmentVariable("WINDIR"), "fonts", Path.GetFileName(fontFilePath));
                //检测系统是否已安装该字体
                if (!File.Exists(fontPath))
                {
                    // File.Copy(System.Windows.Forms.Application.StartupPath + "\\font\\" + FontFileName, FontPath); //font是程序目录下放字体的文件夹
                    //将某路径下的字体拷贝到系统字体文件夹下
                    File.Copy(fontFilePath, fontPath); //font是程序目录下放字体的文件夹
                    AddFontResource(fontPath);

                    //Res = SendMessage(HWND_BROADCAST, WM_FONTCHANGE, 0, 0);
                    //WIN7下编译会出错，不清楚什么问题。注释就行了。
                    //安装字体
                    WriteProfileString("fonts", Path.GetFileNameWithoutExtension(fontFilePath) + "(TrueType)", Path.GetFileName(fontFilePath));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format($"[{Path.GetFileNameWithoutExtension(fontFilePath)}] 字体安装失败！原因：{ex.Message}"));
            }
            return true;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int WriteProfileString(string lpszSection, string lpszKeyName, string lpszString);
    }
}