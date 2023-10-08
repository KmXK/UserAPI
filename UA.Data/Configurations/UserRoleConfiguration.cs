using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UA.Data.Enums;
using UA.Data.Models;

namespace UA.Data.Configurations;

public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");

        builder.HasData(
            Enum.GetValues<RoleEnum>().Select(x => new UserRole
            {
                UserId = Guid.Parse("4166924c-0ff7-4028-9b56-3c590eaeabcf"),
                RoleId = x
            }).ToList());
    }
}