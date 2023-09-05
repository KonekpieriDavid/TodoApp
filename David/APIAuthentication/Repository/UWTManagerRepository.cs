using APIAuthentication.Models;

namespace APIAuthentication.Repository
{
    public interface UWTManagerRepository
    {
        Tokens Authenticate(User user,UserPayment userPayment,UserLogin userLogin,PaymentRequest payment);
    }
}
