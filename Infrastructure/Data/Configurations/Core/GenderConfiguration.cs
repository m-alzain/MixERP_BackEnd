//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
//    {
//        public void Configure(EntityTypeBuilder<Gender> builder)
//        {
//            builder.HasKey(e => e.GenderCode);

//            builder.ToTable("genders", "core");

//            builder.HasIndex(e => e.GenderName)
//                .HasName("UQ__genders__2FB51D273F89A0CA")
//                .IsUnique();

//            builder.Property(e => e.GenderCode)
//                .HasColumnName("gender_code")
//                .HasMaxLength(4)
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.GenderName)
//                .IsRequired()
//                .HasColumnName("gender_name")
//                .HasMaxLength(50);
//        }
//    }
//}
