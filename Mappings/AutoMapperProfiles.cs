using AutoMapper;
using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Mappings
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<RegionDto, Region>().ReverseMap();
                
        }
    }
}
