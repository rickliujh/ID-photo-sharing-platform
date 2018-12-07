using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IdPhotoSharingPlatform_Client.Http
{
    class HttpPost
    {
        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 发起httpPost 请求.
        /// </summary>
        /// <param name="url">请求的地址</param>
        /// <param name="files">文件</param>
        /// <param name="input">表单数据</param>
        /// <param name="endoding">编码</param>
        /// <returns></returns>
        public static string PostResponse(string url, Dictionary<string, string> input, Encoding endoding)
        {
            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            //request.Credentials = CredentialCache.DefaultCredentials;
            request.Expect = "";

            MemoryStream stream = new MemoryStream();

            byte[] line = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            byte[] enterER = Encoding.ASCII.GetBytes("\r\n");

            //提交文本字段
            if (input != null)
            {
                string format = "--" + boundary + "\r\nContent-Disposition:form-data;name=\"{0}\"\r\n\r\n{1}\r\n";    //自带项目分隔符
                foreach (string key in input.Keys)
                {
                    string s = string.Format(format, key, input[key]);
                    byte[] data = Encoding.UTF8.GetBytes(s);
                    stream.Write(data, 0, data.Length);
                }

            }

            byte[] foot_data = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");      //项目最后的分隔符字符串需要带上--  
            stream.Write(foot_data, 0, foot_data.Length);

            request.ContentLength = stream.Length;
            Stream requestStream = request.GetRequestStream(); //写入请求数据
            stream.Position = 0L;
            stream.CopyTo(requestStream); //
            stream.Close();

            requestStream.Close();

            try
            {
                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    try
                    {
                        using (var responseStream = response.GetResponseStream())
                        using (var mstream = new MemoryStream())
                        {
                            responseStream.CopyTo(mstream);
                            string message = endoding.GetString(mstream.ToArray());
                            return message;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                catch (WebException ex)
                {
                    //response = (HttpWebResponse)ex.Response;


                    //if (response.StatusCode == HttpStatusCode.BadRequest)
                    //{
                    //    using (Stream data = response.GetResponseStream())
                    //    {
                    //        using (StreamReader reader = new StreamReader(data))
                    //        {
                    //            string text = reader.ReadToEnd();
                    //            Console.WriteLine(text);
                    //        }
                    //    }
                    //}
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string PostUrl(string url, string postData)
        {
            string result = "";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";

            req.Timeout = 2000;//设置请求超时时间，单位为毫秒

            req.ContentType = "application/json";

            byte[] data = Encoding.UTF8.GetBytes(postData);

            req.ContentLength = data.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
