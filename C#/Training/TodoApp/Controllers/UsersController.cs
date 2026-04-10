using ToDoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services;


namespace TodoAppControllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;


        public UsersController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "BasicAuthentication")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {

            var users = await _userRepository.GetAllUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "BasicAuthentication",Roles ="User")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "BasicAuthentication", Roles = "Admin,User")]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            var createdUser = await _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("ID mismatch in the URL and body.");
            }
            await _userRepository.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}