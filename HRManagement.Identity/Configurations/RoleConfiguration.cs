using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Id = "bfed3d7a-cfff-499d-b3e5-96d1190b3516",
                Name = "Employee",
                NormalizedName = "EMPLOYEE",

            }, new IdentityRole
            {
                Id = "ae75fe8d-6ba1-4d42-979e-c88c1349e4db",
                Name = "Admin",
                NormalizedName = "ADMIN",
            }

            ) ;
        }
    }
}
