//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
//    {
//        public void Configure(EntityTypeBuilder<Registration> entity)
//        {
//            entity.ToTable("registrations", "account");

//            entity.HasIndex(e => e.Email)
//                .HasName("registrations_email_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            entity.Property(e => e.RegistrationId)
//                .HasColumnName("registration_id")
//                .HasDefaultValueSql("(newid())");

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.Browser)
//                .HasColumnName("browser")
//                .HasMaxLength(500);

//            entity.Property(e => e.Confirmed)
//                .HasColumnName("confirmed")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.ConfirmedOn).HasColumnName("confirmed_on");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.Email)
//                .IsRequired()
//                .HasColumnName("email")
//                .HasMaxLength(100);

//            entity.Property(e => e.IpAddress)
//                .HasColumnName("ip_address")
//                .HasMaxLength(50);

//            entity.Property(e => e.Name)
//                .HasColumnName("name")
//                .HasMaxLength(100);

//            entity.Property(e => e.Password)
//                .HasColumnName("password")
//                .HasMaxLength(500);

//            entity.Property(e => e.Phone)
//                .HasColumnName("phone")
//                .HasMaxLength(100);

//            entity.Property(e => e.RegisteredOn)
//                .HasColumnName("registered_on")
//                .HasDefaultValueSql("(getutcdate())");
//        }
//    }
//}
