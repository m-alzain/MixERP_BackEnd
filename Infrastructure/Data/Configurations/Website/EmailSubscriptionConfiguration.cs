//using ApplicationCore.Entities.Website;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Website
//{
//    public class EmailSubscriptionConfiguration : IEntityTypeConfiguration<EmailSubscription>
//    {
//        public void Configure(EntityTypeBuilder<EmailSubscription> builder)
//        {
//            builder.ToTable("email_subscriptions", "website");

//            builder.HasIndex(e => e.Email)
//                .HasName("UQ__email_su__AB6E6164CF62348B")
//                .IsUnique();

//            builder.Property(e => e.EmailSubscriptionId)
//                .HasColumnName("email_subscription_id")
//                .HasDefaultValueSql("(newid())");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Browser)
//                .HasColumnName("browser")
//                .HasMaxLength(500);

//            builder.Property(e => e.Confirmed)
//                .HasColumnName("confirmed")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.ConfirmedOn).HasColumnName("confirmed_on");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Email)
//                .IsRequired()
//                .HasColumnName("email")
//                .HasMaxLength(100);

//            builder.Property(e => e.FirstName)
//                .HasColumnName("first_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.IpAddress)
//                .HasColumnName("ip_address")
//                .HasMaxLength(50);

//            builder.Property(e => e.LastName)
//                .HasColumnName("last_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.SubscribedOn)
//                .HasColumnName("subscribed_on")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.Unsubscribed)
//                .HasColumnName("unsubscribed")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.UnsubscribedOn).HasColumnName("unsubscribed_on");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.EmailSubscriptions)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__email_sub__audit__61316BF4");
//        }
//    }
//}
