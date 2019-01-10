using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EthImgStorage_Web_API.Controllers.DataController
{
    [Route("api/data/[controller]")]
    [ApiController]
    public class LegalPersonListController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostUserList()
        {
            Message.Code = 0;
            Message.Msg = "Success!";

            var result = await Task.Run(() =>
            {
                return DbContext
                .LegalPersonDatas
                .Select(s => new
                {
                    s.ID,
                    s.Name,
                    s.BirthDay,
                    s.CompanyName,
                    s.LastModified
                }).ToList();
            });

            if (result.Count == 0)
            {
                Message.Code = 1;
                Message.Error = "No data!";
            }

            return new JsonResult(new { Message, list = result });
        }
    }
}