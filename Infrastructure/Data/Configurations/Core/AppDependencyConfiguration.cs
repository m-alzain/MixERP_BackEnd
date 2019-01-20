//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class AppDependencyConfiguration : IEntityTypeConfiguration<AppDependency>
//    {
//        public void Configure(EntityTypeBuilder<AppDependency> builder)
//        {
//            builder.ToTable("app_dependencies", "core");

//            builder.Property(e => e.AppDependencyId).HasColumnName("app_dependency_id");

//            builder.Property(e => e.AppName)
//                .HasColumnName("app_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.DependsOn)
//                .HasColumnName("depends_on")
//                .HasMaxLength(100);

//            builder.HasOne(d => d.AppNameNavigation)
//                .WithMany(p => p.AppDependencyAppNameNavigations)
//                .HasForeignKey(d => d.AppName)
//                .HasConstraintName("FK__app_depen__app_n__21B6055D");

//            builder.HasOne(d => d.DependsOnNavigation)
//                .WithMany(p => p.AppDependencyDependsOnNavigations)
//                .HasForeignKey(d => d.DependsOn)
//                .HasConstraintName("FK__app_depen__depen__22AA2996");
//        }
//    }
//}
