
using DinkToPdf;
using DinkToPdf.Contracts;
using Employee_Directory.Concerns;
using Employee_Directory.Models;
using Employee_Directory.Services;

using Microsoft.AspNetCore.Mvc;


namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeServices _employeeServices;

        private readonly PdfServices _pdfServices;

        public EmployeesController(EmployeeServices employeeServices, PdfServices pdfServices)
        {
            _employeeServices = employeeServices;
           
            _pdfServices = pdfServices;
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        [HttpDelete(Constants.Routes.DeleteEmployee)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteEmployee(string id)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                await _employeeServices.DeleteEmployee(id);
                response.Data = Constants.EmployeeDeleteSuccess;
                return response;
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                response.Success = false;
            }
            return response;
        }

        [HttpGet("{page_number}/{limit}")]

        public async Task<ActionResult<ApiResponse<List<Employee>>>> GetEmployyes(int page_number, int limit)
        {
            ApiResponse<List<Employee>> response = new ApiResponse<List<Employee>>();
            try
            {
                List<Employee> employees = await _employeeServices.GetEmployees(page_number, limit);
                response.Data = employees;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                response.Success = false;
            }
            return response;
        }

        [HttpGet("GetEmployeeDataPDF")]
        public async Task<IActionResult> GetEmployeeDataPDF()
        {
            List<Employee> employees = await _employeeServices.GetAllEmployees();
            byte[] pdfBytes = _pdfServices.GeneratePdf(employees);
            return File(pdfBytes, "application/pdf", "EmployeeData.pdf");
        }




        [HttpGet("count")]
        public async Task<ActionResult<ApiResponse<Int32>>> GetEmployeeCount()
        {
            ApiResponse<Int32> response = new ApiResponse<int>();
            try
            {
                int count = await _employeeServices.GetEmployeeCount();
                response.Data = count;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                response.Success = false;
            }
            return response;
        }

    }
}
