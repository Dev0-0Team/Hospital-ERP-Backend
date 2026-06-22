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
    public class RoomAssignmentConfiguration : IEntityTypeConfiguration<RoomAssignment>
    {
        public void Configure(EntityTypeBuilder<RoomAssignment> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__room_ass__3213E83F22B8CF51");

            entity.ToTable("room_assignments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdmittedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("admitted_at");
            entity.Property(e => e.BedId).HasColumnName("bed_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DischargedAt).HasColumnName("discharged_at");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Bed).WithMany(p => p.RoomAssignments)
                .HasForeignKey(d => d.BedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_room_assignments_beds");

            entity.HasOne(d => d.Patient).WithMany(p => p.RoomAssignments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_room_assignments_patients");
        }
    }
}
