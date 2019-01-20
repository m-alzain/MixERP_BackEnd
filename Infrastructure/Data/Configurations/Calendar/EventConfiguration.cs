//using ApplicationCore.Entities.Calendar;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Calendar
//{
//    public class EventConfiguration : IEntityTypeConfiguration<Event>
//    {
//        public void Configure(EntityTypeBuilder<Event> builder)
//        {
//            builder.ToTable("events", "calendar");

//            builder.Property(e => e.EventId)
//                .HasColumnName("event_id")
//                .HasDefaultValueSql("(newsequentialid())");

//            builder.Property(e => e.Alarm).HasColumnName("alarm");

//            builder.Property(e => e.AllDay).HasColumnName("all_day");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CategoryId).HasColumnName("category_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.EndsOn).HasColumnName("ends_on");

//            builder.Property(e => e.IsPrivate).HasColumnName("is_private");

//            builder.Property(e => e.Location)
//                .HasColumnName("location")
//                .HasMaxLength(2000);

//            builder.Property(e => e.Name)
//                .IsRequired()
//                .HasColumnName("name")
//                .HasMaxLength(500);

//            builder.Property(e => e.Note).HasColumnName("note");

//            builder.Property(e => e.Recurrence).HasColumnName("recurrence");

//            builder.Property(e => e.ReminderTypes).HasColumnName("reminder_types");

//            builder.Property(e => e.StartsAt).HasColumnName("starts_at");

//            builder.Property(e => e.TimeZone)
//                .IsRequired()
//                .HasColumnName("time_zone")
//                .HasMaxLength(200);

//            builder.Property(e => e.Until).HasColumnName("until");

//            builder.Property(e => e.Url)
//                .HasColumnName("url")
//                .HasMaxLength(500);

//            builder.Property(e => e.UserId).HasColumnName("user_id");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.EventAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__events__audit_us__351DDF8C");

//            builder.HasOne(d => d.Category)
//                .WithMany(p => p.Events)
//                .HasForeignKey(d => d.CategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__events__category__324172E1");

//            builder.HasOne(d => d.User)
//                .WithMany(p => p.EventUsers)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__events__user_id__3335971A");
//        }
//    }
//}
