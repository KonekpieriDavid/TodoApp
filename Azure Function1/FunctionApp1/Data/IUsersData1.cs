using DataAccess.Models;
using System.Threading.Tasks;

namespace PaymentPlatformV2.Data
{
    public interface IUsersData1
    {
        Task InsertUsers(UserLoginModel UserLogin);
    }
}