using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChainAccess.Ethereum.DateAccess;

namespace EthImgStorage_Web_API.Controllers.DataController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(string transationId)
        {
            DataRead dataRead = new DataRead();
            var result = await dataRead.GetDataFromChain(transationId);
            return new JsonResult(new { data = result });
        }
    }
}