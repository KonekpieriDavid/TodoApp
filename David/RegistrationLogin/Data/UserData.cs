using RegistrationLogin.DBAccess;
using RegistrationLogin.Models;
using RegistrationLogin.Data;

namespace RegistrationLogin.Data
{
    public class UserData : IUserData

    {
        private readonly ISqlDataAccess _db;
        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }
        public async Task<int> InsertUsers(Registration registrationModel)
        {
            string? FullName = registrationModel.FullName;
            string? Email = registrationModel.Email;
            string? Username = registrationModel.UserName;


            string? PasswordHash = registrationModel.PasswordHash;
            string? PhoneNumber = registrationModel.PhoneNumber;
           

            var result = await _db.SaveDataWithResponse(StoredProcedure: "pces_Users_InsSignUp",

                new
                {
                    FullName,
                    Email,
                    Username,
                    PasswordHash,
                    PhoneNumber,

                }
                );
            return result;

        }

        public Task<IEnumerable<Registration>> GetUsers()
        {

            var result= _db.loadData<Registration, dynamic>(StoredProcedure: "PCES_USERS_SELECT",

                new
                {


                }
                );
            return result;

        }

    }
}
