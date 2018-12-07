using System.Collections.Generic;

namespace DataProcessingCenter.DataProcessor
{
    public class SuitableBlockData : ISuitableBlockData
    {
        public int LimitBlockByteSize { get; set; }

        public SuitableBlockData()
        {
            LimitBlockByteSize = 1024;
        }

        public SuitableBlockData(int limitBlockSize)
        {
            LimitBlockByteSize = limitBlockSize;
        }

        public virtual List<string> GetArrayListForSaving(string data)
        {
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

        public virtual string bSubstring(ref string s, int length)
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
