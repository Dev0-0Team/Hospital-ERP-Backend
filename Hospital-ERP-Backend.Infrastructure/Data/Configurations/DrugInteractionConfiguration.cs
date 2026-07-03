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
    public class DrugInteractionConfiguration : IEntityTypeConfiguration<DrugInteraction>
    {
        public void Configure(EntityTypeBuilder<DrugInteraction> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__drug_int__3213E83FF051F2E4");

            entity.ToTable("drug_interactions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Medication1Id).HasColumnName("medication_1_id");
            entity.Property(e => e.Medication2Id).HasColumnName("medication_2_id");
            entity.Property(e => e.Severity)
                .HasMaxLength(20)
                .HasColumnName("severity");
            entity.Property(e => e.Warning).HasColumnName("warning");

            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedAt)
                            .HasDefaultValueSql("(sysutcdatetime())")
                            .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                            .HasDefaultValue(false)
                            .HasColumnName("is_deleted");
            entity.HasQueryFilter(e => e.IsDeleted != true);

            entity.HasOne(d => d.Medication1).WithMany(p => p.DrugInteractionMedication1s)
                .HasForeignKey(d => d.Medication1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_interactions_med1");

            entity.HasOne(d => d.Medication2).WithMany(p => p.DrugInteractionMedication2s)
                .HasForeignKey(d => d.Medication2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_interactions_med2");
        }
    }
}
