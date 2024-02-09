using System;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Repositories.DataAccess
{
	public class UserRepository : IUserRepository
    {
		private readonly RocketSeatAuctionDbConext _dbContext;
		public UserRepository(RocketSeatAuctionDbConext dbContext)
		{
			_dbContext = dbContext;
		}

		public bool ExistUserWithEmail(string email)
		{
			return _dbContext.Users.Any(u => u.Email.Equals(email));
        }

		public User GetUserByEmail(string email)
		{
            return _dbContext.Users.First(u => u.Email.Equals(email));
        }
	}
}

