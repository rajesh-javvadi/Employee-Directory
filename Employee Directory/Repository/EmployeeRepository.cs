﻿using Dapper;
using Employee_Directory.Concerns;
using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.Data.SqlClient;

namespace Employee_Directory.Repository
{
    public class EmployeeRepository
    {
        private IConfiguration _configuration;
        private DepartmentServices _departmentServices;
        private OfficeServices _officeServices;
        public EmployeeRepository(IConfiguration configuration,DepartmentServices departmentServices, OfficeServices officeServices)
        {
            _configuration = configuration;
            _departmentServices = departmentServices;
            _officeServices = officeServices;
        }


        public async Task<bool> AddEmployee(Employee employee)
        {
            try
            {
                string sp = Constants.StoredProcedures.InsertIntoEmployees;
                using var connection = GetSqlConnection();
                Department department = await _departmentServices.GetDepartment(employee.department);
                Office office = await _officeServices.GetOffice(employee.office);
                var count =
                    await connection.ExecuteAsync(sp, new
                    {
                        Id = employee.Id,
                        firstName = employee.firstName,
                        lastName = employee.lastName,
                        email = employee.email,
                        phoneNumber = employee.phoneNumber,
                        office = office.Id,
                        department = department.Id,
                        skypeId = employee.skypeId,
                        preferredName = employee.preferredName,
                        jobTitle = employee.jobTitle,

                    }, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            try
            {
                string sp = Constants.StoredProcedures.UpdateEmployee;
                using var connection = GetSqlConnection();
                Department department = await _departmentServices.GetDepartment(employee.department);
                Office office = await _officeServices.GetOffice(employee.office);
                var count =
                    await connection.ExecuteAsync(sp, new
                    {
                        Id = employee.Id,
                        firstName = employee.firstName,
                        lastName = employee.lastName,
                        email = employee.email,
                        phoneNumber = employee.phoneNumber,
                        office = office.Id,
                        department = department.Id,
                        skypeId = employee.skypeId,
                        preferredName = employee.preferredName,
                        jobTitle = employee.jobTitle,

                    }, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(string id)
        {
           try
           {
                using var connection = GetSqlConnection();
                var count = await connection.ExecuteAsync(Constants.Query.DeleteEmployee, new { id = id });
                return true;
           }
           catch(Exception e)
           {
                Console.WriteLine(e.Message);
                return false;
           }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
           try
            {
                var sp = Constants.StoredProcedures.GetEmployees;
                using var connection = GetSqlConnection();
                IEnumerable<Employee> employees = await connection.QueryAsync<Employee>(sp, commandType: System.Data.CommandType.StoredProcedure);
                return employees.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return [];
        }

        private SqlConnection GetSqlConnection()
        {
            return
                new SqlConnection(_configuration.GetConnectionString(Constants.ConnectionStrings.ConnectionString));
        }

        internal async Task<List<SectionAndCount>> GetJobTitlesCount()
        {
            try
            {
                using var connection = GetSqlConnection();
                var jobTitlesCount = await connection.QueryAsync<SectionAndCount>(Constants.Query.GetJobTitleandCount);
                return jobTitlesCount.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
