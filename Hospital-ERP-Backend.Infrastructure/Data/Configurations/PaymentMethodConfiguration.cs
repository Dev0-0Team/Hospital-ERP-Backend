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
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__payment___3213E83F5B91CD8F");

            entity.ToTable("payment_methods");

            entity.HasIndex(e => e.Name, "UQ__payment___72E12F1B567BA9A1").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        }
    }
}
