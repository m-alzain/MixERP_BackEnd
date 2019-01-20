//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class MaritalStatusConfiguration : IEntityTypeConfiguration<MaritalStatus>
//    {
//        public void Configure(EntityTypeBuilder<MaritalStatus> builder)
//        {
//            builder.ToTable("marital_statuses", "core");

//            builder.HasIndex(e => e.MaritalStatusCode)
//                .HasName("UQ__marital___507BD4B59992DFB0")
//                .IsUnique();

//            builder.Property(e => e.MaritalStatusId).HasColumnName("marital_status_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.IsLegallyRecognizedMarriage).HasColumnName("is_legally_recognized_marriage");

//            builder.Property(e => e.MaritalStatusCode)
//                .IsRequired()
//                .HasColumnName("marital_status_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.MaritalStatusName)
//                .IsRequired()
//                .HasColumnName("marital_status_name")
//                .HasMaxLength(128);
//        }
//    }
//}
