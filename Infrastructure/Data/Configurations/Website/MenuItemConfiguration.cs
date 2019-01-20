//using ApplicationCore.Entities.Website;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Website
//{
//    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
//    {
//        public void Configure(EntityTypeBuilder<MenuItem> builder)
//        {
//            builder.ToTable("menu_items", "website");

//            builder.Property(e => e.MenuItemId).HasColumnName("menu_item_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.ContentId).HasColumnName("content_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.MenuId).HasColumnName("menu_id");

//            builder.Property(e => e.ParentMenuItemId).HasColumnName("parent_menu_item_id");

//            builder.Property(e => e.Sort).HasColumnName("sort");

//            builder.Property(e => e.Target)
//                .HasColumnName("target")
//                .HasMaxLength(20);

//            builder.Property(e => e.Title)
//                .IsRequired()
//                .HasColumnName("title")
//                .HasMaxLength(100);

//            builder.Property(e => e.Url)
//                .HasColumnName("url")
//                .HasMaxLength(500);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.MenuItems)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__menu_item__audit__019E3B86");

//            builder.HasOne(d => d.Content)
//                .WithMany(p => p.MenuItems)
//                .HasForeignKey(d => d.ContentId)
//                .HasConstraintName("FK__menu_item__conte__7FB5F314");

//            builder.HasOne(d => d.Menu)
//                .WithMany(p => p.MenuItems)
//                .HasForeignKey(d => d.MenuId)
//                .HasConstraintName("FK__menu_item__menu___7DCDAAA2");

//            builder.HasOne(d => d.ParentMenuItem)
//                .WithMany(p => p.InverseParentMenuItem)
//                .HasForeignKey(d => d.ParentMenuItemId)
//                .HasConstraintName("FK__menu_item__paren__00AA174D");
//        }
//    }
//}
