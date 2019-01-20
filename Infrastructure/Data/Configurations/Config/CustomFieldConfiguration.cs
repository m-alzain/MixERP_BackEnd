//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Config
//{
//    public class CustomFieldConfiguration : IEntityTypeConfiguration<CustomField>
//    {
//        public void Configure(EntityTypeBuilder<CustomField> builder)
//        {
//            builder.ToTable("custom_fields", "config");

//            builder.Property(e => e.CustomFieldId).HasColumnName("custom_field_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CustomFieldSetupId).HasColumnName("custom_field_setup_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.ResourceId)
//                .IsRequired()
//                .HasColumnName("resource_id")
//                .HasMaxLength(500);

//            builder.Property(e => e.Value).HasColumnName("value");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.CustomFields)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__custom_fi__audit__4A4E069C");

//            builder.HasOne(d => d.CustomFieldSetup)
//                .WithMany(p => p.CustomFields)
//                .HasForeignKey(d => d.CustomFieldSetupId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__custom_fi__custo__4959E263");
//        }
//    }
//}
