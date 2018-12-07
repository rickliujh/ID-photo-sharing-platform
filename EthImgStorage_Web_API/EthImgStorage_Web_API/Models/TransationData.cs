using DataProcessingCenter.IndexDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthImgStorage_Web_API.Models
{
    public class TransationData : ITransationData
    {
        public string Address { get; set; }
        public string Password { get; set; }
        public string ID { get; set; }
        public string IdPhotoData { get; set; }
    }
}
