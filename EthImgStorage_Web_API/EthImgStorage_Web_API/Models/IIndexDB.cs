using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthImgStorage_Web_API.Models
{
    interface IIndexDB
    {
        string ID { get; set; }
        string AccountAddress { get; set; }
        string TransationHash { get; set; }
        DateTime LastUpdate { get; set; }
    }
}
