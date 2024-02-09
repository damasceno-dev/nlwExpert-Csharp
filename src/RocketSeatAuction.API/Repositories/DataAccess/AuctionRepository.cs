using System;
using Microsoft.EntityFrameworkCore;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Repositories.DataAccess
{
	public class AuctionRepository : IAuctionRepository
    {
		private readonly RocketSeatAuctionDbConext _dbContext;
		public AuctionRepository(RocketSeatAuctionDbConext dbConext)
		{
			_dbContext = dbConext;
		}
		//public AuctionRepository(RocketSeatAuctionDbConext dbConext) => _dbContext = dbConext;

		public Auction? GetCurrent()
		{
			var today = DateTime.Today;
			//var today = new DateTime(2024, 01, 20);
			return _dbContext.Auctions.Include(a => a.Items).FirstOrDefault(a => today >= a.Starts);
		}

	}
}

