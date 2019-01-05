using Microsoft.EntityFrameworkCore;

namespace EthImgStorage_Web_API.Models.DataBase
{
    public class PlatformDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LegalPersonData> LegalPersonDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=IdPlatformIndexDB;Uid=root;Pwd=123456;SslMode=none");
        }
    }
}
