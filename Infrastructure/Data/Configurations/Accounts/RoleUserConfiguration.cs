using ApplicationCore.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Accounts
{
    public class RoleUserConfiguration : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder.ToTable("role_users", "account");
            builder.Property(e => e.RoleId).HasColumnName("role_id");
            builder.Property(e => e.UserId).HasColumnName("user_id");
            builder.HasKey(ou => new { ou.RoleId, ou.UserId });
            builder.HasOne(ou => ou.Role).WithMany(o => o.RoleUsers).HasForeignKey(ou => new { ou.RoleId }).HasConstraintName("FK__role_users__role").OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ou => ou.User).WithMany(o => o.RoleUsers).HasForeignKey(ou => ou.UserId).HasConstraintName("FK__role_users__user").OnDelete(DeleteBehavior.Cascade);
        }
    }
}