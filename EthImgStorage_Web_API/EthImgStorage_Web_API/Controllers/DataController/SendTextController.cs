using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EthImgStorage_Web_API.Models.DataTransationModels;

namespace EthImgStorage_Web_API.Controllers.DataController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendTextController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SendTextModel sendData)
        {

        }
    }
}