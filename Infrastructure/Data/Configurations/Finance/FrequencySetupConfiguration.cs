//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class FrequencySetupConfiguration : IEntityTypeConfiguration<FrequencySetup>
//    {
//        public void Configure(EntityTypeBuilder<FrequencySetup> builder)
//        {
//            builder.ToTable("frequency_setups", "finance");

//            builder.HasIndex(e => e.FrequencySetupCode)
//                .HasName("frequency_setups_frequency_setup_code_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.ValueDate)
//                .HasName("UQ__frequenc__43469440FE9D4604")
//                .IsUnique();

//            builder.Property(e => e.FrequencySetupId).HasColumnName("frequency_setup_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.FiscalYearCode)
//                .IsRequired()
//                .HasColumnName("fiscal_year_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.FrequencyId).HasColumnName("frequency_id");

//            builder.Property(e => e.FrequencySetupCode)
//                .IsRequired()
//                .HasColumnName("frequency_setup_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.ValueDate)
//                .HasColumnName("value_date")
//                .HasColumnType("date");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.FrequencySetups)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__frequency__audit__5D2BD0E6");

//            builder.HasOne(d => d.FiscalYearCodeNavigation)
//                .WithMany(p => p.FrequencySetups)
//                .HasForeignKey(d => d.FiscalYearCode)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__frequency__fisca__5A4F643B");

//            builder.HasOne(d => d.Frequency)
//                .WithMany(p => p.FrequencySetups)
//                .HasForeignKey(d => d.FrequencyId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__frequency__frequ__5B438874");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.FrequencySetups)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__frequency__offic__5C37ACAD");
//        }
//    }
//}
