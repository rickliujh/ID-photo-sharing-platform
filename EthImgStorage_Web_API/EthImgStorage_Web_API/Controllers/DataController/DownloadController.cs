using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChainAccess.Ethereum.DateAccess;

namespace EthImgStorage_Web_API.Controllers.DataController
{
    [Route("api/data/[controller]")]
    [ApiController]
    public class DownloadController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string transationId)
        {
            var result = await DownloadText(transationId);
            return result;
        }

        [HttpGet("{transationId}")]
        public async Task<IActionResult> Get(string transationId)
        {
            var result = await DownloadText(transationId);
            return result;
        }

        public async Task<IActionResult> DownloadText(string transationId)
        {
            try
            {
                DataRead dataRead = new DataRead();
                var result = await dataRead.GetDataFromChain(transationId);
                return new JsonResult(new { data = result });
            }
            catch (Exception e)
            {
                return new JsonResult(new { error = e.Message });
            }
        }
    }
}