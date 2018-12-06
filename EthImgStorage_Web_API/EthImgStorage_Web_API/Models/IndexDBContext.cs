using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EthImgStorage_Web_API.Models
{
    public class IndexDBContext : DbContext
    {
        public virtual DbSet<IndexDB> Indexs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=localhost;Database=IdPlatformIndexDB;Uid=Development;Pwd=123456;SslMode=none");
        }
    }
}
