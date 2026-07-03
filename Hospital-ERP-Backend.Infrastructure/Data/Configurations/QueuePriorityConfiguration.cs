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
    public class QueuePriorityConfiguration : IEntityTypeConfiguration<QueuePriority>
    {
        public void Configure(EntityTypeBuilder<QueuePriority> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__queue_pr__3213E83FC8D5C925");

            entity.ToTable("queue_priorities");

            entity.HasIndex(e => e.Name, "UQ__queue_pr__72E12F1B66136CE0").IsUnique();

            entity.HasIndex(e => e.Level, "UQ__queue_pr__C03A140A1CB71ECA").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedAt)
                            .HasDefaultValueSql("(sysutcdatetime())")
                            .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                            .HasDefaultValue(false)
                            .HasColumnName("is_deleted");
            entity.HasQueryFilter(e => e.IsDeleted != true);
        }
    }
}
