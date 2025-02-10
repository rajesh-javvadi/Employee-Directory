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
            await _repository.AddEmployee(employee);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _repository.GetAllEmployees();
        }
    }
}
