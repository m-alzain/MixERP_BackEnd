using ApplicationCore.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Accounts
{
    public class OfficeUserConfiguration : IEntityTypeConfiguration<OfficeUser>
    {
        public void Configure(EntityTypeBuilder<OfficeUser> builder)
        {
            builder.ToTable("office_users", "account");
            builder.HasKey(ou => new { ou.OfficeId, ou.UserId });
            builder.HasOne(ou => ou.Office).WithMany(o => o.OfficeUsers).HasForeignKey(ou => new { ou.OfficeId }).HasConstraintName("FK__office_users__office").OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ou => ou.User).WithMany(o => o.OfficeUsers).HasForeignKey(ou => ou.UserId).HasConstraintName("FK__tenant_office_users__user").OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
