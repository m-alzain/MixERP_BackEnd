using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApplicationCore.Entities.Accounts;
//using ApplicationCore.Entities.Finance;
using Infrastructure.Data.Configurations.Accounts;
using ApplicationCore.Entities.Core;
//using Infrastructure.Data.Configurations.Core;
//using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Auth;
//using ApplicationCore.Entities.AddessBook;
//using ApplicationCore.Entities.Config;
//using ApplicationCore.Entities.Hrm;
//using ApplicationCore.Entities.Inventory;
//using ApplicationCore.Entities.Sales;
//using ApplicationCore.Entities.Purchases;
//using ApplicationCore.Entities.Website;
//using ApplicationCore.Entities.Social;
//using Attribute = ApplicationCore.Entities.Inventory.Attribute;
//using Infrastructure.Data.Configurations.Inventory;
//using Infrastructure.Data.Configurations.Hrm;
//using ApplicationCore.Queries;
//using ApplicationCore.Queries.Forms;
using Infrastructure.Data.Configurations.Auth;
using Infrastructure.Data.Configurations.Core;
//using Infrastructure.Data.Configurations.Finance;
//using Infrastructure.Data.Configurations.Sales;
//using Infrastructure.Data.Configurations.Website;
//using Infrastructure.Data.Configurations.Calendar;
//using Infrastructure.Data.Configurations.AddressBook;
//using Infrastructure.Data.Configurations.Config;
//using Infrastructure.Data.Configurations.Social;
//using Infrastructure.Data.Configurations.Purchases;

namespace Infrastructure.Data
{
    public partial class SqlserverContext : DbContext
    {
        public SqlserverContext()
        {
        }

        public SqlserverContext(DbContextOptions<SqlserverContext> options)
            : base(options)
        {
        }

        ////Accounts
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<OfficeUser> TenantOfficeUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleUser> RoleUsers { get; set; }
        //public virtual DbSet<AccessToken> AccessTokens { get; set; }
        //public virtual DbSet<Application> Applications { get; set; }
        //public virtual DbSet<ConfigurationProfile> ConfigurationProfiles { get; set; }
        //public virtual DbSet<FbAccessToken> FbAccessTokens { get; set; }
        //public virtual DbSet<GoogleAccessToken> GoogleAccessTokens { get; set; }
        //public virtual DbSet<InstalledDomain> InstalledDomains { get; set; }
        //public virtual DbSet<Login> Logins { get; set; }
        //public virtual DbSet<Registration> Registrations { get; set; }
        //public virtual DbSet<ResetRequest> ResetRequests { get; set; }        


        ////Auth
        public virtual DbSet<GroupEntityAccessPolicy> GroupEntityAccessPolicies { get; set; }
        //public virtual DbSet<AccessType> AccessTypes { get; set; }
        //public virtual DbSet<EntityAccessPolicy> EntityAccessPolicies { get; set; }
        //public virtual DbSet<GroupMenuAccessPolicy> GroupMenuAccessPolicies { get; set; }
        //public virtual DbSet<MenuAccessPolicy> MenuAccessPolicies { get; set; }

        //Finanace
        //public virtual DbSet<Account> Accounts { get; set; }
        //public virtual DbSet<AccountMaster> AccountMasters { get; set; }
        //public virtual DbSet<AutoVerificationPolicy> AutoVerificationPolicies { get; set; }
        //public virtual DbSet<BankAccount> BankAccounts { get; set; }
        //public virtual DbSet<BankType> BankTypes { get; set; }
        //public virtual DbSet<CardType> CardTypes { get; set; }
        //public virtual DbSet<CashFlowHeading> CashFlowHeadings { get; set; }
        //public virtual DbSet<CashFlowSetup> CashFlowSetups { get; set; }
        //public virtual DbSet<CashRepository> CashRepositories { get; set; }
        //public virtual DbSet<CostCenter> CostCenters { get; set; }
        //public virtual DbSet<DayOperation> DayOperations { get; set; }
        //public virtual DbSet<DayOperationRoutine> DayOperationRoutines { get; set; }
        //public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }
        //public virtual DbSet<ExchangeRateDetail> ExchangeRateDetails { get; set; }
        //public virtual DbSet<FiscalYear> FiscalYears { get; set; }
        //public virtual DbSet<Frequency> Frequencies { get; set; }
        //public virtual DbSet<FrequencySetup> FrequencySetups { get; set; }
        //public virtual DbSet<JournalVerificationPolicy> JournalVerificationPolicies { get; set; }
        //public virtual DbSet<MerchantFeeSetup> MerchantFeeSetups { get; set; }
        //public virtual DbSet<PaymentCard> PaymentCards { get; set; }
        //public virtual DbSet<Routine> Routines { get; set; }
        //public virtual DbSet<TaxSetup> TaxSetups { get; set; }
        //public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        //public virtual DbSet<TransactionDocument> TransactionDocuments { get; set; }
        //public virtual DbSet<TransactionMaster> TransactionMasters { get; set; }
        //public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        ////Core
        public virtual DbSet<EntityType> EntityTypes { get; set; }
        //public virtual DbSet<App> Apps { get; set; }
        //public virtual DbSet<AppDependency> AppDependencies { get; set; }
        //public virtual DbSet<Country> Countries { get; set; }
        //public virtual DbSet<Currency> Currencies { get; set; }
        //public virtual DbSet<Gender> Genders { get; set; }
        //public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        //public virtual DbSet<Menu> Menus { get; set; }
        //public virtual DbSet<Notification> Notifications { get; set; }
        //public virtual DbSet<NotificationStatus> NotificationStatuses { get; set; }
        //public virtual DbSet<VerificationStatus> VerificationStatuses { get; set; }
        //public virtual DbSet<WeekDay> WeekDays { get; set; }

        ////Hrm
        //public virtual DbSet<Attendance> Attendances { get; set; }
        //public virtual DbSet<Contract> Contracts { get; set; }
        //public virtual DbSet<Department> Departments { get; set; }
        //public virtual DbSet<EducationLevel> EducationLevels { get; set; }
        //public virtual DbSet<Employee> Employees { get; set; }
        //public virtual DbSet<EmployeeExperience> EmployeeExperiences { get; set; }
        //public virtual DbSet<EmployeeIdentificationDetail> EmployeeIdentificationDetails { get; set; }
        //public virtual DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        //public virtual DbSet<EmployeeSocialNetworkDetail> EmployeeSocialNetworkDetails { get; set; }
        //public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        //public virtual DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        //public virtual DbSet<EmploymentStatusCode> EmploymentStatusCodes { get; set; }
        //public virtual DbSet<Exit> Exits { get; set; }
        //public virtual DbSet<ExitType> ExitTypes { get; set; }
        //public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }
        //public virtual DbSet<JobTitle> JobTitles { get; set; }
        //public virtual DbSet<LeaveApplication> LeaveApplications { get; set; }
        //public virtual DbSet<LeaveBenefit> LeaveBenefits { get; set; }
        //public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        //public virtual DbSet<Nationality> Nationalities { get; set; }
        //public virtual DbSet<OfficeHour> OfficeHours { get; set; }
        //public virtual DbSet<PayGrade> PayGrades { get; set; }
        //public virtual DbSet<Resignation> Resignations { get; set; }
        //public virtual DbSet<Role1> Roles1 { get; set; }
        //public virtual DbSet<Shift> Shifts { get; set; }
        //public virtual DbSet<SocialNetwork> SocialNetworks { get; set; }
        //public virtual DbSet<Termination> Terminations { get; set; }
        //public virtual DbSet<WeekDay1> WeekDays1 { get; set; }

        ////Inventory
        //public virtual DbSet<Attribute> Attributes { get; set; }  
        //public virtual DbSet<Brand> Brands { get; set; }
        //public virtual DbSet<Checkout> Checkouts { get; set; }
        //public virtual DbSet<CheckoutDetail> CheckoutDetails { get; set; }
        //public virtual DbSet<CompoundUnit> CompoundUnits { get; set; }
        //public virtual DbSet<Counter> Counters { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        //public virtual DbSet<InventorySetup> InventorySetups { get; set; }
        //public virtual DbSet<InventoryTransferDelivery> InventoryTransferDeliveries { get; set; }
        //public virtual DbSet<InventoryTransferDeliveryDetail> InventoryTransferDeliveryDetails { get; set; }
        //public virtual DbSet<InventoryTransferRequest> InventoryTransferRequests { get; set; }
        //public virtual DbSet<InventoryTransferRequestDetail> InventoryTransferRequestDetails { get; set; }
        //public virtual DbSet<Item> Items { get; set; }
        //public virtual DbSet<ItemGroup> ItemGroups { get; set; }
        //public virtual DbSet<ItemType> ItemTypes { get; set; }
        //public virtual DbSet<ItemVariant> ItemVariants { get; set; }
        //public virtual DbSet<SerialNumber> SerialNumbers { get; set; }
        //public virtual DbSet<Shipper> Shippers { get; set; }
        //public virtual DbSet<Store> Stores { get; set; }
        //public virtual DbSet<StoreType> StoreTypes { get; set; }
        //public virtual DbSet<Supplier> Suppliers { get; set; }
        //public virtual DbSet<SupplierType> SupplierTypes { get; set; }
        //public virtual DbSet<Unit> Units { get; set; }
        //public virtual DbSet<Variant> Variants { get; set; }

        ////Sales
        //public virtual DbSet<Cashier> Cashiers { get; set; }
        //public virtual DbSet<CashierLoginInfo> CashierLoginInfoes { get; set; }
        //public virtual DbSet<ClosingCash> ClosingCashes { get; set; }
        //public virtual DbSet<Coupon> Coupons { get; set; }
        //public virtual DbSet<CustomerReceipt> CustomerReceipts { get; set; }
        //public virtual DbSet<CustomerwiseSellingPrice> CustomerwiseSellingPrices { get; set; }
        //public virtual DbSet<GiftCard> GiftCards { get; set; }
        //public virtual DbSet<GiftCardTransaction> GiftCardTransactions { get; set; }
        //public virtual DbSet<ItemSellingPrice> ItemSellingPrices { get; set; }
        //public virtual DbSet<LateFee> LateFees { get; set; }
        //public virtual DbSet<LateFeePosting> LateFeePostings { get; set; }
        //public virtual DbSet<OpeningCash> OpeningCashes { get; set; }
        //public virtual DbSet<Order1> Orders1 { get; set; }
        //public virtual DbSet<OrderDetail1> OrderDetails1 { get; set; }
        //public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }
        //public virtual DbSet<PriceType1> PriceTypes1 { get; set; }
        //public virtual DbSet<Quotation1> Quotations1 { get; set; }
        //public virtual DbSet<QuotationDetail1> QuotationDetails1 { get; set; }
        //public virtual DbSet<Return> Returns { get; set; }
        //public virtual DbSet<Sale> Sales { get; set; }

        ////Website
        //public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<Configuration> Configurations { get; set; }
        //public virtual DbSet<Contact> Contacts { get; set; }
        //public virtual DbSet<Content> Contents { get; set; }
        //public virtual DbSet<EmailSubscription> EmailSubscriptions { get; set; }
        //public virtual DbSet<Menu1> Menus1 { get; set; }
        //public virtual DbSet<MenuItem> MenuItems { get; set; }


        ////Calendar
        //public virtual DbSet<Category1> Categories1 { get; set; }
        //public virtual DbSet<Event> Events { get; set; }

        ////AddressBook
        //public virtual DbSet<Contact1> Contacts1 { get; set; }

        ////Config
        //public virtual DbSet<CustomField> CustomFields { get; set; }
        //public virtual DbSet<CustomFieldDataType> CustomFieldDataTypes { get; set; }
        //public virtual DbSet<CustomFieldForm> CustomFieldForms { get; set; }
        //public virtual DbSet<CustomFieldSetup> CustomFieldSetups { get; set; }      
        //public virtual DbSet<EmailQueue> EmailQueues { get; set; }
        //public virtual DbSet<Filter> Filters { get; set; }
        //public virtual DbSet<Kanban> Kanbans { get; set; }
        //public virtual DbSet<KanbanDetail> KanbanDetails { get; set; }
        //public virtual DbSet<SmsQueue> SmsQueues { get; set; }
        //public virtual DbSet<SmtpConfig> SmtpConfigs { get; set; }

        ////Social
        //public virtual DbSet<Feed> Feeds { get; set; }

        ////Purchases
        //public virtual DbSet<ItemCostPrice> ItemCostPrices { get; set; }   
        //public virtual DbSet<Order> Orders { get; set; }
        //public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        //public virtual DbSet<PriceType> PriceTypes { get; set; }
        //public virtual DbSet<Purchase> Purchases { get; set; }
        //public virtual DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        //public virtual DbSet<Quotation> Quotations { get; set; }
        //public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }             
        //public virtual DbSet<SupplierPayment> SupplierPayments { get; set; }
        //public virtual DbSet<SupplierwiseCostPrice> SupplierwiseCostPrices { get; set; }



        // Queries
        //public virtual DbQuery<PrimitiveQuery<decimal>> DecimalQuery { get; set; }
        //public virtual DbQuery<EntityColumnQuery> EntityColumnQuery { get; set; }
        //public virtual DbQuery<ApplicationCore.Queries.Finance.JournalViewQuery> JournalViewQuery { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Accounts
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new TenantConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeUserConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleUserConfiguration());
            //modelBuilder.ApplyConfiguration(new AccessTokenConfiguration());
            //modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            //modelBuilder.ApplyConfiguration(new ConfigurationProfileConfiguration());
            //modelBuilder.ApplyConfiguration(new FbAccessTokenConfiguration());
            //modelBuilder.ApplyConfiguration(new GoogleAccessTokenConfiguration());
            //modelBuilder.ApplyConfiguration(new InstalledDomainConfiguration());
            //modelBuilder.ApplyConfiguration(new LoginConfiguration());
            //modelBuilder.ApplyConfiguration(new RegistrationConfiguration());
            //modelBuilder.ApplyConfiguration(new ResetRequestConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());


            //// Auth
            modelBuilder.ApplyConfiguration(new GroupEntityAccessPolicyConfiguration());
            //modelBuilder.ApplyConfiguration(new AccessTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new EntityAccessPolicyConfiguration());
            //modelBuilder.ApplyConfiguration(new GroupMenuAccessPolicyConfiguration());
            //modelBuilder.ApplyConfiguration(new MenuAccessPolicyConfiguration());

            //// Finance
            //modelBuilder.ApplyConfiguration(new AccountCofiguration());
            //modelBuilder.ApplyConfiguration(new AccountMasterConfiguration());
            //modelBuilder.ApplyConfiguration(new AutoVerificationPolicyConfiguration());
            //modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            //modelBuilder.ApplyConfiguration(new BankTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new CardTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new CashFlowHeadingConfiguration());
            //modelBuilder.ApplyConfiguration(new CashFlowSetupConfiguration());
            //modelBuilder.ApplyConfiguration(new CashRepositoryConfiguration());
            //modelBuilder.ApplyConfiguration(new CostCenterConfiguration());
            //modelBuilder.ApplyConfiguration(new DayOperationConfiguration());
            //modelBuilder.ApplyConfiguration(new DayOperationRoutineConfiguration());
            //modelBuilder.ApplyConfiguration(new ExchangeRateConfiguration());
            //modelBuilder.ApplyConfiguration(new ExchangeRateDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new FiscalYearConfiguration());
            //modelBuilder.ApplyConfiguration(new FrequencyConfiguration());
            //modelBuilder.ApplyConfiguration(new FrequencySetupConfiguration());
            //modelBuilder.ApplyConfiguration(new JournalVerificationPolicyConfiguration());
            //modelBuilder.ApplyConfiguration(new MerchantFeeSetupConfiguration());
            //modelBuilder.ApplyConfiguration(new PaymentCardConfiguration());
            //modelBuilder.ApplyConfiguration(new RoutineConfiguration());
            //modelBuilder.ApplyConfiguration(new TaxSetupConfiguration());
            //modelBuilder.ApplyConfiguration(new TransactionDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new TransactionDocumentConfiguration());
            //modelBuilder.ApplyConfiguration(new TransactionMasterConfiguration());
            //modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());

            //// Core
            modelBuilder.ApplyConfiguration(new EntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new AppConfiguration());
            //modelBuilder.ApplyConfiguration(new AppDependencyConfiguration());
            //modelBuilder.ApplyConfiguration(new CountryConfiguration());
            //modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            //modelBuilder.ApplyConfiguration(new GenderConfiguration());
            //modelBuilder.ApplyConfiguration(new MaritalStatusConfiguration());
            //modelBuilder.ApplyConfiguration(new MenuConfiguration());
            //modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            //modelBuilder.ApplyConfiguration(new NotificationStatusConfiguration());
            //modelBuilder.ApplyConfiguration(new VerificationStatusConfiguration());
            //modelBuilder.ApplyConfiguration(new WeekDayConfiguration());

            ////Hrm
            //modelBuilder.ApplyConfiguration(new AttendanceConfiguration());
            //modelBuilder.ApplyConfiguration(new ContractConfiguration());
            //modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            //modelBuilder.ApplyConfiguration(new EducationLevelConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeExperienceConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeIdentificationDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeQualificationConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeSocialNetworkDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new EmploymentStatusConfiguration());
            //modelBuilder.ApplyConfiguration(new EmploymentStatusCodeConfiguration());
            //modelBuilder.ApplyConfiguration(new ExitConfiguration());
            //modelBuilder.ApplyConfiguration(new ExitTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new IdentificationTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new JobTitleConfiguration());
            //modelBuilder.ApplyConfiguration(new LeaveApplicationConfiguration());
            //modelBuilder.ApplyConfiguration(new LeaveBenefitConfiguration());
            //modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new NationalityConfiguration());
            //modelBuilder.ApplyConfiguration(new OfficeHourConfiguration());
            //modelBuilder.ApplyConfiguration(new PayGradeConfiguration());
            //modelBuilder.ApplyConfiguration(new ResignationConfiguration());
            //modelBuilder.ApplyConfiguration(new Role1Configuration());
            //modelBuilder.ApplyConfiguration(new ShiftConfiguration());
            //modelBuilder.ApplyConfiguration(new SocialNetworkConfiguration());
            //modelBuilder.ApplyConfiguration(new TerminationConfiguration());
            //modelBuilder.ApplyConfiguration(new WeekDay1Configuration());

            ////Inventory
            //modelBuilder.ApplyConfiguration(new AttributeConfiguration());
            //modelBuilder.ApplyConfiguration(new BrandConfiguration());
            //modelBuilder.ApplyConfiguration(new CheckoutConfiguration());
            //modelBuilder.ApplyConfiguration(new CheckoutDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new CompoundUnitConfiguration());
            //modelBuilder.ApplyConfiguration(new CounterConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomerCofiguration());
            //modelBuilder.ApplyConfiguration(new CustomerTypeCofiguration());
            //modelBuilder.ApplyConfiguration(new InventorySetupCofiguration());
            //modelBuilder.ApplyConfiguration(new InventoryTransferDeliveryCofiguration());
            //modelBuilder.ApplyConfiguration(new InventoryTransferDeliveryDetailCofiguration());
            //modelBuilder.ApplyConfiguration(new InventoryTransferRequestCofiguration());
            //modelBuilder.ApplyConfiguration(new InventoryTransferRequestDetailCofiguration());
            //modelBuilder.ApplyConfiguration(new ItemConfiguration());
            //modelBuilder.ApplyConfiguration(new ItemGroupConfiguration());
            //modelBuilder.ApplyConfiguration(new ItemTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ItemVariantConfiguration());
            //modelBuilder.ApplyConfiguration(new SerialNumberConfiguration());
            //modelBuilder.ApplyConfiguration(new ShipperConfiguration());
            //modelBuilder.ApplyConfiguration(new StoreConfiguration());
            //modelBuilder.ApplyConfiguration(new StoreTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new SupplierCofiguration());
            //modelBuilder.ApplyConfiguration(new SupplierTypeCofiguration());
            //modelBuilder.ApplyConfiguration(new UnitCofiguration());
            //modelBuilder.ApplyConfiguration(new VariantCofiguration());

            ////Sales
            //modelBuilder.ApplyConfiguration(new CashierConfiguration());
            //modelBuilder.ApplyConfiguration(new CashierLoginInfoConfiguration());
            //modelBuilder.ApplyConfiguration(new ClosingCashConfiguration());
            //modelBuilder.ApplyConfiguration(new CouponConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomerReceiptConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomerwiseSellingPriceConfiguration());
            //modelBuilder.ApplyConfiguration(new GiftCardConfiguration());
            //modelBuilder.ApplyConfiguration(new GiftCardTransactionConfiguration());
            //modelBuilder.ApplyConfiguration(new ItemSellingPriceConfiguration());
            //modelBuilder.ApplyConfiguration(new LateFeeConfiguration());
            //modelBuilder.ApplyConfiguration(new LateFeePostingConfiguration());
            //modelBuilder.ApplyConfiguration(new OpeningCashConfiguration());
            //modelBuilder.ApplyConfiguration(new Order1Configuration());
            //modelBuilder.ApplyConfiguration(new OrderDetail1Configuration());
            //modelBuilder.ApplyConfiguration(new PaymentTermConfiguration());
            //modelBuilder.ApplyConfiguration(new PriceType1Configuration());
            //modelBuilder.ApplyConfiguration(new Quotation1Configuration());
            //modelBuilder.ApplyConfiguration(new QuotationDetail1Configuration());
            //modelBuilder.ApplyConfiguration(new ReturnConfiguration());
            //modelBuilder.ApplyConfiguration(new SaleConfiguration());

            ////Website
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new ConfigurationConfiguration());
            //modelBuilder.ApplyConfiguration(new ContactConfiguration());
            //modelBuilder.ApplyConfiguration(new ContentConfiguration());
            //modelBuilder.ApplyConfiguration(new EmailSubscriptionConfiguration());
            //modelBuilder.ApplyConfiguration(new Menu1Configuration());
            //modelBuilder.ApplyConfiguration(new MenuItemConfiguration());

            ////Calendar
            //modelBuilder.ApplyConfiguration(new Category1Configuration());
            //modelBuilder.ApplyConfiguration(new EventConfiguration());

            ////AddressBook
            //modelBuilder.ApplyConfiguration(new Contact1Configuration());

            ////Config
            //modelBuilder.ApplyConfiguration(new CustomFieldConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomFieldDataTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomFieldFormConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomFieldSetupConfiguration());
            //modelBuilder.ApplyConfiguration(new EmailQueueConfiguration());
            //modelBuilder.ApplyConfiguration(new FilterConfiguration());
            //modelBuilder.ApplyConfiguration(new KanbanConfiguration());
            //modelBuilder.ApplyConfiguration(new KanbanDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new SmsQueueConfiguration());
            //modelBuilder.ApplyConfiguration(new SmtpConfigConfiguration());

            ////Social
            //modelBuilder.ApplyConfiguration(new FeedConfiguration());

            ////Purchases
            //modelBuilder.ApplyConfiguration(new ItemCostPriceConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new PriceTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            //modelBuilder.ApplyConfiguration(new PurchaseReturnConfiguration());
            //modelBuilder.ApplyConfiguration(new QuotationConfiguration());
            //modelBuilder.ApplyConfiguration(new QuotationDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new SupplierPaymentConfiguration());
            //modelBuilder.ApplyConfiguration(new SupplierwiseCostPriceConfiguration());


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
