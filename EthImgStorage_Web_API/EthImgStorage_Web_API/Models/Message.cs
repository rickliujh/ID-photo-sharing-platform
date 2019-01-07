using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthImgStorage_Web_API.Models
{
    public class Message
    {
        public int Code { get; set; }
        public string Error { get; set; }
        public string Msg { get; set; }
    }
}
