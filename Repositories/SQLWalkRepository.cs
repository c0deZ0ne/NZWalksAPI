using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Repositories
{
    public class SQLWalkRepository(NZWalksDbContext dbContext) : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext = dbContext;

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await dbContext.Walks.Include("Dificulty").Include("Region"). ToListAsync();
        }

        public async Task<Walk?> GetWalksByIDAsync(Guid id)
        {
            // using LINQ method 
            return await dbContext.Walks.FirstOrDefaultAsync((x) => x.Id == id);

        }

        public async Task<Walk> CreateWalksAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk); //add the new data to the model 
            await dbContext.SaveChangesAsync();
            return walk;
        }

        //public async Task<Walk?> UpdateWalksAsync(Guid id, Walk walk)
        //{
        //    // check if region exits 
        //    var walkData = await dbContext.Regions.FirstOrDefaultAsync((x) => x.Id == id);
        //    if (walkData == null)
        //    {
        //        return null;
        //    }

        //    walkData.Name = region.Name;
        //    walkData.Code = region.Code;
        //    walkData.RegionImageUrl = region.RegionImageUrl;

        //    await dbContext.SaveChangesAsync();
        //    return regionData;
        //}

        //public async Task<Region?> DeleteRegionAsync(Guid id)
        //{
        //    var region = await dbContext.Regions.FirstOrDefaultAsync((x) => x.Id == id);
        //    if (region == null)
        //    {
        //        return null;
        //    }

        //    dbContext.Remove(region);
        //    await dbContext.SaveChangesAsync();
        //    return region;
        //}


    }
}
