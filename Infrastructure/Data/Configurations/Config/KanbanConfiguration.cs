//using ApplicationCore.Entities.Config;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Config
//{
//    public class KanbanConfiguration : IEntityTypeConfiguration<Kanban>
//    {
//        public void Configure(EntityTypeBuilder<Kanban> builder)
//        {
//            builder.ToTable("kanbans", "config");

//            builder.Property(e => e.KanbanId).HasColumnName("kanban_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Description)
//                .HasColumnName("description")
//                .HasMaxLength(500);

//            builder.Property(e => e.KanbanName)
//                .IsRequired()
//                .HasColumnName("kanban_name")
//                .HasMaxLength(128);

//            builder.Property(e => e.ObjectName)
//                .IsRequired()
//                .HasColumnName("object_name")
//                .HasMaxLength(128);

//            builder.Property(e => e.UserId).HasColumnName("user_id");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.KanbanAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__kanbans__audit_u__0697FACD");

//            builder.HasOne(d => d.User)
//                .WithMany(p => p.KanbanUsers)
//                .HasForeignKey(d => d.UserId)
//                .HasConstraintName("FK__kanbans__user_id__05A3D694");
//        }
//    }
//}
