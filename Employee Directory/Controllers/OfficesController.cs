using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class OfficesController : ControllerBase
    {
        public OfficeServices OfficeServices;

        public OfficesController(OfficeServices officeServices) {
            this.OfficeServices = officeServices;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Office>> Get(string name)
        {
           var office = await OfficeServices.GetOffice(name);
           if(office != null)
           {
                return Ok(office);
           }
            return BadRequest();

        }
        [HttpGet("get-offices")]
        public async Task<ActionResult<List<SectionAndCount>>> GetOfficesCount()
        {
           var offices =  await OfficeServices.GetOfficesAndCount();
            if(offices is null)
            {
                return BadRequest();
            }
            return Ok(offices);
        }
    }
}
