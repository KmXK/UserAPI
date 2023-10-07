using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UA.Data.Models;

namespace UA.Data.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", t =>
        {
            t.HasCheckConstraint("CK_User_Age", "Age >= 0");
        });
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Age).IsRequired();
        builder.Property(x => x.Email).IsRequired();

        builder
            .HasMany(x => x.Roles)
            .WithMany()
            .UsingEntity("UserRole");
    }
}