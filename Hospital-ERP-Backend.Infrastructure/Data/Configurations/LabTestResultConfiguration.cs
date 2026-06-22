

using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class LabTestResultConfiguration : IEntityTypeConfiguration<LabTestResult>
    {
        public void Configure(EntityTypeBuilder<LabTestResult> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__lab_test__3213E83F9FC92E9D");

            entity.ToTable("lab_test_results");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.LabOrderId).HasColumnName("lab_order_id");
            entity.Property(e => e.LabTestId).HasColumnName("lab_test_id");
            entity.Property(e => e.Result).HasColumnName("result");

            entity.HasOne(d => d.LabOrder).WithMany(p => p.LabTestResults)
                .HasForeignKey(d => d.LabOrderId)
                .HasConstraintName("FK_lab_results_orders");

            entity.HasOne(d => d.LabTest).WithMany(p => p.LabTestResults)
                .HasForeignKey(d => d.LabTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lab_results_tests");
        }
    }
}
