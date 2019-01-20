//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class FiscalYearConfiguration : IEntityTypeConfiguration<FiscalYear>
//    {
//        public void Configure(EntityTypeBuilder<FiscalYear> builder)
//        {
//            builder.HasKey(e => e.FiscalYearCode);

//            builder.ToTable("fiscal_year", "finance");

//            builder.HasIndex(e => e.EndsOn)
//                .HasName("fiscal_year_ends_on_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.FiscalYearId)
//                .HasName("UQ__fiscal_y__6F913C0CFAF278F6")
//                .IsUnique();

//            builder.HasIndex(e => e.FiscalYearName)
//                .HasName("fiscal_year_fiscal_year_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.StartsFrom)
//                .HasName("fiscal_year_starts_from_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.FiscalYearCode)
//                .HasColumnName("fiscal_year_code")
//                .HasMaxLength(12)
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.EndsOn)
//                .HasColumnName("ends_on")
//                .HasColumnType("date");

//            builder.Property(e => e.EodRequired)
//                .IsRequired()
//                .HasColumnName("eod_required")
//                .HasDefaultValueSql("((1))");

//            builder.Property(e => e.FiscalYearId)
//                .HasColumnName("fiscal_year_id")
//                .ValueGeneratedOnAdd();

//            builder.Property(e => e.FiscalYearName)
//                .IsRequired()
//                .HasColumnName("fiscal_year_name")
//                .HasMaxLength(50);

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.StartsFrom)
//                .HasColumnName("starts_from")
//                .HasColumnType("date");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.FiscalYears)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__fiscal_ye__audit__4924D839");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.FiscalYears)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__fiscal_ye__offic__4830B400");
//        }
//    }
//}
