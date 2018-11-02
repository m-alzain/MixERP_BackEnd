using ApplicationCore.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations.Inventory
{
    public class SupplierCofiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {          
            builder.ToTable("suppliers", "inventory");

            builder.HasIndex(e => e.AccountId)
                .HasName("suppliers_account_id_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0) AND [account_id] IS NOT NULL)");

            builder.HasIndex(e => e.SupplierCode)
                .HasName("suppliers_supplier_code_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0))");

            builder.Property(e => e.SupplierId).HasColumnName("supplier_id");

            builder.Property(e => e.AccountId).HasColumnName("account_id");

            builder.Property(e => e.AuditTs)
                .HasColumnName("audit_ts")
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

            builder.Property(e => e.CompanyAddressLine1)
                .HasColumnName("company_address_line_1")
                .HasMaxLength(128);

            builder.Property(e => e.CompanyAddressLine2)
                .HasColumnName("company_address_line_2")
                .HasMaxLength(128);

            builder.Property(e => e.CompanyCity)
                .HasColumnName("company_city")
                .HasMaxLength(1000);

            builder.Property(e => e.CompanyCountry)
                .HasColumnName("company_country")
                .HasMaxLength(1000);

            builder.Property(e => e.CompanyFax)
                .HasColumnName("company_fax")
                .HasMaxLength(100);

            builder.Property(e => e.CompanyName)
                .HasColumnName("company_name")
                .HasMaxLength(1000);

            builder.Property(e => e.CompanyPhoneNumbers)
                .HasColumnName("company_phone_numbers")
                .HasMaxLength(1000);

            builder.Property(e => e.CompanyPoBox)
                .HasColumnName("company_po_box")
                .HasMaxLength(1000);

            builder.Property(e => e.CompanyState)
                .HasColumnName("company_state")
                .HasMaxLength(1000);

            builder.Property(e => e.CompanyStreet)
                .HasColumnName("company_street")
                .HasMaxLength(1000);

            builder.Property(e => e.CompanyZipCode)
                .HasColumnName("company_zip_code")
                .HasMaxLength(1000);

            builder.Property(e => e.ContactAddressLine1)
                .HasColumnName("contact_address_line_1")
                .HasMaxLength(128);

            builder.Property(e => e.ContactAddressLine2)
                .HasColumnName("contact_address_line_2")
                .HasMaxLength(128);

            builder.Property(e => e.ContactCity)
                .HasColumnName("contact_city")
                .HasMaxLength(100);

            builder.Property(e => e.ContactCountry)
                .HasColumnName("contact_country")
                .HasMaxLength(100);

            builder.Property(e => e.ContactFax)
                .HasColumnName("contact_fax")
                .HasMaxLength(100);

            builder.Property(e => e.ContactFirstName)
                .HasColumnName("contact_first_name")
                .HasMaxLength(100);

            builder.Property(e => e.ContactLastName)
                .HasColumnName("contact_last_name")
                .HasMaxLength(100);

            builder.Property(e => e.ContactMiddleName)
                .HasColumnName("contact_middle_name")
                .HasMaxLength(100);

            builder.Property(e => e.ContactPhoneNumbers)
                .HasColumnName("contact_phone_numbers")
                .HasMaxLength(100);

            builder.Property(e => e.ContactPoBox)
                .HasColumnName("contact_po_box")
                .HasMaxLength(100);

            builder.Property(e => e.ContactState)
                .HasColumnName("contact_state")
                .HasMaxLength(100);

            builder.Property(e => e.ContactStreet)
                .HasColumnName("contact_street")
                .HasMaxLength(100);

            builder.Property(e => e.ContactZipCode)
                .HasColumnName("contact_zip_code")
                .HasMaxLength(100);

            builder.Property(e => e.CurrencyCode)
                .IsRequired()
                .HasColumnName("currency_code")
                .HasMaxLength(12);

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(128);

            builder.Property(e => e.Logo)
                .HasColumnName("logo");
                //.HasColumnType("photo")
                //.HasMaxLength(4000);

            builder.Property(e => e.PanNumber)
                .HasColumnName("pan_number")
                .HasMaxLength(100);

            builder.Property(e => e.Photo)
                .HasColumnName("photo");
                //.HasColumnType("photo")
                //.HasMaxLength(4000);

            builder.Property(e => e.SupplierCode)
                .IsRequired()
                .HasColumnName("supplier_code")
                .HasMaxLength(24);

            builder.Property(e => e.SupplierName)
                .IsRequired()
                .HasColumnName("supplier_name")
                .HasMaxLength(500);

            builder.Property(e => e.SupplierTypeId).HasColumnName("supplier_type_id");

            builder.HasOne(d => d.Account)
                .WithOne(p => p.Supplier)
                .HasForeignKey<Supplier>(d => d.AccountId)
                .HasConstraintName("FK__suppliers__accou__0559BDD1");

            builder.HasOne(d => d.AuditUser)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.AuditUserId)
                .HasConstraintName("FK__suppliers__audit__07420643");

            builder.HasOne(d => d.CurrencyCodeNavigation)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CurrencyCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__suppliers__curre__064DE20A");

            builder.HasOne(d => d.SupplierType)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.SupplierTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__suppliers__suppl__04659998");
            
        }
    }
}
