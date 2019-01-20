//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    class FbAccessTokenConfiguration : IEntityTypeConfiguration<FbAccessToken>
//    {
//        public void Configure(EntityTypeBuilder<FbAccessToken> builder)
//        {
//            builder.HasKey(e => e.UserId);

//            builder.ToTable("fb_access_tokens", "account");

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

//            builder.Property(e => e.FbUserId)
//                .HasColumnName("fb_user_id")
//                .HasMaxLength(500);

//            builder.Property(e => e.Token).HasColumnName("token");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.FbAccessTokenAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__fb_access__audit__1332DBDC");

//            builder.HasOne(d => d.User)
//                .WithOne(p => p.FbAccessTokenUser)
//                .HasForeignKey<FbAccessToken>(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__fb_access__user___123EB7A3");
//        }
//    }
//}
