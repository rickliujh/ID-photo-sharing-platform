using System;
using System.Threading.Tasks;
using DataProcessingCenter.IndexDB;
using Microsoft.EntityFrameworkCore;
using Nethereum.Geth;

namespace DataProcessingCenter.DataProcessor
{
    public class DataQuery : IDataQuery
    {
        public T GetIndexDbListAsync<T>(IndexDBContext dbContext, T returnList, Func<DbContext, T, T> getList)
        {
            T result = getList.Invoke(dbContext, returnList);
            return result;

            ///<example>
            ///indexDbContext = dbContext as IndexDBContext;
            ///returnList = indexDbContext;
            ///return returnList;
            /// </example>
        }

        public async Task<ITransationData> PriKeyQueryAsync(string gethConnectionUrl, IndexDBContext dbContext, ITransationData transationData, string ID, Func<ITransationData, IndexDB.IndexDBs, ITransationData> requiredData)
        {
            string IdPhotoData = null;
            //从索引数据库拿到交易哈希列表字符串
            var dataIndex = await GetTxHashFormIndexDBAsnyc(dbContext, ID);
            //拆分成交易哈希字符串数字
            string[] TxHashs = dataIndex.TransationHash.Trim().Split(' ');
            //使用交易哈希得到私链中保存的图片数据片段
            var web3 = new Web3Geth(gethConnectionUrl);
            foreach (var Txhash in TxHashs)
            {
                var result = await web3.Eth.Transactions
                    .GetTransactionByHash
                    .SendRequestAsync(Txhash);
                //拼接片段
                IdPhotoData += new Nethereum.Hex.HexConvertors
                    .HexUTF8StringConvertor()
                    .ConvertFromHex(result.Input);
            }
            //将数据转换成传输模型
            transationData.IdPhotoData = IdPhotoData;
            transationData.ID = dataIndex.ID;
            transationData.Address = dataIndex.AccountAddress;
            //如果没有委托，直接返回
            if (requiredData == null) return transationData;
            //使用委托使得用户可以实现传输模型接口,自定义需要获得的数据
            transationData = requiredData.Invoke(transationData, dataIndex);
            return transationData;
        }

        protected virtual async Task<IndexDB.IndexDBs> GetTxHashFormIndexDBAsnyc(IndexDBContext dbContext, string ID)
        {
            try
            {
                var result = await dbContext.indexs.SingleOrDefaultAsync(db => db.ID == ID);
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}