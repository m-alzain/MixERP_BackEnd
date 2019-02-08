using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.Finance;
//using System.Text;
//using ApplicationCore.Entities.AddessBook;
//using ApplicationCore.Entities.Auth;
//using ApplicationCore.Entities.Calendar;
//using ApplicationCore.Entities.Config;
//using ApplicationCore.Entities.Hrm;
//using ApplicationCore.Entities.Inventory;
//using ApplicationCore.Entities.Purchases;
//using ApplicationCore.Entities.Sales;
//using ApplicationCore.Entities.Social;
//using ApplicationCore.Entities.Website;
//using Attribute = ApplicationCore.Entities.Inventory.Attribute;

namespace ApplicationCore.Entities.Accounts
{
    public class User : IEntity, IAuditable
    {
        #region IEntity

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        #endregion

        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool? Status { get; set; }
        public DateTimeOffset? LastSeenOn { get; set; }
        public string LastIp { get; set; }
        public string LastBrowser { get; set; }     
        public bool? Deleted { get; set; }

        
        public ICollection<OfficeUser> OfficeUsers { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; }

      
        public ICollection<User> InverseCreatedUsers { get; set; }
        public ICollection<User> InverseUpdatedUsers { get; set; }
        public ICollection<Office> CreatedOffices { get; set; }
        public ICollection<Office> UpdatedOffices { get; set; }
        public ICollection<Tenant> CreatedTenants { get; set; }
        public ICollection<Tenant> UpdatedTenants { get; set; }
        public ICollection<Role> CreatedRoles { get; set; }
        public ICollection<Role> UpdatedRoles { get; set; }
        public ICollection<GroupEntityAccessPolicy> CreatedGroupEntityAccessPolicies { get; set; }
        public ICollection<GroupEntityAccessPolicy> UpdatedGroupEntityAccessPolicies { get; set; }

        #region IAuditable

        public Guid? CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }

        #endregion

        #region Commented (From the old system)

        //public FbAccessToken FbAccessTokenUser { get; set; }
        //public GoogleAccessToken GoogleAccessTokenUser { get; set; }
        //public ICollection<AccessToken> AccessTokenAuditUsers { get; set; }
        //public ICollection<AccessToken> AccessTokenRevokedByNavigations { get; set; }
        //public ICollection<AccessType> AccessTypes { get; set; }
        //public ICollection<AccountMaster> AccountMasters { get; set; }

        //public ICollection<Account> Accounts { get; set; }
        ////public ICollection<Application> Applications { get; set; }
        ////public ICollection<Attendance> Attendances { get; set; }
        ////public ICollection<Attribute> Attributes { get; set; }
        //public ICollection<AutoVerificationPolicy> AutoVerificationPolicyAuditUsers { get; set; }
        //public ICollection<AutoVerificationPolicy> AutoVerificationPolicyUsers { get; set; }
        //public ICollection<BankAccount> BankAccountAuditUsers { get; set; }
        //public ICollection<BankAccount> BankAccountMaintainedByUsers { get; set; }
        //public ICollection<BankType> BankTypes { get; set; }
        //public ICollection<Brand> Brands { get; set; }
        //public ICollection<CardType> CardTypes { get; set; }
        //public ICollection<CashFlowHeading> CashFlowHeadings { get; set; }
        //public ICollection<CashFlowSetup> CashFlowSetups { get; set; }
        //public ICollection<CashRepository> CashRepositories { get; set; }
        //public ICollection<Cashier> CashierAssociatedUsers { get; set; }
        //public ICollection<Cashier> CashierAuditUsers { get; set; }
        //public ICollection<CashierLoginInfo> CashierLoginInfoAttemptedByNavigations { get; set; }
        //public ICollection<CashierLoginInfo> CashierLoginInfoAuditUsers { get; set; }
        //public ICollection<Category> Categories { get; set; }
        //public ICollection<Category1> Category1AuditUser { get; set; }
        //public ICollection<Category1> Category1User { get; set; }
        //public ICollection<Checkout> CheckoutAuditUsers { get; set; }
        //public ICollection<Checkout> CheckoutPostedByNavigations { get; set; }
        //public ICollection<ClosingCash> ClosingCashApprovedByNavigations { get; set; }
        //public ICollection<ClosingCash> ClosingCashAuditUsers { get; set; }
        //public ICollection<ClosingCash> ClosingCashUsers { get; set; }
        //public ICollection<CompoundUnit> CompoundUnits { get; set; }
        //public ICollection<ConfigurationProfile> ConfigurationProfiles { get; set; }
        //public ICollection<Configuration> Configurations { get; set; }
        //public ICollection<Contact1> Contact1AssociatedUser { get; set; }
        //public ICollection<Contact1> Contact1AuditUser { get; set; }
        //public ICollection<Contact1> Contact1CreatedByNavigation { get; set; }
        //public ICollection<Contact> Contacts { get; set; }
        //public ICollection<Content> ContentAuditUsers { get; set; }
        //public ICollection<Content> ContentAuthors { get; set; }
        //public ICollection<Content> ContentLastEditors { get; set; }
        //public ICollection<Contract> ContractAuditUsers { get; set; }
        //public ICollection<Contract> ContractVerifiedByUsers { get; set; }
        //public ICollection<CostCenter> CostCenters { get; set; }
        //public ICollection<Counter> Counters { get; set; }
        //public ICollection<Coupon> Coupons { get; set; }
        //public ICollection<CustomFieldDataType> CustomFieldDataTypes { get; set; }
        //public ICollection<CustomFieldForm> CustomFieldForms { get; set; }
        //public ICollection<CustomFieldSetup> CustomFieldSetups { get; set; }
        //public ICollection<CustomField> CustomFields { get; set; }
        //public ICollection<CustomerType> CustomerTypes { get; set; }
        //public ICollection<Customer> Customers { get; set; }
        //public ICollection<CustomerwiseSellingPrice> CustomerwiseSellingPrices { get; set; }
        //public ICollection<DayOperation> DayOperationCompletedByNavigations { get; set; }
        //public ICollection<DayOperation> DayOperationStartedByNavigations { get; set; }
        //public ICollection<Department> Departments { get; set; }
        //public ICollection<EducationLevel> EducationLevels { get; set; }
        //public ICollection<EmailQueue> EmailQueues { get; set; }
        //public ICollection<EmailSubscription> EmailSubscriptions { get; set; }
        //public ICollection<Employee> EmployeeAuditUsers { get; set; }
        //public ICollection<EmployeeExperience> EmployeeExperiences { get; set; }
        //public ICollection<EmployeeIdentificationDetail> EmployeeIdentificationDetails { get; set; }
        //public ICollection<EmployeeQualification> EmployeeQualifications { get; set; }
        //public ICollection<EmployeeSocialNetworkDetail> EmployeeSocialNetworkDetails { get; set; }
        //public ICollection<EmployeeType> EmployeeTypes { get; set; }
        //public ICollection<Employee> EmployeeUsers { get; set; }
        //public ICollection<EmploymentStatusCode> EmploymentStatusCodes { get; set; }
        //public ICollection<EmploymentStatus> EmploymentStatuses { get; set; }
        //public ICollection<EntityAccessPolicy> EntityAccessPolicyAuditUsers { get; set; }
        //public ICollection<EntityAccessPolicy> EntityAccessPolicyUsers { get; set; }
        //public ICollection<Event> EventAuditUsers { get; set; }
        //public ICollection<Event> EventUsers { get; set; }
        //public ICollection<Exit> ExitAuditUsers { get; set; }
        //public ICollection<ExitType> ExitTypes { get; set; }
        //public ICollection<Exit> ExitVerifiedByUsers { get; set; }
        //public ICollection<FbAccessToken> FbAccessTokenAuditUsers { get; set; }
        //public ICollection<Feed> FeedCreatedByNavigations { get; set; }
        //public ICollection<Feed> FeedDeletedByNavigations { get; set; }
        //public ICollection<Filter> Filters { get; set; }
        //public ICollection<FiscalYear> FiscalYears { get; set; }
        //public ICollection<Frequency> Frequencies { get; set; }
        //public ICollection<FrequencySetup> FrequencySetups { get; set; }
        //public ICollection<GiftCard> GiftCards { get; set; }
        //public ICollection<GoogleAccessToken> GoogleAccessTokenAuditUsers { get; set; }
        //public ICollection<GroupEntityAccessPolicy> GroupEntityAccessPolicies { get; set; }
        //public ICollection<GroupMenuAccessPolicy> GroupMenuAccessPolicies { get; set; }
        //public ICollection<IdentificationType> IdentificationTypes { get; set; }
        //public ICollection<InventoryTransferDelivery> InventoryTransferDeliveryAuditUsers { get; set; }
        //public ICollection<InventoryTransferDelivery> InventoryTransferDeliveryUsers { get; set; }
        //public ICollection<InventoryTransferRequest> InventoryTransferRequestAuditUsers { get; set; }
        //public ICollection<InventoryTransferRequest> InventoryTransferRequestAuthorizedByUsers { get; set; }
        //public ICollection<InventoryTransferRequest> InventoryTransferRequestDeliveredByUsers { get; set; }
        //public ICollection<InventoryTransferRequest> InventoryTransferRequestReceivedByUsers { get; set; }
        //public ICollection<InventoryTransferRequest> InventoryTransferRequestRejectedByUsers { get; set; }
        //public ICollection<InventoryTransferRequest> InventoryTransferRequestUsers { get; set; }
        //public ICollection<ItemCostPrice> ItemCostPrices { get; set; }
        //public ICollection<ItemGroup> ItemGroups { get; set; }
        //public ICollection<ItemSellingPrice> ItemSellingPrices { get; set; }
        //public ICollection<ItemType> ItemTypes { get; set; }
        //public ICollection<ItemVariant> ItemVariants { get; set; }
        //public ICollection<Item> Items { get; set; }
        //public ICollection<JobTitle> JobTitles { get; set; }
        //public ICollection<JournalVerificationPolicy> JournalVerificationPolicyAuditUsers { get; set; }
        //public ICollection<JournalVerificationPolicy> JournalVerificationPolicyUsers { get; set; }
        //public ICollection<Kanban> KanbanAuditUsers { get; set; }
        //public ICollection<KanbanDetail> KanbanDetails { get; set; }
        //public ICollection<Kanban> KanbanUsers { get; set; }
        //public ICollection<LateFee> LateFees { get; set; }
        //public ICollection<LeaveApplication> LeaveApplicationAuditUsers { get; set; }
        //public ICollection<LeaveApplication> LeaveApplicationEnteredByNavigations { get; set; }
        //public ICollection<LeaveApplication> LeaveApplicationVerifiedByUsers { get; set; }
        //public ICollection<LeaveBenefit> LeaveBenefits { get; set; }
        //public ICollection<LeaveType> LeaveTypes { get; set; }
        //public ICollection<Login> LoginAuditUsers { get; set; }
        //public ICollection<Login> LoginUsers { get; set; }
        //public ICollection<Menu1> Menu1 { get; set; }
        //public ICollection<MenuAccessPolicy> MenuAccessPolicyAuditUsers { get; set; }
        //public ICollection<MenuAccessPolicy> MenuAccessPolicyUsers { get; set; }
        //public ICollection<MenuItem> MenuItems { get; set; }
        //public ICollection<MerchantFeeSetup> MerchantFeeSetups { get; set; }
        //public ICollection<Nationality> Nationalities { get; set; }
        //public ICollection<OfficeHour> OfficeHours { get; set; }

        //public ICollection<OpeningCash> OpeningCashAuditUsers { get; set; }
        //public ICollection<OpeningCash> OpeningCashUsers { get; set; }
        //public ICollection<Order1> Order1AuditUser { get; set; }
        //public ICollection<Order1> Order1User { get; set; }
        //public ICollection<Order> OrderAuditUsers { get; set; }
        //public ICollection<Order> OrderUsers { get; set; }
        //public ICollection<PayGrade> PayGrades { get; set; }
        //public ICollection<PaymentCard> PaymentCards { get; set; }
        //public ICollection<PaymentTerm> PaymentTerms { get; set; }
        //public ICollection<PriceType1> PriceType1 { get; set; }
        //public ICollection<PriceType> PriceTypes { get; set; }
        //public ICollection<Quotation1> Quotation1AuditUser { get; set; }
        //public ICollection<Quotation1> Quotation1User { get; set; }
        //public ICollection<Quotation> QuotationAuditUsers { get; set; }
        //public ICollection<Quotation> QuotationUsers { get; set; }
        //public ICollection<ResetRequest> ResetRequestAuditUsers { get; set; }
        //public ICollection<ResetRequest> ResetRequestUsers { get; set; }
        //public ICollection<Resignation> ResignationAuditUsers { get; set; }
        //public ICollection<Resignation> ResignationEnteredByNavigations { get; set; }
        //public ICollection<Resignation> ResignationVerifiedByUsers { get; set; }
        //public ICollection<Role1> Role1 { get; set; }
        //public ICollection<Role> Roles { get; set; }
        //public ICollection<Sale> Sales { get; set; }
        //public ICollection<Shift> Shifts { get; set; }
        //public ICollection<Shipper> Shippers { get; set; }
        //public ICollection<SmsQueue> SmsQueues { get; set; }
        //public ICollection<SmtpConfig> SmtpConfigs { get; set; }
        //public ICollection<SocialNetwork> SocialNetworks { get; set; }
        //public ICollection<StoreType> StoreTypes { get; set; }
        //public ICollection<Store> Stores { get; set; }
        //public ICollection<SupplierType> SupplierTypes { get; set; }
        //public ICollection<Supplier> Suppliers { get; set; }
        //public ICollection<SupplierwiseCostPrice> SupplierwiseCostPrices { get; set; }
        //public ICollection<TaxSetup> TaxSetups { get; set; }
        //public ICollection<Termination> TerminationAuditUsers { get; set; }
        //public ICollection<Termination> TerminationVerifiedByUsers { get; set; }
        //public ICollection<TransactionDetail> TransactionDetails { get; set; }
        //public ICollection<TransactionDocument> TransactionDocuments { get; set; }
        //public ICollection<TransactionMaster> TransactionMasterAuditUsers { get; set; }
        //public ICollection<TransactionMaster> TransactionMasterUsers { get; set; }
        //public ICollection<TransactionMaster> TransactionMasterVerifiedByUsers { get; set; }
        //public ICollection<TransactionType> TransactionTypes { get; set; }
        //public ICollection<Unit> Units { get; set; }
        //public ICollection<Variant> Variants { get; set; }
        //public ICollection<WeekDay1> WeekDay1 { get; set; }

        #endregion
    }
}
