using DataAccess.DBAccess;
using DataAccess.Models;
using DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPlatformV2.Data
{
    public class UsersData : IUsersData
    {
        private readonly ISqlDataAccess _db;
        public UsersData(ISqlDataAccess db)
        {
            _db = db;
        }
        /*
                public static Task PostUsers(UserloginModel userlogin)
                {
                    throw new NotImplementedException();
                }
        */
        public Task InsertUsers(UserLoginModel Userlogin) =>

            _db.SaveData(StoredProcedure: "dbo.PCES_USERS_INSERT_USERS",

            new
            {
                Userlogin.FullName,
                Userlogin.UserName,
                Userlogin.Email,
                Userlogin.PasswordHash,
                Userlogin.PhoneNumber,

            });



    }
}
