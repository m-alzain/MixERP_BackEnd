//using ApplicationCore.Entities.Website;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Website
//{
//    public class Menu1Configuration : IEntityTypeConfiguration<Menu1>
//    {
//        public void Configure(EntityTypeBuilder<Menu1> builder)
//        {
//            builder.HasKey(e => e.MenuId);

//            builder.ToTable("menus", "website");

//            builder.HasIndex(e => e.MenuName)
//                .HasName("menus_menu_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.MenuId).HasColumnName("menu_id");

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

//            builder.Property(e => e.MenuName)
//                .HasColumnName("menu_name")
//                .HasMaxLength(100);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Menu1)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__menus__audit_use__7908F585");
//        }
//    }
//}
