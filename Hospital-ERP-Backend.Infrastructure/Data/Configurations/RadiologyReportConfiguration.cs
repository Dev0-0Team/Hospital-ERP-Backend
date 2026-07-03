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
    public class RadiologyReportConfiguration : IEntityTypeConfiguration<RadiologyReport>
    {
        public void Configure(EntityTypeBuilder<RadiologyReport> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__radiolog__3213E83F3359F7BE");

            entity.ToTable("radiology_reports");

            entity.HasIndex(e => e.RadiologyOrderId, "UQ__radiolog__FC02BB03E560C3CB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RadiologyOrderId).HasColumnName("radiology_order_id");
            entity.Property(e => e.Report).HasColumnName("report");

            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedAt)
                            .HasDefaultValueSql("(sysutcdatetime())")
                            .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                            .HasDefaultValue(false)
                            .HasColumnName("is_deleted");
            entity.HasQueryFilter(e => e.IsDeleted != true);

            entity.HasOne(d => d.RadiologyOrder).WithOne(p => p.RadiologyReport)
                .HasForeignKey<RadiologyReport>(d => d.RadiologyOrderId)
                .HasConstraintName("FK_rad_reports_orders");
        }
    }
}
