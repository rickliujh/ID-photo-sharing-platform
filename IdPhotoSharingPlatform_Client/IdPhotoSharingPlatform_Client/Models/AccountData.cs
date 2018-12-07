using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdPhotoSharingPlatform_Client.Models
{
    public class AccountData
    {
        public string Address { get; set; }
        public string Password { get; set; }

        public AccountData()
        {

        }

        public AccountData(string address, string password)
        {
            Address = address;
            password = password;
        }
    }
}
