namespace NZWalksAPI.Models.Domains
{
    public class Walk
    {
        public Guid Id { get; set; }
        public required string Description { get; set; }
        public string? LenghtInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid RegionId { get; set; } 
        public Guid DificultyId { get; set; }

        //navigation properties
        public required Region Region { get; set; }
        public required Dificulty Dificulty { get; set; }

    }
}



