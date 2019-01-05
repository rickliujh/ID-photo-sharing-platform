using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EthImgStorage_Web_API.Models.DataTransationModels;
using ChainAccess.Ethereum.DateAccess;

namespace EthImgStorage_Web_API.Controllers.DataController
{
    [Route("api/data/[controller]")]
    [ApiController]
    public class SendTextController : ControllerBase
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