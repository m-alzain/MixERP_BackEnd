//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    public class GoogleAccessTokenConfiguration : IEntityTypeConfiguration<GoogleAccessToken>
//    {
//        public void Configure(EntityTypeBuilder<GoogleAccessToken> builder)
//        {
//            builder.HasKey(e => e.UserId);

//            builder.ToTable("google_access_tokens", "account");

//            builder.Property(e => e.UserId)
//                .HasColumnName("user_id")
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Token).HasColumnName("token");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.GoogleAccessTokenAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__google_ac__audit__18EBB532");

//            builder.HasOne(d => d.User)
//                .WithOne(p => p.GoogleAccessTokenUser)
//                .HasForeignKey<GoogleAccessToken>(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__google_ac__user___17F790F9");
//        }
//    }
//}
