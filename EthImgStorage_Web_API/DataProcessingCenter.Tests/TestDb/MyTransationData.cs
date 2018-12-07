using System;
using System.Collections.Generic;
using System.Text;
using DataProcessingCenter.IndexDB;

namespace DataProcessingCenter.Tests.TestDb
{
    class MyTransationData : ITransationData
    {
        public string Address { get; set; }
        public string Password { get; set; }
        public string ID { get; set; }
        public string IdPhotoData { get; set; }
        public string Name  { get; set; }
    }
}
