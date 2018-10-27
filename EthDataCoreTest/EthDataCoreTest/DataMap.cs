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

        public static async Task<bool> AddImageToMapAsync(string Name, string Address, string TxHash)
        {
            var dbContext = new ImageDataMapContext();
            try
            {
                await dbContext.DataMaps.AddAsync(new ImageDataMap
                {
                    AccountAddress = Address,
                    ImageName = Name,
                    TransactionHash = TxHash,
                    PublishTime = DateTime.Now
                });
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static async Task<List<ImageDataMap>> GetTxHashForAddressAsync(string sendAddress)
        {
            try
            {
                var AddressData = await dbContext.DataMaps.Where(t => t.AccountAddress == sendAddress).ToListAsync();
                //List<string> Imagenames = new List<string>();
                //foreach (var item in AddressData)
                //{
                //    Imagenames.Add(item.ImageName);
                //}
                //return Imagenames;
                return AddressData;
            }
            catch (Exception e)
            {
                throw;
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<List<ImageDataMap>> GetTxHashAsync()
        {
            try
            {
                var AddressData = await dbContext.DataMaps.ToListAsync();
                //List<string> Imagenames = new List<string>();
                //foreach (var item in AddressData)
                //{
                //    Imagenames.Add(item.ImageName);
                //}
                //return Imagenames;
                return AddressData;
            }
            catch (Exception e)
            {
                throw;
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<string> GetTxHashForImageNameAsync(string ImageName)
        {
            try
            {
                var imageDataMap = await dbContext.DataMaps.SingleOrDefaultAsync(t => t.ImageName == ImageName);
                return imageDataMap.TransactionHash;
            }
            catch (Exception e)
            {
                throw;
                return e.Message;
            }
        }

        public static async Task<bool> ChangeImageNameAsync(string CurrentImageName, string ChangeImageName)
        {
            try
            {
                var AddressData = await dbContext.DataMaps.SingleOrDefaultAsync(t => t.ImageName == CurrentImageName);
                AddressData.ImageName = ChangeImageName;
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw;
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<bool> RemoveImageAsync(string ImageName)
        {
            throw new NotImplementedException();
            try
            {
                var AddressData = await dbContext.DataMaps.SingleOrDefaultAsync(t => t.ImageName == ImageName);
                dbContext.DataMaps.Remove(AddressData);
                await dbContext.SaveChangesAsync();
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
