using Entity;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using service;
using Services;
using System.Text.Json;


namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly IUserServices userService;
        private readonly IPasswordServices passwordService;

        public Users(IUserServices userServices, IPasswordServices passwordServices)
        {
            userService = userServices;
            passwordService = passwordServices;
        }


        // POST api/<UsersController>
        [HttpPost]

        public ActionResult<User> post([FromBody] User newUser)
        {
            int passwordScore = passwordService.GetPasswordScore(newUser.password);
            if (passwordScore < 2)
                return BadRequest($"Password too weak (score: {passwordScore}/4). Minimum required: 2");

            newUser = userService.addUser(newUser);
            if (newUser == null)
                return BadRequest("Failed to create user");
            return CreatedAtAction(nameof(Get), new { id = newUser.id }, newUser);



        }


        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] LoginUser loginUser)
        {
            User user = userService.loginUser(loginUser);
            if (user == null)
                return Unauthorized("Invalid username or password");

            return Ok(user);
        }

   


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET api/<Users>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
           User user= userService.getUserById(id);
            if( user!=null)
            return Ok(user);
            else return NotFound();
        }




        // PUT api/<Users>/5
        [HttpPut("{id}")]

        public ActionResult<User> Put(int id, [FromBody] User userToUpdate)
        {
            int passwordScore = passwordService.GetPasswordScore(userToUpdate.password);
            if (passwordScore < 2)
                return BadRequest($"Password too weak (score: {passwordScore}/4). Minimum required: 2");

            if (userService.updateUser(id, userToUpdate))
                return Ok(userToUpdate);

            else
                return BadRequest("Failed to update user");


        }


        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
