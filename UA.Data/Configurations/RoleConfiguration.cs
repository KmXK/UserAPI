using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UA.Data.Enums;
using UA.Data.Models;

namespace UA.Data.Configurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Name).IsRequired();

        builder.HasData(
            new Role
            {
                Id = RoleEnum.User,
                Name = "User"
            },
            new Role
            {
                Id = RoleEnum.Admin,
                Name = "User"
            },
            new Role
            {
                Id = RoleEnum.SuperAdmin,
                Name = "Super Admin"
            },
            new Role
            {
                Id = RoleEnum.Support,
                Name = "Support"
            }
        );
    }
}