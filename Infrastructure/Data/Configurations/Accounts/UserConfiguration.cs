using ApplicationCore.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.Accounts
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("users", "account");

            entity.HasIndex(e => e.Email)
                .HasName("users_email_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0))");

            entity.Property(e => e.Id).HasColumnName("user_id");            

            entity.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(100);

            entity.Property(e => e.LastBrowser)
                .HasColumnName("last_browser")
                .HasMaxLength(500);

            entity.Property(e => e.LastIp)
                .HasColumnName("last_ip")
                .HasMaxLength(500);

            entity.Property(e => e.LastSeenOn).HasColumnName("last_seen_on");

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100);
         

            entity.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(100);

            //entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasDefaultValueSql("((1))");          

            //entity.HasOne(d => d.Role)
            //    .WithMany(p => p.Users)
            //    .HasForeignKey(d => d.RoleId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__users__role_id__7F2BE32F");           


            #region Audit

            entity.Property(e => e.CreatedOn)
                .HasColumnName("created_on")
                .HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_userId");
            entity.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.InverseCreatedUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__created_users__createted_by_user").OnDelete(DeleteBehavior.ClientSetNull);

            entity.Property(e => e.UpdatedOn)
                .HasColumnName("updated_on")
                .HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_userId");
            entity.HasOne(d => d.UpdatedByUser)
                .WithMany(p => p.InverseUpdatedUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK__updated_users__updated_by_user").OnDelete(DeleteBehavior.ClientSetNull);

            #endregion

        }
    }
}
