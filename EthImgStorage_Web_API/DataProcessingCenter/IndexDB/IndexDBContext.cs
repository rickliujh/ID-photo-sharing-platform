using Microsoft.EntityFrameworkCore;

namespace DataProcessingCenter.IndexDB
{
    public class IndexDBContext : DbContext
    {
        public virtual DbSet<IndexDBs> indexs { get; set; }
    }
}
