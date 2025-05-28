using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.BogusHandling
{
    public static class AppUserDataSeed
    {
        public static void SeedUsersAndRoles(ModelBuilder builder)
        {
            AppRole appRole = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString() 
            };


            builder.Entity<AppRole>().HasData(appRole);

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

            AppUser appUser = new()
            {
                Id = 1,
                UserName = "cgr123",
                NormalizedUserName = "CGR123",
                Email = "cagri@gmail.com",
                NormalizedEmail = "CAGRI@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "cgr123"),
                CreatedDate = DateTime.Now,
                Status = Entities.Enums.DataStatus.Inserted

            };

            builder.Entity<AppUser>().HasData(appUser);


            AppUserRole appUserRole = new()
            {
                Id = 1,
                UserId = 1,
                RoleId = 1
            };

            builder.Entity<AppUserRole>().HasData(appUserRole);
        }
    }
}
