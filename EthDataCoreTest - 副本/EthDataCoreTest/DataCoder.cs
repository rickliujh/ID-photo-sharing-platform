using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcess
{
    static class DataCoder
    {
        ///您需要安装libc6-dev以使System.Drawing.Common在Linux上的.NET Core中正常运行。
        ///RUN apt-get install -y libc6-dev
        ///RUN apt-get install -y libgdiplus
        public static string ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        //threeebase64编码的字符串转为图片
        public static Bitmap Base64StringToImage(string strbase64, string SavaAddress, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                bmp.Save(SavaAddress, imageFormat);

                //bmp.Save(@"D:\Code\EthernumConnectionTest\image\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //bmp.Save(@"d:\"test.bmp", ImageFormat.Bmp);
                //bmp.Save(@"d:\"test.gif", ImageFormat.Gif);
                //bmp.Save(@"d:\"test.png", ImageFormat.Png);
                ms.Close();
                return bmp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
