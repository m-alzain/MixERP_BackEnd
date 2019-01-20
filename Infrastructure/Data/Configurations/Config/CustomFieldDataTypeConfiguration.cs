//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Config
//{
//    public class CustomFieldDataTypeConfiguration : IEntityTypeConfiguration<CustomFieldDataType>
//    {
//        public void Configure(EntityTypeBuilder<CustomFieldDataType> builder)
//        {
//            builder.HasKey(e => e.DataType);

//            builder.ToTable("custom_field_data_types", "config");

//            builder.Property(e => e.DataType)
//                .HasColumnName("data_type")
//                .HasMaxLength(50)
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.UnderlyingType)
//                .IsRequired()
//                .HasColumnName("underlying_type")
//                .HasMaxLength(500);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.CustomFieldDataTypes)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__custom_fi__audit__373B3228");
//        }
//    }
//}
