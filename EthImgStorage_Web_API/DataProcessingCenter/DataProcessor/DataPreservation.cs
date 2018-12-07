using System;
using System.Threading.Tasks;
using DataProcessingCenter.Account;
using DataProcessingCenter.IndexDB;
using Microsoft.EntityFrameworkCore;
using Nethereum.Geth;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;

namespace DataProcessingCenter.DataProcessor
{
    public class DataPreservation : IDataPreservation
    {
        public async Task<bool> SaveDataAsync(string gethConnectionUrl, IAccountUnlock accuntUnlock, IndexDBContext dbContext, IndexDBs indexDB, ITransationData transationData)
        {
            ISuitableBlockData suitableData = new SuitableBlockData(31744);
            //获取适合保存到以太坊区块中的字符串长度
            var photoStrings = suitableData.GetArrayListForSaving(transationData.IdPhotoData);

            //保存到以太坊网络中
            var web3 = new Web3Geth(gethConnectionUrl);
            string resultHashs = null;
            foreach (var photoString in photoStrings)
            {
                var input = new TransactionInput(new HexUTF8String(photoString).HexValue, new HexBigInteger("0xffffff"), transationData.Address);
                await accuntUnlock.UnlockAccountAsync(gethConnectionUrl, transationData.Address, transationData.Password);
                resultHashs += await web3.Eth.Transactions
                    .SendTransaction
                    .SendRequestAsync(input) + " ";
            }

            //将交易哈希与个人信息保存到索引数据库
            var isSuccessful = await SaveTxHashToIndexDB(dbContext, indexDB, transationData, resultHashs);
            if (!isSuccessful) return false;
            return true;
        }



        protected virtual async Task<bool> SaveTxHashToIndexDB(IndexDBContext dbContext, IndexDBs indexDB, ITransationData transationData, string HashString)
        {
            indexDB.ID = transationData.ID;
            indexDB.AccountAddress = transationData.Address;
            indexDB.TransationHash = HashString;

            try
            {
                await dbContext.indexs.AddAsync(indexDB);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
