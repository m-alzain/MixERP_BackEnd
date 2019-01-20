//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class PaymentCardConfiguration : IEntityTypeConfiguration<PaymentCard>
//    {
//        public void Configure(EntityTypeBuilder<PaymentCard> entity)
//        {
//            entity.ToTable("payment_cards", "finance");

//            entity.HasIndex(e => e.PaymentCardCode)
//                .HasName("payment_cards_payment_card_code_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            entity.HasIndex(e => e.PaymentCardName)
//                .HasName("payment_cards_payment_card_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            entity.Property(e => e.PaymentCardId).HasColumnName("payment_card_id");

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.CardTypeId).HasColumnName("card_type_id");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.PaymentCardCode)
//                .IsRequired()
//                .HasColumnName("payment_card_code")
//                .HasMaxLength(12);

//            entity.Property(e => e.PaymentCardName)
//                .IsRequired()
//                .HasColumnName("payment_card_name")
//                .HasMaxLength(100);

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.PaymentCards)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__payment_c__audit__33F4B129");

//            entity.HasOne(d => d.CardType)
//                .WithMany(p => p.PaymentCards)
//                .HasForeignKey(d => d.CardTypeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__payment_c__card___33008CF0");
//        }
//    }
//}
