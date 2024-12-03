using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration.Users;

public class UserInRoleConfiguration : IEntityTypeConfiguration<UserInRole>
{
    public void Configure(EntityTypeBuilder<UserInRole> builder)
    {
        builder.ToTable("UserInRoles");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.UserInRoles)
            .HasForeignKey(x => x.RoleId);
        builder.HasOne(x => x.User)
            .WithMany(x => x.UserInRoles)
            .HasForeignKey(x => x.UserId);
    }
}
