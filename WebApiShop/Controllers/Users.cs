using Entity;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using service;
using System.Text.Json;


namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {

        private UserServices userService = new UserServices();


        // POST api/<UsersController>
        [HttpPost]

        public ActionResult<User> post([FromBody] User newUser)
        {

            newUser = userService.addUser(newUser);
            if (newUser == null)
                return BadRequest("password");
            return CreatedAtAction(nameof(Get), new { id = newUser.id }, newUser);



        }


        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] LoginUser loginUser)
        {
            User user = userService.loginUser(loginUser);
            if (user == null)
                return NoContent();

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
            if (userService.updateUser(id, userToUpdate))
                return Ok(userToUpdate);

            else
                return BadRequest();


        }


        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
