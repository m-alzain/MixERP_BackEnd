//using ApplicationCore.Entities.Social;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Social
//{
//    public class FeedConfiguration : IEntityTypeConfiguration<Feed>
//    {
//        public void Configure(EntityTypeBuilder<Feed> builder)
//        {
//            builder.ToTable("feeds", "social");

//            builder.HasIndex(e => e.Scope)
//                .HasName("feeds_scope_inx");

//            builder.Property(e => e.FeedId).HasColumnName("feed_id");

//            builder.Property(e => e.Attachments).HasColumnName("attachments");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.CreatedBy).HasColumnName("created_by");

//            builder.Property(e => e.Deleted).HasColumnName("deleted");

//            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");

//            builder.Property(e => e.DeletedOn).HasColumnName("deleted_on");

//            builder.Property(e => e.EventTimestamp)
//                .HasColumnName("event_timestamp")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.FormattedText)
//                .IsRequired()
//                .HasColumnName("formatted_text")
//                .HasMaxLength(4000);

//            builder.Property(e => e.IsPublic)
//                .IsRequired()
//                .HasColumnName("is_public")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.ParentFeedId).HasColumnName("parent_feed_id");

//            builder.Property(e => e.Scope)
//                .HasColumnName("scope")
//                .HasMaxLength(100);

//            builder.Property(e => e.Url)
//                .HasColumnName("url")
//                .HasMaxLength(4000);

//            builder.HasOne(d => d.CreatedByNavigation)
//                .WithMany(p => p.FeedCreatedByNavigations)
//                .HasForeignKey(d => d.CreatedBy)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__feeds__created_b__77EAB41A");

//            builder.HasOne(d => d.DeletedByNavigation)
//                .WithMany(p => p.FeedDeletedByNavigations)
//                .HasForeignKey(d => d.DeletedBy)
//                .HasConstraintName("FK__feeds__deleted_b__7CAF6937");

//            builder.HasOne(d => d.ParentFeed)
//                .WithMany(p => p.InverseParentFeed)
//                .HasForeignKey(d => d.ParentFeedId)
//                .HasConstraintName("FK__feeds__parent_fe__79D2FC8C");
//        }
//    }
//}
