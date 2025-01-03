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
            return await dbContext.Walks.Include("Dificulty").Include("Region"). FirstOrDefaultAsync((x) => x.Id == id);

        }

        public async Task<Walk> CreateWalksAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk); //add the new data to the model 
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> UpdateWalksAsync(Guid id, Walk walk)
        {
            // check if region exits 
            var walkData = await dbContext.Walks.FirstOrDefaultAsync((x) => x.Id == id);
            if (walkData == null)
            {
                return null;
            }

            walkData.DificultyId = walk.DificultyId;
            walkData.WalkImageUrl = walk.WalkImageUrl;
            walkData.LenghtInKm = walk.LenghtInKm;
            walkData.Description = walk.Description;
            walkData.RegionId = walk.RegionId;
            await dbContext.SaveChangesAsync();
            return walkData;
        }

        public async Task<Walk?> DeleteWalksAsync(Guid id)
        {
            var walk = await dbContext.Walks.FirstOrDefaultAsync((x) => x.Id == id);
            if (walk == null)
            {
                return null;
            }

            dbContext.Remove(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }


    }
}
