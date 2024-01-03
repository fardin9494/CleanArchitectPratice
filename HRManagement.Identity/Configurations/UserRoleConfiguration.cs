using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "ae75fe8d-6ba1-4d42-979e-c88c1349e4db",
                UserId = "6424babb-bc4b-4ca6-9bd2-7abe80f1f730",
            }, new IdentityUserRole<string>
            {
                RoleId = "bfed3d7a-cfff-499d-b3e5-96d1190b3516",
                UserId = "6f46ab02-aac6-4edc-b7fa-b7423bf91ffb",
            });
        }
    }
}
