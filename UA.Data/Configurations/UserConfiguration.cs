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

        builder.HasIndex(x => x.Email).IsUnique();

        builder
            .HasMany(x => x.Roles)
            .WithMany()
            .UsingEntity<UserRole>();

        builder.HasData(new User
        {
            Id = Guid.Parse("4166924c-0ff7-4028-9b56-3c590eaeabcf"),
            Age = 25,
            Name = "admin",
            Email = "admin@example.com",
            PasswordHash = "fc063b5c2ad541510b5e178a237d975dd4bbc74acf10f03d1a1fd901be6581945d53da7ce4b42c6baa0499015d64689cf5d578f37c0106ed7c9d10564869b8b6"
        });
    }
}