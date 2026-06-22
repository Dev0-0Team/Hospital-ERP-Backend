using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class BedConfiguration : IEntityTypeConfiguration<Bed>
    {
        public void Configure(EntityTypeBuilder<Bed> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__beds__3213E83F2E990610");

            entity.ToTable("beds");

            entity.HasIndex(e => new { e.RoomId, e.BedNumber }, "UQ_room_bed").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BedNumber)
                .HasMaxLength(20)
                .HasColumnName("bed_number");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Available")
                .HasColumnName("status");

            entity.HasOne(d => d.Room).WithMany(p => p.Beds)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_beds_rooms");
        }
    }
}
