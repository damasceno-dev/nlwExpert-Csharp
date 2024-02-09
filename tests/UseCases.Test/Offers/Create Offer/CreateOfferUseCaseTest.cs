using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatAuction.API.Comunication.Requests;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;
using RocketSeatAuction.API.Enums;
using RocketSeatAuction.API.Services;
using RocketSeatAuction.API.UseCases.Auctions.GetCurrent;

namespace UseCases.Test.Offers.CreateOffer
{
	public class CreateOfferUseCaseTest
	{

        [Theory]
		[InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Success(int itemId)
		{
			//Arrange
			var requestBogus = new Faker<RequestCreateOfferJson>()
				.RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();

			var offerRepositoryMock = new Mock<IOfferRepository>();
			var loggedUser = new Mock<ILoggedUser>();
			loggedUser.Setup(i => i.User()).Returns(new User());

			var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepositoryMock.Object);

			//Act
			var act = () => useCase.Execute(itemId, requestBogus);

			//Assert
			act.Should().NotThrow();
		}

	}
}

