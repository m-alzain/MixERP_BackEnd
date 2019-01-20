//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class CountryConfiguration : IEntityTypeConfiguration<Country>
//    {
//        public void Configure(EntityTypeBuilder<Country> builder)
//        {
//            builder.HasKey(e => e.CountryCode);

//            builder.ToTable("countries", "core");

//            builder.Property(e => e.CountryCode)
//                .HasColumnName("country_code")
//                .HasMaxLength(12)
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CountryName)
//                .IsRequired()
//                .HasColumnName("country_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");
//        }
//    }
//}
