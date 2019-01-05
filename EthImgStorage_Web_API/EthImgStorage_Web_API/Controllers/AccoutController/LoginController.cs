using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChainAccess.Ethereum;
using EthImgStorage_Web_API.Models.AccountModels;

namespace EthImgStorage_Web_API.Controllers.AccoutController
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login data)
        {
            var account = new Account();
            var isSuccess = await account.UnlockAccountAsync(data.AdminAccount, data.AdminPassword);
            if (!isSuccess)
            {
                string error_msg = "Account or Password wrong!";
                return new JsonResult(error_msg);
            }
            var address = await account.CreateAccountAsync(data.NewAccountPassword);
            return new JsonResult(new { address });
        }
    }
}