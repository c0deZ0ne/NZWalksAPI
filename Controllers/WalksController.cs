using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domains;
using NZWalksAPI.Models.DTOs;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
  

    //htts://localhost:1234/api/controllerName eg "walks"

    [Route("api/[controller]")]
    [ApiController]
    public class WalksController(IWalkRepository walkRepository, IMapper mapper) : ControllerBase
    {
        private readonly IWalkRepository walkRepository = walkRepository;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDomainModel = await walkRepository.GetAllWalksAsync() ;
            //maping from domainModel to DTO
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkByID(Guid id)
        {
            var regionDomainModel = await walkRepository.GetWalksByIDAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain to DTOs
            return Ok(mapper.Map<RegionDto>(regionDomainModel));


        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            walkDomainModel = await walkRepository.CreateWalksAsync(walkDomainModel);
            //Map Domaoin to DTO
            if (walkDomainModel==null) 
            {
                return NotFound();
            }
            var walkDto = mapper.Map<AddWalkRequestDto>(walkDomainModel);
            return CreatedAtAction(nameof(GetWalkByID), new { id = walkDomainModel.Id }, walkDto);

        }

        //[HttpPut]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRgionRequesDto updateRgionRequesDto)
        //{

        //    // create a new region object that holds characteristics to be updated
        //    var regionFDomainModel = mapper.Map<Region>(updateRgionRequesDto);

        //    var region = await regionRepository.UpdateRegionAsync(id, regionFDomainModel);
        //    if (region == null)
        //    {
        //        return NotFound();
        //    }

        //    //Convert DomainModel to dto befor sending
        //    return Ok(mapper.Map<RegionDto>(region));
        //}


        //[HttpDelete]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        //{

        //    // check if region exits 
        //    var region = await regionRepository.DeleteRegionAsync(id);
        //    if (region == null)
        //    {
        //        return NotFound();
        //    }

        //    //Convert DomainModel to dto befor sending 
        //    return Ok(mapper.Map<RegionDto>(region));
        //}

    }


}
