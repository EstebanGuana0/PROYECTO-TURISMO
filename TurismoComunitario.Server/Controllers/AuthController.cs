using Microsoft.AspNetCore.Mvc;
using TurismoComunitario.Server.Models;
using System.Linq;
namespace TurismoComunitario.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login model)
        {
            var user = _context.Usuarios
            .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user == null)
                return Unauthorized();
            return Ok(new { token = "fake-jwt-token", user.Username, user.Role });
        }
    }
}