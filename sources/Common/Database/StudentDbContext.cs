using Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class StudentDbContext(DbContextOptions options) : IdentityDbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
