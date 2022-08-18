using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed : IEntityTypeConfiguration<Order>
    {
        /* public static async Task SeedAsync(OrderContext orderContext)
         {
             if (!orderContext.Orders.Any())
             {
                 orderContext.Orders.AddRange(GetPreconfigureOrders());
                 await orderContext.SaveChangesAsync();
             }
         }

         private static IEnumerable<Order> GetPreconfigureOrders()
         {
             return new List<Order>()
             {
                 new Order()
                 {
                     AuctionId = Guid.NewGuid().ToString(),
                     ProductId = Guid.NewGuid().ToString(),
                     SellerUserName = "test@test.com",
                     UnitPrice = 10,
                     TotalPrice = 1000,
                     CreatedAt = DateTime.UtcNow
                 },
                 new Order()
                 {
                     AuctionId = Guid.NewGuid().ToString(),
                     ProductId = Guid.NewGuid().ToString(),
                     SellerUserName = "test1@test.com",
                     UnitPrice = 10,
                     TotalPrice = 1000,
                     CreatedAt = DateTime.UtcNow
                 },
                 new Order()
                 {
                     AuctionId = Guid.NewGuid().ToString(),
                     ProductId = Guid.NewGuid().ToString(),
                     SellerUserName = "test2@test.com",
                     UnitPrice = 10,
                     TotalPrice = 1000,
                     CreatedAt = DateTime.UtcNow
                 },
                 new Order()
                 {
                     AuctionId = Guid.NewGuid().ToString(),
                     ProductId = Guid.NewGuid().ToString(),
                     SellerUserName = "test3@test.com",
                     UnitPrice = 10,
                     TotalPrice = 1000,
                     CreatedAt = DateTime.UtcNow
                 },
             };
         }*/
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                 new Order()
                 {
                     Id =1,
                     AuctionId = Guid.NewGuid().ToString(),
                     ProductId = Guid.NewGuid().ToString(),
                     SellerUserName = "test@test.com",
                     UnitPrice = 10,
                     TotalPrice = 1000,
                     CreatedAt = DateTime.UtcNow
                 },
                  new Order()
                  {
                      Id = 2,
                      AuctionId = Guid.NewGuid().ToString(),
                      ProductId = Guid.NewGuid().ToString(),
                      SellerUserName = "test1@test.com",
                      UnitPrice = 10,
                      TotalPrice = 1000,
                      CreatedAt = DateTime.UtcNow
                  },
                  new Order()
                  {
                      Id = 3,
                      AuctionId = Guid.NewGuid().ToString(),
                      ProductId = Guid.NewGuid().ToString(),
                      SellerUserName = "test2@test.com",
                      UnitPrice = 10,
                      TotalPrice = 1000,
                      CreatedAt = DateTime.UtcNow
                  },
                  new Order()
                  {
                      Id = 4,
                      AuctionId = Guid.NewGuid().ToString(),
                      ProductId = Guid.NewGuid().ToString(),
                      SellerUserName = "test3@test.com",
                      UnitPrice = 10,
                      TotalPrice = 1000,
                      CreatedAt = DateTime.UtcNow
                  }
                );
        }
    }
}
