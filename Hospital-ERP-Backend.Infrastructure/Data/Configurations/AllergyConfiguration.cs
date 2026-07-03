using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class AllergyConfiguration : IEntityTypeConfiguration<Allergy>  
    {
        public void Configure(EntityTypeBuilder<Allergy> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__allergie__3213E83FC91590B9");

            entity.ToTable("allergies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllergyName)
                .HasMaxLength(150)
                .HasColumnName("allergy_name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Severity)
                .HasMaxLength(20)
                .HasColumnName("severity");

            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedAt)
                            .HasDefaultValueSql("(sysutcdatetime())")
                            .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                            .HasDefaultValue(false)
                            .HasColumnName("is_deleted");
            entity.HasQueryFilter(e => e.IsDeleted != true);

            entity.HasOne(d => d.Patient).WithMany(p => p.Allergies)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_allergies_patients");
        }
    }
}
