using AspNetCoreJwtAuthStarter_Template.Helpers;
using AspNetCoreJwtAuthStarter_Template.Models;

namespace AspNetCoreJwtAuthStarter_Template.Data
{
    public class SeedData
    {
        public static void init(AppDbContext _context)
        {
            if (_context.Users.Any()) return;

            PasswordHelper.CreatePasswordHash("Pass123", out byte[] hash, out byte[] salt);

            var superAdmin = new User
            {
                Username = "superadmin",
                Email = "superadmin@example.com",
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "SA"
            };

            _context.Add(superAdmin);
            _context.SaveChanges();

        }
    }
}
