using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Models.DTOs
{
    public class WalkDto
    {
        public required Guid Id { get; set; }
        public required string Description { get; set; }
        public required string LenghtInKm { get; set; }
        public required string? WalkImageUrl { get; set; }
        //public required Guid RegionId { get; set; }
        public required RegionDto Region { get; set; }
        //public required Guid DificultyId { get; set; }
        public required DificultyDto Dificulty { get; set; }
    }
}
