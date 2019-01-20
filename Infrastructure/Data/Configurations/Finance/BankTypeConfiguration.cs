//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class BankTypeConfiguration : IEntityTypeConfiguration<BankType>
//    {
//        public void Configure(EntityTypeBuilder<BankType> builder)
//        {
//            builder.ToTable("bank_types", "finance");

//            builder.Property(e => e.BankTypeId).HasColumnName("bank_type_id");

//            builder.Property(e => e.AuditTs)
//                .HasColumnName("audit_ts")
//                .HasDefaultValueSql("(getutcdate())");

//            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

//            builder.Property(e => e.BankTypeName)
//                .HasColumnName("bank_type_name")
//                .HasMaxLength(1000);

//            builder.Property(e => e.Deleted)
//                .HasColumnName("deleted")
//                .HasDefaultValueSql("((0))");

//            builder.HasOne(d => d.AuditUser)
//                .WithMany(p => p.BankTypes)
//                .HasForeignKey(d => d.AuditUserId)
//                .HasConstraintName("FK__bank_type__audit__75F77EB0");
//        }
//    }
//}
