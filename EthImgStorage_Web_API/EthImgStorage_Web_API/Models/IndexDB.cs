using System;
using DataProcessingCenter.IndexDB;

namespace EthImgStorage_Web_API.Models
{
    public class IndexDB : IndexDBs
    {
        public string Name { get; set; }
        public override DateTime LastUpdate
        {
            get
            {
                return LastUpdate;
            }
            set
            {
                value = DateTime.UtcNow;
            }
        }
    }
}
