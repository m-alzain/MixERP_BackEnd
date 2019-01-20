//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class TaxSetupConfiguration : IEntityTypeConfiguration<TaxSetup>
//    {
//        public void Configure(EntityTypeBuilder<TaxSetup> entity)
//        {
//            entity.ToTable("tax_setups", "finance");

//            entity.HasIndex(e => e.OfficeId)
//                .HasName("tax_setup_office_id_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            entity.Property(e => e.TaxSetupId).HasColumnName("tax_setup_id");

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.IncomeTaxAccountId).HasColumnName("income_tax_account_id");

//            entity.Property(e => e.IncomeTaxRate)
//                .HasColumnName("income_tax_rate")
//                .HasColumnType("numeric(30, 6)");

//            entity.Property(e => e.OfficeId).HasColumnName("office_id");

//            entity.Property(e => e.SalesTaxAccountId).HasColumnName("sales_tax_account_id");

//            entity.Property(e => e.SalesTaxRate)
//                .HasColumnName("sales_tax_rate")
//                .HasColumnType("numeric(30, 6)");

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.TaxSetups)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__tax_setup__audit__61BB7BD9");

//            entity.HasOne(d => d.IncomeTaxAccount)
//                .WithMany(p => p.TaxSetupIncomeTaxAccounts)
//                .HasForeignKey(d => d.IncomeTaxAccountId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__tax_setup__incom__5FD33367");

//            entity.HasOne(d => d.Office)
//                .WithOne(p => p.TaxSetup)
//                .HasForeignKey<TaxSetup>(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__tax_setup__offic__5EDF0F2E");

//            entity.HasOne(d => d.SalesTaxAccount)
//                .WithMany(p => p.TaxSetupSalesTaxAccounts)
//                .HasForeignKey(d => d.SalesTaxAccountId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__tax_setup__sales__60C757A0");
//        }
//    }
//}
