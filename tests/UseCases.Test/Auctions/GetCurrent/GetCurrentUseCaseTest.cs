using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;
using RocketSeatAuction.API.Enums;
using RocketSeatAuction.API.UseCases.Auctions.GetCurrent;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentUseCaseTest
	{
		[Fact]
		public void Success()
		{
			//AAA

			//Arrange
			var entity = new Auction
			{
				Id =1,
				Name = "Test",
				Starts = DateTime.Now,
			};
			//Insted of creating your own values, using Bogus library to do that:
			var entityBogus = new Faker<Auction>()
				.RuleFor(auction => auction.Id, f => f.UniqueIndex)
				.RuleFor(auction => auction.Name, f => f.Lorem.Word())
				.RuleFor(auction => auction.Starts, f=> f.Date.Past())
				.RuleFor(auction => auction.Ends, f=> f.Date.Future())
				.RuleFor(auction => auction.Items, (f, auction) => new List<Item>
				{
					new Item {Id = f.UniqueIndex, Name= f.Commerce.ProductName(), Brand = f.Commerce.Department(), BasePrice = f.Random.Decimal(50, 10000), Condition = f.PickRandom<ConditionEnum>(), AuctionId = auction.Id}
				}).Generate();

			var mock = new Mock<IAuctionRepository>();
			mock.Setup(i => i.GetCurrent()).Returns(entityBogus);
			var useCase = new GetCurrentAuctionUseCase(mock.Object);

			//Act
			var auction = useCase.Execute();

			//Assert
			//Assert.NotNull(auction);
			//Insted of using dotNet Assert, using FluentAssertion library:
			auction.Should().NotBeNull();
            auction!.Id.Should().Be(entityBogus.Id);
			auction.Name.Should().Be(entityBogus.Name);

		}
	}
}

