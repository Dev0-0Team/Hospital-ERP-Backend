using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__medical___3213E83F8E338F39");

            entity.ToTable("medical_records");

            entity.HasIndex(e => e.PatientId, "IX_medical_records_patient").HasFilter("([is_deleted]=(0))");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Diagnosis).HasColumnName("diagnosis");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.VisitDate)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("visit_date");

            entity.HasOne(d => d.Doctor).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_medical_records_doctors");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_medical_records_patients");
        }
    }
}
