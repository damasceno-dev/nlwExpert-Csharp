using System;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Repositories.DataAccess
{
	public class OfferRepository : IOfferRepository
	{
        private readonly RocketSeatAuctionDbConext _dbContext;
		public OfferRepository(RocketSeatAuctionDbConext dbConext)
        {
            _dbContext = dbConext;
        }
        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
        }
	}
}

