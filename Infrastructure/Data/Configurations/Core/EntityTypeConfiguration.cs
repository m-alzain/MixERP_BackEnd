using ApplicationCore.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configurations.Core
{
    public class EntityTypeConfiguration : IEntityTypeConfiguration<EntityType>
    {
        public void Configure(EntityTypeBuilder<EntityType> builder)
        {
            builder.ToTable("entity_types", "account");

            builder.HasIndex(e => e.EntityName)
                .HasName("UQ__entity_types__783254B1A0BC1C3C")
                .IsUnique();

            #region IEntity

            builder.Property(e => e.Id)
                .HasColumnName("entity_type_id")
                .ValueGeneratedNever();            

            #endregion

            builder.Property(e => e.ModuleName)
                .IsRequired()
                .HasColumnName("module_name")
                .HasMaxLength(100);         

            builder.Property(e => e.EntityName)
                .IsRequired()
                .HasColumnName("entity_name")
                .HasMaxLength(100);

            builder.Property(e => e.Url)
                .IsRequired()
                .HasColumnName("url")
                .HasMaxLength(500);

            builder.Property(e => e.Icon)
                .IsRequired()
                .HasColumnName("icon")
                .HasMaxLength(100);

        }
    }
}
