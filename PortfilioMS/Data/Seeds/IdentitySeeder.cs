using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfilioMS.Models;

namespace PortfilioMS.Data.Seeds
{
    public static class IdentitySeeder
    {
        public static string AdminUserId { get; } = Guid.NewGuid().ToString();
        public static string AdminRoleId { get; } = Guid.NewGuid().ToString();
        public static string UserRoleId { get; } = Guid.NewGuid().ToString();

        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = AdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = UserRoleId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );

            // Seed Admin User
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = AdminUserId,
                UserName = "admin@portfolio.com",
                NormalizedUserName = "ADMIN@PORTFOLIO.COM",
                Email = "admin@portfolio.com",
                NormalizedEmail = "ADMIN@PORTFOLIO.COM",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            // Assign Admin Role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = AdminRoleId,
                    UserId = AdminUserId
                }
            );
        }
    }
}
