//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class TransactionMasterConfiguration : IEntityTypeConfiguration<TransactionMaster>
//    {
//        public void Configure(EntityTypeBuilder<TransactionMaster> entity)
//        {
//            entity.ToTable("transaction_master", "finance");

//            entity.HasIndex(e => e.BookDate)
//                .HasName("transaction_master_book_date_inx")
//                .HasFilter("([deleted]=(0))");

//            entity.HasIndex(e => e.CascadingTranId)
//                .HasName("transaction_master_cascading_tran_id_inx")
//                .HasFilter("([deleted]=(0))");

//            entity.HasIndex(e => e.TransactionCode)
//                .HasName("transaction_master_transaction_code_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            entity.HasIndex(e => e.ValueDate)
//                .HasName("transaction_master_value_date_inx")
//                .HasFilter("([deleted]=(0))");

//            entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.Book)
//                .IsRequired()
//                .HasColumnName("book")
//                .HasMaxLength(50);

//            entity.Property(e => e.BookDate)
//                .HasColumnName("book_date")
//                .HasColumnType("date");

//            entity.Property(e => e.CascadingTranId).HasColumnName("cascading_tran_id");

//            entity.Property(e => e.CostCenterId).HasColumnName("cost_center_id");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.LastVerifiedOn).HasColumnName("last_verified_on");

//            entity.Property(e => e.LoginId).HasColumnName("login_id");

//            entity.Property(e => e.OfficeId).HasColumnName("office_id");

//            entity.Property(e => e.ReferenceNumber)
//                .HasColumnName("reference_number")
//                .HasMaxLength(24);

//            entity.Property(e => e.StatementReference)
//                .HasColumnName("statement_reference")
//                .HasMaxLength(2000);

//            entity.Property(e => e.TransactionCode)
//                .IsRequired()
//                .HasColumnName("transaction_code")
//                .HasMaxLength(50);

//            entity.Property(e => e.TransactionCounter).HasColumnName("transaction_counter");

//            entity.Property(e => e.TransactionTs)
//                .HasColumnName("transaction_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.UserId).HasColumnName("user_id");

//            entity.Property(e => e.ValueDate)
//                .HasColumnName("value_date")
//                .HasColumnType("date");

//            entity.Property(e => e.VerificationReason)
//                .IsRequired()
//                .HasColumnName("verification_reason")
//                .HasMaxLength(128)
//                .HasDefaultValueSql("('')");

//            entity.Property(e => e.VerificationStatusId).HasColumnName("verification_status_id");

//            entity.Property(e => e.VerifiedByUserId).HasColumnName("verified_by_user_id");

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.TransactionMasterAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__transacti__audit__1940BAED");

//            entity.HasOne(d => d.CascadingTran)
//                .WithMany(p => p.InverseCascadingTran)
//                .HasForeignKey(d => d.CascadingTranId)
//                .HasConstraintName("FK__transacti__casca__184C96B4");

//            entity.HasOne(d => d.CostCenter)
//                .WithMany(p => p.TransactionMasters)
//                .HasForeignKey(d => d.CostCenterId)
//                .HasConstraintName("FK__transacti__cost___1387E197");

//            entity.HasOne(d => d.Login)
//                .WithMany(p => p.TransactionMasters)
//                .HasForeignKey(d => d.LoginId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__login__10AB74EC");

//            entity.HasOne(d => d.Office)
//                .WithMany(p => p.TransactionMasters)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__offic__1293BD5E");

//            entity.HasOne(d => d.User)
//                .WithMany(p => p.TransactionMasterUsers)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__user___119F9925");

//            entity.HasOne(d => d.VerificationStatus)
//                .WithMany(p => p.TransactionMasters)
//                .HasForeignKey(d => d.VerificationStatusId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__verif__15702A09");

//            entity.HasOne(d => d.VerifiedByUser)
//                .WithMany(p => p.TransactionMasterVerifiedByUsers)
//                .HasForeignKey(d => d.VerifiedByUserId)
//                .HasConstraintName("FK__transacti__verif__147C05D0");
//        }
//    }
//}
