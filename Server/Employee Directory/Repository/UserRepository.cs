using BCrypt.Net;
using Employee_Directory.Concerns;
using Employee_Directory.DTO;
using Employee_Directory.Models;
using Employee_Directory.Services;

namespace Employee_Directory.Repository
{
    public class UserRepository
    {
        private readonly DBServices _dbServices;
        
        public UserRepository(DBServices dbServices)
        {
            _dbServices = dbServices;
        }

        public async Task AddUser(UserDTO userDTO)
        {
            try
            {
                string password = BCrypt.Net.BCrypt.EnhancedHashPassword(userDTO.Password);
                userDTO.Password = password;
                await _dbServices.AddData(Constants.StoredProcedures.InsertIntoUsers,userDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> GetUserById(string Id)
        {
            try
            {
                User user = await _dbServices.GetSingleDataTAsync<User, Object>(Constants.Query.GetUserById, new { Id });
                if (user == null)
                {
                    throw new Exception(Constants.Errors.UserDoesNotExist);
                }
                return user;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<User> GetUser(String Email)
        {
            try
            {
                User user = await _dbServices.GetSingleDataTAsync<User, Object>(Constants.Query.GetUser, new { Email });
                if (user == null)
                {
                    throw new Exception(Constants.Errors.UserDoesNotExist);
                }
                return user;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
