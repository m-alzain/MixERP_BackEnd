//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class WeekDayConfiguration : IEntityTypeConfiguration<WeekDay>
//    {
//        public void Configure(EntityTypeBuilder<WeekDay> entity)
//        {
//            entity.ToTable("week_days", "core");

//            entity.HasIndex(e => e.WeekDayCode)
//                .HasName("UQ__week_day__2FE49F53C8CB710A")
//                .IsUnique();

//            entity.HasIndex(e => e.WeekDayName)
//                .HasName("UQ__week_day__D111B99E661B0F31")
//                .IsUnique();

//            entity.Property(e => e.WeekDayId)
//                .HasColumnName("week_day_id")
//                .ValueGeneratedNever();

//            entity.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            entity.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            entity.Property(e => e.WeekDayCode)
//                .IsRequired()
//                .HasColumnName("week_day_code")
//                .HasMaxLength(12);

//            entity.Property(e => e.WeekDayName)
//                .IsRequired()
//                .HasColumnName("week_day_name")
//                .HasMaxLength(50);
//        }
//    }
//}
