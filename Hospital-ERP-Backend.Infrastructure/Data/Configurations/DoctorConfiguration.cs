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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
    
        public void Configure(EntityTypeBuilder<Doctor> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__doctors__3213E83F33690FE5");

            entity.ToTable("doctors");

            entity.HasIndex(e => e.PersonId, "UQ__doctors__543848DE2D197A8B").IsUnique();

            entity.HasIndex(e => e.LicenseNumber, "UQ__doctors__D482A003B03D2585").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(100)
                .HasColumnName("license_number");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.SpecializationId).HasColumnName("specialization_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Department).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_doctors_departments");

            entity.HasOne(d => d.Person).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.PersonId)
                .HasConstraintName("FK_doctors_persons");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_doctors_specializations");
        }
    }
}
