using APIAuthentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;


using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace APIAuthentication.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration _configuration;

       /* Dictionary<string, string> UserRecods = new Dictionary<string, string>() {
            {"david@gmail.com","Password1" },
            {"kelvin@gmail.com","Password2" },
             {"Benard@gmail.com","Password1" },
        };*/
        public JWTManagerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Tokens Authenticate(string EmailAddress ,string Password)



        {
            if (EmailAddress != "david@gmail.com" || Password != "Birthday96")
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
                      new Claim(ClaimTypes.Name, EmailAddress,Password)
                   }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenhandler.CreateToken(tokenDescription);
            return new Tokens { Token = tokenhandler.WriteToken(token),};
        }

    }
}
