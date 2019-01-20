//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class MerchantFeeSetupConfiguration : IEntityTypeConfiguration<MerchantFeeSetup>
//    {
//        public void Configure(EntityTypeBuilder<MerchantFeeSetup> entity)
//        {
//            entity.ToTable("merchant_fee_setup", "finance");

//            entity.HasIndex(e => new { e.MerchantAccountId, e.PaymentCardId })
//                .HasName("merchant_fee_setup_merchant_account_id_payment_card_id_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            entity.Property(e => e.MerchantFeeSetupId).HasColumnName("merchant_fee_setup_id");

//            entity.Property(e => e.AccountId).HasColumnName("account_id");

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.CustomerPaysFee).HasColumnName("customer_pays_fee");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.MerchantAccountId).HasColumnName("merchant_account_id");

//            entity.Property(e => e.PaymentCardId).HasColumnName("payment_card_id");

//            entity.Property(e => e.Rate)
//                .HasColumnName("rate")
//                .HasColumnType("numeric(30, 6)");

//            entity.Property(e => e.StatementReference)
//                .IsRequired()
//                .HasColumnName("statement_reference")
//                .HasMaxLength(2000)
//                .HasDefaultValueSql("('')");

//            entity.HasOne(d => d.Account)
//                .WithMany(p => p.MerchantFeeSetups)
//                .HasForeignKey(d => d.AccountId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__merchant___accou__3B95D2F1");

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.MerchantFeeSetups)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__merchant___audit__3D7E1B63");

//            entity.HasOne(d => d.MerchantAccount)
//                .WithMany(p => p.MerchantFeeSetups)
//                .HasForeignKey(d => d.MerchantAccountId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__merchant___merch__38B96646");

//            entity.HasOne(d => d.PaymentCard)
//                .WithMany(p => p.MerchantFeeSetups)
//                .HasForeignKey(d => d.PaymentCardId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__merchant___payme__39AD8A7F");
//        }
//    }
//}
