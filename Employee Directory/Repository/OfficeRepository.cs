using Dapper;
using Employee_Directory.Concerns;
using Employee_Directory.Models;
using Microsoft.Data.SqlClient;

namespace Employee_Directory.Repository
{
    public class OfficeRepository
    {
        private IConfiguration _configuration;

        public OfficeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Office> GetOffice(string officeName)
        {
            try
            {
                using SqlConnection connection = GetSqlConnection();
                var office = 
                    await connection.QuerySingleAsync<Office>(Constants.Query.GetOfficeId, new {office = officeName});
                return office;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SectionAndCount>> GetOfficesAndCount()
        {
            try
            {
                using SqlConnection connection = GetSqlConnection();
                var offices = await connection.QueryAsync<SectionAndCount>(Constants.Query.GetOfficesandCount);
                return offices.ToList();
            }
            catch(ArgumentException)
            {
                throw new Exception(Constants.Errors.UnableToConnectToDB);
            }
            catch(Exception)
            {
                throw new Exception(Constants.Errors.UnableToFetchOffices);
            }
        }

        private SqlConnection GetSqlConnection()
        {
            return
                new SqlConnection(_configuration.GetConnectionString(Constants.ConnectionStrings.ConnectionString));
        }
    }
}
