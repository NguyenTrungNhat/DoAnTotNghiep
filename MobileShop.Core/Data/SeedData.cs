using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MobileShop.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Data
{
    public static class SeedData
    {
        public static void SeedUserAndRole(this ModelBuilder builder)
        {
            var pwd = "1234Hoc@";
            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Seed Roles
            var adminRole = new IdentityRole(SD.Role_Owner);
            adminRole.NormalizedName = adminRole.Name.ToUpper();

            var contributorRole = new IdentityRole(SD.Role_Employee);
            contributorRole.NormalizedName = contributorRole.Name.ToUpper();

            var userRole = new IdentityRole(SD.Role_User);
            userRole.NormalizedName = userRole.Name.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>() {
                adminRole,
                contributorRole,
                userRole
                };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Users
            var adminUser = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

            var contributor = new IdentityUser
            {
                UserName = "contributor@gmail.com",
                Email = "contributor@gmail.com",
                EmailConfirmed = true,
            };
            contributor.NormalizedUserName = contributor.UserName.ToUpper();
            contributor.NormalizedEmail = contributor.Email.ToUpper();
            contributor.PasswordHash = passwordHasher.HashPassword(contributor, pwd);

            var member = new IdentityUser
            {
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                EmailConfirmed = true,
            };
            member.NormalizedUserName = member.UserName.ToUpper();
            member.NormalizedEmail = member.Email.ToUpper();
            member.PasswordHash = passwordHasher.HashPassword(member, pwd);

            List<IdentityUser> users = new List<IdentityUser>() {
                    adminUser,
                    contributor,
                    member,
                };

            builder.Entity<IdentityUser>().HasData(users);

            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == SD.Role_Owner).Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == SD.Role_Employee).Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.First(q => q.Name == SD.Role_User).Id
            });

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
