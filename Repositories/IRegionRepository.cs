using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task< List<Region>> GetAllRegionsAsync();
         Task<Region?>GetRegionByIDAsync(Guid id);
         Task<Region> CreateRegionAsync(Region region);
         Task<Region?> UpdateRegionAsync( Guid id, Region region);
         Task<Region?> DeleteRegionAsync( Guid id);
    }
}
