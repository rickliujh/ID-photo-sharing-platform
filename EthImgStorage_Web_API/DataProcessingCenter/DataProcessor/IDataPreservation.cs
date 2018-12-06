using System.Threading.Tasks;
using DataProcessingCenter.Account;
using Microsoft.EntityFrameworkCore;
using DataProcessingCenter.IndexDB;

namespace DataProcessingCenter.DataProcessor
{
    public interface IDataPreservation
    {
        Task<bool> SaveDataAsync(string gethConnectionUrl, IAccountUnlock accuntUnlock, IndexDBContext dbContext, IndexDB.IndexDBs indexDB, ITransationData transationData);
    }
}
