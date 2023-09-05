using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using System.Threading.Tasks;

namespace CustomersDetails.DataAccess
{
    public class DapperConnService : IDapperConnService
    {
        private readonly IConfiguration _config;
        public DapperConnService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(connectionId));
            var store = await connection.ExecuteAsync(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);

            return store;

        }
    }
}
