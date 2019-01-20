//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    public class AccessTokenConfiguration : IEntityTypeConfiguration<AccessToken>
//    {
//        public void Configure(EntityTypeBuilder<AccessToken> builder)
//        {
//            builder.ToTable("access_tokens", "account");

//            builder.Property(e => e.AccessTokenId)
//                .HasColumnName("access_token_id")
//                .HasDefaultValueSql("(newid())");

//            builder.Property(e => e.ApplicationId).HasColumnName("application_id");

//            builder.Property(e => e.Audience)
//                .IsRequired()
//                .HasColumnName("audience")
//                .HasMaxLength(500);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Claims).HasColumnName("claims");

//            builder.Property(e => e.ClientToken).HasColumnName("client_token");

//            builder.Property(e => e.CreatedOn).HasColumnName("created_on");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.ExpiresOn).HasColumnName("expires_on");

//            builder.Property(e => e.Header)
//                .HasColumnName("header")
//                .HasMaxLength(500);

//            builder.Property(e => e.IpAddress)
//                .HasColumnName("ip_address")
//                .HasMaxLength(100);

//            builder.Property(e => e.IssuedBy)
//                .IsRequired()
//                .HasColumnName("issued_by")
//                .HasMaxLength(500);

//            builder.Property(e => e.LoginId).HasColumnName("login_id");

//            builder.Property(e => e.Revoked).HasColumnName("revoked");

//            builder.Property(e => e.RevokedBy).HasColumnName("revoked_by");

//            builder.Property(e => e.RevokedOn).HasColumnName("revoked_on");

//            builder.Property(e => e.Subject)
//                .HasColumnName("subject")
//                .HasMaxLength(500);

//            builder.Property(e => e.TokenId)
//                .HasColumnName("token_id")
//                .HasMaxLength(500);

//            builder.Property(e => e.UserAgent)
//                .HasColumnName("user_agent")
//                .HasMaxLength(500);

//            builder.HasOne(d => d.Application)
//                .WithMany(p => p.AccessTokens)
//                .HasForeignKey(d => d.ApplicationId)
//                .HasConstraintName("FK__access_to__appli__2DE6D218");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.AccessTokenAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__access_to__audit__31B762FC");

//            builder.HasOne(d => d.Login)
//                .WithMany(p => p.AccessTokens)
//                .HasForeignKey(d => d.LoginId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__access_to__login__2EDAF651");

//            builder.HasOne(d => d.RevokedByNavigation)
//                .WithMany(p => p.AccessTokenRevokedByNavigations)
//                .HasForeignKey(d => d.RevokedBy)
//                .HasConstraintName("FK__access_to__revok__30C33EC3");

//        }
//    }
//}
