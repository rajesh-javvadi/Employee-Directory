using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Employee_Directory.Concerns;
using Employee_Directory.DTO;
using Employee_Directory.Models;
using Employee_Directory.Repository;
using Employee_Directory.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        private readonly UserServices _userServices;
        
        public UserController(UserRepository userRepository, UserServices userServices) 
        {
            _userRepository = userRepository;
            _userServices = userServices;
        }
        [HttpPost(Constants.Routes.Registration)]
        public async Task<IActionResult> Registration(UserDTO userDTO)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                await _userRepository.AddUser(userDTO);
                response.Data = Constants.UserAddedSuccess;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Success = false;
            }
            return BadRequest(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            ApiResponse<User> apiResponse = new ApiResponse<User>();
            try
            {
                User user =  await _userRepository.GetUserById(id);
                apiResponse.Data = user;
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.Success = false;
            }
            return BadRequest(apiResponse);
        }


        [HttpPost(Constants.Routes.Login)]

        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            ApiResponse<string> apiResponse = new ApiResponse<string>();
            try
            {
                apiResponse.Data = await _userServices.GetAuthenticationToken(loginDTO);
                return Ok(apiResponse);
            }
            catch(Exception ex) 
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.Success = false;
            }
            return BadRequest(apiResponse);
        }

    }
}
