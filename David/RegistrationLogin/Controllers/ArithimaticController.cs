using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RegistrationLogin.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ArithimaticController : Controller
    {
        [Authorize]
        [HttpPost]
        [Route("Sumvalues")]
        public IActionResult Sum([FromQuery(Name ="value1")] int value1, [FromQuery(Name = "value2")] int value2)
        {
            var result = value1 + value2;
            return Ok(result);
        }
        
    }
}
