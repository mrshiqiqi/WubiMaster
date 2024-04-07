using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace WubiMaster.Common
{
    public class ZipHelper
    {
        /// <summary>
        /// 将指定目录压缩为Zip文件
        /// </summary>
        /// <param name="folderPath">文件夹地址 D:/1/ </param>
        /// <param name="zipPath">zip地址 D:/1.zip </param>
        public static void CompressDirectoryZip(string folderPath, string zipPath)
        {
            DirectoryInfo directoryInfo = new(zipPath);

            if (directoryInfo.Parent != null)
            {
                directoryInfo = directoryInfo.Parent;
            }

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            ZipFile.CreateFromDirectory(folderPath, zipPath, CompressionLevel.Optimal, false);
        }

        /// <summary>
        /// 将指定文件压缩为Zip文件
        /// </summary>
        /// <param name="filePath">文件地址 D:/1.txt </param>
        /// <param name="zipPath">zip地址 D:/1.zip </param>
        public static void CompressFileZip(string filePath, string zipPath)
        {

            FileInfo fileInfo = new FileInfo(filePath);
            string dirPath = fileInfo.DirectoryName?.Replace("\\", "/") + "/";
            string tempPath = dirPath + Guid.NewGuid() + "_temp/";
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }
            fileInfo.CopyTo(tempPath + fileInfo.Name);
            CompressDirectoryZip(tempPath, zipPath);
            DirectoryInfo directory = new(tempPath);
            if (directory.Exists)
            {
                //将文件夹属性设置为普通,如：只读文件夹设置为普通
                directory.Attributes = FileAttributes.Normal;

                directory.Delete(true);
            }
        }

        /// <summary>
        /// 解压Zip文件到指定目录
        /// </summary>
        /// <param name="zipPath">zip地址 D:/1.zip</param>
        /// <param name="folderPath">文件夹地址 D:/1/</param>
        public static void DecompressZip(string zipPath, string folderPath, bool overwrite=true)
        {
            DirectoryInfo directoryInfo = new(folderPath);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            ZipFile.ExtractToDirectory(zipPath, folderPath, overwrite);
        }
    }
}
