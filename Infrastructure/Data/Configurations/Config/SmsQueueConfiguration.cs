//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Config
//{
//    public class SmsQueueConfiguration : IEntityTypeConfiguration<SmsQueue>
//    {
//        public void Configure(EntityTypeBuilder<SmsQueue> entity)
//        {
//            entity.HasKey(e => e.QueueId);

//            entity.ToTable("sms_queue", "config");

//            entity.Property(e => e.QueueId).HasColumnName("queue_id");

//            entity.Property(e => e.AddedOn)
//                .HasColumnName("added_on")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.ApplicationName)
//                .HasColumnName("application_name")
//                .HasMaxLength(256);

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.Canceled).HasColumnName("canceled");

//            entity.Property(e => e.CanceledOn).HasColumnName("canceled_on");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.Delivered).HasColumnName("delivered");

//            entity.Property(e => e.DeliveredOn).HasColumnName("delivered_on");

//            entity.Property(e => e.FromName)
//                .IsRequired()
//                .HasColumnName("from_name")
//                .HasMaxLength(256);

//            entity.Property(e => e.FromNumber)
//                .IsRequired()
//                .HasColumnName("from_number")
//                .HasMaxLength(256);

//            entity.Property(e => e.IsTest).HasColumnName("is_test");

//            entity.Property(e => e.Message)
//                .IsRequired()
//                .HasColumnName("message");

//            entity.Property(e => e.SendOn)
//                .HasColumnName("send_on")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.SendTo)
//                .IsRequired()
//                .HasColumnName("send_to")
//                .HasMaxLength(256);

//            entity.Property(e => e.Subject)
//                .IsRequired()
//                .HasColumnName("subject")
//                .HasMaxLength(256);

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.SmsQueues)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__sms_queue__audit__29E1370A");
//        }
//    }
//}
