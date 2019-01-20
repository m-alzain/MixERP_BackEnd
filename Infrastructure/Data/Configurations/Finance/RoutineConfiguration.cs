//using ApplicationCore.Entities.Finance;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Configurations.Finance
//{
//    public class RoutineConfiguration : IEntityTypeConfiguration<Routine>
//    {
//        public void Configure(EntityTypeBuilder<Routine> entity)
//        {
//            entity.ToTable("routines", "finance");

//            entity.HasIndex(e => e.RoutineCode)
//                .HasName("routines_routine_code_uix")
//                .IsUnique();

//            entity.HasIndex(e => e.RoutineName)
//                .HasName("UQ__routines__380179507C05F3EA")
//                .IsUnique();

//            entity.Property(e => e.RoutineId).HasColumnName("routine_id");

//            entity.Property(e => e.Order).HasColumnName("order");

//            entity.Property(e => e.RoutineCode)
//                .IsRequired()
//                .HasColumnName("routine_code")
//                .HasMaxLength(48);

//            entity.Property(e => e.RoutineName)
//                .IsRequired()
//                .HasColumnName("routine_name")
//                .HasMaxLength(128);

//            entity.Property(e => e.Status)
//                .IsRequired()
//                .HasColumnName("status")
//                .HasDefaultValueSql("((1))");
//        }
//    }
//}
