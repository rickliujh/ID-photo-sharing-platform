using Nethereum.Geth;
using System;
using System.Collections.Generic;
using System.Text;

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

        public string NewAccount(string Password)
        {
            Web3Geth Web3 = new Web3Geth(url);
            var task = Web3.Personal.NewAccount.SendRequestAsync(Password);
            var accountAddress = task.Result;
            return accountAddress;
        }
    }
}
