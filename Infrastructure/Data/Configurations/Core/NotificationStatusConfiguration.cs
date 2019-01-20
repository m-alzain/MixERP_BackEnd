//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class NotificationStatusConfiguration : IEntityTypeConfiguration<NotificationStatus>
//    {
//        public void Configure(EntityTypeBuilder<NotificationStatus> entity)
//        {
//            entity.ToTable("notification_statuses", "core");

//            entity.Property(e => e.NotificationStatusId)
//                .HasColumnName("notification_status_id")
//                .HasDefaultValueSql("(newid())");

//            entity.Property(e => e.LastSeenOn)
//                .HasColumnName("last_seen_on")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.NotificationId).HasColumnName("notification_id");

//            entity.Property(e => e.SeenBy).HasColumnName("seen_by");

//            entity.HasOne(d => d.Notification)
//                .WithMany(p => p.NotificationStatuses)
//                .HasForeignKey(d => d.NotificationId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__notificat__notif__5441852A");
//        }
//    }
//}
