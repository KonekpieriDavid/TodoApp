using Microsoft.IdentityModel.Tokens;
using RegistrationLogin.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RegistrationLogin
{
    public class JwtAuthenticationManager
    {
        public JwtAuthResponse Authenticate(string UserName, string PasswordHash)
        {
            //validating a user name and password
            if (UserName != "David" || PasswordHash != "Birthday96")
            {
                return null;
            }
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MINS);
            var jwtSecurityTokenHanler = new JwtSecurityTokenHandler();
             var tokenKey = Encoding.ASCII.GetBytes(Constants.Secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("Username", UserName),
                    new Claim(ClaimTypes.PrimaryGroupSid, "User Group 01")
                }),

                Expires = tokenExpiryTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature )
            };
            var securityToken = jwtSecurityTokenHanler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHanler.WriteToken(securityToken);

            return new JwtAuthResponse
            {
                Token = token,
                UserName = UserName,
                Expires_in = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }



    }
}
