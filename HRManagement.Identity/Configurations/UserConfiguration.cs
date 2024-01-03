using HRManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(new ApplicationUser
            {
                Id = "6424babb-bc4b-4ca6-9bd2-7abe80f1f730",
                Email = "Admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                FirstName = "Admin",
                lastName = "Adminian",
                UserName = "Admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null,"Fardin9494"),
                EmailConfirmed = true,
            }, new ApplicationUser
            {
                Id = "6f46ab02-aac6-4edc-b7fa-b7423bf91ffb",
                Email = "User@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                FirstName = "User",
                lastName = "Userian",
                UserName = "User@localhost.com",
                NormalizedUserName = "USER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "Fardin9494"),
                EmailConfirmed = true,
            });
        }
    }
}
