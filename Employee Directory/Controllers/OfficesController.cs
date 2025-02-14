using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        public OfficeServices OfficeServices;

        public OfficesController(OfficeServices officeServices) {
            this.OfficeServices = officeServices;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ApiResponse<Office>>> Get(string name)
        {
           ApiResponse<Office> response = new ApiResponse<Office>();
            try
            {
                Office office = await OfficeServices.GetOffice(name);
                response.Data = office;
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Success = false;
            }
            return response;

        }
        [HttpGet("get-offices")]
        public async Task<ActionResult<ApiResponse<List<SectionAndCount>>>> GetOfficesCount()
        {
            ApiResponse<List<SectionAndCount>> response = new ApiResponse<List<SectionAndCount>>();
            try
            {
                List<SectionAndCount> officeCount = await OfficeServices.GetOfficesAndCount();
                response.Data = officeCount;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
