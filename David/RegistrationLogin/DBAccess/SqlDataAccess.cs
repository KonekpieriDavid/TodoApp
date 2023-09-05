using RegistrationLogin.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RegistrationLogin.DBAccess
{

    public class SqlDataAccess : ISqlDataAccess
    {
        // Configuration is where we get data from where we get data from Json 

        public readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // Here we used Async to loaddata to the database where we are calling  to our database
        public async Task<IEnumerable<T>> loadData<T, U>(string StoredProcedure, U Parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection Connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            return await Connection.QueryAsync<T>(
                StoredProcedure, Parameters,
                commandType: CommandType.StoredProcedure
                );
        }
        // Here we used Async to save data  to the database 
        public async Task SaveData<T>(string StoredProcedure, T Parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection Connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            Connection.Open();
            await Connection.ExecuteAsync(
                StoredProcedure,
                Parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveDataWithResponse<T>(string StoredProcedure, T Parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection Connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            Connection.Open();
            var response = await Connection.ExecuteAsync(
                StoredProcedure,
                Parameters,
                commandType: CommandType.StoredProcedure);
            return response;
        }
    }
}
