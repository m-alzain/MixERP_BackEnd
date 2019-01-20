//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Config
//{
//    public class SmtpConfigConfiguration : IEntityTypeConfiguration<SmtpConfig>
//    {
//        public void Configure(EntityTypeBuilder<SmtpConfig> entity)
//        {
//            entity.ToTable("smtp_configs", "config");

//            entity.HasIndex(e => e.ConfigurationName)
//                .HasName("UQ__smtp_con__8F784E0F0B1E5676")
//                .IsUnique();

//            entity.Property(e => e.SmtpConfigId).HasColumnName("smtp_config_id");

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.ConfigurationName)
//                .IsRequired()
//                .HasColumnName("configuration_name")
//                .HasMaxLength(256);

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.Enabled).HasColumnName("enabled");

//            entity.Property(e => e.FromDisplayName)
//                .IsRequired()
//                .HasColumnName("from_display_name")
//                .HasMaxLength(256);

//            entity.Property(e => e.FromEmailAddress)
//                .IsRequired()
//                .HasColumnName("from_email_address")
//                .HasMaxLength(256);

//            entity.Property(e => e.IsDefault).HasColumnName("is_default");

//            entity.Property(e => e.SmtpEnableSsl)
//                .IsRequired()
//                .HasColumnName("smtp_enable_ssl")
//                .HasDefaultValueSql("((1))");

//            entity.Property(e => e.SmtpHost)
//                .IsRequired()
//                .HasColumnName("smtp_host")
//                .HasMaxLength(256);

//            entity.Property(e => e.SmtpPassword)
//                .IsRequired()
//                .HasColumnName("smtp_password")
//                .HasMaxLength(256);

//            entity.Property(e => e.SmtpPort)
//                .HasColumnName("smtp_port")
//                .HasDefaultValueSql("((587))");

//            entity.Property(e => e.SmtpUsername)
//                .IsRequired()
//                .HasColumnName("smtp_username")
//                .HasMaxLength(256);

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.SmtpConfigs)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__smtp_conf__audit__16CE6296");
//        }
//    }
//}
