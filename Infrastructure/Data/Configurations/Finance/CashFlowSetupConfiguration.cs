//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class CashFlowSetupConfiguration : IEntityTypeConfiguration<CashFlowSetup>
//    {
//        public void Configure(EntityTypeBuilder<CashFlowSetup> builder)
//        {
//            builder.ToTable("cash_flow_setup", "finance");

//            builder.HasIndex(e => e.AccountMasterId)
//                .HasName("cash_flow_setup_account_master_id_inx")
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.CashFlowHeadingId)
//                .HasName("cash_flow_setup_cash_flow_heading_id_inx")
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.CashFlowSetupId).HasColumnName("cash_flow_setup_id");

//            builder.Property(e => e.AccountMasterId).HasColumnName("account_master_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CashFlowHeadingId).HasColumnName("cash_flow_heading_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.HasOne(d => d.AccountMaster)
//                .WithMany(p => p.CashFlowSetups)
//                .HasForeignKey(d => d.AccountMasterId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__cash_flow__accou__09FE775D");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.CashFlowSetups)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__cash_flow__audit__0AF29B96");

//            builder.HasOne(d => d.CashFlowHeading)
//                .WithMany(p => p.CashFlowSetups)
//                .HasForeignKey(d => d.CashFlowHeadingId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__cash_flow__cash___090A5324");
//        }
//    }
//}
