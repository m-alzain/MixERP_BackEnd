//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
//    {
//        public void Configure(EntityTypeBuilder<Currency> builder)
//        {
//            builder.HasKey(e => e.CurrencyCode);

//            builder.ToTable("currencies", "core");

//            builder.HasIndex(e => e.CurrencyName)
//                .HasName("UQ__currenci__EC6E104DA3081EAE")
//                .IsUnique();

//            builder.Property(e => e.CurrencyCode)
//                .HasColumnName("currency_code")
//                .HasMaxLength(12)
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CurrencyId)
//                .HasColumnName("currency_id")
//                .ValueGeneratedOnAdd();

//            builder.Property(e => e.CurrencyName)
//                .IsRequired()
//                .HasColumnName("currency_name")
//                .HasMaxLength(48);

//            builder.Property(e => e.CurrencySymbol)
//                .IsRequired()
//                .HasColumnName("currency_symbol")
//                .HasMaxLength(12);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.HundredthName)
//                .IsRequired()
//                .HasColumnName("hundredth_name")
//                .HasMaxLength(48);
//        }
//    }
//}
