using System;

namespace EthImgStorage_Web_API.Models.DataBase
{
    public class User
    {
        public int ID { get; set; }
        public long Mobile { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EthereumAddress { get; set; }
        public string EthereumPassword { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LastSignInTime { get; set; }
        public string LastSignInIp { get; set; }
        public Character Character { get; set; }

    }

    public enum Character
    {
        administrator,
        Salesman,
        User,
    }
}
