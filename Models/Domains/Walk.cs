namespace NZWalksAPI.Models.Domains
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string lenghtInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        /// <summary>
        /// navigation one:one relation between walk and region  properties  or ference  for entity framewok 
        /// </summary>
        public Guid RegionId { get; set; } 
        public Region Region { get; set; }

        /// <summary>
        /// navigation one:one relation between walk and Dificulty   properties  or ference  for entity framewok 
        /// </summary>
        public Guid DifcultyId { get; set; }
        public Dificulty Dificulty { get; set; }

    }
}



