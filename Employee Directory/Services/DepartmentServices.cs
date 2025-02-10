using Employee_Directory.Models;
using Employee_Directory.Repository;

namespace Employee_Directory.Services
{
    public class DepartmentServices
    {
        private DepartmentRepository _repository;
        public DepartmentServices(DepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Department> GetDepartment(string departmentName)
        {
            return await _repository.GetDepartment(departmentName);
        }
    }
}
