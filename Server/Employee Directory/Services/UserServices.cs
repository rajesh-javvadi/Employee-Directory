using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Employee_Directory.Concerns;
using Employee_Directory.DTO;
using Employee_Directory.Exceptions;
using Employee_Directory.Models;
using Employee_Directory.Repository;
using Microsoft.IdentityModel.Tokens;

namespace Employee_Directory.Services
{
    public class UserServices
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;
       
        public UserServices(UserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<string> GetAuthenticationToken(LoginDTO loginDTO)
        {
            try
            {
                User user = await _userRepository.GetUser(loginDTO.Email);
                bool isValidUser = BCrypt.Net.BCrypt.EnhancedVerify(loginDTO.Password, user.Password);
                if (user != null)
                {
                    if (isValidUser)
                    {
                        Claim[] claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,_configuration[Constants.Jwt.Subject]),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(Constants.Email,user.Email),
                        };
                        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[Constants.Jwt.Key]));
                        SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        DateTime expires = DateTime.UtcNow.AddMinutes(60);
                        JwtSecurityToken token = new(
                            _configuration[Constants.Jwt.Issuer],
                            _configuration[Constants.Jwt.Audience],
                            claims,
                            notBefore: null,
                        expires: DateTime.UtcNow.AddMinutes(60),
                            signingCredentials);
                        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                        return tokenValue;
                    }
                    throw new CredentialsException(Constants.InvalidCredentials);
                }
                throw new Exception(Constants.UserNotFound);

            }
            catch(InvalidOperationException)
            {
                throw new Exception(Constants.UserNotFound);
            }
            catch
            {
                throw;
            }
        }
    }
}
