using AutoMapper;
using NZWalksAPI.Models.Domains;
using NZWalksAPI.Models.DTOs;

namespace NZWalksAPI.Mappings
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
            //region mapper
            CreateMap<RegionDto, Region>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRgionRequesDto, Region>().ReverseMap();
            //walk mapper
            CreateMap<WalkDto, Walk>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalkDto, Dificulty>().ReverseMap();
            CreateMap<UpdateWalkDto, Walk>().ReverseMap();
            //dificulty mapper
            CreateMap<DificultyDto, Dificulty>().ReverseMap();
                
        }
    }
} 
