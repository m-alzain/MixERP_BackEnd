using ApplicationCore.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Accounts
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("offices", "account");

            builder.HasIndex(e => e.OfficeName)
                .HasName("offices_office_name_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0))");

            builder.HasIndex(e => e.OfficeCode)
                .HasName("offices_office_code_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0))");

            builder.Property(e => e.TenantId).HasColumnName("tenant_id");

            builder.Property(e => e.Id).HasColumnName("office_id");

            builder.Property(e => e.AddressLine1)
                .HasColumnName("address_line_1")
                .HasMaxLength(128);

            builder.Property(e => e.AddressLine2)
                .HasColumnName("address_line_2")
                .HasMaxLength(128);

            builder.Property(e => e.AllowTransactionPosting).HasColumnName("allow_transaction_posting");            

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(50);

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(50);

            builder.Property(e => e.CurrencyCode)
                .HasColumnName("currency_code")
                .HasMaxLength(12);

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(128);

            builder.Property(e => e.Fax)
                .HasColumnName("fax")
                .HasMaxLength(24);
            //https://stackoverflow.com/questions/4653095/how-to-store-images-using-entity-framework-code-first-ctp-5
            builder.Property(e => e.Logo)
                .HasColumnName("logo");
            //.HasColumnType("photo")
            //.HasMaxLength(4000);

            builder.Property(e => e.NickName)
                .HasColumnName("nick_name")
                .HasMaxLength(50);

            builder.Property(e => e.OfficeCode)
                .IsRequired()
                .HasColumnName("office_code")
                .HasMaxLength(12);

            builder.Property(e => e.OfficeName)
                .IsRequired()
                .HasColumnName("office_name")
                .HasMaxLength(150);

            builder.Property(e => e.PanNumber)
                .HasColumnName("pan_number")
                .HasMaxLength(100);

            builder.Property(e => e.ParentOfficeId).HasColumnName("parent_office_id");

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(24);

            builder.Property(e => e.PoBox)
                .HasColumnName("po_box")
                .HasMaxLength(128);

            builder.Property(e => e.RegistrationDate)
                .HasColumnName("registration_date")
                .HasColumnType("date");

            builder.Property(e => e.RegistrationNumber)
                .HasColumnName("registration_number")
                .HasMaxLength(100);

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasMaxLength(50);

            builder.Property(e => e.Street)
                .HasColumnName("street")
                .HasMaxLength(50);

            builder.Property(e => e.Url)
                .HasColumnName("url")
                .HasMaxLength(50);

            builder.Property(e => e.ZipCode)
                .HasColumnName("zip_code")
                .HasMaxLength(24);

            builder.HasOne(o => o.Tenant)
                .WithMany(t => t.Offices)
                .HasForeignKey(o => o.TenantId)
                .HasConstraintName("FK__offices__tenant").OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.ParentOffice)
                .WithMany(p => p.InverseParentOffice)
                .HasForeignKey(d => d.ParentOfficeId)
                .HasConstraintName("FK__offices__parent___31EC6D26").OnDelete(DeleteBehavior.ClientSetNull);

            #region Audit

            builder.Property(e => e.CreatedOn)
                .HasColumnName("created_on")
                .HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.CreatedByUserId).HasColumnName("created_by_userId");
            builder.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.CreatedOffices)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__created_offices__createted_by_user").OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(e => e.UpdatedOn)
                .HasColumnName("updated_on")
                .HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_userId");
            builder.HasOne(d => d.UpdatedByUser)
                .WithMany(p => p.UpdatedOffices)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK__updated_offices__updated_by_user").OnDelete(DeleteBehavior.ClientSetNull);

            #endregion

        }
    }
}
