using APIAuthentication.Models;

namespace APIAuthentication.Repository
{
    public interface IPayManagerRepository
    {
        Tokens Authenticate(string CustomerFullName, string CustomerphoneNumber);
    }
}