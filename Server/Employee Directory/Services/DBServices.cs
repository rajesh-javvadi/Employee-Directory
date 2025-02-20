using Dapper;
using Employee_Directory.Concerns;
using Microsoft.Data.SqlClient;

namespace Employee_Directory.Services
{
    public class DBServices
    {
        private readonly IConfiguration _configuration;
        public DBServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<T>> GetDataTAsync<T>(string query,bool isSp)
        {
            try
            {
                using SqlConnection connection = GetSqlConnection();
                IEnumerable<T> values;
                if (!isSp)
                {
                    values = await connection.QueryAsync<T>(query);
                }
                else
                {
                    values = await connection.QueryAsync<T>(query, commandType: System.Data.CommandType.StoredProcedure);
                }
                return values.ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<T>> GetDataAsync<T>(string query,bool isSp,Object? obj = null)
        {
            try
            {
                using SqlConnection connection = GetSqlConnection();
                IEnumerable<T> values;
                if (!isSp)
                {
                    values = await connection.QueryAsync<T>(query);
                }
                else
                {
                    
                    values = await connection.QueryAsync<T>(query,obj, commandType: System.Data.CommandType.StoredProcedure);
                }
                return values.ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<T> GetSingleDataTAsync<T,K>(string query, K obj)
        {
            try
            {
                using SqlConnection sqlConnection = GetSqlConnection();
                T robj = await sqlConnection.QuerySingleAsync<T>(query, obj);
                return robj;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateData(Object obj,string sp)
        {
            try
            {
                using SqlConnection sqlConnection = GetSqlConnection();
                await sqlConnection.ExecuteAsync(sp,obj, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteDataById(string query,string id)
        {
            try
            {
                using SqlConnection sqlConnection = GetSqlConnection();
                await sqlConnection.ExecuteAsync(query, new { id = id }, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task AddData(string query,Object obj)
        {
            try
            {
                using SqlConnection sqlConnection = GetSqlConnection();
                await sqlConnection.ExecuteAsync(query, obj, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        private SqlConnection GetSqlConnection()
        {
            return
                new SqlConnection(_configuration.GetConnectionString(Constants.ConnectionStrings.ConnectionString));
        }

        internal async Task<int> GetEmployeeCount()
        {
            try
            {
                using SqlConnection sqlConnection = GetSqlConnection();
                int count = await sqlConnection.ExecuteScalarAsync<int>(Constants.Query.EmployeeCount);
                return count;
            }
            catch(InvalidOperationException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
