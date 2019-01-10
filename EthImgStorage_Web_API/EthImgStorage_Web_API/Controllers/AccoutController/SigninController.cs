using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChainAccess.Ethereum;
using EthImgStorage_Web_API.Models.AccountModels;
using System.Linq;

namespace EthImgStorage_Web_API.Controllers.AccoutController
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class SigninController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SignIn data)
        {
            var account = new Account();

            var user = DbContext
                .Users
                .SingleOrDefault(u => u.Mobile == data.Mobile);

            if (user == null)
            {
                Message.Code = 1;
                Message.Error = "Account does not exist!";
                return new JsonResult(Message);
            }
            if (user.Password != MD5Encrypt16(data.Password))
            {
                Message.Code = 1;
                Message.Error = "Password is wrong!";
                return new JsonResult(Message);
            }

            Message.Code = 0;
            Message.Msg = "success!";
            return new JsonResult(new { Message = Message });
        }
    }
}
