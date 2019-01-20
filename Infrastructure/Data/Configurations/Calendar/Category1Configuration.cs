//using ApplicationCore.Entities.Calendar;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Calendar
//{
//    public class Category1Configuration : IEntityTypeConfiguration<Category1>
//    {
//        public void Configure(EntityTypeBuilder<Category1> builder)
//        {
//            builder.HasKey(e => e.CategoryId);

//            builder.ToTable("categories", "calendar");

//            builder.HasIndex(e => new { e.UserId, e.CategoryName })
//                .HasName("categories_user_id_category_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.CategoryId).HasColumnName("category_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CategoryName)
//                .IsRequired()
//                .HasColumnName("category_name")
//                .HasMaxLength(200);

//            builder.Property(e => e.CategoryOrder).HasColumnName("category_order");

//            builder.Property(e => e.ColorCode)
//                .IsRequired()
//                .HasColumnName("color_code")
//                .HasMaxLength(50);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.IsLocal)
//                .IsRequired()
//                .HasColumnName("is_local")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.UserId).HasColumnName("user_id");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Category1AuditUser)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__categorie__audit__2C88998B");

//            builder.HasOne(d => d.User)
//                .WithMany(p => p.Category1User)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__categorie__user___2AA05119");
//        }
//    }
//}
