//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class TransactionDetailConfiguration : IEntityTypeConfiguration<TransactionDetail>
//    {
//        public void Configure(EntityTypeBuilder<TransactionDetail> entity)
//        {
//            entity.ToTable("transaction_details", "finance");

//            entity.HasIndex(e => new { e.TransactionMasterId, e.AmountInLocalCurrency, e.TranType })
//                .HasName("transaction_details_tran_type_inx");

//            entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.AccountId })
//                .HasName("transaction_details_account_id_inx");

//            entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.BookDate })
//                .HasName("transaction_details_book_date_inx");

//            entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.CashRepositoryId })
//                .HasName("transaction_details_cash_repository_id_inx");

//            entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.OfficeId })
//                .HasName("transaction_details_office_id_inx");

//            entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.ValueDate })
//                .HasName("transaction_details_value_date_inx");

//            entity.Property(e => e.TransactionDetailId).HasColumnName("transaction_detail_id");

//            entity.Property(e => e.AccountId).HasColumnName("account_id");

//            entity.Property(e => e.AmountInCurrency)
//                .HasColumnName("amount_in_currency")
//                .HasColumnType("numeric(30, 6)");

//            entity.Property(e => e.AmountInLocalCurrency)
//                .HasColumnName("amount_in_local_currency")
//                .HasColumnType("numeric(30, 6)");

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.BookDate)
//                .HasColumnName("book_date")
//                .HasColumnType("date");

//            entity.Property(e => e.CashRepositoryId).HasColumnName("cash_repository_id");

//            entity.Property(e => e.CurrencyCode)
//                .IsRequired()
//                .HasColumnName("currency_code")
//                .HasMaxLength(12);

//            entity.Property(e => e.Er)
//                .HasColumnName("er")
//                .HasColumnType("numeric(30, 6)");

//            entity.Property(e => e.LocalCurrencyCode)
//                .IsRequired()
//                .HasColumnName("local_currency_code")
//                .HasMaxLength(12);

//            entity.Property(e => e.OfficeId).HasColumnName("office_id");

//            entity.Property(e => e.ReconciliationMemo)
//                .HasColumnName("reconciliation_memo")
//                .HasMaxLength(2000);

//            entity.Property(e => e.StatementReference)
//                .HasColumnName("statement_reference")
//                .HasMaxLength(2000);

//            entity.Property(e => e.TranType)
//                .IsRequired()
//                .HasColumnName("tran_type")
//                .HasMaxLength(4);

//            entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

//            entity.Property(e => e.ValueDate)
//                .HasColumnName("value_date")
//                .HasColumnType("date");

//            entity.HasOne(d => d.Account)
//                .WithMany(p => p.TransactionDetails)
//                .HasForeignKey(d => d.AccountId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__accou__25A691D2");

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.TransactionDetails)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__transacti__audit__2A6B46EF");

//            entity.HasOne(d => d.CashRepository)
//                .WithMany(p => p.TransactionDetails)
//                .HasForeignKey(d => d.CashRepositoryId)
//                .HasConstraintName("FK__transacti__cash___269AB60B");

//            entity.HasOne(d => d.CurrencyCodeNavigation)
//                .WithMany(p => p.TransactionDetailCurrencyCodeNavigations)
//                .HasForeignKey(d => d.CurrencyCode)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__curre__278EDA44");

//            entity.HasOne(d => d.LocalCurrencyCodeNavigation)
//                .WithMany(p => p.TransactionDetailLocalCurrencyCodeNavigations)
//                .HasForeignKey(d => d.LocalCurrencyCode)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__local__2882FE7D");

//            entity.HasOne(d => d.Office)
//                .WithMany(p => p.TransactionDetails)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__offic__297722B6");

//            entity.HasOne(d => d.TransactionMaster)
//                .WithMany(p => p.TransactionDetails)
//                .HasForeignKey(d => d.TransactionMasterId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__transacti__trans__23BE4960");
//        }
//    }
//}
