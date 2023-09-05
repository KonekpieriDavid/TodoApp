using APIAuthentication.Models;
using System.Net.Mail;

namespace APIAuthentication.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate( string EmailAddress , string Password);
    }
}