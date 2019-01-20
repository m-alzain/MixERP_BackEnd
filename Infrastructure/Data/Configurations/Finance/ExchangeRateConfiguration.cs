//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
//    {
//        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
//        {
//            builder.ToTable("exchange_rates", "finance");

//            builder.Property(e => e.ExchangeRateId).HasColumnName("exchange_rate_id");

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.Status)
//                .IsRequired()
//                .HasColumnName("status")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.UpdatedOn)
//                .HasColumnName("updated_on")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.ExchangeRates)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__exchange___offic__4336F4B9");
//        }
//    }
//}
