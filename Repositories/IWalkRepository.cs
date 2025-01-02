using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {

        Task<List<Walk>> GetAllWalksAsync();
        Task<Walk?> GetWalksByIDAsync(Guid id);
        Task<Walk> CreateWalksAsync(Walk walk);
        //Task<Walk?> UpdateWalksAsync(Guid id, Walk walk);
        //Task<Walk?> DeleteWalksAsync(Guid id);
    }
}
