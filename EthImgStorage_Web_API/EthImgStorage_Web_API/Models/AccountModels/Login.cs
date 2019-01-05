using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthImgStorage_Web_API.Models.AccountModels
{
    public class Login
    {
        public string AdminAccount { get; set; }
        public string AdminPassword { get; set; }
        public string NewAccountPassword { get; set; }
    }
}
