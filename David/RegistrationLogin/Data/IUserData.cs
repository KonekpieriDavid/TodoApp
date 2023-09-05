using RegistrationLogin.Models;

namespace RegistrationLogin.Data
{
    public interface IUserData
    {
        Task<IEnumerable<Registration>> GetUsers();
        Task<int> InsertUsers(Registration registrationModel);
    }
}