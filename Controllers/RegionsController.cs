using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domains;
using NZWalksAPI.Models.DTOs;
using NZWalksAPI.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace NZWalksAPI.Controllers
{

    //htts://localhost:1234/api/controllerName eg "regions"

    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        //cretae a private readonly dbcontext for this class only to use to interact with the db
        private readonly NZWalksDbContext dbContext;
        //create and initialize the repository for use in this constructor
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        //constructor for this clasee that inject the context to the variable  dbContext
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regionsDomainModel = await  regionRepository.GetAllRegionsAsync(); // await  dbContext.Regions.ToListAsync();

            //Map Domain to DTOs
            //var regionDto = new List<RegionDto>();
            //foreach (var regionDomain in regionsDomainModel)
            //{
            //    regionDto.Add(new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Name= regionDomain.Name,
            //        Code = regionDomain.Code,
            //        RegionImageUrl = regionDomain.RegionImageUrl,
            //    });

            //}

            //using mapper 
            //Map Domain to DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task <IActionResult> GetRegionByID(Guid id) {
            var regionDomainModel = await regionRepository.GetRegionByIDAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //Map Region Domain model to Region DTO

            //Map Domain to DTOs
            var regionDto = new RegionDto
            {
                    Id = regionDomainModel.Id,
                    Name = regionDomainModel.Name,
                    Code = regionDomainModel.Code,
                    RegionImageUrl = regionDomainModel.RegionImageUrl,
            };
                                
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task <IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto ) {

            var regionDomainModel = new Region
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,

            };

            regionDomainModel =  await regionRepository.CreateRegionAsync(regionDomainModel);
            //Map Domaoin to DTO
            var regionDto = new RegionDto
            {
                Id=regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof (GetRegionByID), new {id=regionDomainModel.Id}, regionDto);
            
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRgionRequesDto  updateRgionRequesDto) {

            // create a new region object that holds characteristics to be updated
            var regionFDomainModel = new Region
            {
                Name = updateRgionRequesDto.Name,
                Code = updateRgionRequesDto.Code,
                RegionImageUrl = updateRgionRequesDto.RegionImageUrl
            };
            var region = await regionRepository.UpdateRegionAsync(id, regionFDomainModel);
            if (region == null)
            {
                return NotFound();
            }

            //Convert DomainModel to dto befor sending
            var regionDto = new RegionDto {
                Id=region.Id,
                Name=region.Name,
                Code=region.Code,
                RegionImageUrl=region.RegionImageUrl,
    
            };

            return Ok(regionDto);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id) {

            // check if region exits 
            var region = await regionRepository.DeleteRegionAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            //Convert DomainModel to dto befor sending 
            var regionDto = new RegionDto {
                Id=region.Id,
                Name=region.Name,
                Code=region.Code,
                RegionImageUrl=region.RegionImageUrl,
    
            };

            return Ok(regionDto);
        }
    
    }





}
