//using ApplicationCore.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Accounts
//{
//    public class InstalledDomainConfiguration : IEntityTypeConfiguration<InstalledDomain>
//    {
//        public void Configure(EntityTypeBuilder<InstalledDomain> builder)
//        {
//            builder.HasKey(e => e.DomainId);

//            builder.ToTable("installed_domains", "account");

//            builder.HasIndex(e => e.DomainName)
//                .HasName("installed_domains_domain_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.DomainId).HasColumnName("domain_id");

//            builder.Property(e => e.AdminEmail)
//                .HasColumnName("admin_email")
//                .HasMaxLength(500);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.DomainName)
//                .HasColumnName("domain_name")
//                .HasMaxLength(500);
//        }
//    }
//}
