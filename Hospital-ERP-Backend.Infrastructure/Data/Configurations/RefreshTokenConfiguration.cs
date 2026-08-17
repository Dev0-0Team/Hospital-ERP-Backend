using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("refresh_tokens");

            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Id)
                .HasColumnName("id");

            builder.Property(rt => rt.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(rt => rt.TokenHash)
                .HasColumnName("token_hash")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(rt => rt.ExpiresAt)
                .HasColumnName("expires_at")
                .IsRequired();

            builder.Property(rt => rt.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(rt => rt.UpdatedAt)
                .HasColumnName("updated_at");

            builder.Property(rt => rt.RevokedAt)
                .HasColumnName("revoked_at");

            builder.Property(rt => rt.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(rt => rt.DeletedAt)
                .HasColumnName("deleted_at");
            builder.HasQueryFilter(e => e.IsDeleted != true);


            // Unique Index
            builder.HasIndex(rt => rt.TokenHash)
                .IsUnique();


            // Relationship
            builder.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}