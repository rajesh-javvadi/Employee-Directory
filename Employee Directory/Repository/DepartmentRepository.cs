using Dapper;
using Employee_Directory.Concerns;
using Employee_Directory.Models;
using Microsoft.Data.SqlClient;

namespace Employee_Directory.Repository
{
    public class DepartmentRepository
    {
        private IConfiguration _configuration;

        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetSqlConnection()
        {
            return
                new SqlConnection(_configuration.GetConnectionString(Constants.ConnectionStrings.ConnectionString));
        }

        public async Task<Department> GetDepartment(string departmentName)
        {
            try
            {
                using var connection = GetSqlConnection();
                return 
                    await connection.QuerySingleAsync<Department>
                    (Constants.Query.GetDepartmentId, new { department = departmentName });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        internal async Task<List<SectionAndCount>> GetDepartmentandCount()
        {
            try
            {
                using var connection = GetSqlConnection();
                var departmentsCount = await connection.QueryAsync<SectionAndCount>(Constants.Query.GetDepartmentsandCount);
                return departmentsCount.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
