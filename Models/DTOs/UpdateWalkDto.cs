namespace NZWalksAPI.Models.DTOs
{
    public class UpdateWalkDto
    {
        public string? Description { get; set; }
        public string? LenghtInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid? RegionId { get; set; }
        public Guid? DificultyId { get; set; }
    }
}
