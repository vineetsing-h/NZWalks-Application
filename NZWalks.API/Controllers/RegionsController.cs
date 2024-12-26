using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositries;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;

        }
        // GET ALL REGIONS:
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From DataBase - Domain Models
            // var regionsDomain = await dbContext.Regions.ToListAsync();

            var regionsDomain = await regionRepository.GetAllAsync();

            // Map Domain Models to DTOs (Data Transfer Objects)
            /* 
            var regionDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            } 
            */
            // Map Domain Models to DTOs
            var regionDto = mapper.Map<List<RegionDto>>(regionsDomain);


            // Return DTOs back to clients
            return Ok(regionDto);
        }

        // GET SINGLE REASON (Get Region By ID)
        // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id); Find can be only be used for primary key

            // Get Region Domain Model from Database
            // var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain Model to Region DTO
            /* var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            */
            // Return Dto back to client
            return Ok(mapper.Map<RegionDto>(regionDomain));  
        }


        // POST To Create New Region
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or Convert DTO to Domain Model
            /* var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            */
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
           

            // Use Domain Model to create Region
            // await dbContext.Regions.AddAsync(regionDomainModel);
            // await dbContext.SaveChangesAsync();
             regionDomainModel= await regionRepository.CreateAsync(regionDomainModel);


            // Map Domain Model back to DTO
            /* var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl

            };
            */
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);

        }

        // Update the Region

        // PUT : https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto )

    
        {

            // Map DTO to Domain Model
            /* var regionDomainModel = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            };
            */
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            // Check if region exists
            // var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            
            // Convert Domain Model to DTO
            /* var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            */
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }

        // Delete Region
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomainModel = await regionRepository.DeleteAsync(id);



            if(regionDomainModel == null)
            {
                return NotFound();
            }

            // Delete region
            // dbContext.Regions.Remove(regionDomainModel);
            // await dbContext.SaveChangesAsync();

            // return the deleted region back
            // Map Domain model to DTO 
            /* var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            */
            var regionDto  = mapper.Map<RegionDto>(regionDomainModel);

            // We can also send empty response back but here we are returning the deleted resource
            return Ok(regionDto);

        }

    }
}
