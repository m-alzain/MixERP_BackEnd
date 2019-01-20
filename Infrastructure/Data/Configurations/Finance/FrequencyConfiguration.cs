//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class FrequencyConfiguration : IEntityTypeConfiguration<Frequency>
//    {
//        public void Configure(EntityTypeBuilder<Frequency> builder)
//        {
//            builder.ToTable("frequencies", "finance");

//            builder.HasIndex(e => e.FrequencyCode)
//                .HasName("frequencies_frequency_code_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.HasIndex(e => e.FrequencyName)
//                .HasName("frequencies_frequency_name_uix")
//                .IsUnique()
//                .HasFilter("([deleted]=(0))");

//            builder.Property(e => e.FrequencyId)
//                .HasColumnName("frequency_id")
//                .ValueGeneratedNever();

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.FrequencyCode)
//                .IsRequired()
//                .HasColumnName("frequency_code")
//                .HasMaxLength(12);

//            builder.Property(e => e.FrequencyName)
//                .IsRequired()
//                .HasColumnName("frequency_name")
//                .HasMaxLength(50);

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.Frequencies)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__frequenci__audit__3AD6B8E2");
//        }
//    }
//}
