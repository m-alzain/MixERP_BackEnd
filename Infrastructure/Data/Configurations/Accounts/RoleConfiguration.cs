using ApplicationCore.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Accounts
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles", "account");

            builder.HasIndex(e => e.RoleName)
                .HasName("UQ__roles__783254B1A0BC1C3C")
                .IsUnique();

            #region IEntity, IOffice

            builder.Property(e => e.Id)
                .HasColumnName("role_id")
                .ValueGeneratedNever();
           
            builder.Property(e => e.OfficeId).HasColumnName("office_id");
            builder.HasOne(d => d.Office)
                .WithMany(p => p.Roles)
                .HasForeignKey(d => d.OfficeId)
                .HasConstraintName("FK__roles__office___31EC6D26").OnDelete(DeleteBehavior.ClientSetNull);

            #endregion

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.IsAdministrator).HasColumnName("is_administrator");

            builder.Property(e => e.RoleName)
                .IsRequired()
                .HasColumnName("role_name")
                .HasMaxLength(100);



            #region IAuditable

            builder.Property(e => e.CreatedOn)
                .HasColumnName("created_on")
                .HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.CreatedByUserId).HasColumnName("created_by_userId");
            builder.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.CreatedRoles)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__created_roles__createted_by_user").OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(e => e.UpdatedOn)
                .HasColumnName("updated_on")
                .HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_userId");
            builder.HasOne(d => d.UpdatedByUser)
                .WithMany(p => p.UpdatedRoles)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK__updated_roles__updated_by_user").OnDelete(DeleteBehavior.ClientSetNull);

            #endregion
        }
    }
}
