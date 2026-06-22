using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class MedicationInventoryConfiguration : IEntityTypeConfiguration<MedicationInventory>
    {
        public void Configure(EntityTypeBuilder<MedicationInventory> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__medicati__3213E83FA2C95F1F");

            entity.ToTable("medication_inventory");

            entity.HasIndex(e => new { e.ExpiryDate, e.Quantity }, "IX_med_inventory_expiry");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");
            entity.Property(e => e.MedicationId).HasColumnName("medication_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Medication).WithMany(p => p.MedicationInventories)
                .HasForeignKey(d => d.MedicationId)
                .HasConstraintName("FK_med_inventory_medications");
        }
    }
}
