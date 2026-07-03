

using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class AppointmentQueueConfiguration : IEntityTypeConfiguration<AppointmentQueue>
    {
        public void Configure(EntityTypeBuilder<AppointmentQueue> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__appointm__3213E83FF9E0844A");

            entity.ToTable("appointment_queue");

            entity.HasIndex(e => new { e.AppointmentId, e.Status }, "IX_appointment_queue_lookup");

            entity.HasIndex(e => e.AppointmentId, "UQ__appointm__A50828FDDCAFD24D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");
            entity.Property(e => e.EstimatedTime).HasColumnName("estimated_time");
            entity.Property(e => e.QueueNumber).HasColumnName("queue_number");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Waiting")
                .HasColumnName("status");

            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedAt)
                            .HasDefaultValueSql("(sysutcdatetime())")
                            .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                            .HasDefaultValue(false)
                            .HasColumnName("is_deleted");
            entity.HasQueryFilter(e => e.IsDeleted != true);

            entity.HasOne(d => d.Appointment).WithOne(p => p.AppointmentQueue)
                .HasForeignKey<AppointmentQueue>(d => d.AppointmentId)
                .HasConstraintName("FK_appointment_queue_appointments");
        }
    }
}
