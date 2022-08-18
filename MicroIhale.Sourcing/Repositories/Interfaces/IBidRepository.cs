using MicroIhale.Sourcing.Entities;

namespace MicroIhale.Sourcing.Repositories.Interfaces
{
    public interface IBidRepository
    {
        Task SendBind(Bid bid);
        Task<List<Bid>> GetBidsByAuctionId(string id);
        Task<Bid> GetWinnerBid(string id);

    }
}
