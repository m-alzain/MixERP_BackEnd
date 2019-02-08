using ApplicationCore.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Auth
{
    public class GroupEntityAccessPolicyConfiguration : IEntityTypeConfiguration<GroupEntityAccessPolicy>
    {
        public void Configure(EntityTypeBuilder<GroupEntityAccessPolicy> builder)
        {
            builder.ToTable("group_entity_access_policies", "auth");

            #region IEntity

            builder.Property(e => e.Id).HasColumnName("group_entity_access_policy_id");

            #endregion         

            builder.Property(e => e.AllowAccess).HasColumnName("allow_access");
           
            builder.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.EntityTypeId).HasColumnName("entity_type_id");

            builder.Property(e => e.RoleId).HasColumnName("role_id");

            builder.HasOne(d => d.EntityType)
                .WithMany(p => p.GroupEntityAccessPolicies)
                .HasForeignKey(d => d.EntityTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__group_entity__acces__polciy_entity_type");

            builder.HasOne(d => d.Role)
                .WithMany(p => p.GroupEntityAccessPolicies)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__group_entity__acces__polciy_role");


            #region IAuditable

            builder.Property(e => e.CreatedOn)
                .HasColumnName("created_on")
                .HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.CreatedByUserId).HasColumnName("created_by_userId");
            builder.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.CreatedGroupEntityAccessPolicies)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__created_group_entity_access_policies__createted_by_user").OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(e => e.UpdatedOn)
                .HasColumnName("updated_on")
                .HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_userId");
            builder.HasOne(d => d.UpdatedByUser)
                .WithMany(p => p.UpdatedGroupEntityAccessPolicies)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK__updated_group_entity_access_policies__updated_by_user").OnDelete(DeleteBehavior.ClientSetNull);

            #endregion
        }
    }
}
