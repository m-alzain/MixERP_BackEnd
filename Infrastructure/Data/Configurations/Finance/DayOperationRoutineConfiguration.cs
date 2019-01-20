//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class DayOperationRoutineConfiguration : IEntityTypeConfiguration<DayOperationRoutine>
//    {
//        public void Configure(EntityTypeBuilder<DayOperationRoutine> builder)
//        {
//            builder.ToTable("day_operation_routines", "finance");

//            builder.HasIndex(e => e.CompletedOn)
//                .HasName("day_operation_routines_completed_on_inx");

//            builder.HasIndex(e => e.StartedOn)
//                .HasName("day_operation_routines_started_on_inx");

//            builder.Property(e => e.DayOperationRoutineId).HasColumnName("day_operation_routine_id");

//            builder.Property(e => e.CompletedOn).HasColumnName("completed_on");

//            builder.Property(e => e.DayId).HasColumnName("day_id");

//            builder.Property(e => e.RoutineId).HasColumnName("routine_id");

//            builder.Property(e => e.StartedOn).HasColumnName("started_on");

//            builder.HasOne(d => d.Day)
//                .WithMany(p => p.DayOperationRoutines)
//                .HasForeignKey(d => d.DayId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__day_opera__day_i__70FDBF69");

//            builder.HasOne(d => d.Routine)
//                .WithMany(p => p.DayOperationRoutines)
//                .HasForeignKey(d => d.RoutineId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK__day_opera__routi__71F1E3A2");
//        }
//    }
//}
