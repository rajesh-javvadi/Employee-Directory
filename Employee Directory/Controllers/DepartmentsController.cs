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
        public async Task<ApiResponse<Department>> GetDepartment(string name)
        {
            ApiResponse<Department> response = new ApiResponse<Department>();
            try
            {
                response.Data = await _services.GetDepartment(name);
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Success = false;
            }
            return response;
        }

        [HttpGet("get-departments")]
        public async Task<ActionResult<ApiResponse<List<SectionAndCount>>>> GetDepartmentandCount()
        {
            ApiResponse<List<SectionAndCount>> response = new ApiResponse<List<SectionAndCount>>();
            try
            {
                List<SectionAndCount> departments = await _services.GetDepartmentsandCount();
                response.Data = departments;
                return response;
            }
            catch(Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
            
        }
    }
}
