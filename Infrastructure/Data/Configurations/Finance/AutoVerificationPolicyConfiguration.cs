//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class AutoVerificationPolicyConfiguration : IEntityTypeConfiguration<AutoVerificationPolicy>
//    {
//        public void Configure(EntityTypeBuilder<AutoVerificationPolicy> builder)
//        {
//            builder.ToTable("auto_verification_policy", "finance");

//            builder.Property(e => e.AutoVerificationPolicyId).HasColumnName("auto_verification_policy_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.EffectiveFrom)
//                .HasColumnName("effective_from")
//                .HasColumnType("date");

//            builder.Property(e => e.EndsOn)
//                .HasColumnName("ends_on")
//                .HasColumnType("date");

//            builder.Property(e => e.IsActive).HasColumnName("is_active");

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.UserId).HasColumnName("user_id");

//            builder.Property(e => e.VerificationLimit)
//                .HasColumnName("verification_limit")
//                .HasColumnType("numeric(30, 6)");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.AutoVerificationPolicyAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__auto_veri__audit__5A1A5A11");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.AutoVerificationPolicies)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__auto_veri__offic__5832119F");

//            builder.HasOne(d => d.User)
//                .WithMany(p => p.AutoVerificationPolicyUsers)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__auto_veri__user___573DED66");
//        }
//    }
//}
