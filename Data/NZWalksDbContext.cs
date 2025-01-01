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

        public DbSet <Dificulty> dificulties { get; set; }
        public DbSet <Region> Regions { get; set; }
        public DbSet <Walk> Walks { get; set; }
    }
}
