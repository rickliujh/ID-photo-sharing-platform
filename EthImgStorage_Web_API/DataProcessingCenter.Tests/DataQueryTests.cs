using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DataProcessingCenter.DataProcessor;
using DataProcessingCenter.Tests.TestDb;

namespace DataProcessingCenter.Tests
{
    public class DataQueryTests
    {
        public string url = "http://localhost:8080/";
        public string TestID1 = "3500321432543574646";
        public string Name = "王大锤";
        public string IdPhotoData = "Hello,World";
        [Fact]
        public async void DataQueryTests_shortWork()
        {
            var dq = new DataQuery();
            var reslut = await dq
                .PriKeyQueryAsync(url, new MyIndexDbContext(), new MyTransationData(), TestID1,
               null);
            var reslut1 = reslut as MyTransationData;
            Assert.Equal(reslut1.IdPhotoData, IdPhotoData);

            //Assert.Equal(reslut1.Name, Name);
            //(a, b) =>
            //{
            //    var td = a as MyTransationData;
            //    var id = b as MyIndexDb;
            //    td.Name = id.Name;
            //    return td;
            //}
        }
    }
}
