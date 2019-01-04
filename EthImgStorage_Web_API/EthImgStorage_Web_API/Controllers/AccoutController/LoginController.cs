using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataProcessingCenter.Account;
using EthImgStorage_Web_API.Models;
using System.Text;

namespace EthImgStorage_Web_API.Controllers.AccoutController
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        string url = "http://localhost:8080/";

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAccount user)
        {
            var ac = new Account();
            var isSuccess = await ac.UnlockAccountAsync(url, user.Account, user.Password);
            return new JsonResult(isSuccess);
        }
    }
}
