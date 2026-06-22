

using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class LabOrderConfiguration : IEntityTypeConfiguration<LabOrder>
    {
        public void Configure(EntityTypeBuilder<LabOrder> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__lab_orde__3213E83F84DFE1E8");

            entity.ToTable("lab_orders");

            entity.HasIndex(e => e.PatientId, "IX_lab_orders_patient");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.OrderedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("ordered_at");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Ordered")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Doctor).WithMany(p => p.LabOrders)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lab_orders_doctors");

            entity.HasOne(d => d.Patient).WithMany(p => p.LabOrders)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lab_orders_patients");
        }
    }
}
