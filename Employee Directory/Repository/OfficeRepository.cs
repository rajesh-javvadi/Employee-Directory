using Dapper;
using Employee_Directory.Concerns;
using Employee_Directory.Models;
using Employee_Directory.Services;
using Microsoft.Data.SqlClient;

namespace Employee_Directory.Repository
{
    public class OfficeRepository
    {

        private DBServices _dBServices;

        public OfficeRepository(DBServices dBServices)
        {
            _dBServices = dBServices;
        }

        public async Task<Office> GetOffice(string officeName)
        {
            try
            {
                Office office = await _dBServices.GetSingleDataTAsync<Office, Object>(Constants.Query.GetOfficeId, new { office = officeName });
                return office;

            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<SectionAndCount>> GetOfficesAndCount()
        {
            try
            {
                List<SectionAndCount> sectionAndCounts = await _dBServices.GetDataTAsync<SectionAndCount>(Constants.Query.GetOfficesandCount,false);
                return sectionAndCounts;
            }
            catch(ArgumentException)
            {
                throw new Exception(Constants.Errors.UnableToConnectToDB);
            }
            catch(Exception)
            {
                throw new Exception(Constants.Errors.UnableToFetchOffices);
            }
        }
    }
}
