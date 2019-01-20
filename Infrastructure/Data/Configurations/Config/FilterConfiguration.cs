//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Config
//{
//    class FilterConfiguration : IEntityTypeConfiguration<Filter>
//    {
//        public void Configure(EntityTypeBuilder<Filter> builder)
//        {
//            builder.ToTable("filters", "config");

//            builder.HasIndex(e => e.ObjectName)
//                .HasName("filters_object_name_inx")
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.FilterId).HasColumnName("filter_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.ColumnName)
//                .IsRequired()
//                .HasColumnName("column_name")
//                .HasMaxLength(500);

//            builder.Property(e => e.DataType)
//                .IsRequired()
//                .HasColumnName("data_type")
//                .HasMaxLength(500)
//                .HasDefaultValueSql("('')");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.FilterAndValue)
//                .HasColumnName("filter_and_value")
//                .HasMaxLength(500);

//            builder.Property(e => e.FilterCondition).HasColumnName("filter_condition");

//            builder.Property(e => e.FilterName)
//                .IsRequired()
//                .HasColumnName("filter_name")
//                .HasMaxLength(500);

//            builder.Property(e => e.FilterStatement)
//                .IsRequired()
//                .HasColumnName("filter_statement")
//                .HasMaxLength(12)
//                .HasDefaultValueSql("('WHERE')");

//            builder.Property(e => e.FilterValue)
//                .HasColumnName("filter_value")
//                .HasMaxLength(500);

//            builder.Property(e => e.IsDefault).HasColumnName("is_default");

//            builder.Property(e => e.IsDefaultAdmin).HasColumnName("is_default_admin");

//            builder.Property(e => e.ObjectName)
//                .IsRequired()
//                .HasColumnName("object_name")
//                .HasMaxLength(500);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Filters)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__filters__audit_u__32767D0B");
//        }
//    }
//}
