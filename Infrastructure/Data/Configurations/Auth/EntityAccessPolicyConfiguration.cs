//using ApplicationCore.Entities.Auth;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Auth
//{
//    public class EntityAccessPolicyConfiguration : IEntityTypeConfiguration<EntityAccessPolicy>
//    {
//        public void Configure(EntityTypeBuilder<EntityAccessPolicy> builder)
//        {
//            builder.ToTable("entity_access_policy", "auth");

//            builder.Property(e => e.EntityAccessPolicyId).HasColumnName("entity_access_policy_id");

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

//            builder.Property(e => e.UserId).HasColumnName("user_id");

//            builder.HasOne(d => d.AccessType)
//                .WithMany(p => p.EntityAccessPolicies)
//                .HasForeignKey(d => d.AccessTypeId)
//                .HasConstraintName("FK__entity_ac__acces__65370702");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.EntityAccessPolicyAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__entity_ac__audit__662B2B3B");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.EntityAccessPolicies)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__entity_ac__offic__634EBE90");

//            builder.HasOne(d => d.User)
//                .WithMany(p => p.EntityAccessPolicyUsers)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__entity_ac__user___6442E2C9");
//        }
//    }
//}
