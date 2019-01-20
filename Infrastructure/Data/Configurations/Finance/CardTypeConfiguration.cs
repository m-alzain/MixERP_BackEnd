//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class CardTypeConfiguration : IEntityTypeConfiguration<CardType>
//    {
//        public void Configure(EntityTypeBuilder<CardType> builder)
//        {
//            builder.ToTable("card_types", "finance");

//            builder.HasIndex(e => e.CardTypeCode)
//                .HasName("card_types_card_type_code_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.CardTypeName)
//                .HasName("card_types_card_type_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.CardTypeId)
//                .HasColumnName("card_type_id")
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CardTypeCode)
//                .IsRequired()
//                .HasColumnName("card_type_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.CardTypeName)
//                .IsRequired()
//                .HasColumnName("card_type_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.CardTypes)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__card_type__audit__2E3BD7D3");
//        }
//    }
//}
