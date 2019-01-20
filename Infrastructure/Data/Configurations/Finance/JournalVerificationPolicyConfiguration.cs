//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class JournalVerificationPolicyConfiguration : IEntityTypeConfiguration<JournalVerificationPolicy>
//    {
//        public void Configure(EntityTypeBuilder<JournalVerificationPolicy> builder)
//        {
//            builder.ToTable("journal_verification_policy", "finance");

//            builder.Property(e => e.JournalVerificationPolicyId).HasColumnName("journal_verification_policy_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CanSelfVerify).HasColumnName("can_self_verify");

//            builder.Property(e => e.CanVerify).HasColumnName("can_verify");

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

//            builder.Property(e => e.SelfVerificationLimit)
//                .HasColumnName("self_verification_limit")
//                .HasColumnType("numeric(30, 6)");

//            builder.Property(e => e.UserId).HasColumnName("user_id");

//            builder.Property(e => e.VerificationLimit)
//                .HasColumnName("verification_limit")
//                .HasColumnType("numeric(30, 6)");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.JournalVerificationPolicyAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__journal_v__audit__52793849");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.JournalVerificationPolicies)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__journal_v__offic__4DB4832C");

//            builder.HasOne(d => d.User)
//                .WithMany(p => p.JournalVerificationPolicyUsers)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__journal_v__user___4CC05EF3");
//        }
//    }
//}
