using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Calendar;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Auth;
using ApplicationCore.Entities.AddessBook;
using ApplicationCore.Entities.Config;
using ApplicationCore.Entities.Hrm;
using ApplicationCore.Entities.Inventory;
using ApplicationCore.Entities.Sales;
using ApplicationCore.Entities.Purchases;
using ApplicationCore.Entities.Website;
using ApplicationCore.Entities.Social;
using Attribute = ApplicationCore.Entities.Inventory.Attribute;
using Infrastructure.Data.Configurations.Inventory;
using Infrastructure.Data.Configurations.Hrm;
using Infrastructure.Data.Configurations.Core;
using ApplicationCore.Queries;
using ApplicationCore.Queries.Forms;

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

        public virtual DbSet<AccessToken> AccessTokens { get; set; }
        public virtual DbSet<AccessType> AccessTypes { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountMaster> AccountMasters { get; set; }
        public virtual DbSet<App> Apps { get; set; }
        public virtual DbSet<AppDependency> AppDependencies { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AutoVerificationPolicy> AutoVerificationPolicies { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<BankType> BankTypes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CardType> CardTypes { get; set; }
        public virtual DbSet<CashFlowHeading> CashFlowHeadings { get; set; }
        public virtual DbSet<CashFlowSetup> CashFlowSetups { get; set; }
        public virtual DbSet<Cashier> Cashiers { get; set; }
        public virtual DbSet<CashierLoginInfo> CashierLoginInfoes { get; set; }
        public virtual DbSet<CashRepository> CashRepositories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Category1> Categories1 { get; set; }
        public virtual DbSet<Checkout> Checkouts { get; set; }
        public virtual DbSet<CheckoutDetail> CheckoutDetails { get; set; }
        public virtual DbSet<ClosingCash> ClosingCashes { get; set; }
        public virtual DbSet<CompoundUnit> CompoundUnits { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<ConfigurationProfile> ConfigurationProfiles { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Contact1> Contacts1 { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<CostCenter> CostCenters { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerReceipt> CustomerReceipts { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<CustomerwiseSellingPrice> CustomerwiseSellingPrices { get; set; }
        public virtual DbSet<CustomField> CustomFields { get; set; }
        public virtual DbSet<CustomFieldDataType> CustomFieldDataTypes { get; set; }
        public virtual DbSet<CustomFieldForm> CustomFieldForms { get; set; }
        public virtual DbSet<CustomFieldSetup> CustomFieldSetups { get; set; }
        public virtual DbSet<DayOperation> DayOperations { get; set; }
        public virtual DbSet<DayOperationRoutine> DayOperationRoutines { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EducationLevel> EducationLevels { get; set; }
        public virtual DbSet<EmailQueue> EmailQueues { get; set; }
        public virtual DbSet<EmailSubscription> EmailSubscriptions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeExperience> EmployeeExperiences { get; set; }
        public virtual DbSet<EmployeeIdentificationDetail> EmployeeIdentificationDetails { get; set; }
        public virtual DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        public virtual DbSet<EmployeeSocialNetworkDetail> EmployeeSocialNetworkDetails { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public virtual DbSet<EmploymentStatusCode> EmploymentStatusCodes { get; set; }
        public virtual DbSet<EntityAccessPolicy> EntityAccessPolicies { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }
        public virtual DbSet<ExchangeRateDetail> ExchangeRateDetails { get; set; }
        public virtual DbSet<Exit> Exits { get; set; }
        public virtual DbSet<ExitType> ExitTypes { get; set; }
        public virtual DbSet<FbAccessToken> FbAccessTokens { get; set; }
        public virtual DbSet<Feed> Feeds { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }
        public virtual DbSet<FiscalYear> FiscalYears { get; set; }
        public virtual DbSet<Frequency> Frequencies { get; set; }
        public virtual DbSet<FrequencySetup> FrequencySetups { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<GiftCard> GiftCards { get; set; }
        public virtual DbSet<GiftCardTransaction> GiftCardTransactions { get; set; }
        public virtual DbSet<GoogleAccessToken> GoogleAccessTokens { get; set; }
        public virtual DbSet<GroupEntityAccessPolicy> GroupEntityAccessPolicies { get; set; }
        public virtual DbSet<GroupMenuAccessPolicy> GroupMenuAccessPolicies { get; set; }
        public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }
        public virtual DbSet<InstalledDomain> InstalledDomains { get; set; }
        public virtual DbSet<InventorySetup> InventorySetups { get; set; }
        public virtual DbSet<InventoryTransferDelivery> InventoryTransferDeliveries { get; set; }
        public virtual DbSet<InventoryTransferDeliveryDetail> InventoryTransferDeliveryDetails { get; set; }
        public virtual DbSet<InventoryTransferRequest> InventoryTransferRequests { get; set; }
        public virtual DbSet<InventoryTransferRequestDetail> InventoryTransferRequestDetails { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCostPrice> ItemCostPrices { get; set; }
        public virtual DbSet<ItemGroup> ItemGroups { get; set; }
        public virtual DbSet<ItemSellingPrice> ItemSellingPrices { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<ItemVariant> ItemVariants { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<JournalVerificationPolicy> JournalVerificationPolicies { get; set; }
        public virtual DbSet<Kanban> Kanbans { get; set; }
        public virtual DbSet<KanbanDetail> KanbanDetails { get; set; }
        public virtual DbSet<LateFee> LateFees { get; set; }
        public virtual DbSet<LateFeePosting> LateFeePostings { get; set; }
        public virtual DbSet<LeaveApplication> LeaveApplications { get; set; }
        public virtual DbSet<LeaveBenefit> LeaveBenefits { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Menu1> Menus1 { get; set; }
        public virtual DbSet<MenuAccessPolicy> MenuAccessPolicies { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MerchantFeeSetup> MerchantFeeSetups { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationStatus> NotificationStatuses { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<OfficeHour> OfficeHours { get; set; }
        public virtual DbSet<OpeningCash> OpeningCashes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order1> Orders1 { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderDetail1> OrderDetails1 { get; set; }
        public virtual DbSet<PayGrade> PayGrades { get; set; }
        public virtual DbSet<PaymentCard> PaymentCards { get; set; }
        public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }
        public virtual DbSet<PriceType> PriceTypes { get; set; }
        public virtual DbSet<PriceType1> PriceTypes1 { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<Quotation1> Quotations1 { get; set; }
        public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }
        public virtual DbSet<QuotationDetail1> QuotationDetails1 { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<ResetRequest> ResetRequests { get; set; }
        public virtual DbSet<Resignation> Resignations { get; set; }
        public virtual DbSet<Return> Returns { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Role1> Roles1 { get; set; }
        public virtual DbSet<Routine> Routines { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SerialNumber> SerialNumbers { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<SmsQueue> SmsQueues { get; set; }
        public virtual DbSet<SmtpConfig> SmtpConfigs { get; set; }
        public virtual DbSet<SocialNetwork> SocialNetworks { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreType> StoreTypes { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierPayment> SupplierPayments { get; set; }
        public virtual DbSet<SupplierType> SupplierTypes { get; set; }
        public virtual DbSet<SupplierwiseCostPrice> SupplierwiseCostPrices { get; set; }
        public virtual DbSet<TaxSetup> TaxSetups { get; set; }
        public virtual DbSet<Termination> Terminations { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        public virtual DbSet<TransactionDocument> TransactionDocuments { get; set; }
        public virtual DbSet<TransactionMaster> TransactionMasters { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
        public virtual DbSet<VerificationStatus> VerificationStatuses { get; set; }
        public virtual DbSet<WeekDay> WeekDays { get; set; }
        public virtual DbSet<WeekDay1> WeekDays1 { get; set; }

        // Queries
        public virtual DbQuery<PrimitiveQuery<decimal>> DecimalQuery { get; set; }
        public virtual DbQuery<EntityColumnQuery> EntityColumnQuery { get; set; }
        public virtual DbQuery<ApplicationCore.Queries.Finance.JournalViewQuery> JournalViewQuery { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessToken>(entity =>
            {
                entity.ToTable("access_tokens", "account");

                entity.Property(e => e.AccessTokenId)
                    .HasColumnName("access_token_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApplicationId).HasColumnName("application_id");

                entity.Property(e => e.Audience)
                    .IsRequired()
                    .HasColumnName("audience")
                    .HasMaxLength(500);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Claims).HasColumnName("claims");

                entity.Property(e => e.ClientToken).HasColumnName("client_token");

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpiresOn).HasColumnName("expires_on");

                entity.Property(e => e.Header)
                    .HasColumnName("header")
                    .HasMaxLength(500);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(100);

                entity.Property(e => e.IssuedBy)
                    .IsRequired()
                    .HasColumnName("issued_by")
                    .HasMaxLength(500);

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.Revoked).HasColumnName("revoked");

                entity.Property(e => e.RevokedBy).HasColumnName("revoked_by");

                entity.Property(e => e.RevokedOn).HasColumnName("revoked_on");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(500);

                entity.Property(e => e.TokenId)
                    .HasColumnName("token_id")
                    .HasMaxLength(500);

                entity.Property(e => e.UserAgent)
                    .HasColumnName("user_agent")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AccessTokens)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__access_to__appli__2DE6D218");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.AccessTokenAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__access_to__audit__31B762FC");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.AccessTokens)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__access_to__login__2EDAF651");

                entity.HasOne(d => d.RevokedByNavigation)
                    .WithMany(p => p.AccessTokenRevokedByNavigations)
                    .HasForeignKey(d => d.RevokedBy)
                    .HasConstraintName("FK__access_to__revok__30C33EC3");
            });

            modelBuilder.Entity<AccessType>(entity =>
            {
                entity.ToTable("access_types", "auth");

                entity.HasIndex(e => e.AccessTypeName)
                    .HasName("access_types_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.AccessTypeId)
                    .HasColumnName("access_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessTypeName)
                    .IsRequired()
                    .HasColumnName("access_type_name")
                    .HasMaxLength(48);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.AccessTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__access_ty__audit__56E8E7AB");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts", "finance");

                entity.HasIndex(e => e.AccountName)
                    .HasName("accounts_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("accounts_account_number_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountMasterId).HasColumnName("account_master_id");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasColumnName("account_name")
                    .HasMaxLength(500);

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnName("account_number")
                    .HasMaxLength(24);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Confidential).HasColumnName("confidential");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currency_code")
                    .HasMaxLength(12);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.ExternalCode)
                    .HasColumnName("external_code")
                    .HasMaxLength(24)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsTransactionNode)
                    .IsRequired()
                    .HasColumnName("is_transaction_node")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ParentAccountId).HasColumnName("parent_account_id");

                entity.Property(e => e.SysType).HasColumnName("sys_type");

                entity.HasOne(d => d.AccountMaster)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__accounts__accoun__61F08603");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__accounts__audit___689D8392");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__accounts__curren__63D8CE75");

                entity.HasOne(d => d.ParentAccount)
                    .WithMany(p => p.InverseParentAccount)
                    .HasForeignKey(d => d.ParentAccountId)
                    .HasConstraintName("FK__accounts__parent__67A95F59");
            });

            modelBuilder.Entity<AccountMaster>(entity =>
            {
                entity.ToTable("account_masters", "finance");

                entity.HasIndex(e => e.AccountMasterCode)
                    .HasName("account_master_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.AccountMasterName)
                    .HasName("account_master_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.ParentAccountMasterId)
                    .HasName("account_master_parent_account_master_id_inx")
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.AccountMasterId)
                    .HasColumnName("account_master_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountMasterCode)
                    .IsRequired()
                    .HasColumnName("account_master_code")
                    .HasMaxLength(3);

                entity.Property(e => e.AccountMasterName)
                    .IsRequired()
                    .HasColumnName("account_master_name")
                    .HasMaxLength(40);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NormallyDebit).HasColumnName("normally_debit");

                entity.Property(e => e.ParentAccountMasterId).HasColumnName("parent_account_master_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.AccountMasters)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__account_m__audit__4FD1D5C8");

                entity.HasOne(d => d.ParentAccountMaster)
                    .WithMany(p => p.InverseParentAccountMaster)
                    .HasForeignKey(d => d.ParentAccountMasterId)
                    .HasConstraintName("FK__account_m__paren__4EDDB18F");
            });

            modelBuilder.Entity<App>(entity =>
            {
                entity.HasKey(e => e.AppName);

                entity.ToTable("apps", "core");

                entity.HasIndex(e => e.AppName)
                    .HasName("apps_app_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.AppName)
                    .HasColumnName("app_name")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppId)
                    .HasColumnName("app_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.I18nKey)
                    .IsRequired()
                    .HasColumnName("i18n_key")
                    .HasMaxLength(200);

                entity.Property(e => e.Icon).HasColumnName("icon");

                entity.Property(e => e.LandingUrl)
                    .HasColumnName("landing_url")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.PublishedOn)
                    .HasColumnName("published_on")
                    .HasColumnType("date");

                entity.Property(e => e.Publisher)
                    .HasColumnName("publisher")
                    .HasMaxLength(500);

                entity.Property(e => e.VersionNumber)
                    .HasColumnName("version_number")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AppDependency>(entity =>
            {
                entity.ToTable("app_dependencies", "core");

                entity.Property(e => e.AppDependencyId).HasColumnName("app_dependency_id");

                entity.Property(e => e.AppName)
                    .HasColumnName("app_name")
                    .HasMaxLength(100);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DependsOn)
                    .HasColumnName("depends_on")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AppNameNavigation)
                    .WithMany(p => p.AppDependencyAppNameNavigations)
                    .HasForeignKey(d => d.AppName)
                    .HasConstraintName("FK__app_depen__app_n__21B6055D");

                entity.HasOne(d => d.DependsOnNavigation)
                    .WithMany(p => p.AppDependencyDependsOnNavigations)
                    .HasForeignKey(d => d.DependsOn)
                    .HasConstraintName("FK__app_depen__depen__22AA2996");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("applications", "account");

                entity.HasIndex(e => e.AppSecret)
                    .HasName("UQ__applicat__89A4E7765D484DF6")
                    .IsUnique();

                entity.HasIndex(e => e.ApplicationName)
                    .HasName("applications_app_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("application_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AppSecret)
                    .HasColumnName("app_secret")
                    .HasMaxLength(500);

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasColumnName("application_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ApplicationUrl)
                    .HasColumnName("application_url")
                    .HasMaxLength(500);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BrowserBasedApp).HasColumnName("browser_based_app");

                entity.Property(e => e.Culture)
                    .HasColumnName("culture")
                    .HasMaxLength(12);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(100);

                entity.Property(e => e.PrivacyPolicyUrl)
                    .HasColumnName("privacy_policy_url")
                    .HasMaxLength(500);

                entity.Property(e => e.PublishedOn)
                    .HasColumnName("published_on")
                    .HasColumnType("date");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasColumnName("publisher")
                    .HasMaxLength(100);

                entity.Property(e => e.RedirectUrl)
                    .HasColumnName("redirect_url")
                    .HasMaxLength(500);

                entity.Property(e => e.SupportEmail)
                    .HasColumnName("support_email")
                    .HasMaxLength(100);

                entity.Property(e => e.TermsOfServiceUrl)
                    .HasColumnName("terms_of_service_url")
                    .HasMaxLength(500);

                entity.Property(e => e.VersionNumber)
                    .HasColumnName("version_number")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__applicati__audit__282DF8C2");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("attendances", "hrm");

                entity.HasIndex(e => new { e.AttendanceDate, e.EmployeeId })
                    .HasName("attendance_date_employee_id_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");

                entity.Property(e => e.AttendanceDate)
                    .HasColumnName("attendance_date")
                    .HasColumnType("date");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CheckInTime).HasColumnName("check_in_time");

                entity.Property(e => e.CheckOutTime).HasColumnName("check_out_time");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.OvertimeHours)
                    .HasColumnName("overtime_hours")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ReasonForAbsenteeism)
                    .HasColumnName("reason_for_absenteeism")
                    .HasMaxLength(1000);

                entity.Property(e => e.WasAbsent).HasColumnName("was_absent");

                entity.Property(e => e.WasPresent).HasColumnName("was_present");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__attendanc__audit__569ECEE8");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__attendanc__emplo__54B68676");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__attendanc__offic__53C2623D");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("attributes", "inventory");

                entity.HasIndex(e => e.AttributeCode)
                    .HasName("attributes_attribute_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.AttributeName)
                    .HasName("attributes_attribute_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.AttributeId).HasColumnName("attribute_id");

                entity.Property(e => e.AttributeCode)
                    .IsRequired()
                    .HasColumnName("attribute_code")
                    .HasMaxLength(12);

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasColumnName("attribute_name")
                    .HasMaxLength(100);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__attribute__audit__2962141D");
            });

            modelBuilder.Entity<AutoVerificationPolicy>(entity =>
            {
                entity.ToTable("auto_verification_policy", "finance");

                entity.Property(e => e.AutoVerificationPolicyId).HasColumnName("auto_verification_policy_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EffectiveFrom)
                    .HasColumnName("effective_from")
                    .HasColumnType("date");

                entity.Property(e => e.EndsOn)
                    .HasColumnName("ends_on")
                    .HasColumnType("date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VerificationLimit)
                    .HasColumnName("verification_limit")
                    .HasColumnType("numeric(30, 6)");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.AutoVerificationPolicyAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__auto_veri__audit__5A1A5A11");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.AutoVerificationPolicies)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__auto_veri__offic__5832119F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AutoVerificationPolicyUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__auto_veri__user___573DED66");
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("bank_accounts", "finance");

                entity.Property(e => e.BankAccountId).HasColumnName("bank_account_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BankAccountName)
                    .IsRequired()
                    .HasColumnName("bank_account_name")
                    .HasMaxLength(1000);

                entity.Property(e => e.BankAccountNumber)
                    .HasColumnName("bank_account_number")
                    .HasMaxLength(128);

                entity.Property(e => e.BankAccountType)
                    .HasColumnName("bank_account_type")
                    .HasMaxLength(128);

                entity.Property(e => e.BankBranch)
                    .IsRequired()
                    .HasColumnName("bank_branch")
                    .HasMaxLength(128);

                entity.Property(e => e.BankContactNumber)
                    .HasColumnName("bank_contact_number")
                    .HasMaxLength(128);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("bank_name")
                    .HasMaxLength(128);

                entity.Property(e => e.BankTypeId).HasColumnName("bank_type_id");

                entity.Property(e => e.Cell)
                    .HasColumnName("cell")
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(50);

                entity.Property(e => e.IsMerchantAccount).HasColumnName("is_merchant_account");

                entity.Property(e => e.MaintainedByUserId).HasColumnName("maintained_by_user_id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.RelationshipOfficerContactNumber)
                    .HasColumnName("relationship_officer_contact_number")
                    .HasMaxLength(128);

                entity.Property(e => e.RelationshipOfficerName)
                    .HasColumnName("relationship_officer_name")
                    .HasMaxLength(128);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__bank_acco__accou__7ABC33CD");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.BankAccountAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__bank_acco__audit__7F80E8EA");

                entity.HasOne(d => d.BankType)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.BankTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bank_acco__bank___7CA47C3F");

                entity.HasOne(d => d.MaintainedByUser)
                    .WithMany(p => p.BankAccountMaintainedByUsers)
                    .HasForeignKey(d => d.MaintainedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bank_acco__maint__7BB05806");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bank_acco__offic__7E8CC4B1");
            });

            modelBuilder.Entity<BankType>(entity =>
            {
                entity.ToTable("bank_types", "finance");

                entity.Property(e => e.BankTypeId).HasColumnName("bank_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BankTypeName)
                    .HasColumnName("bank_type_name")
                    .HasMaxLength(1000);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.BankTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__bank_type__audit__75F77EB0");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands", "inventory");

                entity.HasIndex(e => e.BrandCode)
                    .HasName("brands_brand_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.BrandName)
                    .HasName("brands_brand_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BrandCode)
                    .IsRequired()
                    .HasColumnName("brand_code")
                    .HasMaxLength(24);

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("brand_name")
                    .HasMaxLength(500);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__brands__audit_us__27AED5D5");
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.ToTable("card_types", "finance");

                entity.HasIndex(e => e.CardTypeCode)
                    .HasName("card_types_card_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.CardTypeName)
                    .HasName("card_types_card_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CardTypeId)
                    .HasColumnName("card_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CardTypeCode)
                    .IsRequired()
                    .HasColumnName("card_type_code")
                    .HasMaxLength(12);

                entity.Property(e => e.CardTypeName)
                    .IsRequired()
                    .HasColumnName("card_type_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CardTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__card_type__audit__2E3BD7D3");
            });

            modelBuilder.Entity<CashFlowHeading>(entity =>
            {
                entity.ToTable("cash_flow_headings", "finance");

                entity.HasIndex(e => e.CashFlowHeadingCode)
                    .HasName("cash_flow_headings_cash_flow_heading_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CashFlowHeadingId)
                    .HasColumnName("cash_flow_heading_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CashFlowHeadingCode)
                    .IsRequired()
                    .HasColumnName("cash_flow_heading_code")
                    .HasMaxLength(12);

                entity.Property(e => e.CashFlowHeadingName)
                    .IsRequired()
                    .HasColumnName("cash_flow_heading_name")
                    .HasMaxLength(100);

                entity.Property(e => e.CashFlowHeadingType)
                    .IsRequired()
                    .HasColumnName("cash_flow_heading_type")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDebit).HasColumnName("is_debit");

                entity.Property(e => e.IsPurchase).HasColumnName("is_purchase");

                entity.Property(e => e.IsSales).HasColumnName("is_sales");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CashFlowHeadings)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__cash_flow__audit__7132C993");
            });

            modelBuilder.Entity<CashFlowSetup>(entity =>
            {
                entity.ToTable("cash_flow_setup", "finance");

                entity.HasIndex(e => e.AccountMasterId)
                    .HasName("cash_flow_setup_account_master_id_inx")
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.CashFlowHeadingId)
                    .HasName("cash_flow_setup_cash_flow_heading_id_inx")
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CashFlowSetupId).HasColumnName("cash_flow_setup_id");

                entity.Property(e => e.AccountMasterId).HasColumnName("account_master_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CashFlowHeadingId).HasColumnName("cash_flow_heading_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AccountMaster)
                    .WithMany(p => p.CashFlowSetups)
                    .HasForeignKey(d => d.AccountMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cash_flow__accou__09FE775D");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CashFlowSetups)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__cash_flow__audit__0AF29B96");

                entity.HasOne(d => d.CashFlowHeading)
                    .WithMany(p => p.CashFlowSetups)
                    .HasForeignKey(d => d.CashFlowHeadingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cash_flow__cash___090A5324");
            });

            modelBuilder.Entity<Cashier>(entity =>
            {
                entity.ToTable("cashiers", "sales");

                entity.HasIndex(e => e.CashierCode)
                    .HasName("cashiers_cashier_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CashierId).HasColumnName("cashier_id");

                entity.Property(e => e.AssociatedUserId).HasColumnName("associated_user_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CashierCode)
                    .IsRequired()
                    .HasColumnName("cashier_code")
                    .HasMaxLength(12);

                entity.Property(e => e.CounterId).HasColumnName("counter_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasColumnName("pin_code")
                    .HasMaxLength(8);

                entity.Property(e => e.ValidFrom)
                    .HasColumnName("valid_from")
                    .HasColumnType("date");

                entity.Property(e => e.ValidTill)
                    .HasColumnName("valid_till")
                    .HasColumnType("date");

                entity.HasOne(d => d.AssociatedUser)
                    .WithMany(p => p.CashierAssociatedUsers)
                    .HasForeignKey(d => d.AssociatedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cashiers__associ__468862B0");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CashierAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__cashiers__audit___4964CF5B");

                entity.HasOne(d => d.Counter)
                    .WithMany(p => p.Cashiers)
                    .HasForeignKey(d => d.CounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cashiers__counte__477C86E9");
            });

            modelBuilder.Entity<CashierLoginInfo>(entity =>
            {
                entity.ToTable("cashier_login_info", "sales");

                entity.Property(e => e.CashierLoginInfoId)
                    .HasColumnName("cashier_login_info_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AttemptedBy).HasColumnName("attempted_by");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(1000);

                entity.Property(e => e.CashierId).HasColumnName("cashier_id");

                entity.Property(e => e.CounterId).HasColumnName("counter_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(1000);

                entity.Property(e => e.LoginDate).HasColumnName("login_date");

                entity.Property(e => e.Success).HasColumnName("success");

                entity.Property(e => e.UserAgent)
                    .HasColumnName("user_agent")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.AttemptedByNavigation)
                    .WithMany(p => p.CashierLoginInfoAttemptedByNavigations)
                    .HasForeignKey(d => d.AttemptedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cashier_l__attem__5105F123");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CashierLoginInfoAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__cashier_l__audit__51FA155C");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.CashierLoginInfoes)
                    .HasForeignKey(d => d.CashierId)
                    .HasConstraintName("FK__cashier_l__cashi__5011CCEA");

                entity.HasOne(d => d.Counter)
                    .WithMany(p => p.CashierLoginInfoes)
                    .HasForeignKey(d => d.CounterId)
                    .HasConstraintName("FK__cashier_l__count__4F1DA8B1");
            });

            modelBuilder.Entity<CashRepository>(entity =>
            {
                entity.ToTable("cash_repositories", "finance");

                entity.HasIndex(e => new { e.OfficeId, e.CashRepositoryCode })
                    .HasName("cash_repositories_cash_repository_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => new { e.OfficeId, e.CashRepositoryName })
                    .HasName("cash_repositories_cash_repository_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CashRepositoryId).HasColumnName("cash_repository_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CashRepositoryCode)
                    .IsRequired()
                    .HasColumnName("cash_repository_code")
                    .HasMaxLength(12);

                entity.Property(e => e.CashRepositoryName)
                    .IsRequired()
                    .HasColumnName("cash_repository_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.ParentCashRepositoryId).HasColumnName("parent_cash_repository_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CashRepositories)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__cash_repo__audit__4183B671");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.CashRepositories)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cash_repo__offic__3F9B6DFF");

                entity.HasOne(d => d.ParentCashRepository)
                    .WithMany(p => p.InverseParentCashRepository)
                    .HasForeignKey(d => d.ParentCashRepositoryId)
                    .HasConstraintName("FK__cash_repo__paren__408F9238");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories", "website");

                entity.HasIndex(e => e.Alias)
                    .HasName("UQ__categori__8C585C0470CD246F")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasColumnName("alias")
                    .HasMaxLength(250);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(250);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsBlog).HasColumnName("is_blog");

                entity.Property(e => e.SeoDescription)
                    .HasColumnName("seo_description")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__categorie__audit__67DE6983");
            });

            modelBuilder.Entity<Category1>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("categories", "calendar");

                entity.HasIndex(e => new { e.UserId, e.CategoryName })
                    .HasName("categories_user_id_category_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(200);

                entity.Property(e => e.CategoryOrder).HasColumnName("category_order");

                entity.Property(e => e.ColorCode)
                    .IsRequired()
                    .HasColumnName("color_code")
                    .HasMaxLength(50);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLocal)
                    .IsRequired()
                    .HasColumnName("is_local")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Category1AuditUser)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__categorie__audit__2C88998B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Category1User)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__categorie__user___2AA05119");
            });

            modelBuilder.Entity<Checkout>(entity =>
            {
                entity.ToTable("checkouts", "inventory");

                entity.HasIndex(e => e.TransactionMasterId)
                    .HasName("checkouts_transaction_master_id_inx");

                entity.Property(e => e.CheckoutId).HasColumnName("checkout_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BookDate)
                    .HasColumnName("book_date")
                    .HasColumnType("date");

                entity.Property(e => e.CancellationReason)
                    .HasColumnName("cancellation_reason")
                    .HasMaxLength(1000);

                entity.Property(e => e.Cancelled).HasColumnName("cancelled");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NontaxableTotal)
                    .HasColumnName("nontaxable_total")
                    .HasColumnType("numeric(30, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.PostedBy).HasColumnName("posted_by");

                entity.Property(e => e.ShipperId).HasColumnName("shipper_id");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(30, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasColumnType("numeric(30, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxableTotal)
                    .HasColumnName("taxable_total")
                    .HasColumnType("numeric(30, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransactionBook)
                    .IsRequired()
                    .HasColumnName("transaction_book")
                    .HasMaxLength(100);

                entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

                entity.Property(e => e.TransactionTimestamp)
                    .HasColumnName("transaction_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CheckoutAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__checkouts__audit__711DBAFA");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__checkouts__offic__6E414E4F");

                entity.HasOne(d => d.PostedByNavigation)
                    .WithMany(p => p.CheckoutPostedByNavigations)
                    .HasForeignKey(d => d.PostedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__checkouts__poste__6D4D2A16");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK__checkouts__shipp__702996C1");

                entity.HasOne(d => d.TransactionMaster)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.TransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__checkouts__trans__66A02C87");
            });

            modelBuilder.Entity<CheckoutDetail>(entity =>
            {
                entity.ToTable("checkout_details", "inventory");

                entity.Property(e => e.CheckoutDetailId).HasColumnName("checkout_detail_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.BaseQuantity)
                    .HasColumnName("base_quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.BaseUnitId).HasColumnName("base_unit_id");

                entity.Property(e => e.BookDate)
                    .HasColumnName("book_date")
                    .HasColumnType("date");

                entity.Property(e => e.CheckoutId).HasColumnName("checkout_id");

                entity.Property(e => e.CostOfGoodsSold)
                    .HasColumnName("cost_of_goods_sold")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.DiscountRate)
                    .HasColumnName("discount_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.IsTaxed)
                    .IsRequired()
                    .HasColumnName("is_taxed")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ShippingCharge)
                    .HasColumnName("shipping_charge")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("transaction_type")
                    .HasMaxLength(2);

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.BaseUnit)
                    .WithMany(p => p.CheckoutDetailBaseUnits)
                    .HasForeignKey(d => d.BaseUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__checkout___base___7F6BDA51");

                entity.HasOne(d => d.Checkout)
                    .WithMany(p => p.CheckoutDetails)
                    .HasForeignKey(d => d.CheckoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__checkout___check__75E27017");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CheckoutDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__checkout___item___78BEDCC2");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.CheckoutDetails)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__checkout___store__76D69450");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.CheckoutDetailUnits)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__checkout___unit___7E77B618");
            });

            modelBuilder.Entity<ClosingCash>(entity =>
            {
                entity.ToTable("closing_cash", "sales");

                entity.HasIndex(e => new { e.UserId, e.TransactionDate })
                    .HasName("closing_cash_transaction_date_user_id_uix")
                    .IsUnique();

                entity.Property(e => e.ClosingCashId).HasColumnName("closing_cash_id");

                entity.Property(e => e.ApprovalMemo)
                    .HasColumnName("approval_memo")
                    .HasMaxLength(4000);

                entity.Property(e => e.ApprovedBy).HasColumnName("approved_by");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Coins)
                    .HasColumnName("coins")
                    .HasColumnType("numeric(30, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno1)
                    .HasColumnName("deno_1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno10)
                    .HasColumnName("deno_10")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno100)
                    .HasColumnName("deno_100")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno1000)
                    .HasColumnName("deno_1000")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno2)
                    .HasColumnName("deno_2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno20)
                    .HasColumnName("deno_20")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno200)
                    .HasColumnName("deno_200")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno25)
                    .HasColumnName("deno_25")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno250)
                    .HasColumnName("deno_250")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno5)
                    .HasColumnName("deno_5")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno50)
                    .HasColumnName("deno_50")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deno500)
                    .HasColumnName("deno_500")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasColumnName("memo")
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OpeningCash)
                    .HasColumnName("opening_cash")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.SubmittedCash)
                    .HasColumnName("submitted_cash")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.SubmittedTo)
                    .IsRequired()
                    .HasColumnName("submitted_to")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TotalCashSales)
                    .HasColumnName("total_cash_sales")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("transaction_date")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.ClosingCashApprovedByNavigations)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK__closing_c__appro__46535886");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ClosingCashAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__closing_c__audit__47477CBF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ClosingCashUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__closing_c__user___371114F6");
            });

            modelBuilder.Entity<CompoundUnit>(entity =>
            {
                entity.ToTable("compound_units", "inventory");

                entity.HasIndex(e => new { e.BaseUnitId, e.Value })
                    .HasName("compound_units_base_unit_id_value_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CompoundUnitId).HasColumnName("compound_unit_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BaseUnitId).HasColumnName("base_unit_id");

                entity.Property(e => e.CompareUnitId).HasColumnName("compare_unit_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CompoundUnits)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__compound___audit__79E80B25");

                entity.HasOne(d => d.BaseUnit)
                    .WithMany(p => p.CompoundUnitBaseUnits)
                    .HasForeignKey(d => d.BaseUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__compound___base___76177A41");

                entity.HasOne(d => d.CompareUnit)
                    .WithMany(p => p.CompoundUnitCompareUnits)
                    .HasForeignKey(d => d.CompareUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__compound___compa__78F3E6EC");
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("configurations", "website");

                entity.HasIndex(e => e.DomainName)
                    .HasName("configuration_domain_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.ConfigurationId).HasColumnName("configuration_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BlogDescription)
                    .HasColumnName("blog_description")
                    .HasMaxLength(500);

                entity.Property(e => e.BlogTitle)
                    .HasColumnName("blog_title")
                    .HasMaxLength(500);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.DomainName)
                    .IsRequired()
                    .HasColumnName("domain_name")
                    .HasMaxLength(500);

                entity.Property(e => e.IsDefault)
                    .IsRequired()
                    .HasColumnName("is_default")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.WebsiteName)
                    .IsRequired()
                    .HasColumnName("website_name")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Configurations)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__configura__audit__57A801BA");
            });

            modelBuilder.Entity<ConfigurationProfile>(entity =>
            {
                entity.ToTable("configuration_profiles", "account");

                entity.HasIndex(e => e.IsActive)
                    .HasName("configuration_profile_uix")
                    .IsUnique()
                    .HasFilter("([is_active]=(1) AND [deleted]=(0))");

                entity.HasIndex(e => e.ProfileName)
                    .HasName("UQ__configur__0C85D9E128BA427A")
                    .IsUnique();

                entity.Property(e => e.ConfigurationProfileId).HasColumnName("configuration_profile_id");

                entity.Property(e => e.AllowFacebookRegistration)
                    .IsRequired()
                    .HasColumnName("allow_facebook_registration")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AllowGoogleRegistration)
                    .IsRequired()
                    .HasColumnName("allow_google_registration")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AllowRegistration)
                    .IsRequired()
                    .HasColumnName("allow_registration")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacebookAppId)
                    .HasColumnName("facebook_app_id")
                    .HasMaxLength(500);

                entity.Property(e => e.FacebookScope)
                    .HasColumnName("facebook_scope")
                    .HasMaxLength(500);

                entity.Property(e => e.GoogleSigninClientId)
                    .HasColumnName("google_signin_client_id")
                    .HasMaxLength(500);

                entity.Property(e => e.GoogleSigninScope)
                    .HasColumnName("google_signin_scope")
                    .HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProfileName)
                    .IsRequired()
                    .HasColumnName("profile_name")
                    .HasMaxLength(100);

                entity.Property(e => e.RegistrationOfficeId).HasColumnName("registration_office_id");

                entity.Property(e => e.RegistrationRoleId).HasColumnName("registration_role_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ConfigurationProfiles)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__configura__audit__04E4BC85");

                entity.HasOne(d => d.RegistrationOffice)
                    .WithMany(p => p.ConfigurationProfiles)
                    .HasForeignKey(d => d.RegistrationOfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__configura__regis__6FE99F9F");

                entity.HasOne(d => d.RegistrationRole)
                    .WithMany(p => p.ConfigurationProfiles)
                    .HasForeignKey(d => d.RegistrationRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__configura__regis__70DDC3D8");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contacts", "website");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(500);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(500);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(100);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasMaxLength(500);

                entity.Property(e => e.DisplayContactForm)
                    .IsRequired()
                    .HasColumnName("display_contact_form")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DisplayEmail).HasColumnName("display_email");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(500);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(500);

                entity.Property(e => e.Recipients)
                    .HasColumnName("recipients")
                    .HasMaxLength(1000);

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__contacts__audit___0A338187");
            });

            modelBuilder.Entity<Contact1>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("contacts", "addressbook");

                entity.Property(e => e.ContactId)
                    .HasColumnName("contact_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("address_line_1")
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line_2")
                    .HasMaxLength(500);

                entity.Property(e => e.AssociatedUserId).HasColumnName("associated_user_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BirthDay)
                    .HasColumnName("birth_day")
                    .HasColumnType("date");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(500);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmailAddresses)
                    .HasColumnName("email_addresses")
                    .HasMaxLength(1000);

                entity.Property(e => e.FaxNumbers)
                    .HasColumnName("fax_numbers")
                    .HasMaxLength(1000);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(200);

                entity.Property(e => e.FormattedName)
                    .IsRequired()
                    .HasColumnName("formatted_name")
                    .HasMaxLength(610);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsPrivate)
                    .IsRequired()
                    .HasColumnName("is_private")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Kind).HasColumnName("kind");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasMaxLength(500);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(200);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(200);

                entity.Property(e => e.MobileNumbers)
                    .HasColumnName("mobile_numbers")
                    .HasMaxLength(1000);

                entity.Property(e => e.NickName)
                    .HasColumnName("nick_name")
                    .HasMaxLength(610);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.Organization)
                    .HasColumnName("organization")
                    .HasMaxLength(500);

                entity.Property(e => e.OrganizationalUnit)
                    .HasColumnName("organizational_unit")
                    .HasMaxLength(500);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(500);

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .HasMaxLength(200);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(500);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(500);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(500);

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasMaxLength(200);

                entity.Property(e => e.Tags)
                    .HasColumnName("tags")
                    .HasMaxLength(500);

                entity.Property(e => e.Telephones)
                    .HasColumnName("telephones")
                    .HasMaxLength(1000);

                entity.Property(e => e.TimeZone)
                    .HasColumnName("time_zone")
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.AssociatedUser)
                    .WithMany(p => p.Contact1AssociatedUser)
                    .HasForeignKey(d => d.AssociatedUserId)
                    .HasConstraintName("FK__contacts__associ__220B0B18");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Contact1AuditUser)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__contacts__audit___24E777C3");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Contact1CreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__contacts__create__23F3538A");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("contents", "website");

                entity.HasIndex(e => e.Alias)
                    .HasName("UQ__contents__8C585C049FBBBAA4")
                    .IsUnique();

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasColumnName("alias")
                    .HasMaxLength(500);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnName("contents");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.IsDraft)
                    .IsRequired()
                    .HasColumnName("is_draft")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsHomepage).HasColumnName("is_homepage");

                entity.Property(e => e.LastEditedOn).HasColumnName("last_edited_on");

                entity.Property(e => e.LastEditorId).HasColumnName("last_editor_id");

                entity.Property(e => e.Markdown).HasColumnName("markdown");

                entity.Property(e => e.PublishOn).HasColumnName("publish_on");

                entity.Property(e => e.SeoDescription)
                    .IsRequired()
                    .HasColumnName("seo_description")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tags)
                    .HasColumnName("tags")
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ContentAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__contents__audit___74444068");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.ContentAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__contents__author__6E8B6712");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contents__catego__6D9742D9");

                entity.HasOne(d => d.LastEditor)
                    .WithMany(p => p.ContentLastEditors)
                    .HasForeignKey(d => d.LastEditorId)
                    .HasConstraintName("FK__contents__last_e__7073AF84");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contracts", "hrm");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BeganOn)
                    .HasColumnName("began_on")
                    .HasColumnType("date");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EmploymentStatusCodeId).HasColumnName("employment_status_code_id");

                entity.Property(e => e.EndedOn)
                    .HasColumnName("ended_on")
                    .HasColumnType("date");

                entity.Property(e => e.LeaveBenefitId).HasColumnName("leave_benefit_id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.VerificationReason)
                    .HasColumnName("verification_reason")
                    .HasMaxLength(128);

                entity.Property(e => e.VerificationStatusId).HasColumnName("verification_status_id");

                entity.Property(e => e.VerifiedByUserId).HasColumnName("verified_by_user_id");

                entity.Property(e => e.VerifiedOn)
                    .HasColumnName("verified_on")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ContractAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__contracts__audit__13DCE752");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contracts__depar__0E240DFC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contracts__emplo__0C3BC58A");

                entity.HasOne(d => d.EmploymentStatusCode)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.EmploymentStatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contracts__emplo__11007AA7");

                entity.HasOne(d => d.LeaveBenefit)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.LeaveBenefitId)
                    .HasConstraintName("FK__contracts__leave__100C566E");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contracts__offic__0D2FE9C3");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__contracts__role___0F183235");

                entity.HasOne(d => d.VerificationStatus)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.VerificationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contracts__verif__11F49EE0");

                entity.HasOne(d => d.VerifiedByUser)
                    .WithMany(p => p.ContractVerifiedByUsers)
                    .HasForeignKey(d => d.VerifiedByUserId)
                    .HasConstraintName("FK__contracts__verif__12E8C319");
            });

            modelBuilder.Entity<CostCenter>(entity =>
            {
                entity.ToTable("cost_centers", "finance");

                entity.HasIndex(e => e.CostCenterCode)
                    .HasName("cost_centers_cost_center_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.CostCenterName)
                    .HasName("cost_centers_cost_center_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CostCenterId).HasColumnName("cost_center_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CostCenterCode)
                    .IsRequired()
                    .HasColumnName("cost_center_code")
                    .HasMaxLength(24);

                entity.Property(e => e.CostCenterName)
                    .IsRequired()
                    .HasColumnName("cost_center_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CostCenters)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__cost_cent__audit__54968AE5");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.ToTable("counters", "inventory");

                entity.HasIndex(e => e.CounterCode)
                    .HasName("counters_counter_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.CounterName)
                    .HasName("counters_counter_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CounterId).HasColumnName("counter_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CounterCode)
                    .IsRequired()
                    .HasColumnName("counter_code")
                    .HasMaxLength(12);

                entity.Property(e => e.CounterName)
                    .IsRequired()
                    .HasColumnName("counter_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Counters)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__counters__audit___5C229E14");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Counters)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__counters__store___5B2E79DB");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode);

                entity.ToTable("countries", "core");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("country_code")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("coupons", "sales");

                entity.HasIndex(e => e.CouponCode)
                    .HasName("coupons_coupon_code_uix")
                    .IsUnique();

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.AssociatedPriceTypeId).HasColumnName("associated_price_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BeginsFrom)
                    .HasColumnName("begins_from")
                    .HasColumnType("date");

                entity.Property(e => e.CouponCode)
                    .IsRequired()
                    .HasColumnName("coupon_code")
                    .HasMaxLength(100);

                entity.Property(e => e.CouponName)
                    .IsRequired()
                    .HasColumnName("coupon_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountRate)
                    .HasColumnName("discount_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.EnableTicketPrinting).HasColumnName("enable_ticket_printing");

                entity.Property(e => e.ExpiresOn)
                    .HasColumnName("expires_on")
                    .HasColumnType("date");

                entity.Property(e => e.ForTicketHavingMaximumAmount)
                    .HasColumnName("for_ticket_having_maximum_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ForTicketHavingMinimumAmount)
                    .HasColumnName("for_ticket_having_minimum_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ForTicketOfPriceTypeId).HasColumnName("for_ticket_of_price_type_id");

                entity.Property(e => e.ForTicketOfUnknownCustomersOnly).HasColumnName("for_ticket_of_unknown_customers_only");

                entity.Property(e => e.IsPercentage).HasColumnName("is_percentage");

                entity.Property(e => e.MaximumDiscountAmount)
                    .HasColumnName("maximum_discount_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.MaximumPurchaseAmount)
                    .HasColumnName("maximum_purchase_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.MaximumUsage).HasColumnName("maximum_usage");

                entity.Property(e => e.MinimumPurchaseAmount)
                    .HasColumnName("minimum_purchase_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.HasOne(d => d.AssociatedPriceType)
                    .WithMany(p => p.CouponAssociatedPriceTypes)
                    .HasForeignKey(d => d.AssociatedPriceTypeId)
                    .HasConstraintName("FK__coupons__associa__066DDD9B");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Coupons)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__coupons__audit_u__0856260D");

                entity.HasOne(d => d.ForTicketOfPriceType)
                    .WithMany(p => p.CouponForTicketOfPriceTypes)
                    .HasForeignKey(d => d.ForTicketOfPriceTypeId)
                    .HasConstraintName("FK__coupons__for_tic__076201D4");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurrencyCode);

                entity.ToTable("currencies", "core");

                entity.HasIndex(e => e.CurrencyName)
                    .HasName("UQ__currenci__EC6E104DA3081EAE")
                    .IsUnique();

                entity.Property(e => e.CurrencyCode)
                    .HasColumnName("currency_code")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currency_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasColumnName("currency_name")
                    .HasMaxLength(48);

                entity.Property(e => e.CurrencySymbol)
                    .IsRequired()
                    .HasColumnName("currency_symbol")
                    .HasMaxLength(12);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HundredthName)
                    .IsRequired()
                    .HasColumnName("hundredth_name")
                    .HasMaxLength(48);
            });

            modelBuilder.ApplyConfiguration(new CustomerCofiguration());

            modelBuilder.Entity<CustomerReceipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptId);

                entity.ToTable("customer_receipts", "sales");

                entity.HasIndex(e => e.CashRepositoryId)
                    .HasName("customer_receipts_cash_repository_id_inx");

                entity.HasIndex(e => e.CurrencyCode)
                    .HasName("customer_receipts_currency_code_inx");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("customer_receipts_customer_id_inx");

                entity.HasIndex(e => e.PostedDate)
                    .HasName("customer_receipts_posted_date_inx");

                entity.HasIndex(e => e.TransactionMasterId)
                    .HasName("customer_receipts_transaction_master_id_inx");

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.CashRepositoryId).HasColumnName("cash_repository_id");

                entity.Property(e => e.Change)
                    .HasColumnName("change")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.CheckAmount)
                    .HasColumnName("check_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.CheckBankName)
                    .HasColumnName("check_bank_name")
                    .HasMaxLength(1000);

                entity.Property(e => e.CheckClearDate)
                    .HasColumnName("check_clear_date")
                    .HasColumnType("date");

                entity.Property(e => e.CheckCleared).HasColumnName("check_cleared");

                entity.Property(e => e.CheckClearingMemo)
                    .HasColumnName("check_clearing_memo")
                    .HasMaxLength(1000);

                entity.Property(e => e.CheckClearingTransactionMasterId).HasColumnName("check_clearing_transaction_master_id");

                entity.Property(e => e.CheckDate)
                    .HasColumnName("check_date")
                    .HasColumnType("date");

                entity.Property(e => e.CheckNumber)
                    .HasColumnName("check_number")
                    .HasMaxLength(100);

                entity.Property(e => e.CollectedBankInstrumentCode)
                    .HasColumnName("collected_bank_instrument_code")
                    .HasMaxLength(500);

                entity.Property(e => e.CollectedBankTransactionCode)
                    .HasColumnName("collected_bank_transaction_code")
                    .HasMaxLength(500);

                entity.Property(e => e.CollectedOnBankId).HasColumnName("collected_on_bank_id");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currency_code")
                    .HasMaxLength(12);

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ErCredit)
                    .HasColumnName("er_credit")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ErDebit)
                    .HasColumnName("er_debit")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.GiftCardNumber)
                    .HasColumnName("gift_card_number")
                    .HasMaxLength(100);

                entity.Property(e => e.PostedDate)
                    .HasColumnName("posted_date")
                    .HasColumnType("date");

                entity.Property(e => e.Tender)
                    .HasColumnName("tender")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

                entity.HasOne(d => d.CashRepository)
                    .WithMany(p => p.CustomerReceipts)
                    .HasForeignKey(d => d.CashRepositoryId)
                    .HasConstraintName("FK__customer___cash___2121D3D7");

                entity.HasOne(d => d.CheckClearingTransactionMaster)
                    .WithMany(p => p.CustomerReceiptCheckClearingTransactionMasters)
                    .HasForeignKey(d => d.CheckClearingTransactionMasterId)
                    .HasConstraintName("FK__customer___check__230A1C49");

                entity.HasOne(d => d.CollectedOnBank)
                    .WithMany(p => p.CustomerReceipts)
                    .HasForeignKey(d => d.CollectedOnBankId)
                    .HasConstraintName("FK__customer___colle__2215F810");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.CustomerReceipts)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___curre__202DAF9E");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerReceipts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___custo__1F398B65");

                entity.HasOne(d => d.TransactionMaster)
                    .WithMany(p => p.CustomerReceiptTransactionMasters)
                    .HasForeignKey(d => d.TransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___trans__1E45672C");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("customer_types", "inventory");

                entity.HasIndex(e => e.CustomerTypeCode)
                    .HasName("customer_types_customer_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.CustomerTypeName)
                    .HasName("customer_types_customer_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.CustomerTypeId).HasColumnName("customer_type_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CustomerTypeCode)
                    .IsRequired()
                    .HasColumnName("customer_type_code")
                    .HasMaxLength(24);

                entity.Property(e => e.CustomerTypeName)
                    .IsRequired()
                    .HasColumnName("customer_type_name")
                    .HasMaxLength(500);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.CustomerTypes)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___accou__0C06BB60");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CustomerTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__customer___audit__0CFADF99");
            });

            modelBuilder.Entity<CustomerwiseSellingPrice>(entity =>
            {
                entity.HasKey(e => e.SellingPriceId);

                entity.ToTable("customerwise_selling_prices", "sales");

                entity.Property(e => e.SellingPriceId).HasColumnName("selling_price_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CustomerwiseSellingPrices)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__customerw__audit__37461F20");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerwiseSellingPrices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customerw__custo__355DD6AE");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CustomerwiseSellingPrices)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customerw__item___3469B275");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.CustomerwiseSellingPrices)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customerw__unit___3651FAE7");
            });

            modelBuilder.Entity<CustomField>(entity =>
            {
                entity.ToTable("custom_fields", "config");

                entity.Property(e => e.CustomFieldId).HasColumnName("custom_field_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CustomFieldSetupId).HasColumnName("custom_field_setup_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ResourceId)
                    .IsRequired()
                    .HasColumnName("resource_id")
                    .HasMaxLength(500);

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CustomFields)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__custom_fi__audit__4A4E069C");

                entity.HasOne(d => d.CustomFieldSetup)
                    .WithMany(p => p.CustomFields)
                    .HasForeignKey(d => d.CustomFieldSetupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__custom_fi__custo__4959E263");
            });

            modelBuilder.Entity<CustomFieldDataType>(entity =>
            {
                entity.HasKey(e => e.DataType);

                entity.ToTable("custom_field_data_types", "config");

                entity.Property(e => e.DataType)
                    .HasColumnName("data_type")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnderlyingType)
                    .IsRequired()
                    .HasColumnName("underlying_type")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CustomFieldDataTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__custom_fi__audit__373B3228");
            });

            modelBuilder.Entity<CustomFieldForm>(entity =>
            {
                entity.HasKey(e => e.FormName);

                entity.ToTable("custom_field_forms", "config");

                entity.HasIndex(e => e.TableName)
                    .HasName("UQ__custom_f__B228A5BF4DE4C087")
                    .IsUnique();

                entity.Property(e => e.FormName)
                    .HasColumnName("form_name")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.KeyName)
                    .IsRequired()
                    .HasColumnName("key_name")
                    .HasMaxLength(500);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("table_name")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CustomFieldForms)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__custom_fi__audit__3CF40B7E");
            });

            modelBuilder.Entity<CustomFieldSetup>(entity =>
            {
                entity.ToTable("custom_field_setup", "config");

                entity.Property(e => e.CustomFieldSetupId).HasColumnName("custom_field_setup_id");

                entity.Property(e => e.AfterField)
                    .HasColumnName("after_field")
                    .HasMaxLength(500);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BeforeField)
                    .HasColumnName("before_field")
                    .HasMaxLength(500);

                entity.Property(e => e.DataType)
                    .HasColumnName("data_type")
                    .HasMaxLength(50);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.FieldLabel)
                    .IsRequired()
                    .HasColumnName("field_label")
                    .HasMaxLength(200);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasColumnName("field_name")
                    .HasMaxLength(100);

                entity.Property(e => e.FieldOrder).HasColumnName("field_order");

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasColumnName("form_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.CustomFieldSetups)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__custom_fi__audit__44952D46");

                entity.HasOne(d => d.DataTypeNavigation)
                    .WithMany(p => p.CustomFieldSetups)
                    .HasForeignKey(d => d.DataType)
                    .HasConstraintName("FK__custom_fi__data___43A1090D");

                entity.HasOne(d => d.FormNameNavigation)
                    .WithMany(p => p.CustomFieldSetups)
                    .HasForeignKey(d => d.FormName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__custom_fi__form___41B8C09B");
            });

            modelBuilder.Entity<DayOperation>(entity =>
            {
                entity.HasKey(e => e.DayId);

                entity.ToTable("day_operation", "finance");

                entity.HasIndex(e => e.CompletedOn)
                    .HasName("day_operation_completed_on_inx");

                entity.HasIndex(e => e.ValueDate)
                    .HasName("day_operation_value_date_uix")
                    .IsUnique();

                entity.Property(e => e.DayId).HasColumnName("day_id");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.CompletedBy).HasColumnName("completed_by");

                entity.Property(e => e.CompletedOn).HasColumnName("completed_on");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.StartedBy).HasColumnName("started_by");

                entity.Property(e => e.StartedOn).HasColumnName("started_on");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.CompletedByNavigation)
                    .WithMany(p => p.DayOperationCompletedByNavigations)
                    .HasForeignKey(d => d.CompletedBy)
                    .HasConstraintName("FK__day_opera__compl__6C390A4C");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.DayOperations)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__day_opera__offic__6A50C1DA");

                entity.HasOne(d => d.StartedByNavigation)
                    .WithMany(p => p.DayOperationStartedByNavigations)
                    .HasForeignKey(d => d.StartedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__day_opera__start__6B44E613");
            });

            modelBuilder.Entity<DayOperationRoutine>(entity =>
            {
                entity.ToTable("day_operation_routines", "finance");

                entity.HasIndex(e => e.CompletedOn)
                    .HasName("day_operation_routines_completed_on_inx");

                entity.HasIndex(e => e.StartedOn)
                    .HasName("day_operation_routines_started_on_inx");

                entity.Property(e => e.DayOperationRoutineId).HasColumnName("day_operation_routine_id");

                entity.Property(e => e.CompletedOn).HasColumnName("completed_on");

                entity.Property(e => e.DayId).HasColumnName("day_id");

                entity.Property(e => e.RoutineId).HasColumnName("routine_id");

                entity.Property(e => e.StartedOn).HasColumnName("started_on");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.DayOperationRoutines)
                    .HasForeignKey(d => d.DayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__day_opera__day_i__70FDBF69");

                entity.HasOne(d => d.Routine)
                    .WithMany(p => p.DayOperationRoutines)
                    .HasForeignKey(d => d.RoutineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__day_opera__routi__71F1E3A2");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments", "hrm");

                entity.HasIndex(e => e.DepartmentCode)
                    .HasName("departments_department_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.DepartmentName)
                    .HasName("departments_department_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasColumnName("department_code")
                    .HasMaxLength(12);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("department_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__departmen__audit__08A03ED0");
            });

            modelBuilder.Entity<EducationLevel>(entity =>
            {
                entity.ToTable("education_levels", "hrm");

                entity.HasIndex(e => e.EducationLevelName)
                    .HasName("education_levels_education_level_name")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.EducationLevelId).HasColumnName("education_level_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EducationLevelName)
                    .IsRequired()
                    .HasColumnName("education_level_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EducationLevels)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__education__audit__17E28260");
            });

            modelBuilder.Entity<EmailQueue>(entity =>
            {
                entity.HasKey(e => e.QueueId);

                entity.ToTable("email_queue", "config");

                entity.Property(e => e.QueueId).HasColumnName("queue_id");

                entity.Property(e => e.AddedOn)
                    .HasColumnName("added_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ApplicationName)
                    .HasColumnName("application_name")
                    .HasMaxLength(256);

                entity.Property(e => e.Attachments)
                    .HasColumnName("attachments")
                    .HasMaxLength(2000);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Canceled).HasColumnName("canceled");

                entity.Property(e => e.CanceledOn).HasColumnName("canceled_on");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Delivered).HasColumnName("delivered");

                entity.Property(e => e.DeliveredOn).HasColumnName("delivered_on");

                entity.Property(e => e.FromEmail)
                    .IsRequired()
                    .HasColumnName("from_email")
                    .HasMaxLength(256);

                entity.Property(e => e.FromName)
                    .IsRequired()
                    .HasColumnName("from_name")
                    .HasMaxLength(256);

                entity.Property(e => e.IsTest).HasColumnName("is_test");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.Property(e => e.ReplyTo)
                    .IsRequired()
                    .HasColumnName("reply_to")
                    .HasMaxLength(256);

                entity.Property(e => e.ReplyToName)
                    .IsRequired()
                    .HasColumnName("reply_to_name")
                    .HasMaxLength(256);

                entity.Property(e => e.SendOn)
                    .HasColumnName("send_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.SendTo)
                    .IsRequired()
                    .HasColumnName("send_to")
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasMaxLength(256);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EmailQueues)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__email_que__audit__2057CCD0");
            });

            modelBuilder.Entity<EmailSubscription>(entity =>
            {
                entity.ToTable("email_subscriptions", "website");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__email_su__AB6E6164CF62348B")
                    .IsUnique();

                entity.Property(e => e.EmailSubscriptionId)
                    .HasColumnName("email_subscription_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(500);

                entity.Property(e => e.Confirmed)
                    .HasColumnName("confirmed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConfirmedOn).HasColumnName("confirmed_on");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(100);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(100);

                entity.Property(e => e.SubscribedOn)
                    .HasColumnName("subscribed_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Unsubscribed)
                    .HasColumnName("unsubscribed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnsubscribedOn).HasColumnName("unsubscribed_on");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EmailSubscriptions)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__email_sub__audit__61316BF4");
            });

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.Entity<EmployeeExperience>(entity =>
            {
                entity.ToTable("employee_experiences", "hrm");

                entity.Property(e => e.EmployeeExperienceId).HasColumnName("employee_experience_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasMaxLength(1000);

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EndedOn)
                    .HasColumnName("ended_on")
                    .HasColumnType("date");

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasColumnName("organization_name")
                    .HasMaxLength(128);

                entity.Property(e => e.StartedOn)
                    .HasColumnName("started_on")
                    .HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EmployeeExperiences)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__employee___audit__1995C0A8");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeExperiences)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee___emplo__18A19C6F");
            });

            modelBuilder.Entity<EmployeeIdentificationDetail>(entity =>
            {
                entity.ToTable("employee_identification_details", "hrm");

                entity.HasIndex(e => new { e.EmployeeId, e.IdentificationTypeId })
                    .HasName("employee_identification_details_employee_id_itc_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.EmployeeIdentificationDetailId).HasColumnName("employee_identification_detail_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ExpiresOn)
                    .HasColumnName("expires_on")
                    .HasColumnType("date");

                entity.Property(e => e.IdentificationNumber)
                    .IsRequired()
                    .HasColumnName("identification_number")
                    .HasMaxLength(128);

                entity.Property(e => e.IdentificationTypeId).HasColumnName("identification_type_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EmployeeIdentificationDetails)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__employee___audit__00CA12DE");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeIdentificationDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee___emplo__7EE1CA6C");

                entity.HasOne(d => d.IdentificationType)
                    .WithMany(p => p.EmployeeIdentificationDetails)
                    .HasForeignKey(d => d.IdentificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee___ident__7FD5EEA5");
            });

            modelBuilder.Entity<EmployeeQualification>(entity =>
            {
                entity.ToTable("employee_qualifications", "hrm");

                entity.Property(e => e.EmployeeQualificationId).HasColumnName("employee_qualification_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CompletedOn)
                    .HasColumnName("completed_on")
                    .HasColumnType("date");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasMaxLength(1000);

                entity.Property(e => e.EducationLevelId).HasColumnName("education_level_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasColumnName("institution")
                    .HasMaxLength(128);

                entity.Property(e => e.Majors)
                    .IsRequired()
                    .HasColumnName("majors")
                    .HasMaxLength(128);

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.StartedOn)
                    .HasColumnName("started_on")
                    .HasColumnType("date");

                entity.Property(e => e.TotalYears).HasColumnName("total_years");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EmployeeQualifications)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__employee___audit__2042BE37");

                entity.HasOne(d => d.EducationLevel)
                    .WithMany(p => p.EmployeeQualifications)
                    .HasForeignKey(d => d.EducationLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee___educa__1F4E99FE");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeQualifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee___emplo__1E5A75C5");
            });

            modelBuilder.Entity<EmployeeSocialNetworkDetail>(entity =>
            {
                entity.ToTable("employee_social_network_details", "hrm");

                entity.Property(e => e.EmployeeSocialNetworkDetailId).HasColumnName("employee_social_network_detail_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ProfileLink)
                    .IsRequired()
                    .HasColumnName("profile_link")
                    .HasMaxLength(1000);

                entity.Property(e => e.SocialNetworkId).HasColumnName("social_network_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EmployeeSocialNetworkDetails)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__employee___audit__0777106D");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSocialNetworkDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee___emplo__058EC7FB");

                entity.HasOne(d => d.SocialNetwork)
                    .WithMany(p => p.EmployeeSocialNetworkDetails)
                    .HasForeignKey(d => d.SocialNetworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee___socia__0682EC34");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("employee_types", "hrm");

                entity.HasIndex(e => e.EmployeeTypeCode)
                    .HasName("employee_types_employee_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.EmployeeTypeName)
                    .HasName("employee_types_employee_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.EmployeeTypeId).HasColumnName("employee_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmployeeTypeCode)
                    .IsRequired()
                    .HasColumnName("employee_type_code")
                    .HasMaxLength(12);

                entity.Property(e => e.EmployeeTypeName)
                    .IsRequired()
                    .HasColumnName("employee_type_name")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EmployeeTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__employee___audit__54EB90A0");
            });

            modelBuilder.Entity<EmploymentStatus>(entity =>
            {
                entity.ToTable("employment_statuses", "hrm");

                entity.HasIndex(e => e.EmploymentStatusCode)
                    .HasName("employment_statuses_employment_status_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.EmploymentStatusName)
                    .HasName("employment_statuses_employment_status_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.EmploymentStatusId).HasColumnName("employment_status_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.DefaultEmploymentStatusCodeId).HasColumnName("default_employment_status_code_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmploymentStatusCode)
                    .IsRequired()
                    .HasColumnName("employment_status_code")
                    .HasMaxLength(12);

                entity.Property(e => e.EmploymentStatusName)
                    .IsRequired()
                    .HasColumnName("employment_status_name")
                    .HasMaxLength(100);

                entity.Property(e => e.IsContract).HasColumnName("is_contract");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EmploymentStatuses)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__employmen__audit__2630A1B7");

                entity.HasOne(d => d.DefaultEmploymentStatusCode)
                    .WithMany(p => p.EmploymentStatuses)
                    .HasForeignKey(d => d.DefaultEmploymentStatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employmen__defau__24485945");
            });

            modelBuilder.Entity<EmploymentStatusCode>(entity =>
            {
                entity.ToTable("employment_status_codes", "hrm");

                entity.HasIndex(e => e.StatusCode)
                    .HasName("employment_status_codes_status_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.StatusCodeName)
                    .HasName("employment_status_codes_status_code_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.EmploymentStatusCodeId)
                    .HasColumnName("employment_status_code_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasColumnName("status_code")
                    .HasMaxLength(12);

                entity.Property(e => e.StatusCodeName)
                    .IsRequired()
                    .HasColumnName("status_code_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EmploymentStatusCodes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__employmen__audit__1D9B5BB6");
            });

            modelBuilder.Entity<EntityAccessPolicy>(entity =>
            {
                entity.ToTable("entity_access_policy", "auth");

                entity.Property(e => e.EntityAccessPolicyId).HasColumnName("entity_access_policy_id");

                entity.Property(e => e.AccessTypeId).HasColumnName("access_type_id");

                entity.Property(e => e.AllowAccess).HasColumnName("allow_access");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EntityName)
                    .HasColumnName("entity_name")
                    .HasMaxLength(500);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AccessType)
                    .WithMany(p => p.EntityAccessPolicies)
                    .HasForeignKey(d => d.AccessTypeId)
                    .HasConstraintName("FK__entity_ac__acces__65370702");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EntityAccessPolicyAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__entity_ac__audit__662B2B3B");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.EntityAccessPolicies)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__entity_ac__offic__634EBE90");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EntityAccessPolicyUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__entity_ac__user___6442E2C9");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events", "calendar");

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Alarm).HasColumnName("alarm");

                entity.Property(e => e.AllDay).HasColumnName("all_day");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EndsOn).HasColumnName("ends_on");

                entity.Property(e => e.IsPrivate).HasColumnName("is_private");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Recurrence).HasColumnName("recurrence");

                entity.Property(e => e.ReminderTypes).HasColumnName("reminder_types");

                entity.Property(e => e.StartsAt).HasColumnName("starts_at");

                entity.Property(e => e.TimeZone)
                    .IsRequired()
                    .HasColumnName("time_zone")
                    .HasMaxLength(200);

                entity.Property(e => e.Until).HasColumnName("until");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(500);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.EventAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__events__audit_us__351DDF8C");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__events__category__324172E1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__events__user_id__3335971A");
            });

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.ToTable("exchange_rates", "finance");

                entity.Property(e => e.ExchangeRateId).HasColumnName("exchange_rate_id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.ExchangeRates)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exchange___offic__4336F4B9");
            });

            modelBuilder.Entity<ExchangeRateDetail>(entity =>
            {
                entity.ToTable("exchange_rate_details", "finance");

                entity.Property(e => e.ExchangeRateDetailId).HasColumnName("exchange_rate_detail_id");

                entity.Property(e => e.ExchangeRate)
                    .HasColumnName("exchange_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ExchangeRateId).HasColumnName("exchange_rate_id");

                entity.Property(e => e.ForeignCurrencyCode)
                    .IsRequired()
                    .HasColumnName("foreign_currency_code")
                    .HasMaxLength(12);

                entity.Property(e => e.LocalCurrencyCode)
                    .IsRequired()
                    .HasColumnName("local_currency_code")
                    .HasMaxLength(12);

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.HasOne(d => d.ExchangeRateNavigation)
                    .WithMany(p => p.ExchangeRateDetails)
                    .HasForeignKey(d => d.ExchangeRateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exchange___excha__4707859D");

                entity.HasOne(d => d.ForeignCurrencyCodeNavigation)
                    .WithMany(p => p.ExchangeRateDetailForeignCurrencyCodeNavigations)
                    .HasForeignKey(d => d.ForeignCurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exchange___forei__48EFCE0F");

                entity.HasOne(d => d.LocalCurrencyCodeNavigation)
                    .WithMany(p => p.ExchangeRateDetailLocalCurrencyCodeNavigations)
                    .HasForeignKey(d => d.LocalCurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exchange___local__47FBA9D6");
            });

            modelBuilder.Entity<Exit>(entity =>
            {
                entity.ToTable("exits", "hrm");

                entity.Property(e => e.ExitId).HasColumnName("exit_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.ChangeStatusTo).HasColumnName("change_status_to");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasMaxLength(1000);

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ExitInterviewDetails)
                    .HasColumnName("exit_interview_details")
                    .HasMaxLength(1000);

                entity.Property(e => e.ExitTypeId).HasColumnName("exit_type_id");

                entity.Property(e => e.ForwardTo).HasColumnName("forward_to");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(128);

                entity.Property(e => e.ServiceEndDate)
                    .HasColumnName("service_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.VerificationReason)
                    .HasColumnName("verification_reason")
                    .HasMaxLength(128);

                entity.Property(e => e.VerificationStatusId).HasColumnName("verification_status_id");

                entity.Property(e => e.VerifiedByUserId).HasColumnName("verified_by_user_id");

                entity.Property(e => e.VerifiedOn)
                    .HasColumnName("verified_on")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ExitAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__exits__audit_use__4EFDAD20");

                entity.HasOne(d => d.ChangeStatusToNavigation)
                    .WithMany(p => p.Exits)
                    .HasForeignKey(d => d.ChangeStatusTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exits__change_st__4B2D1C3C");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ExitEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exits__employee___4944D3CA");

                entity.HasOne(d => d.ExitType)
                    .WithMany(p => p.Exits)
                    .HasForeignKey(d => d.ExitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exits__exit_type__4C214075");

                entity.HasOne(d => d.ForwardToNavigation)
                    .WithMany(p => p.ExitForwardToNavigations)
                    .HasForeignKey(d => d.ForwardTo)
                    .HasConstraintName("FK__exits__forward_t__4A38F803");

                entity.HasOne(d => d.VerificationStatus)
                    .WithMany(p => p.Exits)
                    .HasForeignKey(d => d.VerificationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__exits__verificat__4D1564AE");

                entity.HasOne(d => d.VerifiedByUser)
                    .WithMany(p => p.ExitVerifiedByUsers)
                    .HasForeignKey(d => d.VerifiedByUserId)
                    .HasConstraintName("FK__exits__verified___4E0988E7");
            });

            modelBuilder.Entity<ExitType>(entity =>
            {
                entity.ToTable("exit_types", "hrm");

                entity.HasIndex(e => e.ExitTypeCode)
                    .HasName("exit_types_exit_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.ExitTypeName)
                    .HasName("exit_types_exit_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.ExitTypeId).HasColumnName("exit_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExitTypeCode)
                    .IsRequired()
                    .HasColumnName("exit_type_code")
                    .HasMaxLength(12);

                entity.Property(e => e.ExitTypeName)
                    .IsRequired()
                    .HasColumnName("exit_type_name")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ExitTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__exit_type__audit__44801EAD");
            });

            modelBuilder.Entity<FbAccessToken>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("fb_access_tokens", "account");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FbUserId)
                    .HasColumnName("fb_user_id")
                    .HasMaxLength(500);

                entity.Property(e => e.Token).HasColumnName("token");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.FbAccessTokenAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__fb_access__audit__1332DBDC");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.FbAccessTokenUser)
                    .HasForeignKey<FbAccessToken>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fb_access__user___123EB7A3");
            });

            modelBuilder.Entity<Feed>(entity =>
            {
                entity.ToTable("feeds", "social");

                entity.HasIndex(e => e.Scope)
                    .HasName("feeds_scope_inx");

                entity.Property(e => e.FeedId).HasColumnName("feed_id");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn).HasColumnName("deleted_on");

                entity.Property(e => e.EventTimestamp)
                    .HasColumnName("event_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FormattedText)
                    .IsRequired()
                    .HasColumnName("formatted_text")
                    .HasMaxLength(4000);

                entity.Property(e => e.IsPublic)
                    .IsRequired()
                    .HasColumnName("is_public")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ParentFeedId).HasColumnName("parent_feed_id");

                entity.Property(e => e.Scope)
                    .HasColumnName("scope")
                    .HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.FeedCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__feeds__created_b__77EAB41A");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.FeedDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__feeds__deleted_b__7CAF6937");

                entity.HasOne(d => d.ParentFeed)
                    .WithMany(p => p.InverseParentFeed)
                    .HasForeignKey(d => d.ParentFeedId)
                    .HasConstraintName("FK__feeds__parent_fe__79D2FC8C");
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.ToTable("filters", "config");

                entity.HasIndex(e => e.ObjectName)
                    .HasName("filters_object_name_inx")
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.FilterId).HasColumnName("filter_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasColumnName("column_name")
                    .HasMaxLength(500);

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasColumnName("data_type")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FilterAndValue)
                    .HasColumnName("filter_and_value")
                    .HasMaxLength(500);

                entity.Property(e => e.FilterCondition).HasColumnName("filter_condition");

                entity.Property(e => e.FilterName)
                    .IsRequired()
                    .HasColumnName("filter_name")
                    .HasMaxLength(500);

                entity.Property(e => e.FilterStatement)
                    .IsRequired()
                    .HasColumnName("filter_statement")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("('WHERE')");

                entity.Property(e => e.FilterValue)
                    .HasColumnName("filter_value")
                    .HasMaxLength(500);

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.IsDefaultAdmin).HasColumnName("is_default_admin");

                entity.Property(e => e.ObjectName)
                    .IsRequired()
                    .HasColumnName("object_name")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Filters)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__filters__audit_u__32767D0B");
            });

            modelBuilder.Entity<FiscalYear>(entity =>
            {
                entity.HasKey(e => e.FiscalYearCode);

                entity.ToTable("fiscal_year", "finance");

                entity.HasIndex(e => e.EndsOn)
                    .HasName("fiscal_year_ends_on_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.FiscalYearId)
                    .HasName("UQ__fiscal_y__6F913C0CFAF278F6")
                    .IsUnique();

                entity.HasIndex(e => e.FiscalYearName)
                    .HasName("fiscal_year_fiscal_year_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.StartsFrom)
                    .HasName("fiscal_year_starts_from_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.FiscalYearCode)
                    .HasColumnName("fiscal_year_code")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EndsOn)
                    .HasColumnName("ends_on")
                    .HasColumnType("date");

                entity.Property(e => e.EodRequired)
                    .IsRequired()
                    .HasColumnName("eod_required")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FiscalYearId)
                    .HasColumnName("fiscal_year_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FiscalYearName)
                    .IsRequired()
                    .HasColumnName("fiscal_year_name")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.StartsFrom)
                    .HasColumnName("starts_from")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.FiscalYears)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__fiscal_ye__audit__4924D839");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.FiscalYears)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fiscal_ye__offic__4830B400");
            });

            modelBuilder.Entity<Frequency>(entity =>
            {
                entity.ToTable("frequencies", "finance");

                entity.HasIndex(e => e.FrequencyCode)
                    .HasName("frequencies_frequency_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.FrequencyName)
                    .HasName("frequencies_frequency_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.FrequencyId)
                    .HasColumnName("frequency_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FrequencyCode)
                    .IsRequired()
                    .HasColumnName("frequency_code")
                    .HasMaxLength(12);

                entity.Property(e => e.FrequencyName)
                    .IsRequired()
                    .HasColumnName("frequency_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Frequencies)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__frequenci__audit__3AD6B8E2");
            });

            modelBuilder.Entity<FrequencySetup>(entity =>
            {
                entity.ToTable("frequency_setups", "finance");

                entity.HasIndex(e => e.FrequencySetupCode)
                    .HasName("frequency_setups_frequency_setup_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.ValueDate)
                    .HasName("UQ__frequenc__43469440FE9D4604")
                    .IsUnique();

                entity.Property(e => e.FrequencySetupId).HasColumnName("frequency_setup_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FiscalYearCode)
                    .IsRequired()
                    .HasColumnName("fiscal_year_code")
                    .HasMaxLength(12);

                entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");

                entity.Property(e => e.FrequencySetupCode)
                    .IsRequired()
                    .HasColumnName("frequency_setup_code")
                    .HasMaxLength(12);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.FrequencySetups)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__frequency__audit__5D2BD0E6");

                entity.HasOne(d => d.FiscalYearCodeNavigation)
                    .WithMany(p => p.FrequencySetups)
                    .HasForeignKey(d => d.FiscalYearCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__frequency__fisca__5A4F643B");

                entity.HasOne(d => d.Frequency)
                    .WithMany(p => p.FrequencySetups)
                    .HasForeignKey(d => d.FrequencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__frequency__frequ__5B438874");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.FrequencySetups)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__frequency__offic__5C37ACAD");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenderCode);

                entity.ToTable("genders", "core");

                entity.HasIndex(e => e.GenderName)
                    .HasName("UQ__genders__2FB51D273F89A0CA")
                    .IsUnique();

                entity.Property(e => e.GenderCode)
                    .HasColumnName("gender_code")
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasColumnName("gender_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GiftCard>(entity =>
            {
                entity.ToTable("gift_cards", "sales");

                entity.HasIndex(e => e.GiftCardNumber)
                    .HasName("gift_cards_gift_card_number_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.GiftCardId).HasColumnName("gift_card_id");

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("address_line_1")
                    .HasMaxLength(128);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line_2")
                    .HasMaxLength(128);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(100);

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(100);

                entity.Property(e => e.GiftCardNumber)
                    .IsRequired()
                    .HasColumnName("gift_card_number")
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(100);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(100);

                entity.Property(e => e.PayableAccountId).HasColumnName("payable_account_id");

                entity.Property(e => e.PhoneNumbers)
                    .HasColumnName("phone_numbers")
                    .HasMaxLength(100);

                entity.Property(e => e.PoBox)
                    .HasColumnName("po_box")
                    .HasMaxLength(100);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(100);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(100);

                entity.Property(e => e.ZipCode)
                    .HasColumnName("zip_code")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.GiftCards)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__gift_card__audit__11207638");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.GiftCards)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__gift_card__custo__102C51FF");

                entity.HasOne(d => d.PayableAccount)
                    .WithMany(p => p.GiftCards)
                    .HasForeignKey(d => d.PayableAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__gift_card__payab__0F382DC6");
            });

            modelBuilder.Entity<GiftCardTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("gift_card_transactions", "sales");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.BookDate)
                    .HasColumnName("book_date")
                    .HasColumnType("date");

                entity.Property(e => e.GiftCardId).HasColumnName("gift_card_id");

                entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("transaction_type")
                    .HasMaxLength(2);

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.GiftCard)
                    .WithMany(p => p.GiftCardTransactions)
                    .HasForeignKey(d => d.GiftCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__gift_card__gift___15E52B55");

                entity.HasOne(d => d.TransactionMaster)
                    .WithMany(p => p.GiftCardTransactions)
                    .HasForeignKey(d => d.TransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__gift_card__trans__16D94F8E");
            });

            modelBuilder.Entity<GoogleAccessToken>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("google_access_tokens", "account");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.GoogleAccessTokenAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__google_ac__audit__18EBB532");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.GoogleAccessTokenUser)
                    .HasForeignKey<GoogleAccessToken>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__google_ac__user___17F790F9");
            });

            modelBuilder.Entity<GroupEntityAccessPolicy>(entity =>
            {
                entity.ToTable("group_entity_access_policy", "auth");

                entity.Property(e => e.GroupEntityAccessPolicyId).HasColumnName("group_entity_access_policy_id");

                entity.Property(e => e.AccessTypeId).HasColumnName("access_type_id");

                entity.Property(e => e.AllowAccess).HasColumnName("allow_access");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EntityName)
                    .HasColumnName("entity_name")
                    .HasMaxLength(500);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.AccessType)
                    .WithMany(p => p.GroupEntityAccessPolicies)
                    .HasForeignKey(d => d.AccessTypeId)
                    .HasConstraintName("FK__group_ent__acces__5D95E53A");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.GroupEntityAccessPolicies)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__group_ent__audit__5E8A0973");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.GroupEntityAccessPolicies)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__group_ent__offic__5BAD9CC8");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.GroupEntityAccessPolicies)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__group_ent__role___5CA1C101");
            });

            modelBuilder.Entity<GroupMenuAccessPolicy>(entity =>
            {
                entity.ToTable("group_menu_access_policy", "auth");

                entity.HasIndex(e => new { e.OfficeId, e.MenuId, e.RoleId })
                    .HasName("menu_access_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.GroupMenuAccessPolicyId).HasColumnName("group_menu_access_policy_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.GroupMenuAccessPolicies)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__group_men__audit__6DCC4D03");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.GroupMenuAccessPolicies)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__group_men__menu___6BE40491");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.GroupMenuAccessPolicies)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__group_men__offic__6AEFE058");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.GroupMenuAccessPolicies)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__group_men__role___6CD828CA");
            });

            modelBuilder.Entity<IdentificationType>(entity =>
            {
                entity.ToTable("identification_types", "hrm");

                entity.HasIndex(e => e.IdentificationTypeCode)
                    .HasName("identification_types_identification_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.IdentificationTypeName)
                    .HasName("identification_types_identification_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.IdentificationTypeId).HasColumnName("identification_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CanExpire).HasColumnName("can_expire");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdentificationTypeCode)
                    .IsRequired()
                    .HasColumnName("identification_type_code")
                    .HasMaxLength(12);

                entity.Property(e => e.IdentificationTypeName)
                    .IsRequired()
                    .HasColumnName("identification_type_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.IdentificationTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__identific__audit__7E22B05D");
            });

            modelBuilder.Entity<InstalledDomain>(entity =>
            {
                entity.HasKey(e => e.DomainId);

                entity.ToTable("installed_domains", "account");

                entity.HasIndex(e => e.DomainName)
                    .HasName("installed_domains_domain_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.DomainId).HasColumnName("domain_id");

                entity.Property(e => e.AdminEmail)
                    .HasColumnName("admin_email")
                    .HasMaxLength(500);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DomainName)
                    .HasColumnName("domain_name")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<InventorySetup>(entity =>
            {
                entity.HasKey(e => e.OfficeId);

                entity.ToTable("inventory_setup", "inventory");

                entity.Property(e => e.OfficeId)
                    .HasColumnName("office_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowMultipleOpeningInventory).HasColumnName("allow_multiple_opening_inventory");

                entity.Property(e => e.CogsCalculationMethod)
                    .IsRequired()
                    .HasColumnName("cogs_calculation_method")
                    .HasMaxLength(50);

                entity.Property(e => e.DefaultDiscountAccountId).HasColumnName("default_discount_account_id");

                entity.Property(e => e.InventorySystem)
                    .IsRequired()
                    .HasColumnName("inventory_system")
                    .HasMaxLength(50);

                entity.Property(e => e.UsePosCheckoutScreen)
                    .IsRequired()
                    .HasColumnName("use_pos_checkout_screen")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.DefaultDiscountAccount)
                    .WithMany(p => p.InventorySetups)
                    .HasForeignKey(d => d.DefaultDiscountAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__defau__3F51553C");

                entity.HasOne(d => d.Office)
                    .WithOne(p => p.InventorySetup)
                    .HasForeignKey<InventorySetup>(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__offic__3B80C458");
            });

            modelBuilder.Entity<InventoryTransferDelivery>(entity =>
            {
                entity.ToTable("inventory_transfer_deliveries", "inventory");

                entity.Property(e => e.InventoryTransferDeliveryId).HasColumnName("inventory_transfer_delivery_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.DestinationStoreId).HasColumnName("destination_store_id");

                entity.Property(e => e.InventoryTransferRequestId).HasColumnName("inventory_transfer_request_id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.ReferenceNumber)
                    .HasColumnName("reference_number")
                    .HasMaxLength(24);

                entity.Property(e => e.StatementReference)
                    .HasColumnName("statement_reference")
                    .HasMaxLength(2000);

                entity.Property(e => e.TransactionTimestamp)
                    .HasColumnName("transaction_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.InventoryTransferDeliveryAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__inventory__audit__1DF06171");

                entity.HasOne(d => d.DestinationStore)
                    .WithMany(p => p.InventoryTransferDeliveries)
                    .HasForeignKey(d => d.DestinationStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__desti__1C0818FF");

                entity.HasOne(d => d.InventoryTransferRequest)
                    .WithMany(p => p.InventoryTransferDeliveries)
                    .HasForeignKey(d => d.InventoryTransferRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__inven__192BAC54");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.InventoryTransferDeliveries)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__offic__1A1FD08D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.InventoryTransferDeliveryUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__user___1B13F4C6");
            });

            modelBuilder.Entity<InventoryTransferDeliveryDetail>(entity =>
            {
                entity.ToTable("inventory_transfer_delivery_details", "inventory");

                entity.Property(e => e.InventoryTransferDeliveryDetailId).HasColumnName("inventory_transfer_delivery_detail_id");

                entity.Property(e => e.BaseQuantity)
                    .HasColumnName("base_quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.BaseUnitId).HasColumnName("base_unit_id");

                entity.Property(e => e.InventoryTransferDeliveryId).HasColumnName("inventory_transfer_delivery_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.RequestDate)
                    .HasColumnName("request_date")
                    .HasColumnType("date");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.BaseUnit)
                    .WithMany(p => p.InventoryTransferDeliveryDetailBaseUnits)
                    .HasForeignKey(d => d.BaseUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__base___25918339");

                entity.HasOne(d => d.InventoryTransferDelivery)
                    .WithMany(p => p.InventoryTransferDeliveryDetails)
                    .HasForeignKey(d => d.InventoryTransferDeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__inven__22B5168E");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.InventoryTransferDeliveryDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__item___23A93AC7");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.InventoryTransferDeliveryDetailUnits)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__unit___249D5F00");
            });

            modelBuilder.Entity<InventoryTransferRequest>(entity =>
            {
                entity.ToTable("inventory_transfer_requests", "inventory");

                entity.Property(e => e.InventoryTransferRequestId).HasColumnName("inventory_transfer_request_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.AuthorizationReason)
                    .HasColumnName("authorization_reason")
                    .HasMaxLength(500);

                entity.Property(e => e.Authorized).HasColumnName("authorized");

                entity.Property(e => e.AuthorizedByUserId).HasColumnName("authorized_by_user_id");

                entity.Property(e => e.AuthorizedOn).HasColumnName("authorized_on");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Delivered).HasColumnName("delivered");

                entity.Property(e => e.DeliveredByUserId).HasColumnName("delivered_by_user_id");

                entity.Property(e => e.DeliveredOn).HasColumnName("delivered_on");

                entity.Property(e => e.DeliveryMemo)
                    .HasColumnName("delivery_memo")
                    .HasMaxLength(500);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.ReceiptMemo)
                    .HasColumnName("receipt_memo")
                    .HasMaxLength(500);

                entity.Property(e => e.Received).HasColumnName("received");

                entity.Property(e => e.ReceivedByUserId).HasColumnName("received_by_user_id");

                entity.Property(e => e.ReceivedOn).HasColumnName("received_on");

                entity.Property(e => e.ReferenceNumber)
                    .HasColumnName("reference_number")
                    .HasMaxLength(24);

                entity.Property(e => e.Rejected).HasColumnName("rejected");

                entity.Property(e => e.RejectedByUserId).HasColumnName("rejected_by_user_id");

                entity.Property(e => e.RejectedOn).HasColumnName("rejected_on");

                entity.Property(e => e.RejectionReason)
                    .HasColumnName("rejection_reason")
                    .HasMaxLength(500);

                entity.Property(e => e.RequestDate)
                    .HasColumnName("request_date")
                    .HasColumnType("date");

                entity.Property(e => e.StatementReference)
                    .HasColumnName("statement_reference")
                    .HasMaxLength(2000);

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.TransactionTimestamp)
                    .HasColumnName("transaction_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.InventoryTransferRequestAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__inventory__audit__0EAE1DE1");

                entity.HasOne(d => d.AuthorizedByUser)
                    .WithMany(p => p.InventoryTransferRequestAuthorizedByUsers)
                    .HasForeignKey(d => d.AuthorizedByUserId)
                    .HasConstraintName("FK__inventory__autho__08012052");

                entity.HasOne(d => d.DeliveredByUser)
                    .WithMany(p => p.InventoryTransferRequestDeliveredByUsers)
                    .HasForeignKey(d => d.DeliveredByUserId)
                    .HasConstraintName("FK__inventory__deliv__0DB9F9A8");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.InventoryTransferRequests)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__offic__033C6B35");

                entity.HasOne(d => d.ReceivedByUser)
                    .WithMany(p => p.InventoryTransferRequestReceivedByUsers)
                    .HasForeignKey(d => d.ReceivedByUserId)
                    .HasConstraintName("FK__inventory__recei__0BD1B136");

                entity.HasOne(d => d.RejectedByUser)
                    .WithMany(p => p.InventoryTransferRequestRejectedByUsers)
                    .HasForeignKey(d => d.RejectedByUserId)
                    .HasConstraintName("FK__inventory__rejec__09E968C4");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.InventoryTransferRequests)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__store__0524B3A7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.InventoryTransferRequestUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__user___04308F6E");
            });

            modelBuilder.Entity<InventoryTransferRequestDetail>(entity =>
            {
                entity.ToTable("inventory_transfer_request_details", "inventory");

                entity.Property(e => e.InventoryTransferRequestDetailId).HasColumnName("inventory_transfer_request_detail_id");

                entity.Property(e => e.BaseQuantity)
                    .HasColumnName("base_quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.BaseUnitId).HasColumnName("base_unit_id");

                entity.Property(e => e.InventoryTransferRequestId).HasColumnName("inventory_transfer_request_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.RequestDate)
                    .HasColumnName("request_date")
                    .HasColumnType("date");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.BaseUnit)
                    .WithMany(p => p.InventoryTransferRequestDetailBaseUnits)
                    .HasForeignKey(d => d.BaseUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__base___164F3FA9");

                entity.HasOne(d => d.InventoryTransferRequest)
                    .WithMany(p => p.InventoryTransferRequestDetails)
                    .HasForeignKey(d => d.InventoryTransferRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__inven__1372D2FE");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.InventoryTransferRequestDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__item___1466F737");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.InventoryTransferRequestDetailUnits)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__unit___155B1B70");
            });

            modelBuilder.ApplyConfiguration(new ItemConfiguration());

            modelBuilder.Entity<ItemCostPrice>(entity =>
            {
                entity.ToTable("item_cost_prices", "purchase");

                entity.HasIndex(e => new { e.ItemId, e.UnitId, e.SupplierId })
                    .HasName("item_cost_prices_item_id_unit_id_supplier_id")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.ItemCostPriceId).HasColumnName("item_cost_price_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IncludesTax).HasColumnName("includes_tax");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.LeadTimeInDays).HasColumnName("lead_time_in_days");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ItemCostPrices)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__item_cost__audit__2FDA0782");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemCostPrices)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_cost__item___2B155265");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ItemCostPrices)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__item_cost__suppl__2CFD9AD7");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.ItemCostPrices)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_cost__unit___2C09769E");
            });

            modelBuilder.Entity<ItemGroup>(entity =>
            {
                entity.ToTable("item_groups", "inventory");

                entity.HasIndex(e => e.ItemGroupCode)
                    .HasName("item_groups_item_group_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.ItemGroupName)
                    .HasName("item_groups_item_group_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.ItemGroupId).HasColumnName("item_group_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CostOfGoodsSoldAccountId).HasColumnName("cost_of_goods_sold_account_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExcludeFromPurchase).HasColumnName("exclude_from_purchase");

                entity.Property(e => e.ExcludeFromSales).HasColumnName("exclude_from_sales");

                entity.Property(e => e.InventoryAccountId).HasColumnName("inventory_account_id");

                entity.Property(e => e.ItemGroupCode)
                    .IsRequired()
                    .HasColumnName("item_group_code")
                    .HasMaxLength(24);

                entity.Property(e => e.ItemGroupName)
                    .IsRequired()
                    .HasColumnName("item_group_name")
                    .HasMaxLength(500);

                entity.Property(e => e.ParentItemGroupId).HasColumnName("parent_item_group_id");

                entity.Property(e => e.PurchaseAccountId).HasColumnName("purchase_account_id");

                entity.Property(e => e.PurchaseDiscountAccountId).HasColumnName("purchase_discount_account_id");

                entity.Property(e => e.SalesAccountId).HasColumnName("sales_account_id");

                entity.Property(e => e.SalesDiscountAccountId).HasColumnName("sales_discount_account_id");

                entity.Property(e => e.SalesReturnAccountId).HasColumnName("sales_return_account_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ItemGroups)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__item_grou__audit__22EA20B8");

                entity.HasOne(d => d.CostOfGoodsSoldAccount)
                    .WithMany(p => p.ItemGroupCostOfGoodsSoldAccounts)
                    .HasForeignKey(d => d.CostOfGoodsSoldAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_grou__cost___2101D846");

                entity.HasOne(d => d.InventoryAccount)
                    .WithMany(p => p.ItemGroupInventoryAccounts)
                    .HasForeignKey(d => d.InventoryAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_grou__inven__200DB40D");

                entity.HasOne(d => d.ParentItemGroup)
                    .WithMany(p => p.InverseParentItemGroup)
                    .HasForeignKey(d => d.ParentItemGroupId)
                    .HasConstraintName("FK__item_grou__paren__21F5FC7F");

                entity.HasOne(d => d.PurchaseAccount)
                    .WithMany(p => p.ItemGroupPurchaseAccounts)
                    .HasForeignKey(d => d.PurchaseAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_grou__purch__1E256B9B");

                entity.HasOne(d => d.PurchaseDiscountAccount)
                    .WithMany(p => p.ItemGroupPurchaseDiscountAccounts)
                    .HasForeignKey(d => d.PurchaseDiscountAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_grou__purch__1F198FD4");

                entity.HasOne(d => d.SalesAccount)
                    .WithMany(p => p.ItemGroupSalesAccounts)
                    .HasForeignKey(d => d.SalesAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_grou__sales__1B48FEF0");

                entity.HasOne(d => d.SalesDiscountAccount)
                    .WithMany(p => p.ItemGroupSalesDiscountAccounts)
                    .HasForeignKey(d => d.SalesDiscountAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_grou__sales__1C3D2329");

                entity.HasOne(d => d.SalesReturnAccount)
                    .WithMany(p => p.ItemGroupSalesReturnAccounts)
                    .HasForeignKey(d => d.SalesReturnAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_grou__sales__1D314762");
            });

            modelBuilder.Entity<ItemSellingPrice>(entity =>
            {
                entity.ToTable("item_selling_prices", "sales");

                entity.Property(e => e.ItemSellingPriceId).HasColumnName("item_selling_price_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CustomerTypeId).HasColumnName("customer_type_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IncludesTax).HasColumnName("includes_tax");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ItemSellingPrices)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__item_sell__audit__2FA4FD58");

                entity.HasOne(d => d.CustomerType)
                    .WithMany(p => p.ItemSellingPrices)
                    .HasForeignKey(d => d.CustomerTypeId)
                    .HasConstraintName("FK__item_sell__custo__2CC890AD");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemSellingPrices)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_sell__item___2AE0483B");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.ItemSellingPrices)
                    .HasForeignKey(d => d.PriceTypeId)
                    .HasConstraintName("FK__item_sell__price__2DBCB4E6");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.ItemSellingPrices)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_sell__unit___2BD46C74");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("item_types", "inventory");

                entity.HasIndex(e => e.ItemTypeCode)
                    .HasName("item_type_item_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.ItemTypeName)
                    .HasName("item_type_item_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsComponent).HasColumnName("is_component");

                entity.Property(e => e.ItemTypeCode)
                    .IsRequired()
                    .HasColumnName("item_type_code")
                    .HasMaxLength(12);

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasColumnName("item_type_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ItemTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__item_type__audit__2D67AF2B");
            });

            modelBuilder.Entity<ItemVariant>(entity =>
            {
                entity.ToTable("item_variants", "inventory");

                entity.Property(e => e.ItemVariantId).HasColumnName("item_variant_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.VariantId).HasColumnName("variant_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ItemVariants)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__item_vari__audit__36BC0F3B");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemVariants)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_vari__item___34D3C6C9");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.ItemVariants)
                    .HasForeignKey(d => d.VariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item_vari__varia__35C7EB02");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.ToTable("job_titles", "hrm");

                entity.HasIndex(e => e.JobTitleCode)
                    .HasName("job_titles_job_title_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.JobTitleName)
                    .HasName("job_titles_job_title_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.JobTitleId).HasColumnName("job_title_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JobTitleCode)
                    .IsRequired()
                    .HasColumnName("job_title_code")
                    .HasMaxLength(12);

                entity.Property(e => e.JobTitleName)
                    .IsRequired()
                    .HasColumnName("job_title_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.JobTitles)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__job_title__audit__2CDD9F46");
            });

            modelBuilder.Entity<JournalVerificationPolicy>(entity =>
            {
                entity.ToTable("journal_verification_policy", "finance");

                entity.Property(e => e.JournalVerificationPolicyId).HasColumnName("journal_verification_policy_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CanSelfVerify).HasColumnName("can_self_verify");

                entity.Property(e => e.CanVerify).HasColumnName("can_verify");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EffectiveFrom)
                    .HasColumnName("effective_from")
                    .HasColumnType("date");

                entity.Property(e => e.EndsOn)
                    .HasColumnName("ends_on")
                    .HasColumnType("date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.SelfVerificationLimit)
                    .HasColumnName("self_verification_limit")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VerificationLimit)
                    .HasColumnName("verification_limit")
                    .HasColumnType("numeric(30, 6)");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.JournalVerificationPolicyAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__journal_v__audit__52793849");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.JournalVerificationPolicies)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__journal_v__offic__4DB4832C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JournalVerificationPolicyUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__journal_v__user___4CC05EF3");
            });

            modelBuilder.Entity<Kanban>(entity =>
            {
                entity.ToTable("kanbans", "config");

                entity.Property(e => e.KanbanId).HasColumnName("kanban_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.KanbanName)
                    .IsRequired()
                    .HasColumnName("kanban_name")
                    .HasMaxLength(128);

                entity.Property(e => e.ObjectName)
                    .IsRequired()
                    .HasColumnName("object_name")
                    .HasMaxLength(128);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.KanbanAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__kanbans__audit_u__0697FACD");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KanbanUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__kanbans__user_id__05A3D694");
            });

            modelBuilder.Entity<KanbanDetail>(entity =>
            {
                entity.ToTable("kanban_details", "config");

                entity.HasIndex(e => new { e.KanbanId, e.ResourceId })
                    .HasName("kanban_details_kanban_id_resource_id_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.KanbanDetailId).HasColumnName("kanban_detail_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.KanbanId).HasColumnName("kanban_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ResourceId)
                    .IsRequired()
                    .HasColumnName("resource_id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.KanbanDetails)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__kanban_de__audit__0D44F85C");

                entity.HasOne(d => d.Kanban)
                    .WithMany(p => p.KanbanDetails)
                    .HasForeignKey(d => d.KanbanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__kanban_de__kanba__0B5CAFEA");
            });

            modelBuilder.Entity<LateFee>(entity =>
            {
                entity.ToTable("late_fee", "sales");

                entity.Property(e => e.LateFeeId).HasColumnName("late_fee_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsFlatAmount).HasColumnName("is_flat_amount");

                entity.Property(e => e.LateFeeCode)
                    .IsRequired()
                    .HasColumnName("late_fee_code")
                    .HasMaxLength(24);

                entity.Property(e => e.LateFeeName)
                    .IsRequired()
                    .HasColumnName("late_fee_name")
                    .HasMaxLength(500);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("numeric(30, 6)");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.LateFees)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__late_fee__accoun__1B9E04AB");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.LateFees)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__late_fee__audit___1C9228E4");
            });

            modelBuilder.Entity<LateFeePosting>(entity =>
            {
                entity.HasKey(e => e.TransactionMasterId);

                entity.ToTable("late_fee_postings", "sales");

                entity.Property(e => e.TransactionMasterId)
                    .HasColumnName("transaction_master_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.LateFeeTranId).HasColumnName("late_fee_tran_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.LateFeePostings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__late_fee___custo__224B023A");

                entity.HasOne(d => d.LateFeeTran)
                    .WithMany(p => p.LateFeePostingLateFeeTrans)
                    .HasForeignKey(d => d.LateFeeTranId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__late_fee___late___233F2673");

                entity.HasOne(d => d.TransactionMaster)
                    .WithOne(p => p.LateFeePostingTransactionMaster)
                    .HasForeignKey<LateFeePosting>(d => d.TransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__late_fee___trans__2156DE01");
            });

            modelBuilder.Entity<LeaveApplication>(entity =>
            {
                entity.ToTable("leave_applications", "hrm");

                entity.Property(e => e.LeaveApplicationId).HasColumnName("leave_application_id");

                entity.Property(e => e.AppliedOn)
                    .HasColumnName("applied_on")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.EnteredBy).HasColumnName("entered_by");

                entity.Property(e => e.LeaveTypeId).HasColumnName("leave_type_id");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(1000);

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.VerificationReason)
                    .HasColumnName("verification_reason")
                    .HasMaxLength(128);

                entity.Property(e => e.VerificationStatusId).HasColumnName("verification_status_id");

                entity.Property(e => e.VerifiedByUserId).HasColumnName("verified_by_user_id");

                entity.Property(e => e.VerifiedOn)
                    .HasColumnName("verified_on")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.LeaveApplicationAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__leave_app__audit__2AC04CAA");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveApplications)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__leave_app__emplo__25077354");

                entity.HasOne(d => d.EnteredByNavigation)
                    .WithMany(p => p.LeaveApplicationEnteredByNavigations)
                    .HasForeignKey(d => d.EnteredBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__leave_app__enter__26EFBBC6");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeaveApplications)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__leave_app__leave__25FB978D");

                entity.HasOne(d => d.VerificationStatus)
                    .WithMany(p => p.LeaveApplications)
                    .HasForeignKey(d => d.VerificationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__leave_app__verif__28D80438");

                entity.HasOne(d => d.VerifiedByUser)
                    .WithMany(p => p.LeaveApplicationVerifiedByUsers)
                    .HasForeignKey(d => d.VerifiedByUserId)
                    .HasConstraintName("FK__leave_app__verif__29CC2871");
            });

            modelBuilder.Entity<LeaveBenefit>(entity =>
            {
                entity.ToTable("leave_benefits", "hrm");

                entity.HasIndex(e => e.LeaveBenefitCode)
                    .HasName("leave_benefits_leave_benefit_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.LeaveBenefitName)
                    .HasName("leave_benefits_leave_benefit_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.LeaveBenefitId).HasColumnName("leave_benefit_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaveBenefitCode)
                    .IsRequired()
                    .HasColumnName("leave_benefit_code")
                    .HasMaxLength(12);

                entity.Property(e => e.LeaveBenefitName)
                    .IsRequired()
                    .HasColumnName("leave_benefit_name")
                    .HasMaxLength(128);

                entity.Property(e => e.TotalDays).HasColumnName("total_days");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.LeaveBenefits)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__leave_ben__audit__4F32B74A");
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.ToTable("leave_types", "hrm");

                entity.HasIndex(e => e.LeaveTypeCode)
                    .HasName("leave_types_leave_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.LeaveTypeName)
                    .HasName("leave_types_leave_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.LeaveTypeId).HasColumnName("leave_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LeaveTypeCode)
                    .IsRequired()
                    .HasColumnName("leave_type_code")
                    .HasMaxLength(12);

                entity.Property(e => e.LeaveTypeName)
                    .IsRequired()
                    .HasColumnName("leave_type_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.LeaveTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__leave_typ__audit__41D8BC2C");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("logins", "account");

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(500);

                entity.Property(e => e.Culture)
                    .IsRequired()
                    .HasColumnName("culture")
                    .HasMaxLength(12);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LoginTimestamp)
                    .HasColumnName("login_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.LoginAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__logins__audit_us__2180FB33");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.OfficeId)
                    .HasConstraintName("FK__logins__office_i__1EA48E88");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__logins__user_id__1DB06A4F");
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.ToTable("marital_statuses", "core");

                entity.HasIndex(e => e.MaritalStatusCode)
                    .HasName("UQ__marital___507BD4B59992DFB0")
                    .IsUnique();

                entity.Property(e => e.MaritalStatusId).HasColumnName("marital_status_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLegallyRecognizedMarriage).HasColumnName("is_legally_recognized_marriage");

                entity.Property(e => e.MaritalStatusCode)
                    .IsRequired()
                    .HasColumnName("marital_status_code")
                    .HasMaxLength(12);

                entity.Property(e => e.MaritalStatusName)
                    .IsRequired()
                    .HasColumnName("marital_status_name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menus", "core");

                entity.HasIndex(e => new { e.AppName, e.MenuName })
                    .HasName("menus_app_name_menu_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasColumnName("app_name")
                    .HasMaxLength(100);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.I18nKey)
                    .IsRequired()
                    .HasColumnName("i18n_key")
                    .HasMaxLength(200);

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(100);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasColumnName("menu_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ParentMenuId).HasColumnName("parent_menu_id");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AppNameNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.AppName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__menus__app_name__276EDEB3");

                entity.HasOne(d => d.ParentMenu)
                    .WithMany(p => p.InverseParentMenu)
                    .HasForeignKey(d => d.ParentMenuId)
                    .HasConstraintName("FK__menus__parent_me__286302EC");
            });

            modelBuilder.Entity<Menu1>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("menus", "website");

                entity.HasIndex(e => e.MenuName)
                    .HasName("menus_menu_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.MenuName)
                    .HasColumnName("menu_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Menu1)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__menus__audit_use__7908F585");
            });

            modelBuilder.Entity<MenuAccessPolicy>(entity =>
            {
                entity.ToTable("menu_access_policy", "auth");

                entity.HasIndex(e => new { e.OfficeId, e.MenuId, e.UserId })
                    .HasName("menu_access_policy_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.MenuAccessPolicyId).HasColumnName("menu_access_policy_id");

                entity.Property(e => e.AllowAccess).HasColumnName("allow_access");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DisallowAccess).HasColumnName("disallow_access");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.MenuAccessPolicyAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__menu_acce__audit__756D6ECB");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuAccessPolicies)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__menu_acce__menu___73852659");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.MenuAccessPolicies)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__menu_acce__offic__72910220");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MenuAccessPolicyUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__menu_acce__user___74794A92");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.ToTable("menu_items", "website");

                entity.Property(e => e.MenuItemId).HasColumnName("menu_item_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.ParentMenuItemId).HasColumnName("parent_menu_item_id");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Target)
                    .HasColumnName("target")
                    .HasMaxLength(20);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__menu_item__audit__019E3B86");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK__menu_item__conte__7FB5F314");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK__menu_item__menu___7DCDAAA2");

                entity.HasOne(d => d.ParentMenuItem)
                    .WithMany(p => p.InverseParentMenuItem)
                    .HasForeignKey(d => d.ParentMenuItemId)
                    .HasConstraintName("FK__menu_item__paren__00AA174D");
            });

            modelBuilder.Entity<MerchantFeeSetup>(entity =>
            {
                entity.ToTable("merchant_fee_setup", "finance");

                entity.HasIndex(e => new { e.MerchantAccountId, e.PaymentCardId })
                    .HasName("merchant_fee_setup_merchant_account_id_payment_card_id_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.MerchantFeeSetupId).HasColumnName("merchant_fee_setup_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CustomerPaysFee).HasColumnName("customer_pays_fee");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MerchantAccountId).HasColumnName("merchant_account_id");

                entity.Property(e => e.PaymentCardId).HasColumnName("payment_card_id");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.StatementReference)
                    .IsRequired()
                    .HasColumnName("statement_reference")
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.MerchantFeeSetups)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__merchant___accou__3B95D2F1");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.MerchantFeeSetups)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__merchant___audit__3D7E1B63");

                entity.HasOne(d => d.MerchantAccount)
                    .WithMany(p => p.MerchantFeeSetups)
                    .HasForeignKey(d => d.MerchantAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__merchant___merch__38B96646");

                entity.HasOne(d => d.PaymentCard)
                    .WithMany(p => p.MerchantFeeSetups)
                    .HasForeignKey(d => d.PaymentCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__merchant___payme__39AD8A7F");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("nationalities", "hrm");

                entity.HasIndex(e => e.NationalityCode)
                    .HasName("nationalities_nationality_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.NationalityName)
                    .HasName("nationalities_nationality_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.NationalityId).HasColumnName("nationality_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NationalityCode)
                    .HasColumnName("nationality_code")
                    .HasMaxLength(12);

                entity.Property(e => e.NationalityName)
                    .IsRequired()
                    .HasColumnName("nationality_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Nationalities)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__nationali__audit__1229A90A");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notifications", "core");

                entity.Property(e => e.NotificationId)
                    .HasColumnName("notification_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AssociatedApp)
                    .IsRequired()
                    .HasColumnName("associated_app")
                    .HasMaxLength(100);

                entity.Property(e => e.AssociatedMenuId).HasColumnName("associated_menu_id");

                entity.Property(e => e.EventTimestamp)
                    .HasColumnName("event_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FormattedText)
                    .HasColumnName("formatted_text")
                    .HasMaxLength(4000);

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(100);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.Tenant)
                    .HasColumnName("tenant")
                    .HasMaxLength(1000);

                entity.Property(e => e.ToLoginId).HasColumnName("to_login_id");

                entity.Property(e => e.ToRoleId).HasColumnName("to_role_id");

                entity.Property(e => e.ToUserId).HasColumnName("to_user_id");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(2000);

                entity.HasOne(d => d.AssociatedAppNavigation)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AssociatedApp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__notificat__assoc__4F7CD00D");

                entity.HasOne(d => d.AssociatedMenu)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AssociatedMenuId)
                    .HasConstraintName("FK__notificat__assoc__5070F446");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.OfficeId)
                    .HasConstraintName("FK__notificat__offic__4E88ABD4");
            });

            modelBuilder.Entity<NotificationStatus>(entity =>
            {
                entity.ToTable("notification_statuses", "core");

                entity.Property(e => e.NotificationStatusId)
                    .HasColumnName("notification_status_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastSeenOn)
                    .HasColumnName("last_seen_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.NotificationId).HasColumnName("notification_id");

                entity.Property(e => e.SeenBy).HasColumnName("seen_by");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.NotificationStatuses)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__notificat__notif__5441852A");
            });

            modelBuilder.ApplyConfiguration(new OfficeConfiguration());

            modelBuilder.Entity<OfficeHour>(entity =>
            {
                entity.ToTable("office_hours", "hrm");

                entity.Property(e => e.OfficeHourId).HasColumnName("office_hour_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BeginsFrom).HasColumnName("begins_from");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EndsOn).HasColumnName("ends_on");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.WeekDayId).HasColumnName("week_day_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.OfficeHours)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__office_ho__audit__4979DDF4");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.OfficeHours)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__office_ho__offic__469D7149");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.OfficeHours)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__office_ho__shift__47919582");

                entity.HasOne(d => d.WeekDay)
                    .WithMany(p => p.OfficeHours)
                    .HasForeignKey(d => d.WeekDayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__office_ho__week___4885B9BB");
            });

            modelBuilder.Entity<OpeningCash>(entity =>
            {
                entity.ToTable("opening_cash", "sales");

                entity.HasIndex(e => new { e.UserId, e.TransactionDate })
                    .HasName("opening_cash_transaction_date_user_id_uix")
                    .IsUnique();

                entity.Property(e => e.OpeningCashId).HasColumnName("opening_cash_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProvidedBy)
                    .IsRequired()
                    .HasColumnName("provided_by")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("transaction_date")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.OpeningCashAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__opening_c__audit__324C5FD9");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OpeningCashUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__opening_c__user___2E7BCEF5");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders", "purchase");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Cancelled).HasColumnName("cancelled");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnName("expected_delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.InternalMemo)
                    .HasColumnName("internal_memo")
                    .HasMaxLength(500);

                entity.Property(e => e.NontaxableTotal)
                    .HasColumnName("nontaxable_total")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.QuotationId).HasColumnName("quotation_id");

                entity.Property(e => e.ReferenceNumber)
                    .HasColumnName("reference_number")
                    .HasMaxLength(24);

                entity.Property(e => e.ShipperId).HasColumnName("shipper_id");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TaxableTotal)
                    .HasColumnName("taxable_total")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Terms)
                    .HasColumnName("terms")
                    .HasMaxLength(500);

                entity.Property(e => e.TransactionTimestamp)
                    .HasColumnName("transaction_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.OrderAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__orders__audit_us__691284DE");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__office_i__6265874F");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PriceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__price_ty__5F891AA4");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.QuotationId)
                    .HasConstraintName("FK__orders__quotatio__5CACADF9");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK__orders__shipper___607D3EDD");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__supplier__5E94F66B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__user_id__61716316");
            });

            modelBuilder.Entity<Order1>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("orders", "sales");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Cancelled).HasColumnName("cancelled");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnName("expected_delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.InternalMemo)
                    .HasColumnName("internal_memo")
                    .HasMaxLength(500);

                entity.Property(e => e.NontaxableTotal)
                    .HasColumnName("nontaxable_total")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.QuotationId).HasColumnName("quotation_id");

                entity.Property(e => e.ReferenceNumber)
                    .HasColumnName("reference_number")
                    .HasMaxLength(24);

                entity.Property(e => e.ShipperId).HasColumnName("shipper_id");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TaxableTotal)
                    .HasColumnName("taxable_total")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Terms)
                    .HasColumnName("terms")
                    .HasMaxLength(500);

                entity.Property(e => e.TransactionTimestamp)
                    .HasColumnName("transaction_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Order1AuditUser)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__orders__audit_us__7A0806B6");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order1)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__customer__6F8A7843");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Order1)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__office_i__735B0927");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.Order1)
                    .HasForeignKey(d => d.PriceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__price_ty__707E9C7C");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.Order1)
                    .HasForeignKey(d => d.QuotationId)
                    .HasConstraintName("FK__orders__quotatio__6DA22FD1");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Order1)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK__orders__shipper___7172C0B5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order1User)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__user_id__7266E4EE");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_details", "purchase");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.DiscountRate)
                    .HasColumnName("discount_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.IsTaxed).HasColumnName("is_taxed");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ShippingCharge)
                    .HasColumnName("shipping_charge")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__item___6ECB5E34");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__order__6DD739FB");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__unit___71A7CADF");
            });

            modelBuilder.Entity<OrderDetail1>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId);

                entity.ToTable("order_details", "sales");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.DiscountRate)
                    .HasColumnName("discount_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.IsTaxed).HasColumnName("is_taxed");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ShippingCharge)
                    .HasColumnName("shipping_charge")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderDetail1)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__item___7FC0E00C");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail1)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__order__7ECCBBD3");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.OrderDetail1)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__unit___029D4CB7");
            });

            modelBuilder.Entity<PayGrade>(entity =>
            {
                entity.ToTable("pay_grades", "hrm");

                entity.HasIndex(e => e.PayGradeCode)
                    .HasName("pay_grades_pay_grade_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.PayGradeName)
                    .HasName("pay_grades_pay_grade_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.PayGradeId).HasColumnName("pay_grade_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaximumSalary)
                    .HasColumnName("maximum_salary")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.MinimumSalary)
                    .HasColumnName("minimum_salary")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.PayGradeCode)
                    .IsRequired()
                    .HasColumnName("pay_grade_code")
                    .HasMaxLength(12);

                entity.Property(e => e.PayGradeName)
                    .IsRequired()
                    .HasColumnName("pay_grade_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.PayGrades)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__pay_grade__audit__347EC10E");
            });

            modelBuilder.Entity<PaymentCard>(entity =>
            {
                entity.ToTable("payment_cards", "finance");

                entity.HasIndex(e => e.PaymentCardCode)
                    .HasName("payment_cards_payment_card_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.PaymentCardName)
                    .HasName("payment_cards_payment_card_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.PaymentCardId).HasColumnName("payment_card_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CardTypeId).HasColumnName("card_type_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentCardCode)
                    .IsRequired()
                    .HasColumnName("payment_card_code")
                    .HasMaxLength(12);

                entity.Property(e => e.PaymentCardName)
                    .IsRequired()
                    .HasColumnName("payment_card_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.PaymentCards)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__payment_c__audit__33F4B129");

                entity.HasOne(d => d.CardType)
                    .WithMany(p => p.PaymentCards)
                    .HasForeignKey(d => d.CardTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__payment_c__card___33008CF0");
            });

            modelBuilder.Entity<PaymentTerm>(entity =>
            {
                entity.ToTable("payment_terms", "sales");

                entity.HasIndex(e => e.PaymentTermCode)
                    .HasName("payment_terms_payment_term_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.PaymentTermName)
                    .HasName("payment_terms_payment_term_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.PaymentTermId).HasColumnName("payment_term_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DueDays).HasColumnName("due_days");

                entity.Property(e => e.DueFrequencyId).HasColumnName("due_frequency_id");

                entity.Property(e => e.DueOnDate).HasColumnName("due_on_date");

                entity.Property(e => e.GracePeriod).HasColumnName("grace_period");

                entity.Property(e => e.LateFeeId).HasColumnName("late_fee_id");

                entity.Property(e => e.LateFeePostingFrequencyId).HasColumnName("late_fee_posting_frequency_id");

                entity.Property(e => e.PaymentTermCode)
                    .IsRequired()
                    .HasColumnName("payment_term_code")
                    .HasMaxLength(24);

                entity.Property(e => e.PaymentTermName)
                    .IsRequired()
                    .HasColumnName("payment_term_name")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.PaymentTerms)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__payment_t__audit__41C3AD93");

                entity.HasOne(d => d.DueFrequency)
                    .WithMany(p => p.PaymentTermDueFrequencies)
                    .HasForeignKey(d => d.DueFrequencyId)
                    .HasConstraintName("FK__payment_t__due_f__3DF31CAF");

                entity.HasOne(d => d.LateFee)
                    .WithMany(p => p.PaymentTerms)
                    .HasForeignKey(d => d.LateFeeId)
                    .HasConstraintName("FK__payment_t__late___3FDB6521");

                entity.HasOne(d => d.LateFeePostingFrequency)
                    .WithMany(p => p.PaymentTermLateFeePostingFrequencies)
                    .HasForeignKey(d => d.LateFeePostingFrequencyId)
                    .HasConstraintName("FK__payment_t__late___40CF895A");
            });

            modelBuilder.Entity<PriceType>(entity =>
            {
                entity.ToTable("price_types", "purchase");

                entity.HasIndex(e => e.PriceTypeCode)
                    .HasName("price_types_price_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.PriceTypeName)
                    .HasName("price_types_price_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PriceTypeCode)
                    .IsRequired()
                    .HasColumnName("price_type_code")
                    .HasMaxLength(24);

                entity.Property(e => e.PriceTypeName)
                    .IsRequired()
                    .HasColumnName("price_type_name")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.PriceTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__price_typ__audit__26509D48");
            });

            modelBuilder.Entity<PriceType1>(entity =>
            {
                entity.HasKey(e => e.PriceTypeId);

                entity.ToTable("price_types", "sales");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PriceTypeCode)
                    .IsRequired()
                    .HasColumnName("price_type_code")
                    .HasMaxLength(24);

                entity.Property(e => e.PriceTypeName)
                    .IsRequired()
                    .HasColumnName("price_type_name")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.PriceType1)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__price_typ__audit__261B931E");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("purchases", "purchase");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.CheckoutId).HasColumnName("checkout_id");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.HasOne(d => d.Checkout)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CheckoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchases__check__3C3FDE67");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.PriceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchases__price__3E2826D9");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchases__suppl__3D3402A0");
            });

            modelBuilder.Entity<PurchaseReturn>(entity =>
            {
                entity.ToTable("purchase_returns", "purchase");

                entity.Property(e => e.PurchaseReturnId).HasColumnName("purchase_return_id");

                entity.Property(e => e.CheckoutId).HasColumnName("checkout_id");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.HasOne(d => d.Checkout)
                    .WithMany(p => p.PurchaseReturns)
                    .HasForeignKey(d => d.CheckoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchase___check__41F8B7BD");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseReturns)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchase___purch__41049384");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PurchaseReturns)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchase___suppl__42ECDBF6");
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.ToTable("quotations", "purchase");

                entity.Property(e => e.QuotationId).HasColumnName("quotation_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Cancelled).HasColumnName("cancelled");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnName("expected_delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.InternalMemo)
                    .HasColumnName("internal_memo")
                    .HasMaxLength(500);

                entity.Property(e => e.NontaxableTotal)
                    .HasColumnName("nontaxable_total")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.ReferenceNumber)
                    .HasColumnName("reference_number")
                    .HasMaxLength(24);

                entity.Property(e => e.ShipperId).HasColumnName("shipper_id");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TaxableTotal)
                    .HasColumnName("taxable_total")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Terms)
                    .HasColumnName("terms")
                    .HasMaxLength(500);

                entity.Property(e => e.TransactionTimestamp)
                    .HasColumnName("transaction_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.QuotationAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__quotation__audit__513AFB4D");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Quotations)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__offic__4A8DFDBE");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.Quotations)
                    .HasForeignKey(d => d.PriceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__price__47B19113");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Quotations)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK__quotation__shipp__48A5B54C");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Quotations)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__suppl__46BD6CDA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuotationUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__user___4999D985");
            });

            modelBuilder.Entity<Quotation1>(entity =>
            {
                entity.HasKey(e => e.QuotationId);

                entity.ToTable("quotations", "sales");

                entity.Property(e => e.QuotationId).HasColumnName("quotation_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Cancelled).HasColumnName("cancelled");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnName("expected_delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.InternalMemo)
                    .HasColumnName("internal_memo")
                    .HasMaxLength(500);

                entity.Property(e => e.NontaxableTotal)
                    .HasColumnName("nontaxable_total")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.ReferenceNumber)
                    .HasColumnName("reference_number")
                    .HasMaxLength(24);

                entity.Property(e => e.ShipperId).HasColumnName("shipper_id");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TaxableTotal)
                    .HasColumnName("taxable_total")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Terms)
                    .HasColumnName("terms")
                    .HasMaxLength(500);

                entity.Property(e => e.TransactionTimestamp)
                    .HasColumnName("transaction_timestamp")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Quotation1AuditUser)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__quotation__audit__62307D25");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Quotation1)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__custo__57B2EEB2");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Quotation1)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__offic__5B837F96");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.Quotation1)
                    .HasForeignKey(d => d.PriceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__price__58A712EB");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Quotation1)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK__quotation__shipp__599B3724");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Quotation1User)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__user___5A8F5B5D");
            });

            modelBuilder.Entity<QuotationDetail>(entity =>
            {
                entity.ToTable("quotation_details", "purchase");

                entity.Property(e => e.QuotationDetailId).HasColumnName("quotation_detail_id");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.DiscountRate)
                    .HasColumnName("discount_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.IsTaxed).HasColumnName("is_taxed");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.QuotationId).HasColumnName("quotation_id");

                entity.Property(e => e.ShippingCharge)
                    .HasColumnName("shipping_charge")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.QuotationDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__item___56F3D4A3");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.QuotationDetails)
                    .HasForeignKey(d => d.QuotationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__quota__55FFB06A");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.QuotationDetails)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__unit___59D0414E");
            });

            modelBuilder.Entity<QuotationDetail1>(entity =>
            {
                entity.HasKey(e => e.QuotationDetailId);

                entity.ToTable("quotation_details", "sales");

                entity.Property(e => e.QuotationDetailId).HasColumnName("quotation_detail_id");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.DiscountRate)
                    .HasColumnName("discount_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.IsTaxed).HasColumnName("is_taxed");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.QuotationId).HasColumnName("quotation_id");

                entity.Property(e => e.ShippingCharge)
                    .HasColumnName("shipping_charge")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.QuotationDetail1)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__item___67E9567B");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.QuotationDetail1)
                    .HasForeignKey(d => d.QuotationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__quota__66F53242");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.QuotationDetail1)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quotation__unit___6AC5C326");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("registrations", "account");

                entity.HasIndex(e => e.Email)
                    .HasName("registrations_email_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.RegistrationId)
                    .HasColumnName("registration_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(500);

                entity.Property(e => e.Confirmed)
                    .HasColumnName("confirmed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConfirmedOn).HasColumnName("confirmed_on");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(500);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(100);

                entity.Property(e => e.RegisteredOn)
                    .HasColumnName("registered_on")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<ResetRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("reset_requests", "account");

                entity.Property(e => e.RequestId)
                    .HasColumnName("request_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(500);

                entity.Property(e => e.Confirmed)
                    .HasColumnName("confirmed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConfirmedOn).HasColumnName("confirmed_on");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(500);

                entity.Property(e => e.ExpiresOn)
                    .HasColumnName("expires_on")
                    .HasDefaultValueSql("(dateadd(day,(1),getutcdate()))");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(500);

                entity.Property(e => e.RequestedOn)
                    .HasColumnName("requested_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ResetRequestAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__reset_req__audit__0D7A0286");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ResetRequestUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__reset_req__user___09A971A2");
            });

            modelBuilder.Entity<Resignation>(entity =>
            {
                entity.ToTable("resignations", "hrm");

                entity.Property(e => e.ResignationId).HasColumnName("resignation_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DesiredResignDate)
                    .HasColumnName("desired_resign_date")
                    .HasColumnType("date");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasMaxLength(1000);

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EnteredBy).HasColumnName("entered_by");

                entity.Property(e => e.ForwardTo).HasColumnName("forward_to");

                entity.Property(e => e.NoticeDate)
                    .HasColumnName("notice_date")
                    .HasColumnType("date");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(128);

                entity.Property(e => e.VerificationReason)
                    .HasColumnName("verification_reason")
                    .HasMaxLength(128);

                entity.Property(e => e.VerificationStatusId).HasColumnName("verification_status_id");

                entity.Property(e => e.VerifiedByUserId).HasColumnName("verified_by_user_id");

                entity.Property(e => e.VerifiedOn)
                    .HasColumnName("verified_on")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.ResignationAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__resignati__audit__3449B6E4");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ResignationEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__resignati__emplo__30792600");

                entity.HasOne(d => d.EnteredByNavigation)
                    .WithMany(p => p.ResignationEnteredByNavigations)
                    .HasForeignKey(d => d.EnteredBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__resignati__enter__2F8501C7");

                entity.HasOne(d => d.ForwardToNavigation)
                    .WithMany(p => p.ResignationForwardToNavigations)
                    .HasForeignKey(d => d.ForwardTo)
                    .HasConstraintName("FK__resignati__forwa__316D4A39");

                entity.HasOne(d => d.VerificationStatus)
                    .WithMany(p => p.Resignations)
                    .HasForeignKey(d => d.VerificationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__resignati__verif__32616E72");

                entity.HasOne(d => d.VerifiedByUser)
                    .WithMany(p => p.ResignationVerifiedByUsers)
                    .HasForeignKey(d => d.VerifiedByUserId)
                    .HasConstraintName("FK__resignati__verif__335592AB");
            });

            modelBuilder.Entity<Return>(entity =>
            {
                entity.ToTable("returns", "sales");

                entity.Property(e => e.ReturnId).HasColumnName("return_id");

                entity.Property(e => e.CheckoutId).HasColumnName("checkout_id");

                entity.Property(e => e.CounterId).HasColumnName("counter_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.IsCredit).HasColumnName("is_credit");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.ReturnTransactionMasterId).HasColumnName("return_transaction_master_id");

                entity.Property(e => e.SalesId).HasColumnName("sales_id");

                entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

                entity.HasOne(d => d.Checkout)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.CheckoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__returns__checkou__26DAAD2D");

                entity.HasOne(d => d.Counter)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.CounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__returns__counter__29B719D8");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__returns__custome__2AAB3E11");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.PriceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__returns__price_t__2B9F624A");

                entity.HasOne(d => d.ReturnTransactionMaster)
                    .WithMany(p => p.ReturnReturnTransactionMasters)
                    .HasForeignKey(d => d.ReturnTransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__returns__return___28C2F59F");

                entity.HasOne(d => d.Sales)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.SalesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__returns__sales_i__25E688F4");

                entity.HasOne(d => d.TransactionMaster)
                    .WithMany(p => p.ReturnTransactionMasters)
                    .HasForeignKey(d => d.TransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__returns__transac__27CED166");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles", "account");

                entity.HasIndex(e => e.RoleName)
                    .HasName("UQ__roles__783254B1A0BC1C3C")
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsAdministrator).HasColumnName("is_administrator");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__roles__audit_use__05D8E0BE");
            });

            modelBuilder.Entity<Role1>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("roles", "hrm");

                entity.HasIndex(e => e.RoleCode)
                    .HasName("roles_role_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.RoleName)
                    .HasName("roles_role_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RoleCode)
                    .IsRequired()
                    .HasColumnName("role_code")
                    .HasMaxLength(12);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Role1)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__roles__audit_use__0D64F3ED");
            });

            modelBuilder.Entity<Routine>(entity =>
            {
                entity.ToTable("routines", "finance");

                entity.HasIndex(e => e.RoutineCode)
                    .HasName("routines_routine_code_uix")
                    .IsUnique();

                entity.HasIndex(e => e.RoutineName)
                    .HasName("UQ__routines__380179507C05F3EA")
                    .IsUnique();

                entity.Property(e => e.RoutineId).HasColumnName("routine_id");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.RoutineCode)
                    .IsRequired()
                    .HasColumnName("routine_code")
                    .HasMaxLength(48);

                entity.Property(e => e.RoutineName)
                    .IsRequired()
                    .HasColumnName("routine_name")
                    .HasMaxLength(128);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SalesId);

                entity.ToTable("sales", "sales");

                entity.HasIndex(e => new { e.FiscalYearCode, e.InvoiceNumber })
                    .HasName("sales_invoice_number_fiscal_year_uix")
                    .IsUnique();

                entity.Property(e => e.SalesId).HasColumnName("sales_id");

                entity.Property(e => e.CashRepositoryId).HasColumnName("cash_repository_id");

                entity.Property(e => e.Change)
                    .HasColumnName("change")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.CheckAmount)
                    .HasColumnName("check_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.CheckBankName)
                    .HasColumnName("check_bank_name")
                    .HasMaxLength(1000);

                entity.Property(e => e.CheckDate)
                    .HasColumnName("check_date")
                    .HasColumnType("date");

                entity.Property(e => e.CheckNumber)
                    .HasColumnName("check_number")
                    .HasMaxLength(100);

                entity.Property(e => e.CheckoutId).HasColumnName("checkout_id");

                entity.Property(e => e.CounterId).HasColumnName("counter_id");

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.CreditSettled).HasColumnName("credit_settled");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.FiscalYearCode)
                    .IsRequired()
                    .HasColumnName("fiscal_year_code")
                    .HasMaxLength(12);

                entity.Property(e => e.GiftCardId).HasColumnName("gift_card_id");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.IsCredit).HasColumnName("is_credit");

                entity.Property(e => e.IsFlatDiscount).HasColumnName("is_flat_discount");

                entity.Property(e => e.PaymentTermId).HasColumnName("payment_term_id");

                entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");

                entity.Property(e => e.ReceiptTransactionMasterId).HasColumnName("receipt_transaction_master_id");

                entity.Property(e => e.RewardPoints)
                    .HasColumnName("reward_points")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.SalesOrderId).HasColumnName("sales_order_id");

                entity.Property(e => e.SalesQuotationId).HasColumnName("sales_quotation_id");

                entity.Property(e => e.SalespersonId).HasColumnName("salesperson_id");

                entity.Property(e => e.Tender)
                    .HasColumnName("tender")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("total_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TotalDiscountAmount)
                    .HasColumnName("total_discount_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

                entity.HasOne(d => d.CashRepository)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CashRepositoryId)
                    .HasConstraintName("FK__sales__cash_repo__0E0EFF63");

                entity.HasOne(d => d.Checkout)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CheckoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__checkout___13C7D8B9");

                entity.HasOne(d => d.Counter)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__counter_i__14BBFCF2");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CouponId)
                    .HasConstraintName("FK__sales__coupon_id__1798699D");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__sales__customer___15B0212B");

                entity.HasOne(d => d.FiscalYearCodeNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.FiscalYearCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__fiscal_ye__0D1ADB2A");

                entity.HasOne(d => d.GiftCard)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.GiftCardId)
                    .HasConstraintName("FK__sales__gift_card__1A74D648");

                entity.HasOne(d => d.PaymentTerm)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.PaymentTermId)
                    .HasConstraintName("FK__sales__payment_t__1980B20F");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.PriceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__price_typ__0F03239C");

                entity.HasOne(d => d.ReceiptTransactionMaster)
                    .WithMany(p => p.SaleReceiptTransactionMasters)
                    .HasForeignKey(d => d.ReceiptTransactionMasterId)
                    .HasConstraintName("FK__sales__receipt_t__11DF9047");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SalesOrderId)
                    .HasConstraintName("FK__sales__sales_ord__0FF747D5");

                entity.HasOne(d => d.SalesQuotation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SalesQuotationId)
                    .HasConstraintName("FK__sales__sales_quo__10EB6C0E");

                entity.HasOne(d => d.Salesperson)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SalespersonId)
                    .HasConstraintName("FK__sales__salespers__16A44564");

                entity.HasOne(d => d.TransactionMaster)
                    .WithMany(p => p.SaleTransactionMasters)
                    .HasForeignKey(d => d.TransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__transacti__12D3B480");
            });

            modelBuilder.Entity<SerialNumber>(entity =>
            {
                entity.ToTable("serial_numbers", "inventory");

                entity.Property(e => e.SerialNumberId).HasColumnName("serial_number_id");

                entity.Property(e => e.BatchNumber)
                    .IsRequired()
                    .HasColumnName("batch_number")
                    .HasMaxLength(50);

                entity.Property(e => e.CheckoutId).HasColumnName("checkout_id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.SalesTransactionId).HasColumnName("sales_transaction_id");

                entity.Property(e => e.SerialNumber1)
                    .IsRequired()
                    .HasColumnName("serial_number")
                    .HasMaxLength(150);

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("transaction_type")
                    .HasMaxLength(2);

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.Checkout)
                    .WithMany(p => p.SerialNumbers)
                    .HasForeignKey(d => d.CheckoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__serial_nu__check__49CEE3AF");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SerialNumbers)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__serial_nu__item___46F27704");

                entity.HasOne(d => d.SalesTransaction)
                    .WithMany(p => p.SerialNumbers)
                    .HasForeignKey(d => d.SalesTransactionId)
                    .HasConstraintName("FK__serial_nu__sales__4AC307E8");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.SerialNumbers)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__serial_nu__store__48DABF76");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.SerialNumbers)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__serial_nu__unit___47E69B3D");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("shifts", "hrm");

                entity.HasIndex(e => e.ShiftCode)
                    .HasName("shifts_shift_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.ShiftName)
                    .HasName("shifts_shift_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BeginsFrom).HasColumnName("begins_from");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EndsOn).HasColumnName("ends_on");

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasColumnName("shift_code")
                    .HasMaxLength(12);

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasColumnName("shift_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__shifts__audit_us__3B2BBE9D");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("shippers", "inventory");

                entity.HasIndex(e => e.ShipperCode)
                    .HasName("shippers_shipper_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.ShipperName)
                    .HasName("shippers_shipper_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.ShipperId).HasColumnName("shipper_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("address_line_1")
                    .HasMaxLength(128);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line_2")
                    .HasMaxLength(128);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Cell)
                    .HasColumnName("cell")
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
                    .HasMaxLength(128);

                entity.Property(e => e.ContactAddressLine1)
                    .HasColumnName("contact_address_line_1")
                    .HasMaxLength(128);

                entity.Property(e => e.ContactAddressLine2)
                    .HasColumnName("contact_address_line_2")
                    .HasMaxLength(128);

                entity.Property(e => e.ContactCell)
                    .HasColumnName("contact_cell")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactCity)
                    .HasColumnName("contact_city")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactCountry)
                    .HasColumnName("contact_country")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("contact_email")
                    .HasMaxLength(128);

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("contact_person")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("contact_phone")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactPoBox)
                    .HasColumnName("contact_po_box")
                    .HasMaxLength(128);

                entity.Property(e => e.ContactState)
                    .HasColumnName("contact_state")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactStreet)
                    .HasColumnName("contact_street")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.CstNumber)
                    .HasColumnName("cst_number")
                    .HasMaxLength(50);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(128);

                entity.Property(e => e.FactoryAddress)
                    .HasColumnName("factory_address")
                    .HasMaxLength(250);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(50);

                entity.Property(e => e.PanNumber)
                    .HasColumnName("pan_number")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.PoBox)
                    .HasColumnName("po_box")
                    .HasMaxLength(128);

                entity.Property(e => e.ShipperCode)
                    .HasColumnName("shipper_code")
                    .HasMaxLength(24);

                entity.Property(e => e.ShipperName)
                    .HasColumnName("shipper_name")
                    .HasMaxLength(150);

                entity.Property(e => e.SstNumber)
                    .HasColumnName("sst_number")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Shippers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shippers__accoun__60E75331");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Shippers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__shippers__audit___61DB776A");
            });

            modelBuilder.Entity<SmsQueue>(entity =>
            {
                entity.HasKey(e => e.QueueId);

                entity.ToTable("sms_queue", "config");

                entity.Property(e => e.QueueId).HasColumnName("queue_id");

                entity.Property(e => e.AddedOn)
                    .HasColumnName("added_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ApplicationName)
                    .HasColumnName("application_name")
                    .HasMaxLength(256);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Canceled).HasColumnName("canceled");

                entity.Property(e => e.CanceledOn).HasColumnName("canceled_on");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Delivered).HasColumnName("delivered");

                entity.Property(e => e.DeliveredOn).HasColumnName("delivered_on");

                entity.Property(e => e.FromName)
                    .IsRequired()
                    .HasColumnName("from_name")
                    .HasMaxLength(256);

                entity.Property(e => e.FromNumber)
                    .IsRequired()
                    .HasColumnName("from_number")
                    .HasMaxLength(256);

                entity.Property(e => e.IsTest).HasColumnName("is_test");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.Property(e => e.SendOn)
                    .HasColumnName("send_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.SendTo)
                    .IsRequired()
                    .HasColumnName("send_to")
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasMaxLength(256);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.SmsQueues)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__sms_queue__audit__29E1370A");
            });

            modelBuilder.Entity<SmtpConfig>(entity =>
            {
                entity.ToTable("smtp_configs", "config");

                entity.HasIndex(e => e.ConfigurationName)
                    .HasName("UQ__smtp_con__8F784E0F0B1E5676")
                    .IsUnique();

                entity.Property(e => e.SmtpConfigId).HasColumnName("smtp_config_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.ConfigurationName)
                    .IsRequired()
                    .HasColumnName("configuration_name")
                    .HasMaxLength(256);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.FromDisplayName)
                    .IsRequired()
                    .HasColumnName("from_display_name")
                    .HasMaxLength(256);

                entity.Property(e => e.FromEmailAddress)
                    .IsRequired()
                    .HasColumnName("from_email_address")
                    .HasMaxLength(256);

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.SmtpEnableSsl)
                    .IsRequired()
                    .HasColumnName("smtp_enable_ssl")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SmtpHost)
                    .IsRequired()
                    .HasColumnName("smtp_host")
                    .HasMaxLength(256);

                entity.Property(e => e.SmtpPassword)
                    .IsRequired()
                    .HasColumnName("smtp_password")
                    .HasMaxLength(256);

                entity.Property(e => e.SmtpPort)
                    .HasColumnName("smtp_port")
                    .HasDefaultValueSql("((587))");

                entity.Property(e => e.SmtpUsername)
                    .IsRequired()
                    .HasColumnName("smtp_username")
                    .HasMaxLength(256);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.SmtpConfigs)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__smtp_conf__audit__16CE6296");
            });

            modelBuilder.Entity<SocialNetwork>(entity =>
            {
                entity.ToTable("social_networks", "hrm");

                entity.Property(e => e.SocialNetworkId).HasColumnName("social_network_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BaseUrl)
                    .HasColumnName("base_url")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IconCssClass)
                    .HasColumnName("icon_css_class")
                    .HasMaxLength(128);

                entity.Property(e => e.SocialNetworkName)
                    .IsRequired()
                    .HasColumnName("social_network_name")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.SocialNetworks)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__social_ne__audit__03DB89B3");
            });

            modelBuilder.ApplyConfiguration(new StoreConfiguration());

            modelBuilder.Entity<StoreType>(entity =>
            {
                entity.ToTable("store_types", "inventory");

                entity.HasIndex(e => e.StoreTypeCode)
                    .HasName("store_types_store_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.StoreTypeName)
                    .HasName("store_types_store_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.StoreTypeId).HasColumnName("store_type_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StoreTypeCode)
                    .IsRequired()
                    .HasColumnName("store_type_code")
                    .HasMaxLength(12);

                entity.Property(e => e.StoreTypeName)
                    .IsRequired()
                    .HasColumnName("store_type_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.StoreTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__store_typ__audit__46335CF5");
            });

            modelBuilder.ApplyConfiguration(new SupplierCofiguration());

            modelBuilder.Entity<SupplierPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("supplier_payments", "purchase");

                entity.HasIndex(e => e.CashRepositoryId)
                    .HasName("supplier_payments_cash_repository_id_inx");

                entity.HasIndex(e => e.CurrencyCode)
                    .HasName("supplier_payments_currency_code_inx");

                entity.HasIndex(e => e.PostedDate)
                    .HasName("supplier_payments_posted_date_inx");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("supplier_payments_supplier_id_inx");

                entity.HasIndex(e => e.TransactionMasterId)
                    .HasName("supplier_payments_transaction_master_id_inx");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.BankId).HasColumnName("bank_id");

                entity.Property(e => e.BankInstrumentCode)
                    .HasColumnName("bank_instrument_code")
                    .HasMaxLength(500);

                entity.Property(e => e.BankTransactionCode)
                    .HasColumnName("bank_transaction_code")
                    .HasMaxLength(500);

                entity.Property(e => e.CashRepositoryId).HasColumnName("cash_repository_id");

                entity.Property(e => e.Change)
                    .HasColumnName("change")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.CheckAmount)
                    .HasColumnName("check_amount")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.CheckBankName)
                    .HasColumnName("check_bank_name")
                    .HasMaxLength(1000);

                entity.Property(e => e.CheckDate)
                    .HasColumnName("check_date")
                    .HasColumnType("date");

                entity.Property(e => e.CheckNumber)
                    .HasColumnName("check_number")
                    .HasMaxLength(100);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currency_code")
                    .HasMaxLength(12);

                entity.Property(e => e.ErCredit)
                    .HasColumnName("er_credit")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.ErDebit)
                    .HasColumnName("er_debit")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.PostedDate)
                    .HasColumnName("posted_date")
                    .HasColumnType("date");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Tender)
                    .HasColumnName("tender")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.SupplierPayments)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK__supplier___bank___7A3D10E0");

                entity.HasOne(d => d.CashRepository)
                    .WithMany(p => p.SupplierPayments)
                    .HasForeignKey(d => d.CashRepositoryId)
                    .HasConstraintName("FK__supplier___cash___7948ECA7");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.SupplierPayments)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supplier___curre__766C7FFC");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierPayments)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supplier___suppl__75785BC3");

                entity.HasOne(d => d.TransactionMaster)
                    .WithMany(p => p.SupplierPayments)
                    .HasForeignKey(d => d.TransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supplier___trans__7484378A");
            });

            modelBuilder.Entity<SupplierType>(entity =>
            {
                entity.ToTable("supplier_types", "inventory");

                entity.HasIndex(e => e.SupplierTypeCode)
                    .HasName("supplier_types_supplier_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.SupplierTypeName)
                    .HasName("supplier_types_supplier_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.SupplierTypeId).HasColumnName("supplier_type_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplierTypeCode)
                    .IsRequired()
                    .HasColumnName("supplier_type_code")
                    .HasMaxLength(24);

                entity.Property(e => e.SupplierTypeName)
                    .IsRequired()
                    .HasColumnName("supplier_type_name")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.SupplierTypes)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supplier___accou__7EACC042");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.SupplierTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__supplier___audit__7FA0E47B");
            });

            modelBuilder.Entity<SupplierwiseCostPrice>(entity =>
            {
                entity.HasKey(e => e.CostPriceId);

                entity.ToTable("supplierwise_cost_prices", "purchase");

                entity.Property(e => e.CostPriceId).HasColumnName("cost_price_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.SupplierwiseCostPrices)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__supplierw__audit__377B294A");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SupplierwiseCostPrices)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supplierw__item___349EBC9F");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierwiseCostPrices)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supplierw__suppl__3592E0D8");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.SupplierwiseCostPrices)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supplierw__unit___36870511");
            });

            modelBuilder.Entity<TaxSetup>(entity =>
            {
                entity.ToTable("tax_setups", "finance");

                entity.HasIndex(e => e.OfficeId)
                    .HasName("tax_setup_office_id_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.TaxSetupId).HasColumnName("tax_setup_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IncomeTaxAccountId).HasColumnName("income_tax_account_id");

                entity.Property(e => e.IncomeTaxRate)
                    .HasColumnName("income_tax_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.SalesTaxAccountId).HasColumnName("sales_tax_account_id");

                entity.Property(e => e.SalesTaxRate)
                    .HasColumnName("sales_tax_rate")
                    .HasColumnType("numeric(30, 6)");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.TaxSetups)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__tax_setup__audit__61BB7BD9");

                entity.HasOne(d => d.IncomeTaxAccount)
                    .WithMany(p => p.TaxSetupIncomeTaxAccounts)
                    .HasForeignKey(d => d.IncomeTaxAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tax_setup__incom__5FD33367");

                entity.HasOne(d => d.Office)
                    .WithOne(p => p.TaxSetup)
                    .HasForeignKey<TaxSetup>(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tax_setup__offic__5EDF0F2E");

                entity.HasOne(d => d.SalesTaxAccount)
                    .WithMany(p => p.TaxSetupSalesTaxAccounts)
                    .HasForeignKey(d => d.SalesTaxAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tax_setup__sales__60C757A0");
            });

            modelBuilder.Entity<Termination>(entity =>
            {
                entity.ToTable("terminations", "hrm");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("UQ__terminat__C52E0BA9D4C44039")
                    .IsUnique();

                entity.Property(e => e.TerminationId).HasColumnName("termination_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.ChangeStatusTo).HasColumnName("change_status_to");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasMaxLength(1000);

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ForwardTo).HasColumnName("forward_to");

                entity.Property(e => e.NoticeDate)
                    .HasColumnName("notice_date")
                    .HasColumnType("date");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(128);

                entity.Property(e => e.ServiceEndDate)
                    .HasColumnName("service_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.VerificationReason)
                    .HasColumnName("verification_reason")
                    .HasMaxLength(128);

                entity.Property(e => e.VerificationStatusId).HasColumnName("verification_status_id");

                entity.Property(e => e.VerifiedByUserId).HasColumnName("verified_by_user_id");

                entity.Property(e => e.VerifiedOn)
                    .HasColumnName("verified_on")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.TerminationAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__terminati__audit__3EC74557");

                entity.HasOne(d => d.ChangeStatusToNavigation)
                    .WithMany(p => p.Terminations)
                    .HasForeignKey(d => d.ChangeStatusTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__terminati__chang__3BEAD8AC");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.TerminationEmployee)
                    .HasForeignKey<Termination>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__terminati__emplo__3A02903A");

                entity.HasOne(d => d.ForwardToNavigation)
                    .WithMany(p => p.TerminationForwardToNavigations)
                    .HasForeignKey(d => d.ForwardTo)
                    .HasConstraintName("FK__terminati__forwa__3AF6B473");

                entity.HasOne(d => d.VerificationStatus)
                    .WithMany(p => p.Terminations)
                    .HasForeignKey(d => d.VerificationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__terminati__verif__3CDEFCE5");

                entity.HasOne(d => d.VerifiedByUser)
                    .WithMany(p => p.TerminationVerifiedByUsers)
                    .HasForeignKey(d => d.VerifiedByUserId)
                    .HasConstraintName("FK__terminati__verif__3DD3211E");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.ToTable("transaction_details", "finance");

                entity.HasIndex(e => new { e.TransactionMasterId, e.AmountInLocalCurrency, e.TranType })
                    .HasName("transaction_details_tran_type_inx");

                entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.AccountId })
                    .HasName("transaction_details_account_id_inx");

                entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.BookDate })
                    .HasName("transaction_details_book_date_inx");

                entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.CashRepositoryId })
                    .HasName("transaction_details_cash_repository_id_inx");

                entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.OfficeId })
                    .HasName("transaction_details_office_id_inx");

                entity.HasIndex(e => new { e.TransactionMasterId, e.TranType, e.AmountInLocalCurrency, e.ValueDate })
                    .HasName("transaction_details_value_date_inx");

                entity.Property(e => e.TransactionDetailId).HasColumnName("transaction_detail_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AmountInCurrency)
                    .HasColumnName("amount_in_currency")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.AmountInLocalCurrency)
                    .HasColumnName("amount_in_local_currency")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.BookDate)
                    .HasColumnName("book_date")
                    .HasColumnType("date");

                entity.Property(e => e.CashRepositoryId).HasColumnName("cash_repository_id");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currency_code")
                    .HasMaxLength(12);

                entity.Property(e => e.Er)
                    .HasColumnName("er")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.LocalCurrencyCode)
                    .IsRequired()
                    .HasColumnName("local_currency_code")
                    .HasMaxLength(12);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.ReconciliationMemo)
                    .HasColumnName("reconciliation_memo")
                    .HasMaxLength(2000);

                entity.Property(e => e.StatementReference)
                    .HasColumnName("statement_reference")
                    .HasMaxLength(2000);

                entity.Property(e => e.TranType)
                    .IsRequired()
                    .HasColumnName("tran_type")
                    .HasMaxLength(4);

                entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__accou__25A691D2");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__transacti__audit__2A6B46EF");

                entity.HasOne(d => d.CashRepository)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.CashRepositoryId)
                    .HasConstraintName("FK__transacti__cash___269AB60B");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.TransactionDetailCurrencyCodeNavigations)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__curre__278EDA44");

                entity.HasOne(d => d.LocalCurrencyCodeNavigation)
                    .WithMany(p => p.TransactionDetailLocalCurrencyCodeNavigations)
                    .HasForeignKey(d => d.LocalCurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__local__2882FE7D");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__offic__297722B6");

                entity.HasOne(d => d.TransactionMaster)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.TransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__trans__23BE4960");
            });

            modelBuilder.Entity<TransactionDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.ToTable("transaction_documents", "finance");

                entity.Property(e => e.DocumentId).HasColumnName("document_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FileExtension)
                    .HasColumnName("file_extension")
                    .HasMaxLength(50);

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasColumnName("file_path")
                    .HasMaxLength(2000);

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .HasMaxLength(2000);

                entity.Property(e => e.OriginalFileName)
                    .IsRequired()
                    .HasColumnName("original_file_name")
                    .HasMaxLength(500);

                entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.TransactionDocuments)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__transacti__audit__1EF99443");

                entity.HasOne(d => d.TransactionMaster)
                    .WithMany(p => p.TransactionDocuments)
                    .HasForeignKey(d => d.TransactionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__trans__1E05700A");
            });

            modelBuilder.Entity<TransactionMaster>(entity =>
            {
                entity.ToTable("transaction_master", "finance");

                entity.HasIndex(e => e.BookDate)
                    .HasName("transaction_master_book_date_inx")
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.CascadingTranId)
                    .HasName("transaction_master_cascading_tran_id_inx")
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.TransactionCode)
                    .HasName("transaction_master_transaction_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.ValueDate)
                    .HasName("transaction_master_value_date_inx")
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.TransactionMasterId).HasColumnName("transaction_master_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Book)
                    .IsRequired()
                    .HasColumnName("book")
                    .HasMaxLength(50);

                entity.Property(e => e.BookDate)
                    .HasColumnName("book_date")
                    .HasColumnType("date");

                entity.Property(e => e.CascadingTranId).HasColumnName("cascading_tran_id");

                entity.Property(e => e.CostCenterId).HasColumnName("cost_center_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastVerifiedOn).HasColumnName("last_verified_on");

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.ReferenceNumber)
                    .HasColumnName("reference_number")
                    .HasMaxLength(24);

                entity.Property(e => e.StatementReference)
                    .HasColumnName("statement_reference")
                    .HasMaxLength(2000);

                entity.Property(e => e.TransactionCode)
                    .IsRequired()
                    .HasColumnName("transaction_code")
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionCounter).HasColumnName("transaction_counter");

                entity.Property(e => e.TransactionTs)
                    .HasColumnName("transaction_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasColumnType("date");

                entity.Property(e => e.VerificationReason)
                    .IsRequired()
                    .HasColumnName("verification_reason")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VerificationStatusId).HasColumnName("verification_status_id");

                entity.Property(e => e.VerifiedByUserId).HasColumnName("verified_by_user_id");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.TransactionMasterAuditUsers)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__transacti__audit__1940BAED");

                entity.HasOne(d => d.CascadingTran)
                    .WithMany(p => p.InverseCascadingTran)
                    .HasForeignKey(d => d.CascadingTranId)
                    .HasConstraintName("FK__transacti__casca__184C96B4");

                entity.HasOne(d => d.CostCenter)
                    .WithMany(p => p.TransactionMasters)
                    .HasForeignKey(d => d.CostCenterId)
                    .HasConstraintName("FK__transacti__cost___1387E197");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.TransactionMasters)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__login__10AB74EC");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.TransactionMasters)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__offic__1293BD5E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TransactionMasterUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__user___119F9925");

                entity.HasOne(d => d.VerificationStatus)
                    .WithMany(p => p.TransactionMasters)
                    .HasForeignKey(d => d.VerificationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacti__verif__15702A09");

                entity.HasOne(d => d.VerifiedByUser)
                    .WithMany(p => p.TransactionMasterVerifiedByUsers)
                    .HasForeignKey(d => d.VerifiedByUserId)
                    .HasConstraintName("FK__transacti__verif__147C05D0");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_types", "finance");

                entity.HasIndex(e => e.TransactionTypeCode)
                    .HasName("transaction_types_transaction_type_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.TransactionTypeName)
                    .HasName("transaction_types_transaction_type_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.TransactionTypeId)
                    .HasColumnName("transaction_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransactionTypeCode)
                    .HasColumnName("transaction_type_code")
                    .HasMaxLength(4);

                entity.Property(e => e.TransactionTypeName)
                    .HasColumnName("transaction_type_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.TransactionTypes)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__transacti__audit__04459E07");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("units", "inventory");

                entity.HasIndex(e => e.UnitCode)
                    .HasName("units_unit_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.UnitName)
                    .HasName("units_unit_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitCode)
                    .IsRequired()
                    .HasColumnName("unit_code")
                    .HasMaxLength(24);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unit_name")
                    .HasMaxLength(500);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__units__audit_use__7152C524");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "account");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.LastBrowser)
                    .HasColumnName("last_browser")
                    .HasMaxLength(500);

                entity.Property(e => e.LastIp)
                    .HasColumnName("last_ip")
                    .HasMaxLength(500);

                entity.Property(e => e.LastSeenOn).HasColumnName("last_seen_on");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(500);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(100);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.InverseAuditUser)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__users__audit_use__02084FDA");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__office_id__7E37BEF6");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__role_id__7F2BE32F");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.ToTable("variants", "inventory");

                entity.HasIndex(e => e.VariantCode)
                    .HasName("variants_variant_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.VariantName)
                    .HasName("variants_variant_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.VariantId).HasColumnName("variant_id");

                entity.Property(e => e.AttributeId).HasColumnName("attribute_id");

                entity.Property(e => e.AttributeValue)
                    .IsRequired()
                    .HasColumnName("attribute_value")
                    .HasMaxLength(200);

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VariantCode)
                    .IsRequired()
                    .HasColumnName("variant_code")
                    .HasMaxLength(12);

                entity.Property(e => e.VariantName)
                    .IsRequired()
                    .HasColumnName("variant_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.Variants)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__variants__attrib__2F1AED73");

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.Variants)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__variants__audit___300F11AC");
            });

            modelBuilder.Entity<VerificationStatus>(entity =>
            {
                entity.ToTable("verification_statuses", "core");

                entity.Property(e => e.VerificationStatusId)
                    .HasColumnName("verification_status_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VerificationStatusName)
                    .IsRequired()
                    .HasColumnName("verification_status_name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<WeekDay>(entity =>
            {
                entity.ToTable("week_days", "core");

                entity.HasIndex(e => e.WeekDayCode)
                    .HasName("UQ__week_day__2FE49F53C8CB710A")
                    .IsUnique();

                entity.HasIndex(e => e.WeekDayName)
                    .HasName("UQ__week_day__D111B99E661B0F31")
                    .IsUnique();

                entity.Property(e => e.WeekDayId)
                    .HasColumnName("week_day_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WeekDayCode)
                    .IsRequired()
                    .HasColumnName("week_day_code")
                    .HasMaxLength(12);

                entity.Property(e => e.WeekDayName)
                    .IsRequired()
                    .HasColumnName("week_day_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WeekDay1>(entity =>
            {
                entity.HasKey(e => e.WeekDayId);

                entity.ToTable("week_days", "hrm");

                entity.HasIndex(e => e.WeekDayCode)
                    .HasName("week_days_week_day_code_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.HasIndex(e => e.WeekDayName)
                    .HasName("week_days_week_day_name_uix")
                    .IsUnique()
                    .HasFilter("([deleted]=(0))");

                entity.Property(e => e.WeekDayId)
                    .HasColumnName("week_day_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTs)
                    .HasColumnName("audit_ts")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserId).HasColumnName("audit_user_id");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WeekDayCode)
                    .IsRequired()
                    .HasColumnName("week_day_code")
                    .HasMaxLength(12);

                entity.Property(e => e.WeekDayName)
                    .IsRequired()
                    .HasColumnName("week_day_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AuditUser)
                    .WithMany(p => p.WeekDay1)
                    .HasForeignKey(d => d.AuditUserId)
                    .HasConstraintName("FK__week_days__audit__7775B2CE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
