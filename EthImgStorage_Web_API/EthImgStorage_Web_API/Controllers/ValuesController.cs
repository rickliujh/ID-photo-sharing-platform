using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProcessingCenter.IndexDB;
using EthImgStorage_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EthImgStorage_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var dbContext = new IndexDbContext();
            dbContext.indexs.Add(new IndexDBs
            {
                ID = "412355436",
                TransationHash = "afasdfdasfsf",
                AccountAddress = "asdfsafsaf",
                LastUpdate = DateTime.Now
            });
            dbContext.SaveChanges();
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
