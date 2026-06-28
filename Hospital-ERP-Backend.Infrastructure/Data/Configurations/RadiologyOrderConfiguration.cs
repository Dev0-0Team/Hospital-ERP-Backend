using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class RadiologyOrderConfiguration : IEntityTypeConfiguration<RadiologyOrder>
    {
        public void Configure(EntityTypeBuilder<RadiologyOrder> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__radiolog__3213E83F9C431A64");

            entity.ToTable("radiology_orders");

            entity.HasIndex(e => e.PatientId, "IX_radiology_orders_patient");

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
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Doctor).WithMany(p => p.RadiologyOrders)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_radiology_orders_doctors");

            entity.HasOne(d => d.Patient).WithMany(p => p.RadiologyOrders)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_radiology_orders_patients");
        }
    }
}
