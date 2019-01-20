//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Config
//{
//    public class CustomFieldSetupConfiguration : IEntityTypeConfiguration<CustomFieldSetup>
//    {
//        public void Configure(EntityTypeBuilder<CustomFieldSetup> builder)
//        {
//            builder.ToTable("custom_field_setup", "config");

//            builder.Property(e => e.CustomFieldSetupId).HasColumnName("custom_field_setup_id");

//            builder.Property(e => e.AfterField)
//                .HasColumnName("after_field")
//                .HasMaxLength(500);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.BeforeField)
//                .HasColumnName("before_field")
//                .HasMaxLength(500);

//            builder.Property(e => e.DataType)
//                .HasColumnName("data_type")
//                .HasMaxLength(50);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Description)
//                .IsRequired()
//                .HasColumnName("description")
//                .HasMaxLength(500);

//            builder.Property(e => e.FieldLabel)
//                .IsRequired()
//                .HasColumnName("field_label")
//                .HasMaxLength(200);

//            builder.Property(e => e.FieldName)
//                .IsRequired()
//                .HasColumnName("field_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.FieldOrder).HasColumnName("field_order");

//            builder.Property(e => e.FormName)
//                .IsRequired()
//                .HasColumnName("form_name")
//                .HasMaxLength(100);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.CustomFieldSetups)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__custom_fi__audit__44952D46");

//            builder.HasOne(d => d.DataTypeNavigation)
//                .WithMany(p => p.CustomFieldSetups)
//                .HasForeignKey(d => d.DataType)
//                .HasConstraintName("FK__custom_fi__data___43A1090D");

//            builder.HasOne(d => d.FormNameNavigation)
//                .WithMany(p => p.CustomFieldSetups)
//                .HasForeignKey(d => d.FormName)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__custom_fi__form___41B8C09B");
//        }
//    }
//}
