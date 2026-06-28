

using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__appointm__3213E83FECD9DE0A");

            entity.ToTable("appointments");

            entity.HasIndex(e => new { e.DoctorId, e.AppointmentDate }, "IX_appointments_doctor_date").HasFilter("([is_deleted]=(0))");

            entity.HasIndex(e => e.PatientId, "IX_appointments_patient").HasFilter("([is_deleted]=(0))");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentDate).HasColumnName("appointment_date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_appointments_doctors");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_appointments_patients");

            entity.HasOne(d => d.Priority).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_appointments_priorities");
        }
    }
}
