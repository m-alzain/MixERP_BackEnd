//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    public class ConfigurationProfileConfiguration : IEntityTypeConfiguration<ConfigurationProfile>
//    {
//        public void Configure(EntityTypeBuilder<ConfigurationProfile> builder)
//        {
//            builder.ToTable("configuration_profiles", "account");

//            builder.HasIndex(e => e.IsActive)
//                .HasName("configuration_profile_uix")
//                .IsUnique()
//                .HasFilter("([is_active]=(1) AND [deleted]=(0))");

//            builder.HasIndex(e => e.ProfileName)
//                .HasName("UQ__configur__0C85D9E128BA427A")
//                .IsUnique();

//            builder.Property(e => e.ConfigurationProfileId).HasColumnName("configuration_profile_id");

//            builder.Property(e => e.AllowFacebookRegistration)
//                .IsRequired()
//                .HasColumnName("allow_facebook_registration")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.AllowGoogleRegistration)
//                .IsRequired()
//                .HasColumnName("allow_google_registration")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.AllowRegistration)
//                .IsRequired()
//                .HasColumnName("allow_registration")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.FacebookAppId)
//                .HasColumnName("facebook_app_id")
//                .HasMaxLength(500);

//            builder.Property(e => e.FacebookScope)
//                .HasColumnName("facebook_scope")
//                .HasMaxLength(500);

//            builder.Property(e => e.GoogleSigninClientId)
//                .HasColumnName("google_signin_client_id")
//                .HasMaxLength(500);

//            builder.Property(e => e.GoogleSigninScope)
//                .HasColumnName("google_signin_scope")
//                .HasMaxLength(500);

//            builder.Property(e => e.IsActive)
//                .IsRequired()
//                .HasColumnName("is_active")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.ProfileName)
//                .IsRequired()
//                .HasColumnName("profile_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.RegistrationOfficeId).HasColumnName("registration_office_id");

//            builder.Property(e => e.RegistrationRoleId).HasColumnName("registration_role_id");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.ConfigurationProfiles)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__configura__audit__04E4BC85");

//            builder.HasOne(d => d.RegistrationOffice)
//                .WithMany(p => p.ConfigurationProfiles)
//                .HasForeignKey(d => d.RegistrationOfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__configura__regis__6FE99F9F");

//            builder.HasOne(d => d.RegistrationRole)
//                .WithMany(p => p.ConfigurationProfiles)
//                .HasForeignKey(d => d.RegistrationRoleId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__configura__regis__70DDC3D8");
//        }
//    }
//}
