//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class CostCenterConfiguration : IEntityTypeConfiguration<CostCenter>
//    {
//        public void Configure(EntityTypeBuilder<CostCenter> builder)
//        {
//            builder.ToTable("cost_centers", "finance");

//            builder.HasIndex(e => e.CostCenterCode)
//                .HasName("cost_centers_cost_center_code_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.CostCenterName)
//                .HasName("cost_centers_cost_center_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.CostCenterId).HasColumnName("cost_center_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CostCenterCode)
//                .IsRequired()
//                .HasColumnName("cost_center_code")
//                .HasMaxLength(24);

//            builder.Property(e => e.CostCenterName)
//                .IsRequired()
//                .HasColumnName("cost_center_name")
//                .HasMaxLength(50);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.CostCenters)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__cost_cent__audit__54968AE5");
//        }
//    }
//}
