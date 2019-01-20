//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class TransactionDocumentConfiguration : IEntityTypeConfiguration<TransactionDocument>
//    {
//        public void Configure(EntityTypeBuilder<TransactionDocument> entity)
//        {
//            entity.HasKey(e => e.DocumentId);

//            entity.ToTable("transaction_documents", "finance");

//            entity.Property(e => e.DocumentId).HasColumnName("document_id");

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.FileExtension)
//                .HasColumnName("file_extension")
//                .HasMaxLength(50);

//            entity.Property(e => e.FilePath)
//                .IsRequired()
//                .HasColumnName("file_path")
//                .HasMaxLength(2000);

//            entity.Property(e => e.Memo)
//                .HasColumnName("memo")
//                .HasMaxLength(2000);

//            entity.Property(e => e.OriginalFileName)
//                .IsRequired()
//                .HasColumnName("original_file_name")
//                .HasMaxLength(500);

//            entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.TransactionDocuments)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__transacti__audit__1EF99443");

//            entity.HasOne(d => d.TransactionMaster)
//                .WithMany(p => p.TransactionDocuments)
//                .HasForeignKey(d => d.TransactionMasterId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__trans__1E05700A");
//        }
//    }
//}
