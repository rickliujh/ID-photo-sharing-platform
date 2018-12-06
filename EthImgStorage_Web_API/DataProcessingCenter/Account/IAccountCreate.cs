using System.Threading.Tasks;

namespace DataProcessingCenter.Account
{
    public interface IAccountCreate
    {
        Task<string> CreateAccountAsync(string gethConnectionUrl, string password);
    }
}
