//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
//    {
//        public void Configure(EntityTypeBuilder<TransactionType> entity)
//        {
//            entity.ToTable("transaction_types", "finance");

//            entity.HasIndex(e => e.TransactionTypeCode)
//                .HasName("transaction_types_transaction_type_code_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            entity.HasIndex(e => e.TransactionTypeName)
//                .HasName("transaction_types_transaction_type_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            entity.Property(e => e.TransactionTypeId)
//                .HasColumnName("transaction_type_id")
//                .ValueGeneratedNever();

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.TransactionTypeCode)
//                .HasColumnName("transaction_type_code")
//                .HasMaxLength(4);

//            entity.Property(e => e.TransactionTypeName)
//                .HasColumnName("transaction_type_name")
//                .HasMaxLength(100);

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.TransactionTypes)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__transacti__audit__04459E07");
//        }
//    }
//}
