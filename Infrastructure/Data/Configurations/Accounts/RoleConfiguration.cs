//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    public class RoleConfiguration : IEntityTypeConfiguration<Role>
//    {
//        public void Configure(EntityTypeBuilder<Role> entity)
//        {
//            entity.ToTable("roles", "account");

//            entity.HasIndex(e => e.RoleName)
//                .HasName("UQ__roles__783254B1A0BC1C3C")
//                .IsUnique();

//            entity.Property(e => e.RoleId)
//                .HasColumnName("role_id")
//                .ValueGeneratedNever();

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.IsAdministrator).HasColumnName("is_administrator");

//            entity.Property(e => e.RoleName)
//                .IsRequired()
//                .HasColumnName("role_name")
//                .HasMaxLength(100);

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Roles)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__roles__audit_use__05D8E0BE");
//        }
//    }
//}
