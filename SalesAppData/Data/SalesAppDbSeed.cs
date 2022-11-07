using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SalesApp.Core.Entities;

namespace SalesAppData.Data
{
    public class SalesAppDbSeed
    {
        //private static IEnumerable<Product> GetPreConfiguredProducts()
        //{
        //    var products = new List<Product>
        //    {
        //        new Product{ Brand="Samsung", Price=20000, CreatedDateTime=DateTime.Now},
        //        new Product{ Brand="Apple", Price=50000, CreatedDateTime=DateTime.Now},
        //    };
        //    return products;
        //}
        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Brand="Samsung",
                    ImageUrl="",
                    Description="Samsung",
                    ModelName="S22 512 Gb",
                    ReceivingPrice = 499,
                    Price=399,
                    CreatedDateTime = DateTime.Now
                    //CategoryId=107,
                    //CoverTypeId=100
                }
            };
            return products;
        }


        public static async Task SeedAsync(SalesAppDbcontext dbContext, ILoggerFactory loggerFactory, int? retryAttempt = 0)
        {
            int retryCount = retryAttempt ?? 0;
            try
            {
                dbContext.Database.Migrate();
                if (!dbContext.Products.Any())
                {
                    var products = GetPreConfiguredProducts();
                    dbContext.Products.AddRange(products);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryCount < 5)
                {
                    retryCount++;
                    var logger = loggerFactory.CreateLogger<SalesAppDbcontext>();
                    logger.LogError(ex.Message);
                    await SeedAsync(dbContext, loggerFactory, retryAttempt);
                }
                throw;
            }
        }
    }
}
