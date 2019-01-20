//using ApplicationCore.Entities.Website;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Website
//{
//    public class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
//    {
//        public void Configure(EntityTypeBuilder<Configuration> builder)
//        {
//            builder.ToTable("configurations", "website");

//            builder.HasIndex(e => e.DomainName)
//                .HasName("configuration_domain_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.ConfigurationId).HasColumnName("configuration_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.BlogDescription)
//                .HasColumnName("blog_description")
//                .HasMaxLength(500);

//            builder.Property(e => e.BlogTitle)
//                .HasColumnName("blog_title")
//                .HasMaxLength(500);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Description)
//                .HasColumnName("description")
//                .HasMaxLength(500);

//            builder.Property(e => e.DomainName)
//                .IsRequired()
//                .HasColumnName("domain_name")
//                .HasMaxLength(500);

//            builder.Property(e => e.IsDefault)
//                .IsRequired()
//                .HasColumnName("is_default")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.WebsiteName)
//                .IsRequired()
//                .HasColumnName("website_name")
//                .HasMaxLength(500);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Configurations)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__configura__audit__57A801BA");
//        }
//    }
//}
