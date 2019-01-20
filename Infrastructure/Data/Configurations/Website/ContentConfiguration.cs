//using ApplicationCore.Entities.Website;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Website
//{
//    public class ContentConfiguration : IEntityTypeConfiguration<Content>
//    {
//        public void Configure(EntityTypeBuilder<Content> builder)
//        {
//            builder.ToTable("contents", "website");

//            builder.HasIndex(e => e.Alias)
//                .HasName("UQ__contents__8C585C049FBBBAA4")
//                .IsUnique();

//            builder.Property(e => e.ContentId).HasColumnName("content_id");

//            builder.Property(e => e.Alias)
//                .IsRequired()
//                .HasColumnName("alias")
//                .HasMaxLength(500);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.AuthorId).HasColumnName("author_id");

//            builder.Property(e => e.CategoryId).HasColumnName("category_id");

//            builder.Property(e => e.Contents)
//                .IsRequired()
//                .HasColumnName("contents");

//            builder.Property(e => e.CreatedOn)
//                .HasColumnName("created_on")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Hits).HasColumnName("hits");

//            builder.Property(e => e.IsDraft)
//                .IsRequired()
//                .HasColumnName("is_draft")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.IsHomepage).HasColumnName("is_homepage");

//            builder.Property(e => e.LastEditedOn).HasColumnName("last_edited_on");

//            builder.Property(e => e.LastEditorId).HasColumnName("last_editor_id");

//            builder.Property(e => e.Markdown).HasColumnName("markdown");

//            builder.Property(e => e.PublishOn).HasColumnName("publish_on");

//            builder.Property(e => e.SeoDescription)
//                .IsRequired()
//                .HasColumnName("seo_description")
//                .HasMaxLength(1000)
//                .HasDefaultValueSql("('')");

//            builder.Property(e => e.Tags)
//                .HasColumnName("tags")
//                .HasMaxLength(500);

//            builder.Property(e => e.Title)
//                .IsRequired()
//                .HasColumnName("title")
//                .HasMaxLength(500);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.ContentAuditUsers)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__contents__audit___74444068");

//            builder.HasOne(d => d.Author)
//                .WithMany(p => p.ContentAuthors)
//                .HasForeignKey(d => d.AuthorId)
//                .HasConstraintName("FK__contents__author__6E8B6712");

//            builder.HasOne(d => d.Category)
//                .WithMany(p => p.Contents)
//                .HasForeignKey(d => d.CategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__contents__catego__6D9742D9");

//            builder.HasOne(d => d.LastEditor)
//                .WithMany(p => p.ContentLastEditors)
//                .HasForeignKey(d => d.LastEditorId)
//                .HasConstraintName("FK__contents__last_e__7073AF84");
//        }
//    }
//}
