
using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class LabTestConfiguration : IEntityTypeConfiguration<LabTest>
    {
        public void Configure(EntityTypeBuilder<LabTest> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__lab_test__3213E83F27615AB0");

            entity.ToTable("lab_tests");

            entity.HasIndex(e => e.Name, "UQ__lab_test__72E12F1B8CDC2683").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.NormalRange)
                .HasMaxLength(100)
                .HasColumnName("normal_range");

            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedAt)
                            .HasDefaultValueSql("(sysutcdatetime())")
                            .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                            .HasDefaultValue(false)
                            .HasColumnName("is_deleted");
            entity.HasQueryFilter(e => e.IsDeleted != true);
        }
    }
}
