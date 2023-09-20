/*namespace ass1.Controllers
{
    public class UserController
    {
    }
}
*/

using Microsoft.AspNetCore.Mvc;
using AssignmentAPI.Models;
using System.Linq;

namespace ProjectFolder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(UserLoginRequest request)
        {
            var user = UserData.Users.FirstOrDefault(u => u.UserId == request.UserId && u.Password == request.Password);

            if (user != null)
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

            var invalidResponse = new
            {
                success = false,
                data = new { },
                message = "Invalid user"
            };
            return Unauthorized(invalidResponse);
        }
    }

    public class UserLoginRequest
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
