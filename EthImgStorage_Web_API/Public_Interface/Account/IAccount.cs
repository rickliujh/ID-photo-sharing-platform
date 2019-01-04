using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Public_Interface.Account
{
    public interface IAccount
    {
        /// <summary>
        /// 创建新账户
        /// </summary>
        /// <param name="id">手机号</param>
        /// <param name="name">账户名称</param>
        /// <param name="password">账户密码</param>
        /// <param name="msg">账户ID</param>
        /// <returns></returns>
        Task<bool> CreateNewAccount(int id, string name, string password, out string msg);

        /// <summary>
        /// 解锁某个账户
        /// </summary>
        /// <param name="id">账户名称</param>
        /// <param name="password">账户密码</param>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        Task<bool> UnlockAccount(int id, string password, out string msg);

        /// <summary>
        /// 停用某账户
        /// </summary>
        /// <param name="id">账户名称</param>
        /// <param name="password">账户密码</param>
        /// <returns></returns>
        Task<bool> DisableAccount(int id, string password);
    }
}
