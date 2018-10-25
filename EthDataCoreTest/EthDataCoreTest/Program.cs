using Nethereum.Geth;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DataProcess;

namespace EthernumConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // #region 新建账户
            // var url = "http://localhost:8080/";
            // var password = "";
            // var Address = new Accounts.Account(url).NewAccount(password);

            // ///<summary>
            // ///url:连接节点字符串
            // /// </summary>
            // #endregion


            // #region 在私有链里写入字符串
            // ///<summary>
            // ///str：要写入的字符串
            // ///address：以太坊中的账户地址
            // ///Accpassword：改账户的密码
            // ///dataname:给这次写入的数据命名
            // ///TxHash：交易的哈希地址
            // /// </summary>
            // var str = "HelloWorld!";
            // var address = "0xd5e4076669b70db438855832d85b9c174680f46b";
            // var Accpassword = "123456";
            // var dataname = "Test";

            // var dataPorter = new DataPorter(url);
            // var TxHash = dataPorter.WriteData(address, Accpassword, str, dataname);
            // #endregion


            // #region 读出数据
            // var data = dataPorter.ReadData(TxHash);
            // Console.WriteLine(data);
            // #endregion


            // #region 写入图片
            // var ImgAddress = @"D:\test.jpg";
            // var ImgSting = DataCoder.ImgToBase64String(ImgAddress);
            // var ImgTxHash = dataPorter.WriteData(address, Accpassword, ImgSting, dataname);
            // #endregion


            // #region 读取图片
            // ///<summary>
            // ///ImageFormat:
            // ///ImageFormat.Jpeg
            // ///ImageFormat.Bmp
            // ///ImageFormat.Gif
            // ///ImageFormat.Png
            // /// </summary>
            // var ImgBase64String = dataPorter.ReadData(ImgTxHash);
            // var ImgSaveAddress = @"D:\result.jpg";
            // var result = DataCoder.Base64StringToImage(ImgBase64String, ImgSaveAddress, System.Drawing.Imaging.ImageFormat.Jpeg);
            // #endregion

            // //var result = DataCoder.ImgToBase64String(@"D:\Code\EthernumConnectionTest\image\220181011222940.jpg");
            // //Console.WriteLine($"第一次:{result}");
            // //DataPorter dataPorter = new DataPorter("http://localhost:8080/");
            // //Console.WriteLine(dataPorter.GetTransactionCount("0xd5e4076669b70db438855832d85b9c174680f46b"));
            // //var TxHash = dataPorter.WriteData("0xd5e4076669b70db438855832d85b9c174680f46b", "123456", result, "Test");
            // //var data = dataPorter.ReadData(TxHash);
            // //Console.WriteLine($"第二次:{data}");
            // //Console.WriteLine(dataPorter.GetTransactionCount("0xd5e4076669b70db438855832d85b9c174680f46b"));
            // //DataCoder.Base64StringToImage(data);

            // //DataPorter dataPorter = new DataPorter("http://localhost:8080/");
            // //var x = dataPorter.WriteData("0xd5e4076669b70db438855832d85b9c174680f46b", "123456", "HelloWorld!", "Test");
            // //var result = dataPorter.ReadData(x);
            // //Console.WriteLine(result);

            ///test
            var ImageUrl = @"/home/richard/图片/1346589-20180312232325883-126791296.jpg";
            var ImaString = DataCoder.ImgToBase64String(ImageUrl);
            var dp = new DataPorter("http://localhost:8080/");
            dp.WriteData("0xa26684a9283d1c1eabed4c9ffe9074bc03522760","123456",ImaString,"Test");

        }


    }
}
