using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Models.DTOs
{
    public class AddWalkRequestDto
    {
        public required string Description { get; set; }
        public required string LenghtInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
        //public required Region Region { get; set; }
        public Guid DificultyId { get; set; }
        //public Dificulty Dificulty { get; set; }
    }
}
