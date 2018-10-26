using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataProcess
{
    public class ImageDataMapContext : DbContext
    {
        public DbSet<ImageDataMap> DataMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=imageDataMap.db");
        }
    }
    public class ImageDataMap
    {
        [Key]
        public string ImageName { get; set; }
        public string AccountAddress { get; set; }
        public string TransactionHash { get; set; }
        public DateTime PublishTime { get; set; }
    }

    public static class DataMapOperator
    {
        private static ImageDataMapContext dbContext = new ImageDataMapContext();

        public static bool AddImageToMap(string Name, string Address, string TxHash)
        {
            var dbContext = new ImageDataMapContext();
            try
            {
                dbContext.DataMaps.Add(new ImageDataMap
                {
                    AccountAddress = Address,
                    ImageName = Name,
                    TransactionHash = TxHash,
                    PublishTime = DateTime.Now
                });
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        //public static List<string> GetTxHashForAddress(string sendAddress)
        //{
        //    try
        //    {
        //        var AddressData = dbContext.DataMaps.Where(t => t.AccountAddress == sendAddress).ToList();
        //        //List<string> Imagenames = new List<string>();
        //        //foreach (var item in AddressData)
        //        //{
        //        //    Imagenames.Add(item.ImageName);
        //        //}
        //        //return Imagenames;
        //        return AddressData;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;
        //        //throw;
        //    }
        //}

        public static string GetTxHashForImageName(string ImageName)
        {
            try
            {
                var imageDataMap = dbContext.DataMaps.SingleOrDefault(t => t.ImageName == ImageName);
                return imageDataMap.TransactionHash;
            }
            catch (Exception e)
            {
                throw;
                return e.Message;
            }
        }

        public static bool ChangeImageName(string CurrentImageName, string ChangeImageName)
        {
            try
            {
                var AddressData = dbContext.DataMaps.SingleOrDefault(t => t.ImageName == CurrentImageName);
                AddressData.ImageName = ChangeImageName;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                //throw;
            }
        }

        public static bool RemoveImage(string ImageName)
        {
            try
            {
                var AddressData = dbContext.DataMaps.SingleOrDefault(t => t.ImageName == ImageName);
                dbContext.DataMaps.Remove(AddressData);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                //throw;
            }
        }
    }
}
