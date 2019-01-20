//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    public class LoginConfiguration : IEntityTypeConfiguration<Login>
//    {
//        public void Configure(EntityTypeBuilder<Login> builder)
//        {
//            builder.ToTable("logins", "account");

//            builder.Property(e => e.LoginId).HasColumnName("login_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Browser)
//                .HasColumnName("browser")
//                .HasMaxLength(500);

//            builder.Property(e => e.Culture)
//                .IsRequired()
//                .HasColumnName("culture")
//                .HasMaxLength(12);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.IpAddress)
//                .HasColumnName("ip_address")
//                .HasMaxLength(50);

//            builder.Property(e => e.IsActive)
//                .IsRequired()
//                .HasColumnName("is_active")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.LoginTimestamp)
//                .HasColumnName("login_timestamp")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.UserId).HasColumnName("user_id");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.LoginAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__logins__audit_us__2180FB33");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.Logins)
//                .HasForeignKey(d => d.OfficeId)
//                .HasConstraintName("FK__logins__office_i__1EA48E88");

//            builder.HasOne(d => d.User)
//                .WithMany(p => p.LoginUsers)
//                .HasForeignKey(d => d.UserId)
//                .HasConstraintName("FK__logins__user_id__1DB06A4F");
//        }
//    }
//}
