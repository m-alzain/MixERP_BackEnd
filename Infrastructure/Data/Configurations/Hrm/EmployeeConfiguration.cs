using ApplicationCore.Entities.Hrm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations.Hrm
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {            
            builder.ToTable("employees", "hrm");

            builder.HasIndex(e => e.EmployeeCode)
                .HasName("employees_employee_code_uix")
                .IsUnique()
                .HasFilter("([deleted]=(0))");

            builder.Property(e => e.EmployeeId).HasColumnName("employee_id");

            builder.Property(e => e.AddressLine1)
                .HasColumnName("address_line_1")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.AddressLine2)
                .HasColumnName("address_line_2")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.AuditTs)
                .HasColumnName("audit_ts")
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

            builder.Property(e => e.BankAccountNumber)
                .HasColumnName("bank_account_number")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.BankBranchName)
                .HasColumnName("bank_branch_name")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.BankName)
                .HasColumnName("bank_name")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.BankReferenceNumber)
                .HasColumnName("bank_reference_number")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Blog)
                .HasColumnName("blog")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CountryCode)
                .HasColumnName("country_code")
                .HasMaxLength(12);

            builder.Property(e => e.CurrentDepartmentId).HasColumnName("current_department_id");

            builder.Property(e => e.CurrentEmploymentStatusId).HasColumnName("current_employment_status_id");

            builder.Property(e => e.CurrentJobTitleId).HasColumnName("current_job_title_id");

            builder.Property(e => e.CurrentPayGradeId).HasColumnName("current_pay_grade_id");

            builder.Property(e => e.CurrentRoleId).HasColumnName("current_role_id");

            builder.Property(e => e.CurrentShiftId).HasColumnName("current_shift_id");

            builder.Property(e => e.DateOfBirth)
                .HasColumnName("date_of_birth")
                .HasColumnType("date");

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.EmailAddress)
                .HasColumnName("email_address")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.EmployeeCode)
                .IsRequired()
                .HasColumnName("employee_code")
                .HasMaxLength(12);

            builder.Property(e => e.EmployeeName)
                .IsRequired()
                .HasColumnName("employee_name")
                .HasMaxLength(160);

            builder.Property(e => e.EmployeeTypeId).HasColumnName("employee_type_id");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(50);

            builder.Property(e => e.GenderCode)
                .IsRequired()
                .HasColumnName("gender_code")
                .HasMaxLength(4);

            builder.Property(e => e.HardOfHearing).HasColumnName("hard_of_hearing");

            builder.Property(e => e.IsAlcoholic).HasColumnName("is_alcoholic");

            builder.Property(e => e.IsAphonic).HasColumnName("is_aphonic");

            builder.Property(e => e.IsAutistic).HasColumnName("is_autistic");

            builder.Property(e => e.IsCognitivelyDisabled).HasColumnName("is_cognitively_disabled");

            builder.Property(e => e.IsSmoker).HasColumnName("is_smoker");

            builder.Property(e => e.JoinedOn)
                .HasColumnName("joined_on")
                .HasColumnType("date");

            builder.Property(e => e.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.LowVision).HasColumnName("low_vision");

            builder.Property(e => e.MaritalStatusId).HasColumnName("marital_status_id");

            builder.Property(e => e.MiddleName)
                .HasColumnName("middle_name")
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.NationalityId).HasColumnName("nationality_id");

            builder.Property(e => e.OfficeId).HasColumnName("office_id");

            builder.Property(e => e.PhoneCell)
                .HasColumnName("phone_cell")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.PhoneEmergency)
                .HasColumnName("phone_emergency")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.PhoneEmergency2)
                .HasColumnName("phone_emergency_2")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.PhoneHome)
                .HasColumnName("phone_home")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.PhoneOfficeExtension)
                .HasColumnName("phone_office_extension")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Photo)
                .HasColumnName("photo");
                //.HasColumnType("photo")
                //.HasMaxLength(4000);

            builder.Property(e => e.ServiceEndedOn)
                .HasColumnName("service_ended_on")
                .HasColumnType("date");

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Street)
                .HasColumnName("street")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.Property(e => e.UsesWheelchair).HasColumnName("uses_wheelchair");

            builder.Property(e => e.Website)
                .HasColumnName("website")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.WithDisabilities).HasColumnName("with_disabilities");

            builder.Property(e => e.ZipCode)
                .HasColumnName("zip_code")
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            builder.HasOne(d => d.AuditUser)
                .WithMany(p => p.EmployeeAuditUsers)
                .HasForeignKey(d => d.AuditUserId)
                .HasConstraintName("FK__employees__audit__7A1D154F");

            builder.HasOne(d => d.CountryCodeNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CountryCode)
                .HasConstraintName("FK__employees__count__7187CF4E");

            builder.HasOne(d => d.CurrentDepartment)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CurrentDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__curre__61516785");

            builder.HasOne(d => d.CurrentEmploymentStatus)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CurrentEmploymentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__curre__6339AFF7");

            builder.HasOne(d => d.CurrentJobTitle)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CurrentJobTitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__curre__642DD430");

            builder.HasOne(d => d.CurrentPayGrade)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CurrentPayGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__curre__6521F869");

            builder.HasOne(d => d.CurrentRole)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CurrentRoleId)
                .HasConstraintName("FK__employees__curre__62458BBE");

            builder.HasOne(d => d.CurrentShift)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CurrentShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__curre__66161CA2");

            builder.HasOne(d => d.EmployeeType)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__emplo__605D434C");

            builder.HasOne(d => d.GenderCodeNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.GenderCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__gende__5C8CB268");

            builder.HasOne(d => d.MaritalStatus)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.MaritalStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__marit__5D80D6A1");

            builder.HasOne(d => d.Nationality)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("FK__employees__natio__670A40DB");

            builder.HasOne(d => d.Office)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__offic__5E74FADA");

            builder.HasOne(d => d.User)
                .WithMany(p => p.EmployeeUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__employees__user___5F691F13");        

        }
    }
}