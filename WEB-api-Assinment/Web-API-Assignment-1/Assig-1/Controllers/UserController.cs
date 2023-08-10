using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourProjectNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly Dictionary<string, (string Password, string Name, string Department)> Users = new Dictionary<string, (string, string, string)>
        {
            { "user1", ("password1", "John", "HR") },
            { "user2", ("password2", "Jane", "IT") }
        };

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (Users.TryGetValue(request.UserId, out var user) && user.Password == request.Password)
            {
                var response = new
                {
                    success = true,
                    data = new
                    {
                        name = user.Name,
                        department = user.Department
                    },
                    message = "Valid user"
                };
                return Ok(response);
            }
            else
            {
                var response = new
                {
                    success = false,
                    data = new { },
                    message = "Invalid user"
                };
                return BadRequest(response);
            }
        }
    }

    public class LoginRequest
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
