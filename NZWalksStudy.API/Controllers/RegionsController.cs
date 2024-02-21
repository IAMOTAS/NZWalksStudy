using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NZWalksStudy.API.Data;
using NZWalksStudy.API.Models.Domain;
using NZWalksStudy.API.Models.DTO;

namespace NZWalksStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext zWalksDbContext;

        public RegionsController(NZWalksDbContext zWalksDbContext)
        {
            this.zWalksDbContext = zWalksDbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = zWalksDbContext.Regions.ToList();




            var regionsDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }





            return Ok(regions);
        }

        //get region by {id}

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id) 


        {

            // var region = zWalksDbContext.Regions.Find(id); you can use this code i commented out. It works the same way as the firstOrDefault();



            var region = zWalksDbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var region = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            }; 

        zWalksDbContext.Regions.Add(region);
            zWalksDbContext.SaveChanges();

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            

            return CreatedAtAction(nameof(GetById), new {id = region.Id},region);

        }

        [HttpPut]
        [Route("{id:Guid}")]
            public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var region = zWalksDbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            region.Code = updateRegionRequestDto.Code;
            region.Name = updateRegionRequestDto.Name;
            region.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            zWalksDbContext.SaveChanges();


            var Region = new Region
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };


            return Ok(region);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var region = zWalksDbContext.Regions.FirstOrDefault(x => x.Id == id);

            if ( region == null )
            {
                return NotFound();
            }

            zWalksDbContext.Regions.Remove(region);
            zWalksDbContext.SaveChanges();
            return Ok();

        }
    }
}

