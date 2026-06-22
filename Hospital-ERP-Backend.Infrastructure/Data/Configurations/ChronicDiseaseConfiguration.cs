
using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class ChronicDiseaseConfiguration : IEntityTypeConfiguration<ChronicDisease>
    {
        public void Configure(EntityTypeBuilder<ChronicDisease> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__chronic___3213E83F2806C775");

            entity.ToTable("chronic_diseases");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiseaseName)
                .HasMaxLength(150)
                .HasColumnName("disease_name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");

            entity.HasOne(d => d.Patient).WithMany(p => p.ChronicDiseases)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_chronic_diseases_patients");
        }
    }
}
