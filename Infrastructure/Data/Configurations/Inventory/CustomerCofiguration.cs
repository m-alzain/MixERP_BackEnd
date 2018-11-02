using ApplicationCore.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations.Inventory
{
    public class CustomerCofiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            
            builder.ToTable("customers", "inventory");

            builder.HasIndex(e => e.AccountId)
                .HasName("customers_account_id_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0) AND [account_id] IS NOT NULL)");

            builder.HasIndex(e => e.CustomerCode)
                .HasName("customers_customer_code_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0))");

            builder.Property(e => e.CustomerId).HasColumnName("customer_id");

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

            builder.Property(e => e.CustomerCode)
                .IsRequired()
                .HasColumnName("customer_code")
                .HasMaxLength(24);

            builder.Property(e => e.CustomerName)
                .IsRequired()
                .HasColumnName("customer_name")
                .HasMaxLength(500);

            builder.Property(e => e.CustomerTypeId).HasColumnName("customer_type_id");

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

            builder.Property(e => e.Photo)
                .HasColumnName("photo");
                //.HasColumnType("photo")
                //.HasMaxLength(4000);

            builder.HasOne(d => d.Account)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.AccountId)
                .HasConstraintName("FK__customers__accou__12B3B8EF");

            builder.HasOne(d => d.AuditUser)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.AuditUserId)
                .HasConstraintName("FK__customers__audit__149C0161");

            builder.HasOne(d => d.CurrencyCodeNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CurrencyCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__customers__curre__13A7DD28");

            builder.HasOne(d => d.CustomerType)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__customers__custo__11BF94B6");
            
        }
    }
}
