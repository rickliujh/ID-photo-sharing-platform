using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EthImgStorage_Web_API.Models.DataTransationModels;
using ChainAccess.Ethereum.DateAccess;

namespace EthImgStorage_Web_API.Controllers.DataController
{
    [Route("api/data/[controller]")]
    [ApiController]
    public class SendTextController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SendTextModel sendData)
        {
            try
            {
                DataSave dataSave = new DataSave();
                var result = await dataSave
                    .SaveDataToChain(
                        sendData.Data,
                        sendData.Account,
                        sendData.Password
                    );
                return new JsonResult(new { transationHash = result });
            }
            catch (Exception e)
            {
                return new JsonResult(new { error = e.Message });
            }
        }
    }
}