using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthImgStorage_Web_API.Models.AccountModels;

namespace EthImgStorage_Web_API.Models.DataTransationModels
{
    public class SendTextModel : SignIn
    {
        public string Data { get; set; }
    }
}
