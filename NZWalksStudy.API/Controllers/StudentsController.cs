using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetActionResult()
        {
            string[] students = new string[]
            {
                "Nii", "Okai","Tettey", "Antie","Samuel","Sidney","Okine"
            };
            return Ok(students);
        }
    }
}
