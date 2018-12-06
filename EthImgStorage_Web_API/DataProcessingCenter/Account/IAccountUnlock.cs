using System.Threading.Tasks;

namespace DataProcessingCenter.Account
{
    public interface IAccountUnlock
    {
        Task<bool> UnlockAccountAsync(string gethConnectionUrl, string address, string password);
    }
}
