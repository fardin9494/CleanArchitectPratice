using System;
using System.Collections.Generic;
using System.Text;
using HRManagement.Identity.Configurations;
using HRManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Identity
{
    internal class LeaveManagementIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public LeaveManagementIdentityContext(DbContextOptions<LeaveManagementIdentityContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
