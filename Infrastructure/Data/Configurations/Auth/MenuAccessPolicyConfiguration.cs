//using ApplicationCore.Entities.Auth;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Auth
//{
//    public class MenuAccessPolicyConfiguration : IEntityTypeConfiguration<MenuAccessPolicy>
//    {
//        public void Configure(EntityTypeBuilder<MenuAccessPolicy> builder)
//        {
//            builder.ToTable("menu_access_policy", "auth");

//            builder.HasIndex(e => new { e.OfficeId, e.MenuId, e.UserId })
//                .HasName("menu_access_policy_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.MenuAccessPolicyId).HasColumnName("menu_access_policy_id");

//            builder.Property(e => e.AllowAccess).HasColumnName("allow_access");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.DisallowAccess).HasColumnName("disallow_access");

//            builder.Property(e => e.MenuId).HasColumnName("menu_id");

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.UserId).HasColumnName("user_id");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.MenuAccessPolicyAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__menu_acce__audit__756D6ECB");

//            builder.HasOne(d => d.Menu)
//                .WithMany(p => p.MenuAccessPolicies)
//                .HasForeignKey(d => d.MenuId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__menu_acce__menu___73852659");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.MenuAccessPolicies)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__menu_acce__offic__72910220");

//            builder.HasOne(d => d.User)
//                .WithMany(p => p.MenuAccessPolicyUsers)
//                .HasForeignKey(d => d.UserId)
//                .HasConstraintName("FK__menu_acce__user___74794A92");
//        }
//    }
//}
