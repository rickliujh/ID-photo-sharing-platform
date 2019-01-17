using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EthImgStorage_Web_API.Models;

namespace EthImgStorage_Web_API.Controllers.DataController
{
    [Route("api/data/[controller]")]
    [ApiController]
    public class UserListController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetUserList(double limit = 1000)
        {
            var dBcontext = new IndexDbContext();
            var indexs = await dBcontext.indexs.ToListAsync();
            return new JsonResult(indexs);
        }
    }
}