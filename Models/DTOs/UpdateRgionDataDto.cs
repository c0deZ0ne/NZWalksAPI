
namespace NZWalksAPI.Models.DTOs
{
    public class UpdateRgionRequesDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? RegionImageUrl
        {
            get; set;
        }
    }
}
