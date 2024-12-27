﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositries;

namespace NZWalks.API.Controllers
{
    // api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase

    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        // Using constructor injection, we will inject IMapper 
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        // CREATE Walk
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map DTO(AddWalkRequestDto)to Doamin(Walk) Model
            // For that we dont have to map it manually, AutoMapper will do the work for us, we just have to create the mapping profile in AutoMapper for this 
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);
            // Map Domain Model to DTO

            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

    }
}