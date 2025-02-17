using System.Collections.Generic;
using System.Reflection.Metadata;
using Employee_Directory.Concerns;
using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.AspNetCore.Cors;
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
        [HttpPost(Constants.Routes.employee)]
        public async Task<ActionResult<ApiResponse<string>>> AddEmployee(Employee employee)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                await _employeeServices.AddEmployee(employee);
                response.Data = Constants.EmployeeAddedSuccess;
            }
            catch(Exception e)
            {
                response.ErrorMessage = e.Message;
                response.Success = false;
            }
            return response;
        }

        [HttpGet()]
        public async Task<ActionResult<ApiResponse<List<Employee>>>> GetAll()
        {
            ApiResponse<List<Employee>> response = new ApiResponse<List<Employee>>();
            try
            {
                List<Employee> employees = await _employeeServices.GetAllEmployees();
                response.Data = employees;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }
        [HttpPut(Constants.Routes.employee)]
        public async Task<ActionResult<ApiResponse<string>>> UpdateEmployee(Employee employee)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                await _employeeServices.UpdateEmployee(employee);
                response.Data = Constants.EmployeeUpdateSuccess;
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        [HttpDelete("employee/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> DeleteEmployee(string id)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                await _employeeServices.DeleteEmployee(id);
                response.Data = Constants.EmployeeDeleteSuccess;
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }
        [HttpGet(Constants.Routes.jobTitlesCount)]
        public async Task<ActionResult<ApiResponse<List<SectionAndCount>>>> GetJobTitlesCount()
        {
            ApiResponse<List<SectionAndCount>> response = new ApiResponse<List<SectionAndCount>>();
            try
            {
                List<SectionAndCount> jobTitleCount = await _employeeServices.GetJobTitlesCount();
                response.Data = jobTitleCount;
            }
            catch(Exception e)
            {
                response.ErrorMessage = e.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
