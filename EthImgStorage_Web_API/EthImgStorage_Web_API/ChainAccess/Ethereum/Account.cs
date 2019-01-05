using System;
using System.Threading.Tasks;

namespace ChainAccess.Ethereum
{
    public class Account : EthereumBase
    {
        /// <summary>
        /// 创建账户
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<string> CreateAccountAsync(string password)
        {
            var result = await Web3.Personal
                .NewAccount
                .SendRequestAsync(password);
            return result;
        }

        /// <summary>
        /// 解锁账户
        /// </summary>
        /// <param name="address">账户地址</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<bool> UnlockAccountAsync(string address, string password)
        {
            try
            {
                ulong? ul = 1;
                for (int i = 0; i < 5; i++)
                {
                    var result = await Web3.Personal.UnlockAccount.SendRequestAsync(address, password, ul);
                    if (result)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
