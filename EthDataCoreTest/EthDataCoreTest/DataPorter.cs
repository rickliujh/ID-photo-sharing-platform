using Nethereum.Geth;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Numerics;
using System.Collections.Generic;

namespace DataProcess
{
    class DataPorter
    {
        private string url { get; set; }

        //Incoming url calls privatechain via http
        public DataPorter(string Url)
        {
            url = Url;
        }

        public bool WriteData(string senderAddress, string Password, string Data, string DataName)
        {
            string TxHash = null;
            try
            {
                if (Data.Length / 2 <= 31744)
                {
                    TxHash = WriteDataToPrvataChain(senderAddress, Password, Data);
                    DataMapOperator.AddImageToMap(DataName, senderAddress, TxHash);
                }
                else
                {
                    var dataList = GetStringList(Data);
                    foreach (var item in dataList)
                    {
                        TxHash += (WriteDataToPrvataChain(senderAddress, Password, item) + " ");
                    }
                    DataMapOperator.AddImageToMap(DataName, senderAddress, TxHash);
                }
                return true;
            }
            catch (System.Exception)
            {
                throw;
                return false;
            }

        }

        public string WriteDataToPrvataChain(string senderAddress, string Password, string Data)
        {
            ///Connection privatechain RPC socket
            Web3Geth Web3 = new Web3Geth(url);

            ///Send transactions and input data
            var x = new TransactionInput(new HexUTF8String(Data).HexValue, new HexBigInteger("0xffffff"), senderAddress);

            ///Unlock account
            ulong? ul = null;
            var t = Web3.Personal.UnlockAccount.SendRequestAsync(senderAddress, Password, ul);

            var result = Web3.Eth.Transactions.SendTransaction.SendRequestAsync(x);
            return result.Result;
        }

        public string ReadData(string Hx)
        {
            //Connection privatechain RPC socket
            Web3Geth Web3 = new Web3Geth(url);
            //Get transactions massage
            var result = Web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(Hx);
            //return Input
            return ConvertHexStringToString(result.Result.Input);
        }



        private string ConvertHexStringToString(string Str)
        {
            return new Nethereum.Hex.HexConvertors.HexUTF8StringConvertor().ConvertFromHex(Str);
        }

        public BigInteger GetTransactionCount(string senderAddress)
        {
            Web3Geth Web3 = new Web3Geth(url);
            var result = Web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(senderAddress);
            return result.Result.Value;
        }

        public string bSubstring(ref string s, int length)
        {
            //https://www.cnblogs.com/nokiaguy/archive/2008/09/06/1285794.html

            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(s);
            int n = 0;  //  表示当前的字节数
            int i = 0;  //  要截取的字节数
            if (bytes.Length == 0)
            {
                return null;
            }
            for (; i < bytes.GetLength(0) && n < length; i++)
            {

                //  偶数位置，如0、2、4等，为UCS2编码中两个字节的第一个字节
                if (i % 2 == 0)
                {
                    n++;      //  在UCS2第一个字节时n加1
                }
                else
                {

                    //  当UCS2编码的第二个字节大于0时，该UCS2字符为汉字，一个汉字算两个字节
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }
            }

            //  如果i为奇数时，处理成偶数

            if (i % 2 == 1)
            {
                //  该UCS2字符是汉字时，去掉这个截一半的汉字

                if (bytes[i] > 0)
                    i = i - 1;

                //  该UCS2字符是字母或数字，则保留该字符
                else
                    i = i + 1;
            }
            s = System.Text.Encoding.Unicode.GetString(bytes, i, bytes.Length - i);
            return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        }

        public List<string> GetStringList(string data)
        {
            var strArray = new List<string>();
            string tmp = data;
            string addToList;
            while ((addToList = bSubstring(ref tmp, 31744)) != null)
            {
                strArray.Add(addToList);
            }
            return strArray;
        }
    }
}
