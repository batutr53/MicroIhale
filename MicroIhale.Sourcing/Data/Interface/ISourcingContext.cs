using MicroIhale.Sourcing.Entities;
using MongoDB.Driver;

namespace MicroIhale.Sourcing.Data.Interface
{
    public interface ISourcingContext
    {
        public IMongoCollection<Auction> Auctions { get; }
        public IMongoCollection<Bid> Bids { get; }
    }
}
