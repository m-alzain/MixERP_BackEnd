using ApplicationCore.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations.Inventory
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {            
            builder.ToTable("stores", "inventory");

            builder.HasIndex(e => e.StoreCode)
                .HasName("stores_store_code_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0))");

            builder.HasIndex(e => e.StoreName)
                .HasName("stores_store_name_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0))");

            builder.Property(e => e.StoreId).HasColumnName("store_id");

            builder.Property(e => e.AddressLine1)
                .HasColumnName("address_line_1")
                .HasMaxLength(128);

            builder.Property(e => e.AddressLine2)
                .HasColumnName("address_line_2")
                .HasMaxLength(128);

            builder.Property(e => e.AllowSales)
                .IsRequired()
                .HasColumnName("allow_sales")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.AuditTs)
                .HasColumnName("audit_ts")
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

            builder.Property(e => e.Cell)
                .HasColumnName("cell")
                .HasMaxLength(50);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(50);

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(50);

            builder.Property(e => e.DefaultAccountIdForChecks).HasColumnName("default_account_id_for_checks");

            builder.Property(e => e.DefaultCashAccountId).HasColumnName("default_cash_account_id");

            builder.Property(e => e.DefaultCashRepositoryId).HasColumnName("default_cash_repository_id");

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.Fax)
                .HasColumnName("fax")
                .HasMaxLength(50);

            builder.Property(e => e.OfficeId).HasColumnName("office_id");

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(50);

            //builder.Property(e => e.PurchaseDiscountAccountId)
            //    .HasColumnName("purchase_discount_account_id")
            //    .HasDefaultValueSql("([finance].[get_account_id_by_account_number]('30700'))");

            //builder.Property(e => e.SalesDiscountAccountId)
            //    .HasColumnName("sales_discount_account_id")
            //    .HasDefaultValueSql("([finance].[get_account_id_by_account_number]('40270'))");

            //builder.Property(e => e.ShippingExpenseAccountId)
            //    .HasColumnName("shipping_expense_account_id")
            //    .HasDefaultValueSql("([finance].[get_account_id_by_account_number]('43000'))");

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasMaxLength(50);

            builder.Property(e => e.StoreCode)
                .IsRequired()
                .HasColumnName("store_code")
                .HasMaxLength(24);

            builder.Property(e => e.StoreName)
                .IsRequired()
                .HasColumnName("store_name")
                .HasMaxLength(500);

            builder.Property(e => e.StoreTypeId).HasColumnName("store_type_id");

            builder.Property(e => e.Street)
                .HasColumnName("street")
                .HasMaxLength(50);

            builder.HasOne(d => d.AuditUser)
                .WithMany(p => p.Stores)
                .HasForeignKey(d => d.AuditUserId)
                .HasConstraintName("FK__stores__audit_us__5669C4BE");

            builder.HasOne(d => d.DefaultAccountIdForChecksNavigation)
                .WithMany(p => p.StoreDefaultAccountIdForChecksNavigations)
                .HasForeignKey(d => d.DefaultAccountIdForChecks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stores__default___4CE05A84");

            builder.HasOne(d => d.DefaultCashAccount)
                .WithMany(p => p.StoreDefaultCashAccounts)
                .HasForeignKey(d => d.DefaultCashAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stores__default___4DD47EBD");

            builder.HasOne(d => d.DefaultCashRepository)
                .WithMany(p => p.Stores)
                .HasForeignKey(d => d.DefaultCashRepositoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stores__default___4EC8A2F6");

            builder.HasOne(d => d.Office)
                .WithMany(p => p.Stores)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stores__office_i__4BEC364B");

            builder.HasOne(d => d.PurchaseDiscountAccount)
                .WithMany(p => p.StorePurchaseDiscountAccounts)
                .HasForeignKey(d => d.PurchaseDiscountAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stores__purchase__529933DA");

            builder.HasOne(d => d.SalesDiscountAccount)
                .WithMany(p => p.StoreSalesDiscountAccounts)
                .HasForeignKey(d => d.SalesDiscountAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stores__sales_di__50B0EB68");

            builder.HasOne(d => d.ShippingExpenseAccount)
                .WithMany(p => p.StoreShippingExpenseAccounts)
                .HasForeignKey(d => d.ShippingExpenseAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stores__shipping__54817C4C");

            builder.HasOne(d => d.StoreType)
                .WithMany(p => p.Stores)
                .HasForeignKey(d => d.StoreTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stores__store_ty__4AF81212");
            
        }
    }
}
