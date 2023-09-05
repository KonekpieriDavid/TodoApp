using Microsoft.AspNetCore.Mvc;
using APIAuthentication.Repository;
using APIAuthentication.Models;
using Microsoft.AspNetCore.Authorization;


namespace APIAuthentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController : Controller
    {
       
        private readonly IJWTManagerRepository _jWTManagerRepository;
        public UserController(IJWTManagerRepository jWTManagerRepository)
        {

            _jWTManagerRepository = jWTManagerRepository;
        }
        [HttpGet]
        public List<string> Get() 
        { 
             var users = new List<string>
            {
                "David Amour",
                "Gilbert Kofi",
                "Bright Bidiako",
                "Prince Nyako"
            };
            return users;
            
        }
        public static User user = new User();
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]

        public IActionResult   Authenticate(User user, string EmailAddress, string Password)
        {
            var token = _jWTManagerRepository.Authenticate(EmailAddress,Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
