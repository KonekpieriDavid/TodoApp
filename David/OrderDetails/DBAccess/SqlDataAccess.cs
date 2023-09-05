using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderDetails.DBAccess
{
    public class SqlDataAccess
    {
        private readonly IConfiguration _config;

        // Configuration is where we get data from where we get data from Json 
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        // Here we used Async to loaddata to the database where we are calling  to our database

        public async Task<IEnumerable<T>> loadData<T, U>(string StoredProcedure, U Parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection Connection = new SqlConnection(_config.GetConnectionString(connectionId));
            return await Connection.QueryAsync<T>(
                StoredProcedure, Parameters,
                commandType: CommandType.StoredProcedure
                );
        }

        // Here we used Async to save data  to the database 
        public async Task SaveData<T>(string StoredProcedure, T Parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection Connection = new SqlConnection(_config.GetConnectionString(connectionId));
            Connection.Open();
            await Connection.ExecuteAsync(
                StoredProcedure,
                Parameters,
                commandType: CommandType.StoredProcedure);
        }


    }
}
