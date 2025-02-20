using Employee_Directory.Models;
using Employee_Directory.Repository;

namespace Employee_Directory.Services
{
    public class EmployeeServices
    {
        private EmployeeRepository _repository;
        
        public EmployeeServices(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task AddEmployee(Employee employee)
        {
            try
            {
                await _repository.AddEmployee(employee);

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
           try
            {
                List<Employee> employees = await _repository.GetAllEmployees();
                return employees;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try
            {
                await _repository.UpdateEmployee(employee);
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
                await _repository.DeleteEmployee(id);
            }
            catch
            {
                throw;
            }
        }

        internal async Task<List<SectionAndCount>> GetJobTitlesCount()
        {
            try
            {
                List<SectionAndCount> jobTitleCount = await _repository.GetJobTitlesCount();
                return jobTitleCount;
            }
            catch
            {
                throw;
            }
        }

        internal async Task<List<Employee>> GetEmployees(int page_number, int limit)
        {
            try
            {
                int offset_value = (page_number - 1) * limit;
                List<Employee> employees = await _repository.GetEmployees(offset_value, limit);
                return employees;
            }
            catch
            {
                throw;
            }
        }

        internal async Task<int> GetEmployeeCount()
        {
           try
            {
                int count = await _repository.GetEmployeesCount();
                return count;
            }
            catch
            {
                throw;
            }
        }
    }
}
