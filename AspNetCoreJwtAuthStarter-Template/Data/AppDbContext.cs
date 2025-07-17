using AspNetCoreJwtAuthStarter_Template.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreJwtAuthStarter_Template.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
