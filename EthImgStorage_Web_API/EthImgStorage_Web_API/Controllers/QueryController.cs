using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProcessingCenter.DataProcessor;
using EthImgStorage_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EthImgStorage_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        string url = "http://localhost:8080/";

        // GET: api/Query
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Query/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            var qd = new DataQuery();
            var dbContext = new IndexDbContext();
            var td = new TransationData();
            var result = await qd.PriKeyQueryAsync(url, dbContext, td, id, null);
            var transData = new TransData();
            transData.IdCard = result.ID;
            transData.IdPhotoData = result.IdPhotoData;
            return new JsonResult(transData);
        }

        // POST: api/Query
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Query/5
        [HttpPut("{id}")]
        public async void PutQuery([FromBody] TransData values)
        {

            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
