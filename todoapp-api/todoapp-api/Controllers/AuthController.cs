using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoapp_api.Data;

namespace todoapp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            using (var context = new Wep )
            {

            }
        }
    }
}
