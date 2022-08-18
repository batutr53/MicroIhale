using MicroIhale.Sourcing.Entities;
using MongoDB.Driver;

namespace MicroIhale.Sourcing.Data
{
    public class SourcingContextSeed
    {
        public static void SeedData(IMongoCollection<Auction> auctionCollection)
        {
            bool exist = auctionCollection.Find(p => true).Any();
            if (!exist)
            {
                auctionCollection.InsertManyAsync(GetPreconfigureAuction());
            }
        }

        private static IEnumerable<Auction> GetPreconfigureAuction()
        {
            return new List<Auction>()
            {
                new Auction() 
                {
                    Name = "Auction 1",
                    Description = "Auction desc ",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    ProductId = "600512354789654125487",
                    IncludedSellers = new List<string>()
                    {
                        "test1@test.com",
                        "test2@test.com",
                        "test3@test.com"
                    },
                    Quantity = 5,
                    Status=(int)Status.Active
                },
                  new Auction()
                {
                    Name = "Auction 2",
                    Description = "Auction desc 2 ",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    ProductId = "600512354789654125487",
                    IncludedSellers = new List<string>()
                    {
                        "test1@test.com",
                        "test2@test.com",
                        "test3@test.com"
                    },
                    Quantity = 5,
                    Status=(int)Status.Active
                },
                    new Auction()
                {
                    Name = "Auction 3",
                    Description = "Auction desc 3",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    ProductId = "600512354789654125487",
                    IncludedSellers = new List<string>()
                    {
                        "test1@test.com",
                        "test2@test.com",
                        "test3@test.com"
                    },
                    Quantity = 5,
                    Status=(int)Status.Active
                }
            };
        }
    }
}
