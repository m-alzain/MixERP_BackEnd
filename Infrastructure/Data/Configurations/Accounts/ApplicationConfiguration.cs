//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
//    {
//        public void Configure(EntityTypeBuilder<Application> builder)
//        {
//            builder.ToTable("applications", "account");

//            builder.HasIndex(e => e.AppSecret)
//                .HasName("UQ__applicat__89A4E7765D484DF6")
//                .IsUnique();

//            builder.HasIndex(e => e.ApplicationName)
//                .HasName("applications_app_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.ApplicationId)
//                .HasColumnName("application_id")
//                .HasDefaultValueSql("(newid())");

//            builder.Property(e => e.AppSecret)
//                .HasColumnName("app_secret")
//                .HasMaxLength(500);

//            builder.Property(e => e.ApplicationName)
//                .IsRequired()
//                .HasColumnName("application_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.ApplicationUrl)
//                .HasColumnName("application_url")
//                .HasMaxLength(500);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.BrowserBasedApp).HasColumnName("browser_based_app");

//            builder.Property(e => e.Culture)
//                .HasColumnName("culture")
//                .HasMaxLength(12);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Description)
//                .HasColumnName("description")
//                .HasMaxLength(500);

//            builder.Property(e => e.DisplayName)
//                .HasColumnName("display_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.PrivacyPolicyUrl)
//                .HasColumnName("privacy_policy_url")
//                .HasMaxLength(500);

//            builder.Property(e => e.PublishedOn)
//                .HasColumnName("published_on")
//                .HasColumnType("date");

//            builder.Property(e => e.Publisher)
//                .IsRequired()
//                .HasColumnName("publisher")
//                .HasMaxLength(100);

//            builder.Property(e => e.RedirectUrl)
//                .HasColumnName("redirect_url")
//                .HasMaxLength(500);

//            builder.Property(e => e.SupportEmail)
//                .HasColumnName("support_email")
//                .HasMaxLength(100);

//            builder.Property(e => e.TermsOfServiceUrl)
//                .HasColumnName("terms_of_service_url")
//                .HasMaxLength(500);

//            builder.Property(e => e.VersionNumber)
//                .HasColumnName("version_number")
//                .HasMaxLength(100);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Applications)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__applicati__audit__282DF8C2");
//        }
//    }
//}
