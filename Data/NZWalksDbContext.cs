using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext:DbContext
    {
        //create a contructor 
        public NZWalksDbContext(DbContextOptions nzWalksDbContextOptions):base(nzWalksDbContextOptions) //pass to base class
        {
            
        }

        //db set is  collection of entities in the databse 

        public DbSet <Dificulty> Dificulties { get; set; }
        public DbSet <Region> Regions { get; set; }
        public DbSet <Walk> Walks { get; set; }

        //seedind data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // seed data for dificulties
            // Easy , Meduim , Hard 
            var dificulties = new List<Dificulty>()
            {
                new Dificulty()
                {
                    Id = Guid.Parse("2512c7f7-d46b-4328-9a9c-57aa6ca7e1c5"),
                    Name="Easy",


                },
                new Dificulty()
                {
                    Id =Guid.Parse("047ac5c3-ff02-4843-b378-01ccbd237444"),
                    Name="Medium",


                },
                new Dificulty()
                {
                    Id =Guid.Parse("605f416a-44dc-467e-bc95-5400c26bb0de"),
                    Name="Hard",


                },
            };
            //start seed data to dificulty table database 
            modelBuilder.Entity<Dificulty>().HasData(dificulties);

            // seed data to region table database 
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("5359fa24-b74c-475f-9f64-d3cfeb40e436"),
                    Name = "Nigeria",
                    Code = "NGR",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Flag_of_Nigeria.svg/1200px-Flag_of_Nigeria.svg.png" // Example URL
                },
                new Region()
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef"), // New GUID
                    Name = "United States",
                    Code = "USA",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Flag_of_the_United_States.svg/1200px-Flag_of_the_United_States.svg.png" // Example URL
                },
                new Region()
                {
                    Id = Guid.Parse("b2c3d4e5-f678-9012-3456-7890abcdef01"), // New GUID
                    Name = "Canada",
                    Code = "CAN",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cf/Flag_of_Canada.svg/1200px-Flag_of_Canada.svg.png" // Example URL
                },
                new Region()
                {
                    Id = Guid.Parse("c3d4e5f6-7890-1234-5678-90abcdef0123"), // New GUID
                    Name = "United Kingdom",
                    Code = "GBR", // Or UK for ISO 3166-1 alpha-2
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Flag_of_the_United_Kingdom.svg/1200px-Flag_of_the_United_Kingdom.svg.png" // Example URL
                },
                new Region()
                {
                    Id = Guid.Parse("d4e5f678-9012-3456-7890-abcdef012345"), // New GUID
                    Name = "Japan",
                    Code = "JPN",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Flag_of_Japan.svg/1200px-Flag_of_Japan.svg.png" // Example URL
                }
            };
            //start seed data to regions table database 
            modelBuilder.Entity<Region>().HasData(regions);



        }
    }
}
