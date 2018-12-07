using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProcessingCenter.IndexDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataProcessingCenter.DataProcessor;
using DataProcessingCenter.Account;
using EthImgStorage_Web_API.Models;

namespace EthImgStorage_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        string url = "http://localhost:8080/";

        // GET: api/Upload
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Upload/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Upload
        [HttpPost]
        public async void Post([FromBody] UploadData value)
        {
            var dbcontext = new IndexDBContext();
            var dp = new DataPreservation();
            var td = new TransationData();
            td.ID = value.IdCard;
            td.Address = value.SenderAddress;
            td.Password = value.SenderPassword;
            td.IdPhotoData = value.IdPhotoData;

            await dp.SaveDataAsync(url, new Account(), dbcontext, new IndexDBs(), td);
        }

        // PUT: api/Upload/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
