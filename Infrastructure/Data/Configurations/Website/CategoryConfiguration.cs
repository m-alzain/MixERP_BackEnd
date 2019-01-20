//using ApplicationCore.Entities.Website;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Website
//{
//    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
//    {
//        public void Configure(EntityTypeBuilder<Category> builder)
//        {
//            builder.ToTable("categories", "website");

//            builder.HasIndex(e => e.Alias)
//                .HasName("UQ__categori__8C585C0470CD246F")
//                .IsUnique();

//            builder.Property(e => e.CategoryId).HasColumnName("category_id");

//            builder.Property(e => e.Alias)
//                .IsRequired()
//                .HasColumnName("alias")
//                .HasMaxLength(250);

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CategoryName)
//                .IsRequired()
//                .HasColumnName("category_name")
//                .HasMaxLength(250);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.IsBlog).HasColumnName("is_blog");

//            builder.Property(e => e.SeoDescription)
//                .HasColumnName("seo_description")
//                .HasMaxLength(100);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Categories)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__categorie__audit__67DE6983");
//        }
//    }
//}
