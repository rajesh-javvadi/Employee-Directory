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
            await _employeeServices.AddEmployee(employee);
            return Ok();
        }

        [HttpGet()]
        public async Task<List<Employee>> GetAll()
        {
            return await _employeeServices.GetAllEmployees();
        }
        [HttpPut("employee")]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeServices.UpdateEmployee(employee); 
            return Ok();
        }

        [HttpDelete("employee/{id}")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            await _employeeServices.DeleteEmployee(id);
            return Ok();
        }
    }
}
