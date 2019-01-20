//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Config
//{
//    public class EmailQueueConfiguration : IEntityTypeConfiguration<EmailQueue>
//    {
//        public void Configure(EntityTypeBuilder<EmailQueue> builder)
//        {
//            builder.HasKey(e => e.QueueId);

//            builder.ToTable("email_queue", "config");

//            builder.Property(e => e.QueueId).HasColumnName("queue_id");

//            builder.Property(e => e.AddedOn)
//                .HasColumnName("added_on")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.ApplicationName)
//                .HasColumnName("application_name")
//                .HasMaxLength(256);

//            builder.Property(e => e.Attachments)
//                .HasColumnName("attachments")
//                .HasMaxLength(2000);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Canceled).HasColumnName("canceled");

//            builder.Property(e => e.CanceledOn).HasColumnName("canceled_on");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Delivered).HasColumnName("delivered");

//            builder.Property(e => e.DeliveredOn).HasColumnName("delivered_on");

//            builder.Property(e => e.FromEmail)
//                .IsRequired()
//                .HasColumnName("from_email")
//                .HasMaxLength(256);

//            builder.Property(e => e.FromName)
//                .IsRequired()
//                .HasColumnName("from_name")
//                .HasMaxLength(256);

//            builder.Property(e => e.IsTest).HasColumnName("is_test");

//            builder.Property(e => e.Message)
//                .IsRequired()
//                .HasColumnName("message");

//            builder.Property(e => e.ReplyTo)
//                .IsRequired()
//                .HasColumnName("reply_to")
//                .HasMaxLength(256);

//            builder.Property(e => e.ReplyToName)
//                .IsRequired()
//                .HasColumnName("reply_to_name")
//                .HasMaxLength(256);

//            builder.Property(e => e.SendOn)
//                .HasColumnName("send_on")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.SendTo)
//                .IsRequired()
//                .HasColumnName("send_to")
//                .HasMaxLength(256);

//            builder.Property(e => e.Subject)
//                .IsRequired()
//                .HasColumnName("subject")
//                .HasMaxLength(256);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.EmailQueues)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__email_que__audit__2057CCD0");
//        }
//    }
//}
