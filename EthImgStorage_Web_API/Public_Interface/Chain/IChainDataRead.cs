using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Public_Interface.Chain
{
    public interface IChainDataRead
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="transactionId">事物ID号</param>
        /// <returns>数据</returns>
        Task<string> GetData(string transactionId);
    }
}
