using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class SurgeriesHistoryConfiguration : IEntityTypeConfiguration<SurgeriesHistory>
    {
        public void Configure(EntityTypeBuilder<SurgeriesHistory> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__surgerie__3213E83FB348B5F1");

            entity.ToTable("surgeries_history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.SurgeryDate).HasColumnName("surgery_date");
            entity.Property(e => e.SurgeryName)
                .HasMaxLength(150)
                .HasColumnName("surgery_name");

            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedAt)
                            .HasDefaultValueSql("(sysutcdatetime())")
                            .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                            .HasDefaultValue(false)
                            .HasColumnName("is_deleted");
            entity.HasQueryFilter(e => e.IsDeleted != true);

            entity.HasOne(d => d.Patient).WithMany(p => p.SurgeriesHistories)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_surgeries_history_patients");
        }
    }
}
