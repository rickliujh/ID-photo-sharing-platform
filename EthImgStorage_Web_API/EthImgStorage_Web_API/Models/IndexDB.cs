using System;

namespace EthImgStorage_Web_API.Models
{
    public class IndexDB : IIndexDB
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string AccountAddress { get; set; }
        public string TransationHash { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
