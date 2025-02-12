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
                using var connection = GetSqlConnection();
                var office = 
                    await connection.QuerySingleAsync<Office>(Constants.Query.GetOfficeId, new {office = officeName});
                return office;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<List<SectionAndCount>> GetOfficesAndCount()
        {
            try
            {
                using var connection = GetSqlConnection();
                var offices = await connection.QueryAsync<SectionAndCount>(Constants.Query.GetOfficesandCount);
                return offices.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private SqlConnection GetSqlConnection()
        {
            return
                new SqlConnection(_configuration.GetConnectionString(Constants.ConnectionStrings.ConnectionString));
        }
    }
}
