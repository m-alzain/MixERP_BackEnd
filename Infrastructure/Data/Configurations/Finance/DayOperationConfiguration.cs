//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class DayOperationConfiguration : IEntityTypeConfiguration<DayOperation>
//    {
//        public void Configure(EntityTypeBuilder<DayOperation> builder)
//        {
//            builder.HasKey(e => e.DayId);

//            builder.ToTable("day_operation", "finance");

//            builder.HasIndex(e => e.CompletedOn)
//                .HasName("day_operation_completed_on_inx");

//            builder.HasIndex(e => e.ValueDate)
//                .HasName("day_operation_value_date_uix")
//                .IsUnique();

//            builder.Property(e => e.DayId).HasColumnName("day_id");

//            builder.Property(e => e.Completed).HasColumnName("completed");

//            builder.Property(e => e.CompletedBy).HasColumnName("completed_by");

//            builder.Property(e => e.CompletedOn).HasColumnName("completed_on");

//            builder.Property(e => e.OfficeId).HasColumnName("office_id");

//            builder.Property(e => e.StartedBy).HasColumnName("started_by");

//            builder.Property(e => e.StartedOn).HasColumnName("started_on");

//            builder.Property(e => e.ValueDate)
//                .HasColumnName("value_date")
//                .HasColumnType("date");

//            builder.HasOne(d => d.CompletedByNavigation)
//                .WithMany(p => p.DayOperationCompletedByNavigations)
//                .HasForeignKey(d => d.CompletedBy)
//                .HasConstraintName("FK__day_opera__compl__6C390A4C");

//            builder.HasOne(d => d.Office)
//                .WithMany(p => p.DayOperations)
//                .HasForeignKey(d => d.OfficeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__day_opera__offic__6A50C1DA");

//            builder.HasOne(d => d.StartedByNavigation)
//                .WithMany(p => p.DayOperationStartedByNavigations)
//                .HasForeignKey(d => d.StartedBy)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__day_opera__start__6B44E613");
//        }
//    }
//}
