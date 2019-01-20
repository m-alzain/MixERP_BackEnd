//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class ExchangeRateDetailConfiguration : IEntityTypeConfiguration<ExchangeRateDetail>
//    {
//        public void Configure(EntityTypeBuilder<ExchangeRateDetail> builder)
//        {
//            builder.ToTable("exchange_rate_details", "finance");

//            builder.Property(e => e.ExchangeRateDetailId).HasColumnName("exchange_rate_detail_id");

//            builder.Property(e => e.ExchangeRate)
//                .HasColumnName("exchange_rate")
//                .HasColumnType("numeric(30, 6)");

//            builder.Property(e => e.ExchangeRateId).HasColumnName("exchange_rate_id");

//            builder.Property(e => e.ForeignCurrencyCode)
//                .IsRequired()
//                .HasColumnName("foreign_currency_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.LocalCurrencyCode)
//                .IsRequired()
//                .HasColumnName("local_currency_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.Unit).HasColumnName("unit");

//            builder.HasOne(d => d.ExchangeRateNavigation)
//                .WithMany(p => p.ExchangeRateDetails)
//                .HasForeignKey(d => d.ExchangeRateId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__exchange___excha__4707859D");

//            builder.HasOne(d => d.ForeignCurrencyCodeNavigation)
//                .WithMany(p => p.ExchangeRateDetailForeignCurrencyCodeNavigations)
//                .HasForeignKey(d => d.ForeignCurrencyCode)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__exchange___forei__48EFCE0F");

//            builder.HasOne(d => d.LocalCurrencyCodeNavigation)
//                .WithMany(p => p.ExchangeRateDetailLocalCurrencyCodeNavigations)
//                .HasForeignKey(d => d.LocalCurrencyCode)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__exchange___local__47FBA9D6");
//        }
//    }
//}
