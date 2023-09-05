using APIAuthentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIAuthentication.Repository
{
    public class PayManagerRepository : IPayManagerRepository
    {

        private readonly IConfiguration _configuration;

        /* Dictionary<string, string> UserRecods = new Dictionary<string, string>() {
             {"david@gmail.com","Password1" },
             {"kelvin@gmail.com","Password2" },
              {"Benard@gmail.com","Password1" },
         };*/
        public PayManagerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Tokens Authenticate(string EmailAddress, string Password)



        {
            if (EmailAddress!= "maaizle@gmail.com" || Password != "Holland233")
            {
                return null;
            }
            // else we generate the token 
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:key"]);
            var tokenDescription = new SecurityTokenDescriptor

            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                   new Claim[]
                   {
                      new Claim(ClaimTypes.Name, EmailAddress ,Password)
                   }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenhandler.CreateToken(tokenDescription);
            return new Tokens { Token = tokenhandler.WriteToken(token) };
        }


    }
}
