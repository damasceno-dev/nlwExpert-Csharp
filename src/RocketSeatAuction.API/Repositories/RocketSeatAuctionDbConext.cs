using System;
using Microsoft.EntityFrameworkCore;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Repositories
{
	public class RocketSeatAuctionDbConext : DbContext
	{
        public RocketSeatAuctionDbConext(DbContextOptions options) : base (options)
        {

        }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var currentDirectory = System.IO.Directory.GetCurrentDirectory();
        //    var stringT = "/Users/fernandodamasceno/Coding/CursosRocketSeat/nlw14Expert/TrilhaC#/Project/RocketSeatAuction/src/RocketSeatAuction.API";
        //    //optionsBuilder.UseSqlite("Data Source=/Users/fernandodamasceno/Coding/CursosRocketSeat/nlw14Expert/TrilhaC\\#/Arquivos/leilaoDbNLW.db");
        //    optionsBuilder.UseSqlite("Data Source=" + currentDirectory + "/leilaoDbNLW.db");
        //}
    }
}

