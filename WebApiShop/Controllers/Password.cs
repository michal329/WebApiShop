using Microsoft.AspNetCore.Mvc;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IPasswordServices passwordService;

        public PasswordsController(IPasswordServices passwordServices)
        {
            passwordService = passwordServices;
        }
        {
            passwordService = passwordServices;
        }

        [HttpPost("PasswordScore")]
        public ActionResult<int> PasswordScore([FromBody] string password)
        {
            int strength = passwordService.GetPasswordScore(password);
            return Ok(strength);
        }
    }
}
