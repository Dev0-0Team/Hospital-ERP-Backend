using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("user_roles");

        // PK
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        // Columns
        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.RoleId)
            .IsRequired();

        // Relationships
        builder.HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes (important for joins)
        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.RoleId);

        // Prevent duplicate assignments (VERY IMPORTANT)
        builder.HasIndex(x => new { x.UserId, x.RoleId })
            .IsUnique();
    }
}