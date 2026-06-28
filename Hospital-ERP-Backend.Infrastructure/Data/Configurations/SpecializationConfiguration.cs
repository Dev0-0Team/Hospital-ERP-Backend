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
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__speciali__3213E83F22926047");

            entity.ToTable("specializations");

            entity.HasIndex(e => e.Name, "UQ__speciali__72E12F1B8AE1AF68").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        }
    }
}
