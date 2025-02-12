using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeServices _employeeServices;
        public EmployeesController(EmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        [HttpPost("employee")]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            bool status = await _employeeServices.AddEmployee(employee);
            if(status)
            {
                return Created(); 
            }
            return BadRequest();
            
        }

        [HttpGet()]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var employees =  await _employeeServices.GetAllEmployees();
            if(employees is not null)
            {
                return Ok(employees);
            }
            return BadRequest();
        }
        [HttpPut("employee")]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            bool status =  await _employeeServices.UpdateEmployee(employee); 
            if(status)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("employee/{id}")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            bool status =  await _employeeServices.DeleteEmployee(id);
            if(status)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpGet("jobTitles-count")]
        public async Task<ActionResult<List<SectionAndCount>>> GetJobTitlesCount()
        {
            List<SectionAndCount> jobTitleCount = await _employeeServices.GetJobTitlesCount();
            if(jobTitleCount is null)
            {
                return BadRequest();
            }
            return Ok(jobTitleCount);
        }
    }
}
