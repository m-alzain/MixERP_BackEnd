//using ApplicationCore.Entities.Auth;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Auth
//{
//    public class AccessTypeConfiguration : IEntityTypeConfiguration<AccessType>
//    {
//        public void Configure(EntityTypeBuilder<AccessType> builder)
//        {
//            builder.ToTable("access_types", "auth");

//            builder.HasIndex(e => e.AccessTypeName)
//                .HasName("access_types_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.AccessTypeId)
//                .HasColumnName("access_type_id")
//                .ValueGeneratedNever();

//            builder.Property(e => e.AccessTypeName)
//                .IsRequired()
//                .HasColumnName("access_type_name")
//                .HasMaxLength(48);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.AccessTypes)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__access_ty__audit__56E8E7AB");
//        }
//    }
//}
