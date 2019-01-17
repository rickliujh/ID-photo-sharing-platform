using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChainAccess.Ethereum.DateAccess;
using Newtonsoft.Json;

namespace EthImgStorage_Web_API.Models
{
    public class ChainModel
    {

        /// <summary>
        /// 保存一个对象到以太坊数据库
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="address">发起保存的用户地址</param>
        /// <param name="password">发起保存的用户密码</param>
        /// <returns>所有交易哈希的列表</returns>
        public async Task<List<string>> SaveDataToChainAsync(object obj, string address, string password)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dataList = GetLegalSizeList(json);
            var dataSave = new DataSave();
            var hashList = new List<string>();

            foreach (var data in dataList)
            {
                var resHash = dataSave.SaveDataToChain(data, address, password);
                if (resHash == null) new Exception("Data cannot be written to the blockchain！");
                hashList.Add(await resHash);
            }

            return hashList;
        }


        /// <summary>
        /// 获得合法小于32kb大小的数据列表
        /// </summary>
        /// <param name="data">需要转换的字符串数据</param>
        /// <returns>一个数据列表，数据连续且每项小于32kb</returns>
        protected List<string> GetLegalSizeList(string data)
        {
            int LimitBlockByteSize = 31744;
            var list = new List<string>();

            if (data.Length / 2 <= LimitBlockByteSize)
            {
                list.Add(data);
                return list;
            }

            string temp;
            while ((temp = bSubstring(ref data, LimitBlockByteSize)) != null)
            {
                list.Add(temp);
            }
            return list;
        }


        /// <summary>
        /// 指定大小分割字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="length">需要分割的大小</param>
        /// <returns>从0长度到指定长度的字符串</returns>
        private string bSubstring(ref string s, int length)
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
    }
}
