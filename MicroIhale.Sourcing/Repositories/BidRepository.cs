﻿using MicroIhale.Sourcing.Data.Interface;
using MicroIhale.Sourcing.Entities;
using MicroIhale.Sourcing.Repositories.Interfaces;
using MongoDB.Driver;

namespace MicroIhale.Sourcing.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ISourcingContext _context;

        public BidRepository(ISourcingContext context)
        {
            _context = context;
        }

        public async Task<List<Bid>> GetBidsByAuctionId(string id)
        {
            FilterDefinition<Bid> filter = Builders<Bid>.Filter.Eq(a => a.AuctionId, id);
            List<Bid> bids = await _context.Bids.Find(filter).ToListAsync();

            bids = bids.OrderByDescending(a => a.CreatedAt).GroupBy(a => a.SellerUserName)
                .Select(a => new Bid
                {
                    AuctionId = a.FirstOrDefault().AuctionId,
                    Price = a.FirstOrDefault().Price,
                    CreatedAt = a.FirstOrDefault().CreatedAt,
                    SellerUserName = a.FirstOrDefault().SellerUserName,
                    ProductId = a.FirstOrDefault().ProductId,
                    Id = a.FirstOrDefault().Id
                }).ToList();

            return bids;
        }

        public async Task<Bid> GetWinnerBid(string id)
        {
            List<Bid> bids = await GetBidsByAuctionId(id);

            return bids.OrderByDescending(a => a.Price).FirstOrDefault();
        }

        public async Task SendBind(Bid bid)
        {
            await _context.Bids.InsertOneAsync(bid);
        }
    }
}
