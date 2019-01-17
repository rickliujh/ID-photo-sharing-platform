using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EthImgStorage_Web_API.Models;

namespace EthImgStorage_Web_API.Controllers.DataController
{
    [Route("api/data/[controller]")]
    [ApiController]
    public class AddPersonController : ApiControllerBase
    {
        public ChainModel ChainModel { get; set; }

        public AddPersonController()
        {
            ChainModel = new ChainModel();
        }

        //[HttpPost]
        //public async Task<IActionResult> AddPersonPost()
        //{
        //}
    }
}