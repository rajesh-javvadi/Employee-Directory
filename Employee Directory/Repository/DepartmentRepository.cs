using Dapper;
using Employee_Directory.Concerns;
using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.Data.SqlClient;

namespace Employee_Directory.Repository
{
    public class DepartmentRepository
    {

        private DBServices _dbServices;

        public DepartmentRepository(DBServices dBServices)
        {
            _dbServices = dBServices;
        }

        public async Task<Department> GetDepartment(string departmentName)
        {
            try
            {
                var obj = new
                {
                    department = departmentName,
                };
                Department department =
                    await _dbServices.GetSingleDataTAsync<Department,Object>
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
                List<SectionAndCount> sectionAndCounts = await _dbServices.GetDataTAsync<SectionAndCount>(Constants.Query.GetDepartmentsandCount,false);
                return sectionAndCounts;
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
