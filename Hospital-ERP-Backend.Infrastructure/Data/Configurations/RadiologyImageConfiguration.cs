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
    public class RadiologyImageConfiguration : IEntityTypeConfiguration<RadiologyImage>
    {
        public void Configure(EntityTypeBuilder<RadiologyImage> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__radiolog__3213E83F8D48F99F");

            entity.ToTable("radiology_images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(2083)
                .HasColumnName("image_url");
            entity.Property(e => e.RadiologyOrderId).HasColumnName("radiology_order_id");

            entity.HasOne(d => d.RadiologyOrder).WithMany(p => p.RadiologyImages)
                .HasForeignKey(d => d.RadiologyOrderId)
                .HasConstraintName("FK_rad_images_orders");
        }
    }
}
