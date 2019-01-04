using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Public_Interface.Chain
{
    public interface IChainDataStorage
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="transactionId">返回事物ID号</param>
        /// <returns></returns>
        Task<bool> SaveData(object data, out string transactionId);
    }
}
