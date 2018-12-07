using System;
using System.Collections.Generic;
using System.Text;
using DataProcessingCenter.IndexDB;

namespace DataProcessingCenter.Tests.TestDb
{
    class MyIndexDb : IndexDBs
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string AccountAddress { get; set; }
        public string TransationHash { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
