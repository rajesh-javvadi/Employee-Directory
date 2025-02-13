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

                using SqlConnection connection = GetSqlConnection();
                Department department =
                    await connection.QuerySingleAsync<Department>
                    (Constants.Query.GetDepartmentId, new { department = departmentName });
                return department;
            }
            catch(ArgumentException)
            {
                throw new Exception(Constants.Errors.UnableToConnectToDB);
            }
            catch (InvalidOperationException)
            {
                throw new Exception(Constants.Errors.UnableToFetchDepartmentID);
            }
            catch (Exception)
            {
                throw new Exception(Constants.Errors.ErrorFetchingDepratmentID);
            }
        }

        internal async Task<List<SectionAndCount>> GetDepartmentandCount()
        {
            try
            {
                using SqlConnection  connection = GetSqlConnection();
                IEnumerable<SectionAndCount> departmentsCount = await connection.QueryAsync<SectionAndCount>(Constants.Query.GetDepartmentsandCount);
                return departmentsCount.ToList();
            }
            catch(ArgumentException)
            {
                throw new Exception(Constants.Errors.UnableToConnectToDB);
            }
            catch(Exception ex)
            {

                throw new Exception(Constants.Errors.UnableToFetchDepartment);
            }
        }
    }
}
