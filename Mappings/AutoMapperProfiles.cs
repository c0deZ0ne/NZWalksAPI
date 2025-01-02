using AutoMapper;
using NZWalksAPI.Models.Domains;
using NZWalksAPI.Models.DTOs;

namespace NZWalksAPI.Mappings
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<RegionDto, Region>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRgionRequesDto, Region>().ReverseMap();
                
        }
    }
} 
