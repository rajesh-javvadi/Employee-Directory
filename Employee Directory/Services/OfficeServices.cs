using Employee_Directory.Models;
using Employee_Directory.Repository;

namespace Employee_Directory.Services
{
    public class OfficeServices
    {
        private OfficeRepository _officeRepository;

        public OfficeServices(OfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<Office> GetOffice(string officeName)
        {
            return await _officeRepository.GetOffice(officeName);
        }

        public async Task<List<SectionAndCount>> GetOfficesAndCount()
        {
            return await _officeRepository.GetOfficesAndCount();
        }
    }
}
