using ApplicationCore.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Core
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {           
            builder.ToTable("offices", "core");

            builder.Property(e => e.OfficeId).HasColumnName("office_id");

            builder.Property(e => e.AddressLine1)
                .HasColumnName("address_line_1")
                .HasMaxLength(128);

            builder.Property(e => e.AddressLine2)
                .HasColumnName("address_line_2")
                .HasMaxLength(128);

            builder.Property(e => e.AllowTransactionPosting).HasColumnName("allow_transaction_posting");

            builder.Property(e => e.AuditTs)
                .HasColumnName("audit_ts")
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

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

            builder.HasOne(d => d.AuditUser)
                .WithMany(p => p.Offices)
                .HasForeignKey(d => d.AuditUserId)
                .HasConstraintName("FK__offices__audit_u__4F47C5E3");

            builder.HasOne(d => d.ParentOffice)
                .WithMany(p => p.InverseParentOffice)
                .HasForeignKey(d => d.ParentOfficeId)
                .HasConstraintName("FK__offices__parent___31EC6D26");          

        }
    }
}
