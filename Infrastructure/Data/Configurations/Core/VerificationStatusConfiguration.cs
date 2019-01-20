//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class VerificationStatusConfiguration : IEntityTypeConfiguration<VerificationStatus>
//    {
//        public void Configure(EntityTypeBuilder<VerificationStatus> entity)
//        {
//            entity.ToTable("verification_statuses", "core");

//            entity.Property(e => e.VerificationStatusId)
//                .HasColumnName("verification_status_id")
//                .ValueGeneratedNever();

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.VerificationStatusName)
//                .IsRequired()
//                .HasColumnName("verification_status_name")
//                .HasMaxLength(128);
//        }
//    }
//}
