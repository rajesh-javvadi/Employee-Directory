using Dapper;
using Employee_Directory.Concerns;
using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.Data.SqlClient;

namespace Employee_Directory.Repository
{
    public class EmployeeRepository
    {
    
        private DepartmentServices _departmentServices;
        private OfficeServices _officeServices;
        private DBServices _dbServices;
        public EmployeeRepository(DepartmentServices departmentServices, OfficeServices officeServices, DBServices dbServices)
        {
            _departmentServices = departmentServices;
            _officeServices = officeServices;
            _dbServices = dbServices;
        }


        public async Task AddEmployee(Employee employee)
        {
            try
            {
                string sp = Constants.StoredProcedures.InsertIntoEmployees;
                Department department = await _departmentServices.GetDepartment(employee.Department);
                Office office = await _officeServices.GetOffice(employee.Office);
                var employeeDTOObject = new
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email, 
                    PhoneNumber = employee.PhoneNumber,
                    Office = office.Id,
                    Department = department.Id,
                    SkypeId = employee.SkypeId,
                    PreferredName = employee.PreferredName,
                    JobTitle = employee.JobTitle,

                };
                await _dbServices.AddData(sp, employeeDTOObject);
            }
            catch(ArgumentException)
            {
                throw new Exception(Constants.Errors.UnableToConnectToDB);
            }
            catch (Exception)
            {
                throw new Exception(Constants.Errors.EmployeeAddingFailure);
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try
            {
                string sp = Constants.StoredProcedures.UpdateEmployee;
                Department department = await _departmentServices.GetDepartment(employee.Department);
                Office office = await _officeServices.GetOffice(employee.Office);
                var obj = new
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    Office = office.Id,
                    Department = department.Id,
                    SkypeId = employee.SkypeId,
                    PreferredName = employee.PreferredName,
                    JobTitle = employee.JobTitle,

                };
                await _dbServices.UpdateData(obj, sp);
            }
            catch (ArgumentException)
            {
                throw new Exception(Constants.Errors.EmployeeUpdateFailure);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteEmployee(string id)
        {
           try
           {
                string query = Constants.StoredProcedures.DeleteEmployee;
                await _dbServices.DeleteDataById(query,id);
           }
           catch(ArgumentException)
           {
               throw new Exception(Constants.Errors.EmployeeDeletionFailure);
           }
           catch(Exception)
           {
                throw;
           }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
           try
            {
                string sp = Constants.StoredProcedures.GetEmployees;
                List<Employee> employees = await _dbServices.GetDataTAsync<Employee>(sp, true);
                return employees;
            }
            catch(ArgumentException)
            {
                throw new Exception(Constants.Errors.UnableToConnectToDB);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        internal async Task<List<SectionAndCount>> GetJobTitlesCount()
        {
            try
            {
                List<SectionAndCount> sectionAndCounts = await _dbServices.GetDataTAsync<SectionAndCount>(Constants.Query.GetJobTitleandCount, false);
                return sectionAndCounts;
            }
            catch(ArgumentException)
            {
                throw new Exception(Constants.Errors.UnableToConnectToDB);
            }
            catch(Exception)
            {
                throw new Exception(Constants.Errors.UnabletToFetchJobTitles);
            }
        }

        internal async Task<List<Employee>> GetEmployees(int offset_value, int limit)
        {
            try
            {
                List<Employee> employees = await _dbServices.GetDataAsync<Employee>(Constants.StoredProcedures.PageEmployeeData, true, new { start = offset_value, limit });
                return employees;
            }
            catch(ArgumentException)
            {
                throw new Exception(Constants.Errors.UnableToConnectToDB);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal async Task<int> GetEmployeesCount()
        {
            try
            {
                int count = await _dbServices.GetEmployeeCount();
                return count;
            }
            catch
            {
                throw;
            }
        }
    }
}
