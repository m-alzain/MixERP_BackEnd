//using ApplicationCore.Entities.Auth;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Auth
//{
//    public class GroupMenuAccessPolicyConfiguration : IEntityTypeConfiguration<GroupMenuAccessPolicy>
//    {
//        public void Configure(EntityTypeBuilder<GroupMenuAccessPolicy> builder)
//        {
//            builder.ToTable("group_menu_access_policy", "auth");

//            builder.HasIndex(e => new { e.OfficeId, e.MenuId, e.RoleId })
//                .HasName("menu_access_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.GroupMenuAccessPolicyId).HasColumnName("group_menu_access_policy_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.MenuId).HasColumnName("menu_id");

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.RoleId).HasColumnName("role_id");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.GroupMenuAccessPolicies)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__group_men__audit__6DCC4D03");

//            builder.HasOne(d => d.Menu)
//                .WithMany(p => p.GroupMenuAccessPolicies)
//                .HasForeignKey(d => d.MenuId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__group_men__menu___6BE40491");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.GroupMenuAccessPolicies)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__group_men__offic__6AEFE058");

//            builder.HasOne(d => d.Role)
//                .WithMany(p => p.GroupMenuAccessPolicies)
//                .HasForeignKey(d => d.RoleId)
//                .HasConstraintName("FK__group_men__role___6CD828CA");
//        }
//    }
//}
