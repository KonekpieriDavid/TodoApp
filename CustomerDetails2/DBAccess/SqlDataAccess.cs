
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using CustomerDetails2.Models;

namespace CustomerDetails2.DBAccess
{
    public class SqlDataAccess : ISqlDataAccess
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

        public (IEnumerable<Status>,IEnumerable<OrdersData>) GetMultiple<U>(string StoredProcedure, U Parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection Connection = new SqlConnection(_config.GetConnectionString(connectionId));
            var result = Connection.QueryMultiple(
              StoredProcedure, Parameters,
              commandType: CommandType.StoredProcedure
              );

            var filteredData = result.Read<OrdersData>();
            var counts = result.Read<Status>();

            return (counts, filteredData);
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
