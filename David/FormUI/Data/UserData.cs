using FormUI.DBAccess;
using FormUI.Model;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;

using System.Globalization;

using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace FormUI.Data
{
    public class UserData : IUserData

    {
        private readonly ISqlDataAccess _db;
        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }
        // below are the parameters needed to do the inserting to the db
        public Task InsertRegister(Register register)
        {
            int? Id = register.Id;
            string? UserName = register.UserName;
            string? Password = register.Password;

            var result = _db.SaveData(StoredProcedure: "dbo.PCES_Registration",

          new
          {
              Id,
              UserName,
              Password,

          }
          );
            return result;



        }
    }
}
