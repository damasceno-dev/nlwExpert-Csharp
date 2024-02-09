using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.UseCases.Auctions.GetCurrent
{
	public class GetCurrentAuctionUseCase
	{

		private readonly IAuctionRepository _repository;
		public GetCurrentAuctionUseCase(IAuctionRepository repository)
		{
			_repository = repository;
		}
		public Auction? Execute()
		{
			return _repository.GetCurrent();
		}
	}
}

