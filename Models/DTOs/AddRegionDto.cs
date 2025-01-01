﻿namespace NZWalksAPI.Models.DTOs
{
    public class AddRegionRequestDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}