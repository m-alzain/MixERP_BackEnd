//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    public class ResetRequestConfiguration : IEntityTypeConfiguration<ResetRequest>
//    {
//        public void Configure(EntityTypeBuilder<ResetRequest> entity)
//        {
//            entity.HasKey(e => e.RequestId);

//            entity.ToTable("reset_requests", "account");

//            entity.Property(e => e.RequestId)
//                .HasColumnName("request_id")
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
//                .HasColumnName("email")
//                .HasMaxLength(500);

//            entity.Property(e => e.ExpiresOn)
//                .HasColumnName("expires_on")
//                .HasDefaultValueSql("(dateadd(day,(1),getutcdate()))");

//            entity.Property(e => e.IpAddress)
//                .HasColumnName("ip_address")
//                .HasMaxLength(50);

//            entity.Property(e => e.Name)
//                .HasColumnName("name")
//                .HasMaxLength(500);

//            entity.Property(e => e.RequestedOn)
//                .HasColumnName("requested_on")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.UserId).HasColumnName("user_id");

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.ResetRequestAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__reset_req__audit__0D7A0286");

//            entity.HasOne(d => d.User)
//                .WithMany(p => p.ResetRequestUsers)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__reset_req__user___09A971A2");
//        }
//    }
//}
