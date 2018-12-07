using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataProcessingCenter.Account;
using EthImgStorage_Web_API.Models;

namespace EthImgStorage_Web_API.Controllers.AccoutController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        string url = "http://localhost:8080/";

        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        [HttpGet]
        public async Task<IActionResult> Get(string address, string password)
        {
            var ac = new Account();
            var isSuccess = await ac.UnlockAccountAsync(url, address, password);
            return new JsonResult(isSuccess);
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAccount user)
        {
            var ac = new Account();
            var isSuccess = await ac.UnlockAccountAsync(url, user.Account, user.Password);
            return new JsonResult(isSuccess);
        }

        // PUT: api/Login/5
        //[HttpPut("address",Name = "Put")]
        //public async Task<IActionResult> Put(string address, string password)
        //{

        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
