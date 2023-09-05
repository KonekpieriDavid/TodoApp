using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataAccess.DBAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;


        // Configuration is where we get data from where we get data from Json 
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;


        }

        // Here we used Async to navigate to our UI where we are calling  to our database

        public async Task<System.Collections.Generic.IEnumerable<T>> loadData<T, U>(string StoredProcedure, U Parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection Connection = new SqlConnection(_config.GetConnectionString(connectionId));
            return await Connection.QueryAsync<T>(
                StoredProcedure, Parameters,
                commandType: CommandType.StoredProcedure
                );
        }


        public async Task SaveData<T>(string StoredProcedure, T Parameters, string connectionId = "SqlDatabase")
        {
            using IDbConnection Connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await Connection.ExecuteAsync(
                StoredProcedure,
                Parameters,
                commandType: CommandType.StoredProcedure);
        }

        Task<IEnumerable<T>> ISqlDataAccess.loadData<T, U>(string StoredProcedure, U Parameters, string connectionId)
        {
            throw new System.NotImplementedException();
        }

      

        
      

    }





}

        



        








        
  
           

    
    
           





       
        




    

