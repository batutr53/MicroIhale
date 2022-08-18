using MicroIhale.Sourcing.Data.Interface;
using MicroIhale.Sourcing.Entities;
using MicroIhale.Sourcing.Settings;
using MongoDB.Driver;

namespace MicroIhale.Sourcing.Data
{
    public class SourcingContext : ISourcingContext
    {
        public SourcingContext(ISourcingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Auctions = database.GetCollection<Auction>(nameof(Auction));
            Bids = database.GetCollection<Bid>(nameof(Bid));

            SourcingContextSeed.SeedData(Auctions);
        }
      public IMongoCollection<Auction> Auctions { get; }
      public IMongoCollection<Bid> Bids { get; }
    }
}
