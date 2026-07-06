using Hospital_ERP_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Hospital_ERP_Backend.Infrastructure.Data.Configurations
{
    public class AdministrativeStaffConfiguration : IEntityTypeConfiguration<AdministrativeStaff>
    {
        public void Configure(EntityTypeBuilder<AdministrativeStaff> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__administ__3213E83FC130DE71");

            entity.ToTable("administrative_staff");

            entity.HasIndex(e => e.PersonId, "UQ__administ__543848DEC344BB45").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(100)
                .HasColumnName("job_title");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedAt)
                            .HasDefaultValueSql("(sysutcdatetime())")
                            .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                            .HasDefaultValue(false)
                            .HasColumnName("is_deleted");
            entity.HasQueryFilter(e => e.IsDeleted != true);

            entity.HasOne(d => d.Department).WithMany(p => p.AdministrativeStaffs)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_admin_staff_departments");

            entity.HasOne(d => d.Person).WithOne(p => p.AdministrativeStaff)
                .HasForeignKey<AdministrativeStaff>(d => d.PersonId)
                .HasConstraintName("FK_admin_staff_persons");
        }
    }
}
