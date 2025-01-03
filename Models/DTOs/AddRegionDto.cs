using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTOs
{
    public class AddRegionRequestDto
    {
        [Required(ErrorMessage ="Please provide a Name")]
        [MaxLength(100,ErrorMessage ="Name has a maximum of 100 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Please provide a Code")]
        [MaxLength(3, ErrorMessage = "Code has a maximum of 3 characters")]
        [MinLength(3, ErrorMessage = "Code has a minimum of 3 characters")]
        public required string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
