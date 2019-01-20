//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class AccountMasterConfiguration : IEntityTypeConfiguration<AccountMaster>
//    {
//        public void Configure(EntityTypeBuilder<AccountMaster> builder)
//        {
//            builder.ToTable("account_masters", "finance");

//            builder.HasIndex(e => e.AccountMasterCode)
//                .HasName("account_master_code_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.AccountMasterName)
//                .HasName("account_master_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.ParentAccountMasterId)
//                .HasName("account_master_parent_account_master_id_inx")
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.AccountMasterId)
//                .HasColumnName("account_master_id")
//                .ValueGeneratedNever();

//            builder.Property(e => e.AccountMasterCode)
//                .IsRequired()
//                .HasColumnName("account_master_code")
//                .HasMaxLength(3);

//            builder.Property(e => e.AccountMasterName)
//                .IsRequired()
//                .HasColumnName("account_master_name")
//                .HasMaxLength(40);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.NormallyDebit).HasColumnName("normally_debit");

//            builder.Property(e => e.ParentAccountMasterId).HasColumnName("parent_account_master_id");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.AccountMasters)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__account_m__audit__4FD1D5C8");

//            builder.HasOne(d => d.ParentAccountMaster)
//                .WithMany(p => p.InverseParentAccountMaster)
//                .HasForeignKey(d => d.ParentAccountMasterId)
//                .HasConstraintName("FK__account_m__paren__4EDDB18F");
//        }
//    }
//}
