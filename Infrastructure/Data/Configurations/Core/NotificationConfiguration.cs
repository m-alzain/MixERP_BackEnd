//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
//    {
//        public void Configure(EntityTypeBuilder<Notification> entity)
//        {
//            entity.ToTable("notifications", "core");

//            entity.Property(e => e.NotificationId)
//                .HasColumnName("notification_id")
//                .HasDefaultValueSql("(newid())");

//            entity.Property(e => e.AssociatedApp)
//                .IsRequired()
//                .HasColumnName("associated_app")
//                .HasMaxLength(100);

//            entity.Property(e => e.AssociatedMenuId).HasColumnName("associated_menu_id");

//            entity.Property(e => e.EventTimestamp)
//                .HasColumnName("event_timestamp")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.FormattedText)
//                .HasColumnName("formatted_text")
//                .HasMaxLength(4000);

//            entity.Property(e => e.Icon)
//                .HasColumnName("icon")
//                .HasMaxLength(100);

//            entity.Property(e => e.OfficeId).HasColumnName("office_id");

//            entity.Property(e => e.Tenant)
//                .HasColumnName("tenant")
//                .HasMaxLength(1000);

//            entity.Property(e => e.ToLoginId).HasColumnName("to_login_id");

//            entity.Property(e => e.ToRoleId).HasColumnName("to_role_id");

//            entity.Property(e => e.ToUserId).HasColumnName("to_user_id");

//            entity.Property(e => e.Url)
//                .HasColumnName("url")
//                .HasMaxLength(2000);

//            entity.HasOne(d => d.AssociatedAppNavigation)
//                .WithMany(p => p.Notifications)
//                .HasForeignKey(d => d.AssociatedApp)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__notificat__assoc__4F7CD00D");

//            entity.HasOne(d => d.AssociatedMenu)
//                .WithMany(p => p.Notifications)
//                .HasForeignKey(d => d.AssociatedMenuId)
//                .HasConstraintName("FK__notificat__assoc__5070F446");

//            entity.HasOne(d => d.Office)
//                .WithMany(p => p.Notifications)
//                .HasForeignKey(d => d.OfficeId)
//                .HasConstraintName("FK__notificat__offic__4E88ABD4");
//        }
//    }
//}
