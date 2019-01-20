//using ApplicationCore.Entities.Website;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Website
//{
//    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
//    {
//        public void Configure(EntityTypeBuilder<Contact> entity)
//        {
//            entity.ToTable("contacts", "website");

//            entity.Property(e => e.ContactId).HasColumnName("contact_id");

//            entity.Property(e => e.Address)
//                .HasColumnName("address")
//                .HasMaxLength(500);

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.City)
//                .HasColumnName("city")
//                .HasMaxLength(500);

//            entity.Property(e => e.Country)
//                .HasColumnName("country")
//                .HasMaxLength(100);

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.Details)
//                .HasColumnName("details")
//                .HasMaxLength(500);

//            entity.Property(e => e.DisplayContactForm)
//                .IsRequired()
//                .HasColumnName("display_contact_form")
//                .HasDefaultValueSql("((1))");

//            entity.Property(e => e.DisplayEmail).HasColumnName("display_email");

//            entity.Property(e => e.Email)
//                .HasColumnName("email")
//                .HasMaxLength(500);

//            entity.Property(e => e.Name)
//                .IsRequired()
//                .HasColumnName("name")
//                .HasMaxLength(500);

//            entity.Property(e => e.Position)
//                .HasColumnName("position")
//                .HasMaxLength(500);

//            entity.Property(e => e.PostalCode)
//                .HasColumnName("postal_code")
//                .HasMaxLength(500);

//            entity.Property(e => e.Recipients)
//                .HasColumnName("recipients")
//                .HasMaxLength(1000);

//            entity.Property(e => e.Sort).HasColumnName("sort");

//            entity.Property(e => e.State)
//                .HasColumnName("state")
//                .HasMaxLength(500);

//            entity.Property(e => e.Status)
//                .IsRequired()
//                .HasColumnName("status")
//                .HasDefaultValueSql("((1))");

//            entity.Property(e => e.Telephone)
//                .HasColumnName("telephone")
//                .HasMaxLength(500);

//            entity.Property(e => e.Title)
//                .IsRequired()
//                .HasColumnName("title")
//                .HasMaxLength(500);

//            entity.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Contacts)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__contacts__audit___0A338187");
//        }
//    }
//}
