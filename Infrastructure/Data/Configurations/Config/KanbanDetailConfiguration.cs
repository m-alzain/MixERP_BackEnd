//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Config
//{
//    public class KanbanDetailConfiguration : IEntityTypeConfiguration<KanbanDetail>
//    {
//        public void Configure(EntityTypeBuilder<KanbanDetail> builder)
//        {
//            builder.ToTable("kanban_details", "config");

//            builder.HasIndex(e => new { e.KanbanId, e.ResourceId })
//                .HasName("kanban_details_kanban_id_resource_id_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.KanbanDetailId).HasColumnName("kanban_detail_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.KanbanId).HasColumnName("kanban_id");

//            builder.Property(e => e.Rating).HasColumnName("rating");

//            builder.Property(e => e.ResourceId)
//                .IsRequired()
//                .HasColumnName("resource_id")
//                .HasMaxLength(128);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.KanbanDetails)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__kanban_de__audit__0D44F85C");

//            builder.HasOne(d => d.Kanban)
//                .WithMany(p => p.KanbanDetails)
//                .HasForeignKey(d => d.KanbanId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__kanban_de__kanba__0B5CAFEA");
//        }
//    }
//}
