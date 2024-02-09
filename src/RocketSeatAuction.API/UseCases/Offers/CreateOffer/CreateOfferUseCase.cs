using RocketSeatAuction.API.Comunication.Requests;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;
using RocketSeatAuction.API.Services;

namespace RocketSeatAuction.API.UseCases.Auctions.GetCurrent
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _repository;
        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository)
        {
            _loggedUser = loggedUser;
            _repository = repository;
        }
        public int Execute(int itemId, RequestCreateOfferJson request)
        {

            var user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };

            _repository.Add(offer);

            return offer.Id;
        }
    }
}

