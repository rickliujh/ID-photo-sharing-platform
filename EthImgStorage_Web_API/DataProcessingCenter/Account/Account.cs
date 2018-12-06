using Nethereum.Geth;
using System.Threading.Tasks;

namespace DataProcessingCenter.Account
{
    public class Account : IAccountCreate, IAccountUnlock
    {
        public async Task<string> CreateAccountAsync(string gethConnectionUrl, string password)
        {

            Web3Geth web3 = new Web3Geth(gethConnectionUrl);
            var result = await web3.Personal.NewAccount.SendRequestAsync(password);
            return result;
        }

        public async Task<bool> UnlockAccountAsync(string gethConnectionUrl, string address, string password)
        {
            Web3Geth web3 = new Web3Geth(gethConnectionUrl);
            ulong? ul = null;
            var result = await web3.Personal.UnlockAccount.SendRequestAsync(address, password, ul);
            return result;
        }
    }
}
