//using ApplicationCore.Entities.Auth;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Auth
//{
//    public class GroupEntityAccessPolicyConfiguration : IEntityTypeConfiguration<GroupEntityAccessPolicy>
//    {
//        public void Configure(EntityTypeBuilder<GroupEntityAccessPolicy> builder)
//        {
//            builder.ToTable("group_entity_access_policy", "auth");

//            builder.Property(e => e.GroupEntityAccessPolicyId).HasColumnName("group_entity_access_policy_id");

//            builder.Property(e => e.AccessTypeId).HasColumnName("access_type_id");

//            builder.Property(e => e.AllowAccess).HasColumnName("allow_access");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.EntityName)
//                .HasColumnName("entity_name")
//                .HasMaxLength(500);

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.RoleId).HasColumnName("role_id");

//            builder.HasOne(d => d.AccessType)
//                .WithMany(p => p.GroupEntityAccessPolicies)
//                .HasForeignKey(d => d.AccessTypeId)
//                .HasConstraintName("FK__group_ent__acces__5D95E53A");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.GroupEntityAccessPolicies)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__group_ent__audit__5E8A0973");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.GroupEntityAccessPolicies)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__group_ent__offic__5BAD9CC8");

//            builder.HasOne(d => d.Role)
//                .WithMany(p => p.GroupEntityAccessPolicies)
//                .HasForeignKey(d => d.RoleId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__group_ent__role___5CA1C101");
//        }
//    }
//}
