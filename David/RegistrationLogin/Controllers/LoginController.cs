using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistrationLogin.Models;

namespace RegistrationLogin.Controllers
{
    [Route("api/controller")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("Login")]

        public IActionResult Login([FromForm] AuthenticationRequest authenticationRequest)
        {
            var jwtAuthentication = new JwtAuthenticationManager();
            var authResult = jwtAuthentication.Authenticate(authenticationRequest.UserName, authenticationRequest.PasswordHash);
            if(authResult == null)
                return Unauthorized();
            else
            return Ok(authResult);
        }
    }
}
