using DataAccess.Models;
using System.Threading.Tasks;

namespace PaymentPlatformV2.Data
{
    public interface IUsersData
    {
        Task InsertUsers(UserLoginModel UserLogin);

        /*Task PostUsers(UserloginModel userlogin); */
       /* Task PostUsers(UserloginModel userloginModel, object userlogin); */
    }
}