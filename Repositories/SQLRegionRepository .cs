using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domains;
using NZWalksAPI.Models.DTOs;

namespace NZWalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public  async Task<List<Region>> GetAllRegionsAsync()
        {
           return  await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIDAsync(Guid id)
        {
            // using LINQ method 
            return  await dbContext.Regions.FirstOrDefaultAsync((x) => x.Id == id);
          
        }

        public  async Task<Region> CreateRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region); //add the new data to the model 
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async  Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            // check if region exits 
            var regionData = await dbContext.Regions.FirstOrDefaultAsync((x) => x.Id == id);
            if (regionData == null)
            {
                return null;
            }

            regionData.Name = region.Name;
            regionData.Code= region.Code;
            regionData.RegionImageUrl= region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return regionData;
        }

        public async Task<Region?>DeleteRegionAsync(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync((x) => x.Id == id);
            if (region == null)
            {
                return null;
            }

            dbContext.Remove(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
    }
}
