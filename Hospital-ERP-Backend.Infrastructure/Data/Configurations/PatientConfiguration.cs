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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__patients__3213E83F9C9D83E7");

            entity.ToTable("patients");

            entity.HasIndex(e => e.PersonId, "UQ__patients__543848DE4D7E9BCB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BloodType)
                .HasMaxLength(10)
                .HasColumnName("blood_type");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Person).WithOne(p => p.Patient)
                .HasForeignKey<Patient>(d => d.PersonId)
                .HasConstraintName("FK_patients_persons");
        }
    }
}
