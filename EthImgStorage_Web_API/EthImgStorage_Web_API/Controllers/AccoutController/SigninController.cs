using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EthImgStorage_Web_API.Models;
using System.Text;
using ChainAccess.Ethereum;

namespace EthImgStorage_Web_API.Controllers.AccoutController
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class SigninController : ControllerBase
    {
        string url = "http://localhost:8080/";

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAccount user)
        {
            var account = new Account();
            account.ConnectionUrl = url;
            var isSuccess = await account.UnlockAccountAsync(user.Account, user.Password);
            return new JsonResult(isSuccess);
        }
    }
}
