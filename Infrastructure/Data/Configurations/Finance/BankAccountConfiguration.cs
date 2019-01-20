//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
//    {
//        public void Configure(EntityTypeBuilder<BankAccount> builder)
//        {
//            builder.ToTable("bank_accounts", "finance");

//            builder.Property(e => e.BankAccountId).HasColumnName("bank_account_id");

//            builder.Property(e => e.AccountId).HasColumnName("account_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.BankAccountName)
//                .IsRequired()
//                .HasColumnName("bank_account_name")
//                .HasMaxLength(1000);

//            builder.Property(e => e.BankAccountNumber)
//                .HasColumnName("bank_account_number")
//                .HasMaxLength(128);

//            builder.Property(e => e.BankAccountType)
//                .HasColumnName("bank_account_type")
//                .HasMaxLength(128);

//            builder.Property(e => e.BankBranch)
//                .IsRequired()
//                .HasColumnName("bank_branch")
//                .HasMaxLength(128);

//            builder.Property(e => e.BankContactNumber)
//                .HasColumnName("bank_contact_number")
//                .HasMaxLength(128);

//            builder.Property(e => e.BankName)
//                .IsRequired()
//                .HasColumnName("bank_name")
//                .HasMaxLength(128);

//            builder.Property(e => e.BankTypeId).HasColumnName("bank_type_id");

//            builder.Property(e => e.Cell)
//                .HasColumnName("cell")
//                .HasMaxLength(50);

//            builder.Property(e => e.City)
//                .HasColumnName("city")
//                .HasMaxLength(50);

//            builder.Property(e => e.Country)
//                .HasColumnName("country")
//                .HasMaxLength(50);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Fax)
//                .HasColumnName("fax")
//                .HasMaxLength(50);

//            builder.Property(e => e.IsMerchantAccount).HasColumnName("is_merchant_account");

//            builder.Property(e => e.MaintainedByUserId).HasColumnName("maintained_by_user_id");

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.Phone)
//                .HasColumnName("phone")
//                .HasMaxLength(50);

//            builder.Property(e => e.RelationshipOfficerContactNumber)
//                .HasColumnName("relationship_officer_contact_number")
//                .HasMaxLength(128);

//            builder.Property(e => e.RelationshipOfficerName)
//                .HasColumnName("relationship_officer_name")
//                .HasMaxLength(128);

//            builder.Property(e => e.State)
//                .HasColumnName("state")
//                .HasMaxLength(50);

//            builder.Property(e => e.Street)
//                .HasColumnName("street")
//                .HasMaxLength(50);

//            builder.HasOne(d => d.Account)
//                .WithMany(p => p.BankAccounts)
//                .HasForeignKey(d => d.AccountId)
//                .HasConstraintName("FK__bank_acco__accou__7ABC33CD");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.BankAccountAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__bank_acco__audit__7F80E8EA");

//            builder.HasOne(d => d.BankType)
//                .WithMany(p => p.BankAccounts)
//                .HasForeignKey(d => d.BankTypeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__bank_acco__bank___7CA47C3F");

//            builder.HasOne(d => d.MaintainedByUser)
//                .WithMany(p => p.BankAccountMaintainedByUsers)
//                .HasForeignKey(d => d.MaintainedByUserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__bank_acco__maint__7BB05806");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.BankAccounts)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__bank_acco__offic__7E8CC4B1");
//        }
//    }
//}
