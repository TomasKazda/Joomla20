using Joomla20.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Joomla20.Data
{
    public class ApplicationDbContext : IdentityDbContext<JUser,IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<JUser> JUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JUser>().ToTable("Users");
            modelBuilder.Entity<JUser>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Article>().Property(a => a.CreatedAt).HasDefaultValue(DateTime.UtcNow);

            var haser = new PasswordHasher<JUser>();
            var adminId = Guid.NewGuid();
            var adminRoleId = Guid.NewGuid();

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
            {
                Id = adminRoleId,
                Name = "Administrators",
                NormalizedName = "ADMINISTRATORS"
            });
            modelBuilder.Entity<JUser>().HasData(new JUser
            {
                Id = adminId,
                UserName = "admin@dev.null",
                NormalizedUserName = "ADMIN@DEV.NULL",
                FullName = "Administrator",
                Email = "admin@dev.null",
                NormalizedEmail = "ADMIN@DEV.NULL",
                EmailConfirmed = true,
                SecurityStamp = "necovymysli",
                PasswordHash = haser.HashPassword(new JUser(), "admin"),
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = adminRoleId,
                UserId = adminId
            });
        }   
    }
}
