using ApplicationCore.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Inventory
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> entity)
        {
           
            entity.ToTable("items", "inventory");

            entity.HasIndex(e => e.ItemCode)
                .HasName("items_item_code_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0))");

            entity.Property(e => e.ItemId).HasColumnName("item_id");

            entity.Property(e => e.AllowPurchase)
                .IsRequired()
                .HasColumnName("allow_purchase")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.AllowSales)
                .IsRequired()
                .HasColumnName("allow_sales")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.AuditTs)
                .HasColumnName("audit_ts")
                .HasDefaultValueSql("(getutcdate())");

            entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

            entity.Property(e => e.Barcode)
                .HasColumnName("barcode")
                .HasMaxLength(100);

            entity.Property(e => e.BrandId).HasColumnName("brand_id");

            entity.Property(e => e.CostPrice)
                .HasColumnName("cost_price")
                .HasColumnType("numeric(30, 6)");

            entity.Property(e => e.CostPriceIncludesTax).HasColumnName("cost_price_includes_tax");

            entity.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.HotItem).HasColumnName("hot_item");

            entity.Property(e => e.IsTaxableItem)
                .IsRequired()
                .HasColumnName("is_taxable_item")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.IsVariantOf).HasColumnName("is_variant_of");

            entity.Property(e => e.ItemCode)
                .IsRequired()
                .HasColumnName("item_code")
                .HasMaxLength(24);

            entity.Property(e => e.ItemGroupId).HasColumnName("item_group_id");

            entity.Property(e => e.ItemName)
                .IsRequired()
                .HasColumnName("item_name")
                .HasMaxLength(500);

            entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");

            entity.Property(e => e.LeadTimeInDays).HasColumnName("lead_time_in_days");

            entity.Property(e => e.MaintainInventory)
                .IsRequired()
                .HasColumnName("maintain_inventory")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Photo)
                .HasColumnName("photo");
                //.HasColumnType("photo")
                //.HasMaxLength(4000);

            entity.Property(e => e.PreferredSupplierId).HasColumnName("preferred_supplier_id");

            entity.Property(e => e.ReorderLevel).HasColumnName("reorder_level");

            entity.Property(e => e.ReorderQuantity)
                .HasColumnName("reorder_quantity")
                .HasColumnType("numeric(30, 6)");

            entity.Property(e => e.ReorderUnitId).HasColumnName("reorder_unit_id");

            entity.Property(e => e.SellingPrice)
                .HasColumnName("selling_price")
                .HasColumnType("numeric(30, 6)");

            entity.Property(e => e.SellingPriceIncludesTax).HasColumnName("selling_price_includes_tax");

            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.AuditUser)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.AuditUserId)
                .HasConstraintName("FK__items__audit_use__416EA7D8");

            entity.HasOne(d => d.Brand)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__items__brand_id__3414ACBA");

            entity.HasOne(d => d.IsVariantOfNavigation)
                .WithMany(p => p.InverseIsVariantOfNavigation)
                .HasForeignKey(d => d.IsVariantOf)
                .HasConstraintName("FK__items__is_varian__407A839F");

            entity.HasOne(d => d.ItemGroup)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__items__item_grou__322C6448");

            entity.HasOne(d => d.ItemType)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__items__item_type__33208881");

            entity.HasOne(d => d.PreferredSupplier)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.PreferredSupplierId)
                .HasConstraintName("FK__items__preferred__3508D0F3");

            entity.HasOne(d => d.ReorderUnit)
                .WithMany(p => p.ItemReorderUnits)
                .HasForeignKey(d => d.ReorderUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__items__reorder_u__3CA9F2BB");

            entity.HasOne(d => d.Unit)
                .WithMany(p => p.ItemUnits)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__items__unit_id__35FCF52C");
           
        }
    }
}
