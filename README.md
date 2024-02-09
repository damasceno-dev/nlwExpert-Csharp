## This is a simple C# ASP.NET Core API made on nlw Expert bootcamp
routes:
GET
/Auction => lists all auctions in database
POST
/Offer/{itemId} => insert an offer for the itemId in database

Used:
AspNetCore.OpenApi for routing
EntityFrameworkCore for database managing
xUnit for tests
Bogus for simulating data to be tested
Moq for simulating the database
