using System;
using System.Collections.Generic;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Inventory;
using ApplicationCore.Entities.Purchases;

namespace ApplicationCore.Entities.Hrm
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeName { get; set; }
        public string GenderCode { get; set; }
        public int MaritalStatusId { get; set; }
        public DateTime? JoinedOn { get; set; }
        public int OfficeId { get; set; }
        public int? UserId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int CurrentDepartmentId { get; set; }
        public int? CurrentRoleId { get; set; }
        public int CurrentEmploymentStatusId { get; set; }
        public int CurrentJobTitleId { get; set; }
        public int CurrentPayGradeId { get; set; }
        public int CurrentShiftId { get; set; }
        public int? NationalityId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranchName { get; set; }
        public string BankReferenceNumber { get; set; }
        public string ZipCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneOfficeExtension { get; set; }
        public string PhoneEmergency { get; set; }
        public string PhoneEmergency2 { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }
        public string Blog { get; set; }
        public bool? IsSmoker { get; set; }
        public bool? IsAlcoholic { get; set; }
        public bool? WithDisabilities { get; set; }
        public bool? LowVision { get; set; }
        public bool? UsesWheelchair { get; set; }
        public bool? HardOfHearing { get; set; }
        public bool? IsAphonic { get; set; }
        public bool? IsCognitivelyDisabled { get; set; }
        public bool? IsAutistic { get; set; }
        public DateTime? ServiceEndedOn { get; set; }
        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTs { get; set; }
        public bool? Deleted { get; set; }

        public User AuditUser { get; set; }
        public Country CountryCodeNavigation { get; set; }
        public Department CurrentDepartment { get; set; }
        public EmploymentStatus CurrentEmploymentStatus { get; set; }
        public JobTitle CurrentJobTitle { get; set; }
        public PayGrade CurrentPayGrade { get; set; }
        public Role1 CurrentRole { get; set; }
        public Shift CurrentShift { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public Gender GenderCodeNavigation { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Nationality Nationality { get; set; }
        public Office Office { get; set; }
        public User User { get; set; }
        public Termination TerminationEmployee { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<EmployeeExperience> EmployeeExperiences { get; set; }
        public ICollection<EmployeeIdentificationDetail> EmployeeIdentificationDetails { get; set; }
        public ICollection<EmployeeQualification> EmployeeQualifications { get; set; }
        public ICollection<EmployeeSocialNetworkDetail> EmployeeSocialNetworkDetails { get; set; }
        public ICollection<Exit> ExitEmployees { get; set; }
        public ICollection<Exit> ExitForwardToNavigations { get; set; }
        public ICollection<LeaveApplication> LeaveApplications { get; set; }
        public ICollection<Resignation> ResignationEmployees { get; set; }
        public ICollection<Resignation> ResignationForwardToNavigations { get; set; }
        public ICollection<Termination> TerminationForwardToNavigations { get; set; }
    }
}
