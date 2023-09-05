using FunctionApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

namespace Azure.FunctionApp1.DataAccess
{
    public class DapperConnService : IDapperConnService
    {
        private readonly IConfiguration _config;
        public DapperConnService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "SQLdb")
        {
            using IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
            );
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "SQLdb")
        {
            using IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);

        }
    }
}
