using System;
using System.Threading.Tasks;
using DataProcess;

namespace EthernumConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Tset().Wait();
        }
        public static async Task Tset()
        {
            #region 新建账户
            ///<summary>
            ///<param name="url">连接以太坊节点的HTTP地址</param>
            /// </summary>

            var url = "http://localhost:8080/";
            //string password = "123456";
            //var newAddress = await new Accounts.Account(url).NewAccountAsync(password);
            //Console.WriteLine(newAddress);
            #endregion


            #region 在私有链里写入字符串
            ///<summary>
            ///<param name="str">要写入的字符串</param>
            ///<param name="address">以太坊中的账户地址</param>
            ///<param name="accPassword">该账户的密码</param>
            ///<param name="dataName">为此次写入的数据命名</param>
            /// </summary>
            var str = "HelloWorld!";
            var address = "0xd5e4076669b70db438855832d85b9c174680f46b";
            var accPassword = "123456";
            var dataName = "Test1-1";

            var dataPorter = new DataPorter(url);
            await dataPorter.WriteDataAsync(address, accPassword, str, dataName);
            #endregion


            #region 读出数据
            var data = await dataPorter.ReadDataAsync(dataName);
            Console.WriteLine(data);
            #endregion


            #region 写入图片
            var imgAddress = @"D:\Test.jpg";
            var imgDataName = "Test1-2";
            var imgSting = DataCoder.ImgToBase64String(imgAddress);
            await dataPorter.WriteDataAsync(address, accPassword, imgSting, imgDataName);
            #endregion


            #region 读取图片
            ///<summary>
            ///<param name="ImageFormat.Jpeg"></param>
            ///<param name="ImageFormat.Bmp"></param>
            ///<param name="ImageFormat.Gif"></param>
            ///<param name="ImageFormat.Png"></param>
            /// </summary>
            var imgBase64String = await dataPorter.ReadDataAsync(imgDataName);
            var imgSaveAddress = @"D:\result.jpg";
            var result = DataCoder.Base64StringToImage(imgBase64String, imgSaveAddress, System.Drawing.Imaging.ImageFormat.Jpeg);
            #endregion



            ///test

            //var result = DataCoder.ImgToBase64String(@"D:\Code\EthernumConnectionTest\image\220181011222940.jpg");
            //Console.WriteLine($"第一次:{result}");
            //DataPorter dataPorter = new DataPorter("http://localhost:8080/");
            //Console.WriteLine(dataPorter.GetTransactionCount("0xd5e4076669b70db438855832d85b9c174680f46b"));
            //var TxHash = dataPorter.WriteData("0xd5e4076669b70db438855832d85b9c174680f46b", "123456", result, "Test");
            //var data = dataPorter.ReadData(TxHash);
            //Console.WriteLine($"第二次:{data}");
            //Console.WriteLine(dataPorter.GetTransactionCount("0xd5e4076669b70db438855832d85b9c174680f46b"));
            //DataCoder.Base64StringToImage(data);

            //DataPorter dataPorter = new DataPorter("http://localhost:8080/");
            //var x = dataPorter.WriteData("0xd5e4076669b70db438855832d85b9c174680f46b", "123456", "HelloWorld!", "Test");
            //var result = dataPorter.ReadData(x);
            //Console.WriteLine(result);

            //var dp = new DataPorter("http://localhost:8080/");
            //var ImageUrl = @"C:\Users\CZH\Pictures\2b6c7439a6d1c80200fe7d3700d4ad00.jpg";
            //var ImaString = DataCoder.ImgToBase64String(ImageUrl);
            //dp.WriteData("0xd5e4076669b70db438855832d85b9c174680f46b", "123456", ImaString, "Test");
            //DataCoder.Base64StringToImage(await dp.ReadDataAsync("Test"), @"C:\Users\CZH\Pictures\Tset.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
