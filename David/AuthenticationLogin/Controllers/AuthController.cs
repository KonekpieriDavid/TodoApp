using Microsoft.AspNetCore.Mvc;

namespace AuthenticationLogin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return Ok("Success");
        }
    }
}
