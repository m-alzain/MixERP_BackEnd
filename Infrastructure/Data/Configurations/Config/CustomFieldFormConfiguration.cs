//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//namespace Infrastructure.Data.Configurations.Config
//{
//    public class CustomFieldFormConfiguration : IEntityTypeConfiguration<CustomFieldForm>
//    {
//        public void Configure(EntityTypeBuilder<CustomFieldForm> builder)
//        {
//            builder.HasKey(e => e.FormName);

//            builder.ToTable("custom_field_forms", "config");

//            builder.HasIndex(e => e.TableName)
//                .HasName("UQ__custom_f__B228A5BF4DE4C087")
//                .IsUnique();

//            builder.Property(e => e.FormName)
//                .HasColumnName("form_name")
//                .HasMaxLength(100)
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.KeyName)
//                .IsRequired()
//                .HasColumnName("key_name")
//                .HasMaxLength(500);

//            builder.Property(e => e.TableName)
//                .IsRequired()
//                .HasColumnName("table_name")
//                .HasMaxLength(500);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.CustomFieldForms)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__custom_fi__audit__3CF40B7E");
//        }
//    }
//}
