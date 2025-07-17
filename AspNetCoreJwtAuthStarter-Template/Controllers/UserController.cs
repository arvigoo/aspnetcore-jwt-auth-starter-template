using AspNetCoreJwtAuthStarter_Template.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AspNetCoreJwtAuthStarter_Template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {

        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                ??User.FindFirstValue(ClaimTypes.Name);
            
            if(string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new {message="Invalid Token"});
            }

            var user = await _context.Users
                .Where(u=>u.Id.ToString() == userId)
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    u.Email,
                    u.Role
                })
                .FirstOrDefaultAsync();
            if (user == null) {
                return NotFound(new { message = "User Not Found" });
                    }

            return Ok(user);

        }

        [HttpGet("/api/admin/users")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> GetUsersForAdmin()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    u.Email,
                    u.Role
                })
                .ToListAsync();

            return Ok(users);
        }

        // ✅ GET: /api/superadmin/users
        [HttpGet("/api/superadmin/users")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetUsersForSuperAdmin()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    u.Email,
                    u.Role
                })
                .ToListAsync();

            return Ok(users);
        }
    }
}
