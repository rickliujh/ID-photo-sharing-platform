using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChainAccess.Ethereum;
using EthImgStorage_Web_API.Models.AccountModels;

namespace EthImgStorage_Web_API.Controllers.AccoutController
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class SigninController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SignIn user)
        {
            var account = new Account();
            var isSuccess = await account.UnlockAccountAsync(user.Account, user.Password);
            return new JsonResult(new { isSuccess });
        }
    }
}
