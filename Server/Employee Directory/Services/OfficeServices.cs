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
            try
            {
                return await _officeRepository.GetOffice(officeName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SectionAndCount>> GetOfficesAndCount()
        {
            try
            {
                List<SectionAndCount> officeCount = await _officeRepository.GetOfficesAndCount();
                return officeCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
