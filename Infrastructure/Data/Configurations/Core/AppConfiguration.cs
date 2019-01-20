//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class AppConfiguration : IEntityTypeConfiguration<App>
//    {
//        public void Configure(EntityTypeBuilder<App> builder)
//        {
//            builder.HasKey(e => e.AppName);

//            builder.ToTable("apps", "core");

//            builder.HasIndex(e => e.AppName)
//                .HasName("apps_app_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.AppName)
//                .HasColumnName("app_name")
//                .HasMaxLength(100)
//                .ValueGeneratedNever();

//            builder.Property(e => e.AppId)
//                .HasColumnName("app_id")
//                .ValueGeneratedOnAdd();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.I18nKey)
//                .IsRequired()
//                .HasColumnName("i18n_key")
//                .HasMaxLength(200);

//            builder.Property(e => e.Icon).HasColumnName("icon");

//            builder.Property(e => e.LandingUrl)
//                .HasColumnName("landing_url")
//                .HasMaxLength(500);

//            builder.Property(e => e.Name)
//                .HasColumnName("name")
//                .HasMaxLength(100);

//            builder.Property(e => e.PublishedOn)
//                .HasColumnName("published_on")
//                .HasColumnType("date");

//            builder.Property(e => e.Publisher)
//                .HasColumnName("publisher")
//                .HasMaxLength(500);

//            builder.Property(e => e.VersionNumber)
//                .HasColumnName("version_number")
//                .HasMaxLength(100);
//        }
//    }
//}
