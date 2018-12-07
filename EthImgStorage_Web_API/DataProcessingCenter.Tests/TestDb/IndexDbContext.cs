using Microsoft.EntityFrameworkCore;
using DataProcessingCenter.IndexDB;

namespace DataProcessingCenter.Tests.TestDb
{
    class MyIndexDbContext : IndexDBContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=IdPlatformIndexDB_Test;Uid=Development;Pwd=123456;SslMode=none");
        }
    }
}
