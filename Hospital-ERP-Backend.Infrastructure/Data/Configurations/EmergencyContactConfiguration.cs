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
    public class EmergencyContactConfiguration : IEntityTypeConfiguration<EmergencyContact>
    {
        public void Configure(EntityTypeBuilder<EmergencyContact> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__emergenc__3213E83F42BCD8F6");

            entity.ToTable("emergency_contacts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Relationship)
                .HasMaxLength(50)
                .HasColumnName("relationship");

            entity.HasOne(d => d.Patient).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_emergency_contacts_patients");
        }
    }
}
