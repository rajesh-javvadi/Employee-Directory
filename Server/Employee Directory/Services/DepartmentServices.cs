using Employee_Directory.Concerns;
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
            try
            {
                Department department = await _repository.GetDepartment(departmentName);
                return department;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<List<SectionAndCount>> GetDepartmentsandCount()
        {
            try
            {
                List<SectionAndCount> departmentAndCount = await _repository.GetDepartmentandCount();
                return departmentAndCount;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
