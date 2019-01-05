using System;

namespace EthImgStorage_Web_API.Models.DataBase
{
    public class LegalPersonData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string CompanyName { get; set; }
        public string IdPhotoAddress { get; set; }
        public DateTime LastModified { get; set; }
    }
}
