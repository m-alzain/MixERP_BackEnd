//using ApplicationCore.Entities.AddessBook;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.AddressBook
//{
//    public class Contact1Configuration : IEntityTypeConfiguration<Contact1>
//    {
//        public void Configure(EntityTypeBuilder<Contact1> builder)
//        {
//            builder.HasKey(e => e.ContactId);

//            builder.ToTable("contacts", "addressbook");

//            builder.Property(e => e.ContactId)
//                .HasColumnName("contact_id")
//                .HasDefaultValueSql("(newid())");

//            builder.Property(e => e.AddressLine1)
//                .HasColumnName("address_line_1")
//                .HasMaxLength(500);

//            builder.Property(e => e.AddressLine2)
//                .HasColumnName("address_line_2")
//                .HasMaxLength(500);

//            builder.Property(e => e.AssociatedUserId).HasColumnName("associated_user_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.BirthDay)
//                .HasColumnName("birth_day")
//                .HasColumnType("date");

//            builder.Property(e => e.City)
//                .HasColumnName("city")
//                .HasMaxLength(500);

//            builder.Property(e => e.Country)
//                .HasColumnName("country")
//                .HasMaxLength(500);

//            builder.Property(e => e.CreatedBy).HasColumnName("created_by");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.EmailAddresses)
//                .HasColumnName("email_addresses")
//                .HasMaxLength(1000);

//            builder.Property(e => e.FaxNumbers)
//                .HasColumnName("fax_numbers")
//                .HasMaxLength(1000);

//            builder.Property(e => e.FirstName)
//                .HasColumnName("first_name")
//                .HasMaxLength(200);

//            builder.Property(e => e.FormattedName)
//                .IsRequired()
//                .HasColumnName("formatted_name")
//                .HasMaxLength(610);

//            builder.Property(e => e.Gender).HasColumnName("gender");

//            builder.Property(e => e.IsPrivate)
//                .IsRequired()
//                .HasColumnName("is_private")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.Kind).HasColumnName("kind");

//            builder.Property(e => e.Language)
//                .HasColumnName("language")
//                .HasMaxLength(500);

//            builder.Property(e => e.LastName)
//                .HasColumnName("last_name")
//                .HasMaxLength(200);

//            builder.Property(e => e.MiddleName)
//                .HasColumnName("middle_name")
//                .HasMaxLength(200);

//            builder.Property(e => e.MobileNumbers)
//                .HasColumnName("mobile_numbers")
//                .HasMaxLength(1000);

//            builder.Property(e => e.NickName)
//                .HasColumnName("nick_name")
//                .HasMaxLength(610);

//            builder.Property(e => e.Note)
//                .HasColumnName("note")
//                .HasColumnType("text");

//            builder.Property(e => e.Organization)
//                .HasColumnName("organization")
//                .HasMaxLength(500);

//            builder.Property(e => e.OrganizationalUnit)
//                .HasColumnName("organizational_unit")
//                .HasMaxLength(500);

//            builder.Property(e => e.PostalCode)
//                .HasColumnName("postal_code")
//                .HasMaxLength(500);

//            builder.Property(e => e.Prefix)
//                .HasColumnName("prefix")
//                .HasMaxLength(200);

//            builder.Property(e => e.Role)
//                .HasColumnName("role")
//                .HasMaxLength(500);

//            builder.Property(e => e.State)
//                .HasColumnName("state")
//                .HasMaxLength(500);

//            builder.Property(e => e.Street)
//                .HasColumnName("street")
//                .HasMaxLength(500);

//            builder.Property(e => e.Suffix)
//                .HasColumnName("suffix")
//                .HasMaxLength(200);

//            builder.Property(e => e.Tags)
//                .HasColumnName("tags")
//                .HasMaxLength(500);

//            builder.Property(e => e.Telephones)
//                .HasColumnName("telephones")
//                .HasMaxLength(1000);

//            builder.Property(e => e.TimeZone)
//                .HasColumnName("time_zone")
//                .HasMaxLength(500);

//            builder.Property(e => e.Title)
//                .HasColumnName("title")
//                .HasMaxLength(500);

//            builder.Property(e => e.Url)
//                .HasColumnName("url")
//                .HasMaxLength(1000);

//            builder.HasOne(d => d.AssociatedUser)
//                .WithMany(p => p.Contact1AssociatedUser)
//                .HasForeignKey(d => d.AssociatedUserId)
//                .HasConstraintName("FK__contacts__associ__220B0B18");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Contact1AuditUser)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__contacts__audit___24E777C3");

//            builder.HasOne(d => d.CreatedByNavigation)
//                .WithMany(p => p.Contact1CreatedByNavigation)
//                .HasForeignKey(d => d.CreatedBy)
//                .HasConstraintName("FK__contacts__create__23F3538A");
//        }
//    }
//}
