using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class EmergencyCaseConfiguration : IEntityTypeConfiguration<EmergencyCase>
    {
        public void Configure(EntityTypeBuilder<EmergencyCase> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__emergenc__3213E83F05B12C7B");

            entity.ToTable("emergency_cases");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArrivalTime)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("arrival_time");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Triage")
                .HasColumnName("status");
            entity.Property(e => e.TriageColor)
                .HasMaxLength(10)
                .HasColumnName("triage_color");

            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedAt)
                            .HasDefaultValueSql("(sysutcdatetime())")
                            .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                            .HasDefaultValue(false)
                            .HasColumnName("is_deleted");
            entity.HasQueryFilter(e => e.IsDeleted != true);

            entity.HasOne(d => d.Patient).WithMany(p => p.EmergencyCases)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_emergency_cases_patients");
        }
    }
}
