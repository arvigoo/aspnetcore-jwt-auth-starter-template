using AspNetCoreJwtAuthStarter_Template.Data;
using AspNetCoreJwtAuthStarter_Template.Helpers;
using AspNetCoreJwtAuthStarter_Template.Models;
using AspNetCoreJwtAuthStarter_Template.Models.DTOs;
using AspNetCoreJwtAuthStarter_Template.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreJwtAuthStarter_Template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthConroller : Controller
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthConroller(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return BadRequest(new { message = "Email already registered" });
            }

            PasswordHelper.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = request.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Register(LoginRequest req)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == req.Email);
            if (user == null)
            {
                return Unauthorized(new {message = "Invalid Credential"});
            }
            if (!PasswordHelper.VerifyPasswordHash(req.Password, user.PasswordHash, user.PasswordSalt)){
                return Unauthorized(new { message = "Invalid Credential" });
            }
            var token = _jwtService.GenerateToken(user);
            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Username,
                    user.Email,
                    user.Role
                }
            });
        }

    }
}
