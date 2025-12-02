using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Services;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // POST api/users/login
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginUser loginUser)
        {
            var user = await _userServices.loginUserAsync(loginUser);
            if (user == null) return Unauthorized("Invalid credentials");
            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            var addedUser = await _userServices.addUserAsync(user);
            if (addedUser == null) return BadRequest("Password too weak");
            return Ok(addedUser);
        }

        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userServices.getUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // PUT api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var result = await _userServices.updateUserAsync(id, user);
            if (!result) return BadRequest("Password too weak or user not found");
            return NoContent();
        }
    }
}
