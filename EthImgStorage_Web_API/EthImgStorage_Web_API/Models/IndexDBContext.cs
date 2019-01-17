using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataProcessingCenter.IndexDB;

namespace EthImgStorage_Web_API.Models
{
    class IndexDbContext : IndexDBContext
    {
        //public override DbSet<IndexDBs> indexs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=IdPlatformIndexDB;Uid=root;Pwd=123456;SslMode=none");
        }
    }
}
