using UserManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Repository
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.EmailAddress })
                .IsUnique(true);
        }
    }
}