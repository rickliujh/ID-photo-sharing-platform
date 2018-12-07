using System;
using System.Threading.Tasks;
using DataProcessingCenter.IndexDB;
using Microsoft.EntityFrameworkCore;

namespace DataProcessingCenter.DataProcessor
{
    public interface IDataQuery
    {
        T GetIndexDbListAsync<T>(IndexDBContext dbContext, T returnList, Func<DbContext, T, T> getList);
        Task<ITransationData> PriKeyQueryAsync(string gethConnectionUrl, IndexDBContext dbContext, ITransationData transationData, string ID, Func<ITransationData, IndexDB.IndexDBs, ITransationData> requiredData);
    }
}
