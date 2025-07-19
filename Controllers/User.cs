using Microsoft.AspNetCore.Mvc;
using Quizzler.Models;
using Quizzler.Data;
using Microsoft.AspNetCore.Identity;

namespace Quizzler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        DBContext _context;
        PasswordHasher<User> hasher;
        public UsersController(DBContext _context) : base()
        {
            this._context = _context;
            hasher = new PasswordHasher<User>();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] DTO.RegisterRequest registerRequest)
        {
            User user = new User();
            user.username = registerRequest.username;
            user.passwordHash = hasher.HashPassword(user, registerRequest.password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User created");
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            if (!Guid.TryParse(id, out Guid guid)) return BadRequest("Not a valid guid");

            User? user = _context.Users.FirstOrDefault(user => user.Id == guid);

            if (user == null) return NotFound($"User with id {id} does not exist");

            //exclude password hash from being send
            DTO.User dtoUser = new DTO.User
            {
                Id = user.Id,
                username = user.username
            };

            return Ok(dtoUser);
        }
    }
}