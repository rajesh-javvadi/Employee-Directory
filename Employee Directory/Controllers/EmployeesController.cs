using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeServices _employeeServices;
        public EmployeesController(EmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        [HttpPost("employee")]
        public async Task AddEmployee(Employee employee)
        {
            await _employeeServices.AddEmployee(employee);
        }

        [HttpGet()]

        public async Task<List<Employee>> GetAll()
        {
            return await _employeeServices.GetAllEmployees();
        }
    }
}
