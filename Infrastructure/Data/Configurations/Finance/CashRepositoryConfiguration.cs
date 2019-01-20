//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class CashRepositoryConfiguration : IEntityTypeConfiguration<CashRepository>
//    {
//        public void Configure(EntityTypeBuilder<CashRepository> builder)
//        {
//            builder.ToTable("cash_repositories", "finance");

//            builder.HasIndex(e => new { e.OfficeId, e.CashRepositoryCode })
//                .HasName("cash_repositories_cash_repository_code_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => new { e.OfficeId, e.CashRepositoryName })
//                .HasName("cash_repositories_cash_repository_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.CashRepositoryId).HasColumnName("cash_repository_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.CashRepositoryCode)
//                .IsRequired()
//                .HasColumnName("cash_repository_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.CashRepositoryName)
//                .IsRequired()
//                .HasColumnName("cash_repository_name")
//                .HasMaxLength(50);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.Description)
//                .HasColumnName("description")
//                .HasMaxLength(100);

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.ParentCashRepositoryId).HasColumnName("parent_cash_repository_id");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.CashRepositories)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__cash_repo__audit__4183B671");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.CashRepositories)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__cash_repo__offic__3F9B6DFF");

//            builder.HasOne(d => d.ParentCashRepository)
//                .WithMany(p => p.InverseParentCashRepository)
//                .HasForeignKey(d => d.ParentCashRepositoryId)
//                .HasConstraintName("FK__cash_repo__paren__408F9238");
//        }
//    }
//}
