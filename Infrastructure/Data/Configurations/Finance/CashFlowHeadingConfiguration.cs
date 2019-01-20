//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class CashFlowHeadingConfiguration : IEntityTypeConfiguration<CashFlowHeading>
//    {
//        public void Configure(EntityTypeBuilder<CashFlowHeading> builder)
//        {
//            builder.ToTable("cash_flow_headings", "finance");

//            builder.HasIndex(e => e.CashFlowHeadingCode)
//                .HasName("cash_flow_headings_cash_flow_heading_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.CashFlowHeadingId)
//                .HasColumnName("cash_flow_heading_id")
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CashFlowHeadingCode)
//                .IsRequired()
//                .HasColumnName("cash_flow_heading_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.CashFlowHeadingName)
//                .IsRequired()
//                .HasColumnName("cash_flow_heading_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.CashFlowHeadingType)
//                .IsRequired()
//                .HasColumnName("cash_flow_heading_type")
//                .HasMaxLength(1)
//                .IsUnicode(false);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.IsDebit).HasColumnName("is_debit");

//            builder.Property(e => e.IsPurchase).HasColumnName("is_purchase");

//            builder.Property(e => e.IsSales).HasColumnName("is_sales");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.CashFlowHeadings)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__cash_flow__audit__7132C993");
//        }
//    }
//}
