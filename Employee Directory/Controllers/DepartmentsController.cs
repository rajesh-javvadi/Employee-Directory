using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private DepartmentServices _services;

        public DepartmentsController(DepartmentServices services)
        {
            _services = services;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Department>> GetDepartment(string name)
        {
            return await _services.GetDepartment(name);
        }

        [HttpGet("get-departments")]
        public async Task<ActionResult<List<SectionAndCount>>> GetDepartmentandCount()
        {
            var departments = await _services.GetDepartmentsandCount();
            if(departments is null)
            {
                return BadRequest();
            }
            return Ok(departments);
        }
    }
}
