﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Finance;
//using ApplicationCore.Entities.Auth;
//using ApplicationCore.Entities.Hrm;
//using ApplicationCore.Entities.Inventory;
//using ApplicationCore.Entities.Purchases;
//using ApplicationCore.Entities.Sales;

namespace ApplicationCore.Entities.Accounts
{
    public class Office : IEntity, ITenant, IAuditable
    {

        #region ITenant

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        #endregion

        #region IEntity

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        #endregion

        public string OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public string NickName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string CurrencyCode { get; set; }
        public string PoBox { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public byte[] Logo { get; set; }
        public Guid? ParentOfficeId { get; set; }
        public string RegistrationNumber { get; set; }
        public string PanNumber { get; set; }
        public bool AllowTransactionPosting { get; set; }                
        public bool? Deleted { get; set; }


        public Office ParentOffice { get; set; }
        public ICollection<OfficeUser> OfficeUsers { get; set; }
        public ICollection<Office> InverseParentOffice { get; set; }
        public ICollection<Role> Roles { get; set; }

        #region IAuditable

        public Guid? CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }

        #endregion

        #region Commented (From the old system)

        //public InventorySetup InventorySetup { get; set; }
        //public TaxSetup TaxSetup { get; set; }
        //public ICollection<Attendance> Attendances { get; set; }
        //public ICollection<AutoVerificationPolicy> AutoVerificationPolicies { get; set; }
        //public ICollection<BankAccount> BankAccounts { get; set; }
        //public ICollection<CashRepository> CashRepositories { get; set; }
        //public ICollection<Checkout> Checkouts { get; set; }
        //public ICollection<ConfigurationProfile> ConfigurationProfiles { get; set; }
        //public ICollection<Contract> Contracts { get; set; }
        //public ICollection<DayOperation> DayOperations { get; set; }
        //public ICollection<Employee> Employees { get; set; }
        //public ICollection<EntityAccessPolicy> EntityAccessPolicies { get; set; }
        //public ICollection<ExchangeRate> ExchangeRates { get; set; }
        //public ICollection<FiscalYear> FiscalYears { get; set; }
        //public ICollection<FrequencySetup> FrequencySetups { get; set; }
        //public ICollection<GroupEntityAccessPolicy> GroupEntityAccessPolicies { get; set; }
        //public ICollection<GroupMenuAccessPolicy> GroupMenuAccessPolicies { get; set; }
        //public ICollection<InventoryTransferDelivery> InventoryTransferDeliveries { get; set; }
        //public ICollection<InventoryTransferRequest> InventoryTransferRequests { get; set; }        
        //public ICollection<JournalVerificationPolicy> JournalVerificationPolicies { get; set; }
        //public ICollection<Login> Logins { get; set; }
        //public ICollection<MenuAccessPolicy> MenuAccessPolicies { get; set; }
        //public ICollection<Notification> Notifications { get; set; }
        //public ICollection<OfficeHour> OfficeHours { get; set; }
        //public ICollection<Order1> Order1 { get; set; }
        //public ICollection<Order> Orders { get; set; }
        //public ICollection<Quotation1> Quotation1 { get; set; }
        //public ICollection<Quotation> Quotations { get; set; }
        //public ICollection<Store> Stores { get; set; }
        //public ICollection<TransactionDetail> TransactionDetails { get; set; }
        //public ICollection<TransactionMaster> TransactionMasters { get; set; }
        //public ICollection<User> Users { get; set; }

        #endregion
    }
}
