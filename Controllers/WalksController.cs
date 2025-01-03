using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domains;
using NZWalksAPI.Models.DTOs;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
  
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
            var walkDomainModel = await walkRepository.GetWalksByIDAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain to DTOs
            return Ok(mapper.Map<WalkDto>(walkDomainModel));


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

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkDto updateWalkDto)
        {
            // Map DTO to Dmain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkDto);
            var walk = await walkRepository.UpdateWalksAsync(id, walkDomainModel);
            if (walk == null)
            {
                return NotFound();
            }

            //Convert DomainModel to dto befor sending
            return Ok(mapper.Map<WalkDto>(walk));
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {

            // check if region exits 
            var walk = await walkRepository.DeleteWalksAsync(id);
            if (walk == null)
            {
                return NotFound();
            }

            //Convert DomainModel to dto befor sending 
            return Ok(mapper.Map<WalkDto>(walk));
        }

    }


}
