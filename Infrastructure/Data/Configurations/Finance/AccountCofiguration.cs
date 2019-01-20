//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class AccountCofiguration : IEntityTypeConfiguration<Account>
//    {
//        public void Configure(EntityTypeBuilder<Account> builder)
//        {
//            builder.ToTable("accounts", "finance");

//            builder.HasIndex(e => e.AccountName)
//                .HasName("accounts_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.AccountNumber)
//                .HasName("accounts_account_number_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.AccountId).HasColumnName("account_id");

//            builder.Property(e => e.AccountMasterId).HasColumnName("account_master_id");

//            builder.Property(e => e.AccountName)
//                .IsRequired()
//                .HasColumnName("account_name")
//                .HasMaxLength(500);

//            builder.Property(e => e.AccountNumber)
//                .IsRequired()
//                .HasColumnName("account_number")
//                .HasMaxLength(24);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Confidential).HasColumnName("confidential");

//            builder.Property(e => e.CurrencyCode)
//                .IsRequired()
//                .HasColumnName("currency_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Description)
//                .HasColumnName("description")
//                .HasMaxLength(1000);

//            builder.Property(e => e.ExternalCode)
//                .HasColumnName("external_code")
//                .HasMaxLength(24)
//                .HasDefaultValueSql("('')");

//            builder.Property(e => e.IsTransactionNode)
//                .IsRequired()
//                .HasColumnName("is_transaction_node")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.ParentAccountId).HasColumnName("parent_account_id");

//            builder.Property(e => e.SysType).HasColumnName("sys_type");

//            builder.HasOne(d => d.AccountMaster)
//                .WithMany(p => p.Accounts)
//                .HasForeignKey(d => d.AccountMasterId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__accounts__accoun__61F08603");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Accounts)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__accounts__audit___689D8392");

//            builder.HasOne(d => d.CurrencyCodeNavigation)
//                .WithMany(p => p.Accounts)
//                .HasForeignKey(d => d.CurrencyCode)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__accounts__curren__63D8CE75");

//            builder.HasOne(d => d.ParentAccount)
//                .WithMany(p => p.InverseParentAccount)
//                .HasForeignKey(d => d.ParentAccountId)
//                .HasConstraintName("FK__accounts__parent__67A95F59");
//        }
//    }
//}
