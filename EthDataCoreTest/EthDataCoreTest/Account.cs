using Nethereum.Geth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    class Account
    {
        private string url { get; set; }

        //Incoming url calls privatechain via http
        public Account(string Url)
        {
            url = Url;
        }

        public async Task<string> NewAccountAsync(string Password)
        {
            Web3Geth Web3 = new Web3Geth(url);
            var result = await Web3.Personal.NewAccount.SendRequestAsync(Password);
            return result;
        }
    }
}
