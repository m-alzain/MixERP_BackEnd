//using ApplicationCore.Entities.Core;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Core
//{
//    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
//    {
//        public void Configure(EntityTypeBuilder<Menu> builder)
//        {
//            builder.ToTable("menus", "core");

//            builder.HasIndex(e => new { e.AppName, e.MenuName })
//                .HasName("menus_app_name_menu_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.MenuId).HasColumnName("menu_id");

//            builder.Property(e => e.AppName)
//                .IsRequired()
//                .HasColumnName("app_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.I18nKey)
//                .IsRequired()
//                .HasColumnName("i18n_key")
//                .HasMaxLength(200);

//            builder.Property(e => e.Icon)
//                .HasColumnName("icon")
//                .HasMaxLength(100);

//            builder.Property(e => e.MenuName)
//                .IsRequired()
//                .HasColumnName("menu_name")
//                .HasMaxLength(100);

//            builder.Property(e => e.ParentMenuId).HasColumnName("parent_menu_id");

//            builder.Property(e => e.Sort).HasColumnName("sort");

//            builder.Property(e => e.Url)
//                .HasColumnName("url")
//                .HasMaxLength(500);

//            builder.HasOne(d => d.AppNameNavigation)
//                .WithMany(p => p.Menus)
//                .HasForeignKey(d => d.AppName)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__menus__app_name__276EDEB3");

//            builder.HasOne(d => d.ParentMenu)
//                .WithMany(p => p.InverseParentMenu)
//                .HasForeignKey(d => d.ParentMenuId)
//                .HasConstraintName("FK__menus__parent_me__286302EC");
//        }
//    }
//}
