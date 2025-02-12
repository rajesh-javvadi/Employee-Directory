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

        public async Task<bool> AddEmployee(Employee employee)
        {
            return await _repository.AddEmployee(employee);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _repository.GetAllEmployees();
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            return await _repository.UpdateEmployee(employee);
        }

        public async Task<bool> DeleteEmployee(string id)
        {
           return await _repository.DeleteEmployee(id);
        }

        internal async Task<List<SectionAndCount>> GetJobTitlesCount()
        {
            return await _repository.GetJobTitlesCount();
        }
    }
}
