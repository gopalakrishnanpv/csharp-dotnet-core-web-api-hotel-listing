using csharp_dotnet_core_web_api_hotel_listing.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_dotnet_core_web_api_hotel_listing.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "India",
                    Code = "IN"
                },
                 new Country
                 {
                     Id = 2,
                     Name = "Australia",
                     Code = "AU"
                 },
                  new Country
                  {
                      Id = 3,
                      Name = "France",
                      Code = "FR"
                  }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    CountryId = 1,
                    Name = "Indian Coffee House",
                    Address = "Bangalore, India",
                    Rating = 4.5,
                },
                 new Hotel
                 {
                     Id = 2,
                     CountryId = 3,
                     Name = "Australian Hut",
                     Address = "Sydney, Australia",
                     Rating = 4.6,
                 },
                 new Hotel
                 {
                     Id = 3,
                     CountryId = 2,
                     Name = "Paris Corner",
                     Address = "Paris, France",
                     Rating = 3.5,
                 }
                );
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
