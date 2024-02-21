using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NZWalksStudy.API.Data;
using NZWalksStudy.API.Models.Domain;

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
            return Ok(region);
        }
        

    }
}

