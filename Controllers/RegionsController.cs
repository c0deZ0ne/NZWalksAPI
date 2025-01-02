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
        //create and initialize the repository for use in this constructor
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        //constructor for this clasee that inject the context to the variable  dbContext
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regionsDomainModel = await  regionRepository.GetAllRegionsAsync();
            //maping from domainModel to DTO
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

            //Map Domain to DTOs
            return Ok(mapper.Map<RegionDto>(regionDomainModel));


        }

        [HttpPost]
        public async Task <IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto ) {
            //Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            regionDomainModel =  await regionRepository.CreateRegionAsync(regionDomainModel);
            //Map Domaoin to DTO
            var regionDto =  mapper.Map<AddRegionRequestDto>(regionDomainModel);
            return CreatedAtAction(nameof (GetRegionByID), new {id=regionDomainModel.Id}, regionDto);
            
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRgionRequesDto  updateRgionRequesDto) {

            // create a new region object that holds characteristics to be updated
            var regionFDomainModel = mapper.Map<Region>(updateRgionRequesDto);

            var region = await regionRepository.UpdateRegionAsync(id, regionFDomainModel);
            if (region == null)
            {
                return NotFound();
            }

            //Convert DomainModel to dto befor sending
            return Ok(mapper.Map<RegionDto>(region));
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
            return Ok(mapper.Map<RegionDto>(region));
        }
    
    }





}
