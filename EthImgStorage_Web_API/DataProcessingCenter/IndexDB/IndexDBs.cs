using System;

namespace DataProcessingCenter.IndexDB
{
    public class IndexDBs
    {
        public virtual string ID { get; set; }
        public virtual string AccountAddress { get; set; }
        public virtual string TransationHash { get; set; }
        public virtual DateTime LastUpdate { get; set; }
    }
}
