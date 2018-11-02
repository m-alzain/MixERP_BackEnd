using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "account");

            migrationBuilder.EnsureSchema(
                name: "addressbook");

            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.EnsureSchema(
                name: "calendar");

            migrationBuilder.EnsureSchema(
                name: "config");

            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.EnsureSchema(
                name: "finance");

            migrationBuilder.EnsureSchema(
                name: "hrm");

            migrationBuilder.EnsureSchema(
                name: "inventory");

            migrationBuilder.EnsureSchema(
                name: "purchase");

            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.EnsureSchema(
                name: "social");

            migrationBuilder.EnsureSchema(
                name: "website");

            migrationBuilder.CreateTable(
                name: "installed_domains",
                schema: "account",
                columns: table => new
                {
                    domain_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    domain_name = table.Column<string>(maxLength: 500, nullable: true),
                    admin_email = table.Column<string>(maxLength: 500, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_installed_domains", x => x.domain_id);
                });

            migrationBuilder.CreateTable(
                name: "registrations",
                schema: "account",
                columns: table => new
                {
                    registration_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    phone = table.Column<string>(maxLength: 100, nullable: true),
                    password = table.Column<string>(maxLength: 500, nullable: true),
                    browser = table.Column<string>(maxLength: 500, nullable: true),
                    ip_address = table.Column<string>(maxLength: 50, nullable: true),
                    registered_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    confirmed = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    confirmed_on = table.Column<DateTimeOffset>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrations", x => x.registration_id);
                });

            migrationBuilder.CreateTable(
                name: "apps",
                schema: "core",
                columns: table => new
                {
                    app_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    app_name = table.Column<string>(maxLength: 100, nullable: false),
                    i18n_key = table.Column<string>(maxLength: 200, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    version_number = table.Column<string>(maxLength: 100, nullable: true),
                    publisher = table.Column<string>(maxLength: 500, nullable: true),
                    published_on = table.Column<DateTime>(type: "date", nullable: true),
                    icon = table.Column<string>(nullable: true),
                    landing_url = table.Column<string>(maxLength: 500, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apps", x => x.app_name);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "core",
                columns: table => new
                {
                    country_code = table.Column<string>(maxLength: 12, nullable: false),
                    country_name = table.Column<string>(maxLength: 100, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.country_code);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                schema: "core",
                columns: table => new
                {
                    currency_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    currency_symbol = table.Column<string>(maxLength: 12, nullable: false),
                    currency_name = table.Column<string>(maxLength: 48, nullable: false),
                    hundredth_name = table.Column<string>(maxLength: 48, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.currency_code);
                });

            migrationBuilder.CreateTable(
                name: "genders",
                schema: "core",
                columns: table => new
                {
                    gender_code = table.Column<string>(maxLength: 4, nullable: false),
                    gender_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders", x => x.gender_code);
                });

            migrationBuilder.CreateTable(
                name: "marital_statuses",
                schema: "core",
                columns: table => new
                {
                    marital_status_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    marital_status_code = table.Column<string>(maxLength: 12, nullable: false),
                    marital_status_name = table.Column<string>(maxLength: 128, nullable: false),
                    is_legally_recognized_marriage = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marital_statuses", x => x.marital_status_id);
                });

            migrationBuilder.CreateTable(
                name: "verification_statuses",
                schema: "core",
                columns: table => new
                {
                    verification_status_id = table.Column<short>(nullable: false),
                    verification_status_name = table.Column<string>(maxLength: 128, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verification_statuses", x => x.verification_status_id);
                });

            migrationBuilder.CreateTable(
                name: "week_days",
                schema: "core",
                columns: table => new
                {
                    week_day_id = table.Column<int>(nullable: false),
                    week_day_code = table.Column<string>(maxLength: 12, nullable: false),
                    week_day_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_week_days", x => x.week_day_id);
                });

            migrationBuilder.CreateTable(
                name: "routines",
                schema: "finance",
                columns: table => new
                {
                    routine_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    order = table.Column<int>(nullable: false),
                    routine_code = table.Column<string>(maxLength: 48, nullable: false),
                    routine_name = table.Column<string>(maxLength: 128, nullable: false),
                    status = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routines", x => x.routine_id);
                });

            migrationBuilder.CreateTable(
                name: "app_dependencies",
                schema: "core",
                columns: table => new
                {
                    app_dependency_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    app_name = table.Column<string>(maxLength: 100, nullable: true),
                    depends_on = table.Column<string>(maxLength: 100, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_dependencies", x => x.app_dependency_id);
                    table.ForeignKey(
                        name: "FK__app_depen__app_n__21B6055D",
                        column: x => x.app_name,
                        principalSchema: "core",
                        principalTable: "apps",
                        principalColumn: "app_name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__app_depen__depen__22AA2996",
                        column: x => x.depends_on,
                        principalSchema: "core",
                        principalTable: "apps",
                        principalColumn: "app_name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                schema: "core",
                columns: table => new
                {
                    menu_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sort = table.Column<int>(nullable: true),
                    i18n_key = table.Column<string>(maxLength: 200, nullable: false),
                    app_name = table.Column<string>(maxLength: 100, nullable: false),
                    menu_name = table.Column<string>(maxLength: 100, nullable: false),
                    url = table.Column<string>(maxLength: 500, nullable: true),
                    icon = table.Column<string>(maxLength: 100, nullable: true),
                    parent_menu_id = table.Column<int>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.menu_id);
                    table.ForeignKey(
                        name: "FK__menus__app_name__276EDEB3",
                        column: x => x.app_name,
                        principalSchema: "core",
                        principalTable: "apps",
                        principalColumn: "app_name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__menus__parent_me__286302EC",
                        column: x => x.parent_menu_id,
                        principalSchema: "core",
                        principalTable: "menus",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "access_tokens",
                schema: "account",
                columns: table => new
                {
                    access_token_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    issued_by = table.Column<string>(maxLength: 500, nullable: false),
                    audience = table.Column<string>(maxLength: 500, nullable: false),
                    ip_address = table.Column<string>(maxLength: 100, nullable: true),
                    user_agent = table.Column<string>(maxLength: 500, nullable: true),
                    header = table.Column<string>(maxLength: 500, nullable: true),
                    subject = table.Column<string>(maxLength: 500, nullable: true),
                    token_id = table.Column<string>(maxLength: 500, nullable: true),
                    application_id = table.Column<Guid>(nullable: true),
                    login_id = table.Column<long>(nullable: false),
                    client_token = table.Column<string>(nullable: true),
                    claims = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTimeOffset>(nullable: false),
                    expires_on = table.Column<DateTimeOffset>(nullable: false),
                    revoked = table.Column<bool>(nullable: false),
                    revoked_by = table.Column<int>(nullable: true),
                    revoked_on = table.Column<DateTimeOffset>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access_tokens", x => x.access_token_id);
                });

            migrationBuilder.CreateTable(
                name: "transaction_master",
                schema: "finance",
                columns: table => new
                {
                    transaction_master_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transaction_counter = table.Column<int>(nullable: false),
                    transaction_code = table.Column<string>(maxLength: 50, nullable: false),
                    book = table.Column<string>(maxLength: 50, nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    book_date = table.Column<DateTime>(type: "date", nullable: false),
                    transaction_ts = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    login_id = table.Column<long>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    cost_center_id = table.Column<int>(nullable: true),
                    reference_number = table.Column<string>(maxLength: 24, nullable: true),
                    statement_reference = table.Column<string>(maxLength: 2000, nullable: true),
                    last_verified_on = table.Column<DateTimeOffset>(nullable: true),
                    verified_by_user_id = table.Column<int>(nullable: true),
                    verification_status_id = table.Column<short>(nullable: false),
                    verification_reason = table.Column<string>(maxLength: 128, nullable: false, defaultValueSql: "('')"),
                    cascading_tran_id = table.Column<long>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_master", x => x.transaction_master_id);
                    table.ForeignKey(
                        name: "FK__transacti__casca__184C96B4",
                        column: x => x.cascading_tran_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__transacti__verif__15702A09",
                        column: x => x.verification_status_id,
                        principalSchema: "core",
                        principalTable: "verification_statuses",
                        principalColumn: "verification_status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "configuration_profiles",
                schema: "account",
                columns: table => new
                {
                    configuration_profile_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    profile_name = table.Column<string>(maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    allow_registration = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    registration_office_id = table.Column<int>(nullable: false),
                    registration_role_id = table.Column<int>(nullable: false),
                    allow_facebook_registration = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    allow_google_registration = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    google_signin_client_id = table.Column<string>(maxLength: 500, nullable: true),
                    google_signin_scope = table.Column<string>(maxLength: 500, nullable: true),
                    facebook_app_id = table.Column<string>(maxLength: 500, nullable: true),
                    facebook_scope = table.Column<string>(maxLength: 500, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuration_profiles", x => x.configuration_profile_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "account",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    password = table.Column<string>(maxLength: 500, nullable: true),
                    office_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    phone = table.Column<string>(maxLength: 100, nullable: true),
                    status = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    created_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    last_seen_on = table.Column<DateTimeOffset>(nullable: true),
                    last_ip = table.Column<string>(maxLength: 500, nullable: true),
                    last_browser = table.Column<string>(maxLength: 500, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__users__audit_use__02084FDA",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "applications",
                schema: "account",
                columns: table => new
                {
                    application_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    application_name = table.Column<string>(maxLength: 100, nullable: false),
                    display_name = table.Column<string>(maxLength: 100, nullable: true),
                    version_number = table.Column<string>(maxLength: 100, nullable: true),
                    publisher = table.Column<string>(maxLength: 100, nullable: false),
                    published_on = table.Column<DateTime>(type: "date", nullable: true),
                    application_url = table.Column<string>(maxLength: 500, nullable: true),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    browser_based_app = table.Column<bool>(nullable: false),
                    privacy_policy_url = table.Column<string>(maxLength: 500, nullable: true),
                    terms_of_service_url = table.Column<string>(maxLength: 500, nullable: true),
                    support_email = table.Column<string>(maxLength: 100, nullable: true),
                    culture = table.Column<string>(maxLength: 12, nullable: true),
                    redirect_url = table.Column<string>(maxLength: 500, nullable: true),
                    app_secret = table.Column<string>(maxLength: 500, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.application_id);
                    table.ForeignKey(
                        name: "FK__applicati__audit__282DF8C2",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fb_access_tokens",
                schema: "account",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    fb_user_id = table.Column<string>(maxLength: 500, nullable: true),
                    token = table.Column<string>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fb_access_tokens", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__fb_access__audit__1332DBDC",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__fb_access__user___123EB7A3",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "google_access_tokens",
                schema: "account",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    token = table.Column<string>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_google_access_tokens", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__google_ac__audit__18EBB532",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__google_ac__user___17F790F9",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reset_requests",
                schema: "account",
                columns: table => new
                {
                    request_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    user_id = table.Column<int>(nullable: false),
                    email = table.Column<string>(maxLength: 500, nullable: true),
                    name = table.Column<string>(maxLength: 500, nullable: true),
                    requested_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    expires_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(dateadd(day,(1),getutcdate()))"),
                    browser = table.Column<string>(maxLength: 500, nullable: true),
                    ip_address = table.Column<string>(maxLength: 50, nullable: true),
                    confirmed = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    confirmed_on = table.Column<DateTimeOffset>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reset_requests", x => x.request_id);
                    table.ForeignKey(
                        name: "FK__reset_req__audit__0D7A0286",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__reset_req__user___09A971A2",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "account",
                columns: table => new
                {
                    role_id = table.Column<int>(nullable: false),
                    role_name = table.Column<string>(maxLength: 100, nullable: false),
                    is_administrator = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                    table.ForeignKey(
                        name: "FK__roles__audit_use__05D8E0BE",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                schema: "addressbook",
                columns: table => new
                {
                    contact_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    associated_user_id = table.Column<int>(nullable: true),
                    first_name = table.Column<string>(maxLength: 200, nullable: true),
                    prefix = table.Column<string>(maxLength: 200, nullable: true),
                    middle_name = table.Column<string>(maxLength: 200, nullable: true),
                    last_name = table.Column<string>(maxLength: 200, nullable: true),
                    suffix = table.Column<string>(maxLength: 200, nullable: true),
                    formatted_name = table.Column<string>(maxLength: 610, nullable: false),
                    nick_name = table.Column<string>(maxLength: 610, nullable: true),
                    email_addresses = table.Column<string>(maxLength: 1000, nullable: true),
                    telephones = table.Column<string>(maxLength: 1000, nullable: true),
                    fax_numbers = table.Column<string>(maxLength: 1000, nullable: true),
                    mobile_numbers = table.Column<string>(maxLength: 1000, nullable: true),
                    url = table.Column<string>(maxLength: 1000, nullable: true),
                    kind = table.Column<int>(nullable: true),
                    gender = table.Column<int>(nullable: true),
                    language = table.Column<string>(maxLength: 500, nullable: true),
                    time_zone = table.Column<string>(maxLength: 500, nullable: true),
                    birth_day = table.Column<DateTime>(type: "date", nullable: true),
                    address_line_1 = table.Column<string>(maxLength: 500, nullable: true),
                    address_line_2 = table.Column<string>(maxLength: 500, nullable: true),
                    postal_code = table.Column<string>(maxLength: 500, nullable: true),
                    street = table.Column<string>(maxLength: 500, nullable: true),
                    city = table.Column<string>(maxLength: 500, nullable: true),
                    state = table.Column<string>(maxLength: 500, nullable: true),
                    country = table.Column<string>(maxLength: 500, nullable: true),
                    organization = table.Column<string>(maxLength: 500, nullable: true),
                    organizational_unit = table.Column<string>(maxLength: 500, nullable: true),
                    title = table.Column<string>(maxLength: 500, nullable: true),
                    role = table.Column<string>(maxLength: 500, nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    is_private = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    tags = table.Column<string>(maxLength: 500, nullable: true),
                    created_by = table.Column<int>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.contact_id);
                    table.ForeignKey(
                        name: "FK__contacts__associ__220B0B18",
                        column: x => x.associated_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contacts__audit___24E777C3",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contacts__create__23F3538A",
                        column: x => x.created_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "access_types",
                schema: "auth",
                columns: table => new
                {
                    access_type_id = table.Column<int>(nullable: false),
                    access_type_name = table.Column<string>(maxLength: 48, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access_types", x => x.access_type_id);
                    table.ForeignKey(
                        name: "FK__access_ty__audit__56E8E7AB",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "calendar",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(nullable: false),
                    category_name = table.Column<string>(maxLength: 200, nullable: false),
                    color_code = table.Column<string>(maxLength: 50, nullable: false),
                    is_local = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    category_order = table.Column<short>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                    table.ForeignKey(
                        name: "FK__categorie__audit__2C88998B",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__categorie__user___2AA05119",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "custom_field_data_types",
                schema: "config",
                columns: table => new
                {
                    data_type = table.Column<string>(maxLength: 50, nullable: false),
                    underlying_type = table.Column<string>(maxLength: 500, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custom_field_data_types", x => x.data_type);
                    table.ForeignKey(
                        name: "FK__custom_fi__audit__373B3228",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "custom_field_forms",
                schema: "config",
                columns: table => new
                {
                    form_name = table.Column<string>(maxLength: 100, nullable: false),
                    table_name = table.Column<string>(maxLength: 500, nullable: false),
                    key_name = table.Column<string>(maxLength: 500, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custom_field_forms", x => x.form_name);
                    table.ForeignKey(
                        name: "FK__custom_fi__audit__3CF40B7E",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "email_queue",
                schema: "config",
                columns: table => new
                {
                    queue_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    application_name = table.Column<string>(maxLength: 256, nullable: true),
                    from_name = table.Column<string>(maxLength: 256, nullable: false),
                    from_email = table.Column<string>(maxLength: 256, nullable: false),
                    reply_to = table.Column<string>(maxLength: 256, nullable: false),
                    reply_to_name = table.Column<string>(maxLength: 256, nullable: false),
                    subject = table.Column<string>(maxLength: 256, nullable: false),
                    send_to = table.Column<string>(maxLength: 256, nullable: false),
                    attachments = table.Column<string>(maxLength: 2000, nullable: true),
                    message = table.Column<string>(nullable: false),
                    added_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    send_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    delivered = table.Column<bool>(nullable: false),
                    delivered_on = table.Column<DateTimeOffset>(nullable: true),
                    canceled = table.Column<bool>(nullable: false),
                    canceled_on = table.Column<DateTimeOffset>(nullable: true),
                    is_test = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_queue", x => x.queue_id);
                    table.ForeignKey(
                        name: "FK__email_que__audit__2057CCD0",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "filters",
                schema: "config",
                columns: table => new
                {
                    filter_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    object_name = table.Column<string>(maxLength: 500, nullable: false),
                    filter_name = table.Column<string>(maxLength: 500, nullable: false),
                    is_default = table.Column<bool>(nullable: false),
                    is_default_admin = table.Column<bool>(nullable: false),
                    filter_statement = table.Column<string>(maxLength: 12, nullable: false, defaultValueSql: "('WHERE')"),
                    column_name = table.Column<string>(maxLength: 500, nullable: false),
                    data_type = table.Column<string>(maxLength: 500, nullable: false, defaultValueSql: "('')"),
                    filter_condition = table.Column<int>(nullable: false),
                    filter_value = table.Column<string>(maxLength: 500, nullable: true),
                    filter_and_value = table.Column<string>(maxLength: 500, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filters", x => x.filter_id);
                    table.ForeignKey(
                        name: "FK__filters__audit_u__32767D0B",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kanbans",
                schema: "config",
                columns: table => new
                {
                    kanban_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    object_name = table.Column<string>(maxLength: 128, nullable: false),
                    user_id = table.Column<int>(nullable: true),
                    kanban_name = table.Column<string>(maxLength: 128, nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kanbans", x => x.kanban_id);
                    table.ForeignKey(
                        name: "FK__kanbans__audit_u__0697FACD",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__kanbans__user_id__05A3D694",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sms_queue",
                schema: "config",
                columns: table => new
                {
                    queue_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    application_name = table.Column<string>(maxLength: 256, nullable: true),
                    from_name = table.Column<string>(maxLength: 256, nullable: false),
                    from_number = table.Column<string>(maxLength: 256, nullable: false),
                    subject = table.Column<string>(maxLength: 256, nullable: false),
                    send_to = table.Column<string>(maxLength: 256, nullable: false),
                    message = table.Column<string>(nullable: false),
                    added_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    send_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    delivered = table.Column<bool>(nullable: false),
                    delivered_on = table.Column<DateTimeOffset>(nullable: true),
                    canceled = table.Column<bool>(nullable: false),
                    canceled_on = table.Column<DateTimeOffset>(nullable: true),
                    is_test = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_queue", x => x.queue_id);
                    table.ForeignKey(
                        name: "FK__sms_queue__audit__29E1370A",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "smtp_configs",
                schema: "config",
                columns: table => new
                {
                    smtp_config_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    configuration_name = table.Column<string>(maxLength: 256, nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    is_default = table.Column<bool>(nullable: false),
                    from_display_name = table.Column<string>(maxLength: 256, nullable: false),
                    from_email_address = table.Column<string>(maxLength: 256, nullable: false),
                    smtp_host = table.Column<string>(maxLength: 256, nullable: false),
                    smtp_enable_ssl = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    smtp_username = table.Column<string>(maxLength: 256, nullable: false),
                    smtp_password = table.Column<string>(maxLength: 256, nullable: false),
                    smtp_port = table.Column<int>(nullable: false, defaultValueSql: "((587))"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_smtp_configs", x => x.smtp_config_id);
                    table.ForeignKey(
                        name: "FK__smtp_conf__audit__16CE6296",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "offices",
                schema: "core",
                columns: table => new
                {
                    office_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    office_code = table.Column<string>(maxLength: 12, nullable: false),
                    office_name = table.Column<string>(maxLength: 150, nullable: false),
                    nick_name = table.Column<string>(maxLength: 50, nullable: true),
                    registration_date = table.Column<DateTime>(type: "date", nullable: true),
                    currency_code = table.Column<string>(maxLength: 12, nullable: true),
                    po_box = table.Column<string>(maxLength: 128, nullable: true),
                    address_line_1 = table.Column<string>(maxLength: 128, nullable: true),
                    address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    street = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    state = table.Column<string>(maxLength: 50, nullable: true),
                    zip_code = table.Column<string>(maxLength: 24, nullable: true),
                    country = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 24, nullable: true),
                    fax = table.Column<string>(maxLength: 24, nullable: true),
                    email = table.Column<string>(maxLength: 128, nullable: true),
                    url = table.Column<string>(maxLength: 50, nullable: true),
                    logo = table.Column<byte[]>(nullable: true),
                    parent_office_id = table.Column<int>(nullable: true),
                    registration_number = table.Column<string>(maxLength: 100, nullable: true),
                    pan_number = table.Column<string>(maxLength: 100, nullable: true),
                    allow_transaction_posting = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offices", x => x.office_id);
                    table.ForeignKey(
                        name: "FK__offices__audit_u__4F47C5E3",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__offices__parent___31EC6D26",
                        column: x => x.parent_office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "account_masters",
                schema: "finance",
                columns: table => new
                {
                    account_master_id = table.Column<short>(nullable: false),
                    account_master_code = table.Column<string>(maxLength: 3, nullable: false),
                    account_master_name = table.Column<string>(maxLength: 40, nullable: false),
                    normally_debit = table.Column<bool>(nullable: false),
                    parent_account_master_id = table.Column<short>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_masters", x => x.account_master_id);
                    table.ForeignKey(
                        name: "FK__account_m__audit__4FD1D5C8",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__account_m__paren__4EDDB18F",
                        column: x => x.parent_account_master_id,
                        principalSchema: "finance",
                        principalTable: "account_masters",
                        principalColumn: "account_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bank_types",
                schema: "finance",
                columns: table => new
                {
                    bank_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bank_type_name = table.Column<string>(maxLength: 1000, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_types", x => x.bank_type_id);
                    table.ForeignKey(
                        name: "FK__bank_type__audit__75F77EB0",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "card_types",
                schema: "finance",
                columns: table => new
                {
                    card_type_id = table.Column<int>(nullable: false),
                    card_type_code = table.Column<string>(maxLength: 12, nullable: false),
                    card_type_name = table.Column<string>(maxLength: 100, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card_types", x => x.card_type_id);
                    table.ForeignKey(
                        name: "FK__card_type__audit__2E3BD7D3",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cash_flow_headings",
                schema: "finance",
                columns: table => new
                {
                    cash_flow_heading_id = table.Column<int>(nullable: false),
                    cash_flow_heading_code = table.Column<string>(maxLength: 12, nullable: false),
                    cash_flow_heading_name = table.Column<string>(maxLength: 100, nullable: false),
                    cash_flow_heading_type = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    is_debit = table.Column<bool>(nullable: false),
                    is_sales = table.Column<bool>(nullable: false),
                    is_purchase = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cash_flow_headings", x => x.cash_flow_heading_id);
                    table.ForeignKey(
                        name: "FK__cash_flow__audit__7132C993",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cost_centers",
                schema: "finance",
                columns: table => new
                {
                    cost_center_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cost_center_code = table.Column<string>(maxLength: 24, nullable: false),
                    cost_center_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cost_centers", x => x.cost_center_id);
                    table.ForeignKey(
                        name: "FK__cost_cent__audit__54968AE5",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "frequencies",
                schema: "finance",
                columns: table => new
                {
                    frequency_id = table.Column<int>(nullable: false),
                    frequency_code = table.Column<string>(maxLength: 12, nullable: false),
                    frequency_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_frequencies", x => x.frequency_id);
                    table.ForeignKey(
                        name: "FK__frequenci__audit__3AD6B8E2",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transaction_documents",
                schema: "finance",
                columns: table => new
                {
                    document_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transaction_master_id = table.Column<long>(nullable: false),
                    original_file_name = table.Column<string>(maxLength: 500, nullable: false),
                    file_extension = table.Column<string>(maxLength: 50, nullable: true),
                    file_path = table.Column<string>(maxLength: 2000, nullable: false),
                    memo = table.Column<string>(maxLength: 2000, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_documents", x => x.document_id);
                    table.ForeignKey(
                        name: "FK__transacti__audit__1EF99443",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__transacti__trans__1E05700A",
                        column: x => x.transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transaction_types",
                schema: "finance",
                columns: table => new
                {
                    transaction_type_id = table.Column<short>(nullable: false),
                    transaction_type_code = table.Column<string>(maxLength: 4, nullable: true),
                    transaction_type_name = table.Column<string>(maxLength: 100, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_types", x => x.transaction_type_id);
                    table.ForeignKey(
                        name: "FK__transacti__audit__04459E07",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                schema: "hrm",
                columns: table => new
                {
                    department_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    department_code = table.Column<string>(maxLength: 12, nullable: false),
                    department_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.department_id);
                    table.ForeignKey(
                        name: "FK__departmen__audit__08A03ED0",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "education_levels",
                schema: "hrm",
                columns: table => new
                {
                    education_level_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    education_level_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education_levels", x => x.education_level_id);
                    table.ForeignKey(
                        name: "FK__education__audit__17E28260",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employee_types",
                schema: "hrm",
                columns: table => new
                {
                    employee_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employee_type_code = table.Column<string>(maxLength: 12, nullable: false),
                    employee_type_name = table.Column<string>(maxLength: 128, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_types", x => x.employee_type_id);
                    table.ForeignKey(
                        name: "FK__employee___audit__54EB90A0",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employment_status_codes",
                schema: "hrm",
                columns: table => new
                {
                    employment_status_code_id = table.Column<int>(nullable: false),
                    status_code = table.Column<string>(maxLength: 12, nullable: false),
                    status_code_name = table.Column<string>(maxLength: 100, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employment_status_codes", x => x.employment_status_code_id);
                    table.ForeignKey(
                        name: "FK__employmen__audit__1D9B5BB6",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exit_types",
                schema: "hrm",
                columns: table => new
                {
                    exit_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    exit_type_code = table.Column<string>(maxLength: 12, nullable: false),
                    exit_type_name = table.Column<string>(maxLength: 128, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exit_types", x => x.exit_type_id);
                    table.ForeignKey(
                        name: "FK__exit_type__audit__44801EAD",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "identification_types",
                schema: "hrm",
                columns: table => new
                {
                    identification_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    identification_type_code = table.Column<string>(maxLength: 12, nullable: false),
                    identification_type_name = table.Column<string>(maxLength: 100, nullable: false),
                    can_expire = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identification_types", x => x.identification_type_id);
                    table.ForeignKey(
                        name: "FK__identific__audit__7E22B05D",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "job_titles",
                schema: "hrm",
                columns: table => new
                {
                    job_title_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    job_title_code = table.Column<string>(maxLength: 12, nullable: false),
                    job_title_name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "('')"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_titles", x => x.job_title_id);
                    table.ForeignKey(
                        name: "FK__job_title__audit__2CDD9F46",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "leave_benefits",
                schema: "hrm",
                columns: table => new
                {
                    leave_benefit_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    leave_benefit_code = table.Column<string>(maxLength: 12, nullable: false),
                    leave_benefit_name = table.Column<string>(maxLength: 128, nullable: false),
                    total_days = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leave_benefits", x => x.leave_benefit_id);
                    table.ForeignKey(
                        name: "FK__leave_ben__audit__4F32B74A",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "leave_types",
                schema: "hrm",
                columns: table => new
                {
                    leave_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    leave_type_code = table.Column<string>(maxLength: 12, nullable: false),
                    leave_type_name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "('')"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leave_types", x => x.leave_type_id);
                    table.ForeignKey(
                        name: "FK__leave_typ__audit__41D8BC2C",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nationalities",
                schema: "hrm",
                columns: table => new
                {
                    nationality_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nationality_code = table.Column<string>(maxLength: 12, nullable: true),
                    nationality_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationalities", x => x.nationality_id);
                    table.ForeignKey(
                        name: "FK__nationali__audit__1229A90A",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pay_grades",
                schema: "hrm",
                columns: table => new
                {
                    pay_grade_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pay_grade_code = table.Column<string>(maxLength: 12, nullable: false),
                    pay_grade_name = table.Column<string>(maxLength: 100, nullable: false),
                    minimum_salary = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    maximum_salary = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "('')"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pay_grades", x => x.pay_grade_id);
                    table.ForeignKey(
                        name: "FK__pay_grade__audit__347EC10E",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "hrm",
                columns: table => new
                {
                    role_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    role_code = table.Column<string>(maxLength: 12, nullable: false),
                    role_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                    table.ForeignKey(
                        name: "FK__roles__audit_use__0D64F3ED",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shifts",
                schema: "hrm",
                columns: table => new
                {
                    shift_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    shift_code = table.Column<string>(maxLength: 12, nullable: false),
                    shift_name = table.Column<string>(maxLength: 100, nullable: false),
                    begins_from = table.Column<TimeSpan>(nullable: false),
                    ends_on = table.Column<TimeSpan>(nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "('')"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shifts", x => x.shift_id);
                    table.ForeignKey(
                        name: "FK__shifts__audit_us__3B2BBE9D",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "social_networks",
                schema: "hrm",
                columns: table => new
                {
                    social_network_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    social_network_name = table.Column<string>(maxLength: 128, nullable: false),
                    icon_css_class = table.Column<string>(maxLength: 128, nullable: true),
                    base_url = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_networks", x => x.social_network_id);
                    table.ForeignKey(
                        name: "FK__social_ne__audit__03DB89B3",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "week_days",
                schema: "hrm",
                columns: table => new
                {
                    week_day_id = table.Column<int>(nullable: false),
                    week_day_code = table.Column<string>(maxLength: 12, nullable: false),
                    week_day_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_week_days", x => x.week_day_id);
                    table.ForeignKey(
                        name: "FK__week_days__audit__7775B2CE",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attributes",
                schema: "inventory",
                columns: table => new
                {
                    attribute_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    attribute_code = table.Column<string>(maxLength: 12, nullable: false),
                    attribute_name = table.Column<string>(maxLength: 100, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attributes", x => x.attribute_id);
                    table.ForeignKey(
                        name: "FK__attribute__audit__2962141D",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "brands",
                schema: "inventory",
                columns: table => new
                {
                    brand_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    brand_code = table.Column<string>(maxLength: 24, nullable: false),
                    brand_name = table.Column<string>(maxLength: 500, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.brand_id);
                    table.ForeignKey(
                        name: "FK__brands__audit_us__27AED5D5",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item_types",
                schema: "inventory",
                columns: table => new
                {
                    item_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_type_code = table.Column<string>(maxLength: 12, nullable: false),
                    item_type_name = table.Column<string>(maxLength: 50, nullable: false),
                    is_component = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_types", x => x.item_type_id);
                    table.ForeignKey(
                        name: "FK__item_type__audit__2D67AF2B",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "store_types",
                schema: "inventory",
                columns: table => new
                {
                    store_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    store_type_code = table.Column<string>(maxLength: 12, nullable: false),
                    store_type_name = table.Column<string>(maxLength: 50, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_types", x => x.store_type_id);
                    table.ForeignKey(
                        name: "FK__store_typ__audit__46335CF5",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "units",
                schema: "inventory",
                columns: table => new
                {
                    unit_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    unit_code = table.Column<string>(maxLength: 24, nullable: false),
                    unit_name = table.Column<string>(maxLength: 500, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.unit_id);
                    table.ForeignKey(
                        name: "FK__units__audit_use__7152C524",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "price_types",
                schema: "purchase",
                columns: table => new
                {
                    price_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    price_type_code = table.Column<string>(maxLength: 24, nullable: false),
                    price_type_name = table.Column<string>(maxLength: 500, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_price_types", x => x.price_type_id);
                    table.ForeignKey(
                        name: "FK__price_typ__audit__26509D48",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "closing_cash",
                schema: "sales",
                columns: table => new
                {
                    closing_cash_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(nullable: false),
                    transaction_date = table.Column<DateTime>(type: "date", nullable: false),
                    opening_cash = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    total_cash_sales = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    submitted_to = table.Column<string>(maxLength: 1000, nullable: false, defaultValueSql: "('')"),
                    memo = table.Column<string>(maxLength: 4000, nullable: false, defaultValueSql: "('')"),
                    deno_1000 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_500 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_250 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_200 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_100 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_50 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_25 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_20 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_10 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_5 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_2 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    deno_1 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    coins = table.Column<decimal>(type: "numeric(30, 6)", nullable: true, defaultValueSql: "((0))"),
                    submitted_cash = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    approved_by = table.Column<int>(nullable: true),
                    approval_memo = table.Column<string>(maxLength: 4000, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_closing_cash", x => x.closing_cash_id);
                    table.ForeignKey(
                        name: "FK__closing_c__appro__46535886",
                        column: x => x.approved_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__closing_c__audit__47477CBF",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__closing_c__user___371114F6",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "opening_cash",
                schema: "sales",
                columns: table => new
                {
                    opening_cash_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(nullable: false),
                    transaction_date = table.Column<DateTime>(type: "date", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    provided_by = table.Column<string>(maxLength: 1000, nullable: false, defaultValueSql: "('')"),
                    memo = table.Column<string>(maxLength: 4000, nullable: true, defaultValueSql: "('')"),
                    closed = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opening_cash", x => x.opening_cash_id);
                    table.ForeignKey(
                        name: "FK__opening_c__audit__324C5FD9",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__opening_c__user___2E7BCEF5",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "price_types",
                schema: "sales",
                columns: table => new
                {
                    price_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    price_type_code = table.Column<string>(maxLength: 24, nullable: false),
                    price_type_name = table.Column<string>(maxLength: 500, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_price_types", x => x.price_type_id);
                    table.ForeignKey(
                        name: "FK__price_typ__audit__261B931E",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feeds",
                schema: "social",
                columns: table => new
                {
                    feed_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    event_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    formatted_text = table.Column<string>(maxLength: 4000, nullable: false),
                    created_by = table.Column<int>(nullable: false),
                    attachments = table.Column<string>(nullable: true),
                    scope = table.Column<string>(maxLength: 100, nullable: true),
                    is_public = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    parent_feed_id = table.Column<long>(nullable: true),
                    url = table.Column<string>(maxLength: 4000, nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: false),
                    deleted_on = table.Column<DateTimeOffset>(nullable: true),
                    deleted_by = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feeds", x => x.feed_id);
                    table.ForeignKey(
                        name: "FK__feeds__created_b__77EAB41A",
                        column: x => x.created_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__feeds__deleted_b__7CAF6937",
                        column: x => x.deleted_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__feeds__parent_fe__79D2FC8C",
                        column: x => x.parent_feed_id,
                        principalSchema: "social",
                        principalTable: "feeds",
                        principalColumn: "feed_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "website",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    category_name = table.Column<string>(maxLength: 250, nullable: false),
                    alias = table.Column<string>(maxLength: 250, nullable: false),
                    seo_description = table.Column<string>(maxLength: 100, nullable: true),
                    is_blog = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                    table.ForeignKey(
                        name: "FK__categorie__audit__67DE6983",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "configurations",
                schema: "website",
                columns: table => new
                {
                    configuration_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    domain_name = table.Column<string>(maxLength: 500, nullable: false),
                    website_name = table.Column<string>(maxLength: 500, nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    blog_title = table.Column<string>(maxLength: 500, nullable: true),
                    blog_description = table.Column<string>(maxLength: 500, nullable: true),
                    is_default = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configurations", x => x.configuration_id);
                    table.ForeignKey(
                        name: "FK__configura__audit__57A801BA",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                schema: "website",
                columns: table => new
                {
                    contact_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 500, nullable: false),
                    name = table.Column<string>(maxLength: 500, nullable: false),
                    position = table.Column<string>(maxLength: 500, nullable: true),
                    address = table.Column<string>(maxLength: 500, nullable: true),
                    city = table.Column<string>(maxLength: 500, nullable: true),
                    state = table.Column<string>(maxLength: 500, nullable: true),
                    country = table.Column<string>(maxLength: 100, nullable: true),
                    postal_code = table.Column<string>(maxLength: 500, nullable: true),
                    telephone = table.Column<string>(maxLength: 500, nullable: true),
                    details = table.Column<string>(maxLength: 500, nullable: true),
                    email = table.Column<string>(maxLength: 500, nullable: true),
                    recipients = table.Column<string>(maxLength: 1000, nullable: true),
                    display_email = table.Column<bool>(nullable: false),
                    display_contact_form = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    sort = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.contact_id);
                    table.ForeignKey(
                        name: "FK__contacts__audit___0A338187",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "email_subscriptions",
                schema: "website",
                columns: table => new
                {
                    email_subscription_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    first_name = table.Column<string>(maxLength: 100, nullable: true),
                    last_name = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    browser = table.Column<string>(maxLength: 500, nullable: true),
                    ip_address = table.Column<string>(maxLength: 50, nullable: true),
                    confirmed = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    confirmed_on = table.Column<DateTimeOffset>(nullable: true),
                    unsubscribed = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    subscribed_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    unsubscribed_on = table.Column<DateTimeOffset>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_subscriptions", x => x.email_subscription_id);
                    table.ForeignKey(
                        name: "FK__email_sub__audit__61316BF4",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                schema: "website",
                columns: table => new
                {
                    menu_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    menu_name = table.Column<string>(maxLength: 100, nullable: true),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.menu_id);
                    table.ForeignKey(
                        name: "FK__menus__audit_use__7908F585",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "events",
                schema: "calendar",
                columns: table => new
                {
                    event_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    category_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 500, nullable: false),
                    location = table.Column<string>(maxLength: 2000, nullable: true),
                    starts_at = table.Column<DateTimeOffset>(nullable: false),
                    ends_on = table.Column<DateTimeOffset>(nullable: false),
                    time_zone = table.Column<string>(maxLength: 200, nullable: false),
                    all_day = table.Column<bool>(nullable: false),
                    recurrence = table.Column<string>(nullable: true),
                    until = table.Column<DateTimeOffset>(nullable: true),
                    alarm = table.Column<int>(nullable: true),
                    reminder_types = table.Column<string>(nullable: true),
                    is_private = table.Column<bool>(nullable: true),
                    url = table.Column<string>(maxLength: 500, nullable: true),
                    note = table.Column<string>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.event_id);
                    table.ForeignKey(
                        name: "FK__events__audit_us__351DDF8C",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__events__category__324172E1",
                        column: x => x.category_id,
                        principalSchema: "calendar",
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__events__user_id__3335971A",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "custom_field_setup",
                schema: "config",
                columns: table => new
                {
                    custom_field_setup_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    form_name = table.Column<string>(maxLength: 100, nullable: false),
                    before_field = table.Column<string>(maxLength: 500, nullable: true),
                    field_order = table.Column<int>(nullable: false),
                    after_field = table.Column<string>(maxLength: 500, nullable: true),
                    field_name = table.Column<string>(maxLength: 100, nullable: false),
                    field_label = table.Column<string>(maxLength: 200, nullable: false),
                    data_type = table.Column<string>(maxLength: 50, nullable: true),
                    description = table.Column<string>(maxLength: 500, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custom_field_setup", x => x.custom_field_setup_id);
                    table.ForeignKey(
                        name: "FK__custom_fi__audit__44952D46",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__custom_fi__data___43A1090D",
                        column: x => x.data_type,
                        principalSchema: "config",
                        principalTable: "custom_field_data_types",
                        principalColumn: "data_type",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__custom_fi__form___41B8C09B",
                        column: x => x.form_name,
                        principalSchema: "config",
                        principalTable: "custom_field_forms",
                        principalColumn: "form_name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kanban_details",
                schema: "config",
                columns: table => new
                {
                    kanban_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    kanban_id = table.Column<long>(nullable: false),
                    rating = table.Column<short>(nullable: true),
                    resource_id = table.Column<string>(maxLength: 128, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kanban_details", x => x.kanban_detail_id);
                    table.ForeignKey(
                        name: "FK__kanban_de__audit__0D44F85C",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__kanban_de__kanba__0B5CAFEA",
                        column: x => x.kanban_id,
                        principalSchema: "config",
                        principalTable: "kanbans",
                        principalColumn: "kanban_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                schema: "account",
                columns: table => new
                {
                    login_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(nullable: true),
                    office_id = table.Column<int>(nullable: true),
                    browser = table.Column<string>(maxLength: 500, nullable: true),
                    ip_address = table.Column<string>(maxLength: 50, nullable: true),
                    is_active = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    login_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    culture = table.Column<string>(maxLength: 12, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.login_id);
                    table.ForeignKey(
                        name: "FK__logins__audit_us__2180FB33",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__logins__office_i__1EA48E88",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__logins__user_id__1DB06A4F",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "entity_access_policy",
                schema: "auth",
                columns: table => new
                {
                    entity_access_policy_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    entity_name = table.Column<string>(maxLength: 500, nullable: true),
                    office_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    access_type_id = table.Column<int>(nullable: true),
                    allow_access = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity_access_policy", x => x.entity_access_policy_id);
                    table.ForeignKey(
                        name: "FK__entity_ac__acces__65370702",
                        column: x => x.access_type_id,
                        principalSchema: "auth",
                        principalTable: "access_types",
                        principalColumn: "access_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__entity_ac__audit__662B2B3B",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__entity_ac__offic__634EBE90",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__entity_ac__user___6442E2C9",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group_entity_access_policy",
                schema: "auth",
                columns: table => new
                {
                    group_entity_access_policy_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    entity_name = table.Column<string>(maxLength: 500, nullable: true),
                    office_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false),
                    access_type_id = table.Column<int>(nullable: true),
                    allow_access = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_entity_access_policy", x => x.group_entity_access_policy_id);
                    table.ForeignKey(
                        name: "FK__group_ent__acces__5D95E53A",
                        column: x => x.access_type_id,
                        principalSchema: "auth",
                        principalTable: "access_types",
                        principalColumn: "access_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__group_ent__audit__5E8A0973",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__group_ent__offic__5BAD9CC8",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__group_ent__role___5CA1C101",
                        column: x => x.role_id,
                        principalSchema: "account",
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group_menu_access_policy",
                schema: "auth",
                columns: table => new
                {
                    group_menu_access_policy_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    office_id = table.Column<int>(nullable: false),
                    menu_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_menu_access_policy", x => x.group_menu_access_policy_id);
                    table.ForeignKey(
                        name: "FK__group_men__audit__6DCC4D03",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__group_men__menu___6BE40491",
                        column: x => x.menu_id,
                        principalSchema: "core",
                        principalTable: "menus",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__group_men__offic__6AEFE058",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__group_men__role___6CD828CA",
                        column: x => x.role_id,
                        principalSchema: "account",
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menu_access_policy",
                schema: "auth",
                columns: table => new
                {
                    menu_access_policy_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    office_id = table.Column<int>(nullable: false),
                    menu_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: true),
                    allow_access = table.Column<bool>(nullable: true),
                    disallow_access = table.Column<bool>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_access_policy", x => x.menu_access_policy_id);
                    table.ForeignKey(
                        name: "FK__menu_acce__audit__756D6ECB",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__menu_acce__menu___73852659",
                        column: x => x.menu_id,
                        principalSchema: "core",
                        principalTable: "menus",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__menu_acce__offic__72910220",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__menu_acce__user___74794A92",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                schema: "core",
                columns: table => new
                {
                    notification_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    event_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    tenant = table.Column<string>(maxLength: 1000, nullable: true),
                    office_id = table.Column<int>(nullable: true),
                    associated_app = table.Column<string>(maxLength: 100, nullable: false),
                    associated_menu_id = table.Column<int>(nullable: true),
                    to_user_id = table.Column<int>(nullable: true),
                    to_role_id = table.Column<int>(nullable: true),
                    to_login_id = table.Column<long>(nullable: true),
                    url = table.Column<string>(maxLength: 2000, nullable: true),
                    formatted_text = table.Column<string>(maxLength: 4000, nullable: true),
                    icon = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK__notificat__assoc__4F7CD00D",
                        column: x => x.associated_app,
                        principalSchema: "core",
                        principalTable: "apps",
                        principalColumn: "app_name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__notificat__assoc__5070F446",
                        column: x => x.associated_menu_id,
                        principalSchema: "core",
                        principalTable: "menus",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__notificat__offic__4E88ABD4",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "auto_verification_policy",
                schema: "finance",
                columns: table => new
                {
                    auto_verification_policy_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    verification_limit = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    effective_from = table.Column<DateTime>(type: "date", nullable: false),
                    ends_on = table.Column<DateTime>(type: "date", nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auto_verification_policy", x => x.auto_verification_policy_id);
                    table.ForeignKey(
                        name: "FK__auto_veri__audit__5A1A5A11",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__auto_veri__offic__5832119F",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__auto_veri__user___573DED66",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cash_repositories",
                schema: "finance",
                columns: table => new
                {
                    cash_repository_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    office_id = table.Column<int>(nullable: false),
                    cash_repository_code = table.Column<string>(maxLength: 12, nullable: false),
                    cash_repository_name = table.Column<string>(maxLength: 50, nullable: false),
                    parent_cash_repository_id = table.Column<int>(nullable: true),
                    description = table.Column<string>(maxLength: 100, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cash_repositories", x => x.cash_repository_id);
                    table.ForeignKey(
                        name: "FK__cash_repo__audit__4183B671",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__cash_repo__offic__3F9B6DFF",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__cash_repo__paren__408F9238",
                        column: x => x.parent_cash_repository_id,
                        principalSchema: "finance",
                        principalTable: "cash_repositories",
                        principalColumn: "cash_repository_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "day_operation",
                schema: "finance",
                columns: table => new
                {
                    day_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    office_id = table.Column<int>(nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    started_on = table.Column<DateTimeOffset>(nullable: false),
                    started_by = table.Column<int>(nullable: false),
                    completed_on = table.Column<DateTimeOffset>(nullable: true),
                    completed_by = table.Column<int>(nullable: true),
                    completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_day_operation", x => x.day_id);
                    table.ForeignKey(
                        name: "FK__day_opera__compl__6C390A4C",
                        column: x => x.completed_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__day_opera__offic__6A50C1DA",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__day_opera__start__6B44E613",
                        column: x => x.started_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exchange_rates",
                schema: "finance",
                columns: table => new
                {
                    exchange_rate_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    updated_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    office_id = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exchange_rates", x => x.exchange_rate_id);
                    table.ForeignKey(
                        name: "FK__exchange___offic__4336F4B9",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fiscal_year",
                schema: "finance",
                columns: table => new
                {
                    fiscal_year_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fiscal_year_code = table.Column<string>(maxLength: 12, nullable: false),
                    fiscal_year_name = table.Column<string>(maxLength: 50, nullable: false),
                    starts_from = table.Column<DateTime>(type: "date", nullable: false),
                    ends_on = table.Column<DateTime>(type: "date", nullable: false),
                    eod_required = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    office_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fiscal_year", x => x.fiscal_year_code);
                    table.ForeignKey(
                        name: "FK__fiscal_ye__audit__4924D839",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__fiscal_ye__offic__4830B400",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "journal_verification_policy",
                schema: "finance",
                columns: table => new
                {
                    journal_verification_policy_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    can_verify = table.Column<bool>(nullable: false),
                    verification_limit = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    can_self_verify = table.Column<bool>(nullable: false),
                    self_verification_limit = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    effective_from = table.Column<DateTime>(type: "date", nullable: false),
                    ends_on = table.Column<DateTime>(type: "date", nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_journal_verification_policy", x => x.journal_verification_policy_id);
                    table.ForeignKey(
                        name: "FK__journal_v__audit__52793849",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__journal_v__offic__4DB4832C",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__journal_v__user___4CC05EF3",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "finance",
                columns: table => new
                {
                    account_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    account_master_id = table.Column<short>(nullable: false),
                    account_number = table.Column<string>(maxLength: 24, nullable: false),
                    external_code = table.Column<string>(maxLength: 24, nullable: true, defaultValueSql: "('')"),
                    currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    account_name = table.Column<string>(maxLength: 500, nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: true),
                    confidential = table.Column<bool>(nullable: false),
                    is_transaction_node = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    sys_type = table.Column<bool>(nullable: false),
                    parent_account_id = table.Column<int>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.account_id);
                    table.ForeignKey(
                        name: "FK__accounts__accoun__61F08603",
                        column: x => x.account_master_id,
                        principalSchema: "finance",
                        principalTable: "account_masters",
                        principalColumn: "account_master_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__accounts__audit___689D8392",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__accounts__curren__63D8CE75",
                        column: x => x.currency_code,
                        principalSchema: "core",
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__accounts__parent__67A95F59",
                        column: x => x.parent_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payment_cards",
                schema: "finance",
                columns: table => new
                {
                    payment_card_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    payment_card_code = table.Column<string>(maxLength: 12, nullable: false),
                    payment_card_name = table.Column<string>(maxLength: 100, nullable: false),
                    card_type_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_cards", x => x.payment_card_id);
                    table.ForeignKey(
                        name: "FK__payment_c__audit__33F4B129",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__payment_c__card___33008CF0",
                        column: x => x.card_type_id,
                        principalSchema: "finance",
                        principalTable: "card_types",
                        principalColumn: "card_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cash_flow_setup",
                schema: "finance",
                columns: table => new
                {
                    cash_flow_setup_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cash_flow_heading_id = table.Column<int>(nullable: false),
                    account_master_id = table.Column<short>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cash_flow_setup", x => x.cash_flow_setup_id);
                    table.ForeignKey(
                        name: "FK__cash_flow__accou__09FE775D",
                        column: x => x.account_master_id,
                        principalSchema: "finance",
                        principalTable: "account_masters",
                        principalColumn: "account_master_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__cash_flow__audit__0AF29B96",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__cash_flow__cash___090A5324",
                        column: x => x.cash_flow_heading_id,
                        principalSchema: "finance",
                        principalTable: "cash_flow_headings",
                        principalColumn: "cash_flow_heading_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employment_statuses",
                schema: "hrm",
                columns: table => new
                {
                    employment_status_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employment_status_code = table.Column<string>(maxLength: 12, nullable: false),
                    employment_status_name = table.Column<string>(maxLength: 100, nullable: false),
                    is_contract = table.Column<bool>(nullable: false),
                    default_employment_status_code_id = table.Column<int>(nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "('')"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employment_statuses", x => x.employment_status_id);
                    table.ForeignKey(
                        name: "FK__employmen__audit__2630A1B7",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employmen__defau__24485945",
                        column: x => x.default_employment_status_code_id,
                        principalSchema: "hrm",
                        principalTable: "employment_status_codes",
                        principalColumn: "employment_status_code_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "office_hours",
                schema: "hrm",
                columns: table => new
                {
                    office_hour_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    office_id = table.Column<int>(nullable: false),
                    shift_id = table.Column<int>(nullable: false),
                    week_day_id = table.Column<int>(nullable: false),
                    begins_from = table.Column<TimeSpan>(nullable: false),
                    ends_on = table.Column<TimeSpan>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office_hours", x => x.office_hour_id);
                    table.ForeignKey(
                        name: "FK__office_ho__audit__4979DDF4",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__office_ho__offic__469D7149",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__office_ho__shift__47919582",
                        column: x => x.shift_id,
                        principalSchema: "hrm",
                        principalTable: "shifts",
                        principalColumn: "shift_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__office_ho__week___4885B9BB",
                        column: x => x.week_day_id,
                        principalSchema: "hrm",
                        principalTable: "week_days",
                        principalColumn: "week_day_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "variants",
                schema: "inventory",
                columns: table => new
                {
                    variant_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    variant_code = table.Column<string>(maxLength: 12, nullable: false),
                    variant_name = table.Column<string>(maxLength: 100, nullable: false),
                    attribute_id = table.Column<int>(nullable: false),
                    attribute_value = table.Column<string>(maxLength: 200, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variants", x => x.variant_id);
                    table.ForeignKey(
                        name: "FK__variants__attrib__2F1AED73",
                        column: x => x.attribute_id,
                        principalSchema: "inventory",
                        principalTable: "attributes",
                        principalColumn: "attribute_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__variants__audit___300F11AC",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "compound_units",
                schema: "inventory",
                columns: table => new
                {
                    compound_unit_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    base_unit_id = table.Column<int>(nullable: false),
                    value = table.Column<short>(nullable: false),
                    compare_unit_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compound_units", x => x.compound_unit_id);
                    table.ForeignKey(
                        name: "FK__compound___audit__79E80B25",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__compound___base___76177A41",
                        column: x => x.base_unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__compound___compa__78F3E6EC",
                        column: x => x.compare_unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "coupons",
                schema: "sales",
                columns: table => new
                {
                    coupon_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    coupon_name = table.Column<string>(maxLength: 100, nullable: false),
                    coupon_code = table.Column<string>(maxLength: 100, nullable: false),
                    discount_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    is_percentage = table.Column<bool>(nullable: false),
                    maximum_discount_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    associated_price_type_id = table.Column<int>(nullable: true),
                    minimum_purchase_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    maximum_purchase_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    begins_from = table.Column<DateTime>(type: "date", nullable: true),
                    expires_on = table.Column<DateTime>(type: "date", nullable: true),
                    maximum_usage = table.Column<int>(nullable: true),
                    enable_ticket_printing = table.Column<bool>(nullable: true),
                    for_ticket_of_price_type_id = table.Column<int>(nullable: true),
                    for_ticket_having_minimum_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    for_ticket_having_maximum_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    for_ticket_of_unknown_customers_only = table.Column<bool>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupons", x => x.coupon_id);
                    table.ForeignKey(
                        name: "FK__coupons__associa__066DDD9B",
                        column: x => x.associated_price_type_id,
                        principalSchema: "sales",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__coupons__audit_u__0856260D",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__coupons__for_tic__076201D4",
                        column: x => x.for_ticket_of_price_type_id,
                        principalSchema: "sales",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contents",
                schema: "website",
                columns: table => new
                {
                    content_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    category_id = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 500, nullable: false),
                    alias = table.Column<string>(maxLength: 500, nullable: false),
                    author_id = table.Column<int>(nullable: true),
                    publish_on = table.Column<DateTimeOffset>(nullable: false),
                    created_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    last_editor_id = table.Column<int>(nullable: true),
                    last_edited_on = table.Column<DateTimeOffset>(nullable: true),
                    markdown = table.Column<string>(nullable: true),
                    contents = table.Column<string>(nullable: false),
                    tags = table.Column<string>(maxLength: 500, nullable: true),
                    hits = table.Column<long>(nullable: true),
                    is_draft = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    seo_description = table.Column<string>(maxLength: 1000, nullable: false, defaultValueSql: "('')"),
                    is_homepage = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contents", x => x.content_id);
                    table.ForeignKey(
                        name: "FK__contents__audit___74444068",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contents__author__6E8B6712",
                        column: x => x.author_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contents__catego__6D9742D9",
                        column: x => x.category_id,
                        principalSchema: "website",
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contents__last_e__7073AF84",
                        column: x => x.last_editor_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "custom_fields",
                schema: "config",
                columns: table => new
                {
                    custom_field_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    custom_field_setup_id = table.Column<int>(nullable: false),
                    resource_id = table.Column<string>(maxLength: 500, nullable: false),
                    value = table.Column<string>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custom_fields", x => x.custom_field_id);
                    table.ForeignKey(
                        name: "FK__custom_fi__audit__4A4E069C",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__custom_fi__custo__4959E263",
                        column: x => x.custom_field_setup_id,
                        principalSchema: "config",
                        principalTable: "custom_field_setup",
                        principalColumn: "custom_field_setup_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notification_statuses",
                schema: "core",
                columns: table => new
                {
                    notification_status_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    notification_id = table.Column<Guid>(nullable: false),
                    last_seen_on = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    seen_by = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification_statuses", x => x.notification_status_id);
                    table.ForeignKey(
                        name: "FK__notificat__notif__5441852A",
                        column: x => x.notification_id,
                        principalSchema: "core",
                        principalTable: "notifications",
                        principalColumn: "notification_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "day_operation_routines",
                schema: "finance",
                columns: table => new
                {
                    day_operation_routine_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    day_id = table.Column<long>(nullable: false),
                    routine_id = table.Column<int>(nullable: false),
                    started_on = table.Column<DateTimeOffset>(nullable: false),
                    completed_on = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_day_operation_routines", x => x.day_operation_routine_id);
                    table.ForeignKey(
                        name: "FK__day_opera__day_i__70FDBF69",
                        column: x => x.day_id,
                        principalSchema: "finance",
                        principalTable: "day_operation",
                        principalColumn: "day_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__day_opera__routi__71F1E3A2",
                        column: x => x.routine_id,
                        principalSchema: "finance",
                        principalTable: "routines",
                        principalColumn: "routine_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exchange_rate_details",
                schema: "finance",
                columns: table => new
                {
                    exchange_rate_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    exchange_rate_id = table.Column<long>(nullable: false),
                    local_currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    foreign_currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    unit = table.Column<int>(nullable: false),
                    exchange_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exchange_rate_details", x => x.exchange_rate_detail_id);
                    table.ForeignKey(
                        name: "FK__exchange___excha__4707859D",
                        column: x => x.exchange_rate_id,
                        principalSchema: "finance",
                        principalTable: "exchange_rates",
                        principalColumn: "exchange_rate_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__exchange___forei__48EFCE0F",
                        column: x => x.foreign_currency_code,
                        principalSchema: "core",
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__exchange___local__47FBA9D6",
                        column: x => x.local_currency_code,
                        principalSchema: "core",
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "frequency_setups",
                schema: "finance",
                columns: table => new
                {
                    frequency_setup_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fiscal_year_code = table.Column<string>(maxLength: 12, nullable: false),
                    frequency_setup_code = table.Column<string>(maxLength: 12, nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    frequency_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_frequency_setups", x => x.frequency_setup_id);
                    table.ForeignKey(
                        name: "FK__frequency__audit__5D2BD0E6",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__frequency__fisca__5A4F643B",
                        column: x => x.fiscal_year_code,
                        principalSchema: "finance",
                        principalTable: "fiscal_year",
                        principalColumn: "fiscal_year_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__frequency__frequ__5B438874",
                        column: x => x.frequency_id,
                        principalSchema: "finance",
                        principalTable: "frequencies",
                        principalColumn: "frequency_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__frequency__offic__5C37ACAD",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bank_accounts",
                schema: "finance",
                columns: table => new
                {
                    bank_account_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bank_account_name = table.Column<string>(maxLength: 1000, nullable: false),
                    account_id = table.Column<int>(nullable: true),
                    maintained_by_user_id = table.Column<int>(nullable: false),
                    bank_type_id = table.Column<int>(nullable: false),
                    is_merchant_account = table.Column<bool>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    bank_name = table.Column<string>(maxLength: 128, nullable: false),
                    bank_branch = table.Column<string>(maxLength: 128, nullable: false),
                    bank_contact_number = table.Column<string>(maxLength: 128, nullable: true),
                    bank_account_number = table.Column<string>(maxLength: 128, nullable: true),
                    bank_account_type = table.Column<string>(maxLength: 128, nullable: true),
                    street = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    state = table.Column<string>(maxLength: 50, nullable: true),
                    country = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    fax = table.Column<string>(maxLength: 50, nullable: true),
                    cell = table.Column<string>(maxLength: 50, nullable: true),
                    relationship_officer_name = table.Column<string>(maxLength: 128, nullable: true),
                    relationship_officer_contact_number = table.Column<string>(maxLength: 128, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_accounts", x => x.bank_account_id);
                    table.ForeignKey(
                        name: "FK__bank_acco__accou__7ABC33CD",
                        column: x => x.account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__bank_acco__audit__7F80E8EA",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__bank_acco__bank___7CA47C3F",
                        column: x => x.bank_type_id,
                        principalSchema: "finance",
                        principalTable: "bank_types",
                        principalColumn: "bank_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__bank_acco__maint__7BB05806",
                        column: x => x.maintained_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__bank_acco__offic__7E8CC4B1",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tax_setups",
                schema: "finance",
                columns: table => new
                {
                    tax_setup_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    office_id = table.Column<int>(nullable: false),
                    income_tax_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    income_tax_account_id = table.Column<int>(nullable: false),
                    sales_tax_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    sales_tax_account_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tax_setups", x => x.tax_setup_id);
                    table.ForeignKey(
                        name: "FK__tax_setup__audit__61BB7BD9",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tax_setup__incom__5FD33367",
                        column: x => x.income_tax_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tax_setup__offic__5EDF0F2E",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tax_setup__sales__60C757A0",
                        column: x => x.sales_tax_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transaction_details",
                schema: "finance",
                columns: table => new
                {
                    transaction_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transaction_master_id = table.Column<long>(nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    book_date = table.Column<DateTime>(type: "date", nullable: false),
                    tran_type = table.Column<string>(maxLength: 4, nullable: false),
                    account_id = table.Column<int>(nullable: false),
                    statement_reference = table.Column<string>(maxLength: 2000, nullable: true),
                    reconciliation_memo = table.Column<string>(maxLength: 2000, nullable: true),
                    cash_repository_id = table.Column<int>(nullable: true),
                    currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    amount_in_currency = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    local_currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    er = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    amount_in_local_currency = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_details", x => x.transaction_detail_id);
                    table.ForeignKey(
                        name: "FK__transacti__accou__25A691D2",
                        column: x => x.account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__transacti__audit__2A6B46EF",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__transacti__cash___269AB60B",
                        column: x => x.cash_repository_id,
                        principalSchema: "finance",
                        principalTable: "cash_repositories",
                        principalColumn: "cash_repository_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__transacti__curre__278EDA44",
                        column: x => x.currency_code,
                        principalSchema: "core",
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__transacti__local__2882FE7D",
                        column: x => x.local_currency_code,
                        principalSchema: "core",
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__transacti__offic__297722B6",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__transacti__trans__23BE4960",
                        column: x => x.transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer_types",
                schema: "inventory",
                columns: table => new
                {
                    customer_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    customer_type_code = table.Column<string>(maxLength: 24, nullable: false),
                    customer_type_name = table.Column<string>(maxLength: 500, nullable: false),
                    account_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_types", x => x.customer_type_id);
                    table.ForeignKey(
                        name: "FK__customer___accou__0C06BB60",
                        column: x => x.account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customer___audit__0CFADF99",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_setup",
                schema: "inventory",
                columns: table => new
                {
                    office_id = table.Column<int>(nullable: false),
                    inventory_system = table.Column<string>(maxLength: 50, nullable: false),
                    cogs_calculation_method = table.Column<string>(maxLength: 50, nullable: false),
                    allow_multiple_opening_inventory = table.Column<bool>(nullable: false),
                    default_discount_account_id = table.Column<int>(nullable: false),
                    use_pos_checkout_screen = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_setup", x => x.office_id);
                    table.ForeignKey(
                        name: "FK__inventory__defau__3F51553C",
                        column: x => x.default_discount_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__offic__3B80C458",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item_groups",
                schema: "inventory",
                columns: table => new
                {
                    item_group_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_group_code = table.Column<string>(maxLength: 24, nullable: false),
                    item_group_name = table.Column<string>(maxLength: 500, nullable: false),
                    exclude_from_purchase = table.Column<bool>(nullable: false),
                    exclude_from_sales = table.Column<bool>(nullable: false),
                    sales_account_id = table.Column<int>(nullable: false),
                    sales_discount_account_id = table.Column<int>(nullable: false),
                    sales_return_account_id = table.Column<int>(nullable: false),
                    purchase_account_id = table.Column<int>(nullable: false),
                    purchase_discount_account_id = table.Column<int>(nullable: false),
                    inventory_account_id = table.Column<int>(nullable: false),
                    cost_of_goods_sold_account_id = table.Column<int>(nullable: false),
                    parent_item_group_id = table.Column<int>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_groups", x => x.item_group_id);
                    table.ForeignKey(
                        name: "FK__item_grou__audit__22EA20B8",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_grou__cost___2101D846",
                        column: x => x.cost_of_goods_sold_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_grou__inven__200DB40D",
                        column: x => x.inventory_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_grou__paren__21F5FC7F",
                        column: x => x.parent_item_group_id,
                        principalSchema: "inventory",
                        principalTable: "item_groups",
                        principalColumn: "item_group_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_grou__purch__1E256B9B",
                        column: x => x.purchase_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_grou__purch__1F198FD4",
                        column: x => x.purchase_discount_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_grou__sales__1B48FEF0",
                        column: x => x.sales_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_grou__sales__1C3D2329",
                        column: x => x.sales_discount_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_grou__sales__1D314762",
                        column: x => x.sales_return_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shippers",
                schema: "inventory",
                columns: table => new
                {
                    shipper_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    shipper_code = table.Column<string>(maxLength: 24, nullable: true),
                    company_name = table.Column<string>(maxLength: 128, nullable: false),
                    shipper_name = table.Column<string>(maxLength: 150, nullable: true),
                    po_box = table.Column<string>(maxLength: 128, nullable: true),
                    address_line_1 = table.Column<string>(maxLength: 128, nullable: true),
                    address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    street = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    state = table.Column<string>(maxLength: 50, nullable: true),
                    country = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    fax = table.Column<string>(maxLength: 50, nullable: true),
                    cell = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 128, nullable: true),
                    url = table.Column<string>(maxLength: 50, nullable: true),
                    contact_person = table.Column<string>(maxLength: 50, nullable: true),
                    contact_po_box = table.Column<string>(maxLength: 128, nullable: true),
                    contact_address_line_1 = table.Column<string>(maxLength: 128, nullable: true),
                    contact_address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    contact_street = table.Column<string>(maxLength: 50, nullable: true),
                    contact_city = table.Column<string>(maxLength: 50, nullable: true),
                    contact_state = table.Column<string>(maxLength: 50, nullable: true),
                    contact_country = table.Column<string>(maxLength: 50, nullable: true),
                    contact_email = table.Column<string>(maxLength: 128, nullable: true),
                    contact_phone = table.Column<string>(maxLength: 50, nullable: true),
                    contact_cell = table.Column<string>(maxLength: 50, nullable: true),
                    factory_address = table.Column<string>(maxLength: 250, nullable: true),
                    pan_number = table.Column<string>(maxLength: 50, nullable: true),
                    sst_number = table.Column<string>(maxLength: 50, nullable: true),
                    cst_number = table.Column<string>(maxLength: 50, nullable: true),
                    account_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippers", x => x.shipper_id);
                    table.ForeignKey(
                        name: "FK__shippers__accoun__60E75331",
                        column: x => x.account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__shippers__audit___61DB776A",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "inventory",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    store_code = table.Column<string>(maxLength: 24, nullable: false),
                    store_name = table.Column<string>(maxLength: 500, nullable: false),
                    store_type_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    default_account_id_for_checks = table.Column<int>(nullable: false),
                    default_cash_account_id = table.Column<int>(nullable: false),
                    default_cash_repository_id = table.Column<int>(nullable: false),
                    address_line_1 = table.Column<string>(maxLength: 128, nullable: true),
                    address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    street = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    state = table.Column<string>(maxLength: 50, nullable: true),
                    country = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    fax = table.Column<string>(maxLength: 50, nullable: true),
                    cell = table.Column<string>(maxLength: 50, nullable: true),
                    allow_sales = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    SalesDiscountAccountId = table.Column<int>(nullable: false),
                    PurchaseDiscountAccountId = table.Column<int>(nullable: false),
                    ShippingExpenseAccountId = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.store_id);
                    table.ForeignKey(
                        name: "FK__stores__audit_us__5669C4BE",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__stores__default___4CE05A84",
                        column: x => x.default_account_id_for_checks,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__stores__default___4DD47EBD",
                        column: x => x.default_cash_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__stores__default___4EC8A2F6",
                        column: x => x.default_cash_repository_id,
                        principalSchema: "finance",
                        principalTable: "cash_repositories",
                        principalColumn: "cash_repository_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__stores__office_i__4BEC364B",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__stores__purchase__529933DA",
                        column: x => x.PurchaseDiscountAccountId,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__stores__sales_di__50B0EB68",
                        column: x => x.SalesDiscountAccountId,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__stores__shipping__54817C4C",
                        column: x => x.ShippingExpenseAccountId,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__stores__store_ty__4AF81212",
                        column: x => x.store_type_id,
                        principalSchema: "inventory",
                        principalTable: "store_types",
                        principalColumn: "store_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "supplier_types",
                schema: "inventory",
                columns: table => new
                {
                    supplier_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    supplier_type_code = table.Column<string>(maxLength: 24, nullable: false),
                    supplier_type_name = table.Column<string>(maxLength: 500, nullable: false),
                    account_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_types", x => x.supplier_type_id);
                    table.ForeignKey(
                        name: "FK__supplier___accou__7EACC042",
                        column: x => x.account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__supplier___audit__7FA0E47B",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "late_fee",
                schema: "sales",
                columns: table => new
                {
                    late_fee_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    late_fee_code = table.Column<string>(maxLength: 24, nullable: false),
                    late_fee_name = table.Column<string>(maxLength: 500, nullable: false),
                    is_flat_amount = table.Column<bool>(nullable: false),
                    rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    account_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_late_fee", x => x.late_fee_id);
                    table.ForeignKey(
                        name: "FK__late_fee__accoun__1B9E04AB",
                        column: x => x.account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__late_fee__audit___1C9228E4",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "hrm",
                columns: table => new
                {
                    employee_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employee_code = table.Column<string>(maxLength: 12, nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "('')"),
                    last_name = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "('')"),
                    employee_name = table.Column<string>(maxLength: 160, nullable: false),
                    gender_code = table.Column<string>(maxLength: 4, nullable: false),
                    marital_status_id = table.Column<int>(nullable: false),
                    joined_on = table.Column<DateTime>(type: "date", nullable: true),
                    office_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: true),
                    employee_type_id = table.Column<int>(nullable: false),
                    current_department_id = table.Column<int>(nullable: false),
                    current_role_id = table.Column<int>(nullable: true),
                    current_employment_status_id = table.Column<int>(nullable: false),
                    current_job_title_id = table.Column<int>(nullable: false),
                    current_pay_grade_id = table.Column<int>(nullable: false),
                    current_shift_id = table.Column<int>(nullable: false),
                    nationality_id = table.Column<int>(nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: true),
                    photo = table.Column<byte[]>(nullable: true),
                    bank_account_number = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    bank_name = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    bank_branch_name = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    bank_reference_number = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    zip_code = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    address_line_1 = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    address_line_2 = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    street = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    city = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    state = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    country_code = table.Column<string>(maxLength: 12, nullable: true),
                    phone_home = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    phone_cell = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    phone_office_extension = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    phone_emergency = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    phone_emergency_2 = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    email_address = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    website = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    blog = table.Column<string>(maxLength: 128, nullable: true, defaultValueSql: "('')"),
                    is_smoker = table.Column<bool>(nullable: true),
                    is_alcoholic = table.Column<bool>(nullable: true),
                    with_disabilities = table.Column<bool>(nullable: true),
                    low_vision = table.Column<bool>(nullable: true),
                    uses_wheelchair = table.Column<bool>(nullable: true),
                    hard_of_hearing = table.Column<bool>(nullable: true),
                    is_aphonic = table.Column<bool>(nullable: true),
                    is_cognitively_disabled = table.Column<bool>(nullable: true),
                    is_autistic = table.Column<bool>(nullable: true),
                    service_ended_on = table.Column<DateTime>(type: "date", nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK__employees__audit__7A1D154F",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__count__7187CF4E",
                        column: x => x.country_code,
                        principalSchema: "core",
                        principalTable: "countries",
                        principalColumn: "country_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__curre__61516785",
                        column: x => x.current_department_id,
                        principalSchema: "hrm",
                        principalTable: "departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__curre__6339AFF7",
                        column: x => x.current_employment_status_id,
                        principalSchema: "hrm",
                        principalTable: "employment_statuses",
                        principalColumn: "employment_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__curre__642DD430",
                        column: x => x.current_job_title_id,
                        principalSchema: "hrm",
                        principalTable: "job_titles",
                        principalColumn: "job_title_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__curre__6521F869",
                        column: x => x.current_pay_grade_id,
                        principalSchema: "hrm",
                        principalTable: "pay_grades",
                        principalColumn: "pay_grade_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__curre__62458BBE",
                        column: x => x.current_role_id,
                        principalSchema: "hrm",
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__curre__66161CA2",
                        column: x => x.current_shift_id,
                        principalSchema: "hrm",
                        principalTable: "shifts",
                        principalColumn: "shift_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__emplo__605D434C",
                        column: x => x.employee_type_id,
                        principalSchema: "hrm",
                        principalTable: "employee_types",
                        principalColumn: "employee_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__gende__5C8CB268",
                        column: x => x.gender_code,
                        principalSchema: "core",
                        principalTable: "genders",
                        principalColumn: "gender_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__marit__5D80D6A1",
                        column: x => x.marital_status_id,
                        principalSchema: "core",
                        principalTable: "marital_statuses",
                        principalColumn: "marital_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__natio__670A40DB",
                        column: x => x.nationality_id,
                        principalSchema: "hrm",
                        principalTable: "nationalities",
                        principalColumn: "nationality_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__offic__5E74FADA",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employees__user___5F691F13",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menu_items",
                schema: "website",
                columns: table => new
                {
                    menu_item_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    menu_id = table.Column<int>(nullable: true),
                    sort = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: false),
                    url = table.Column<string>(maxLength: 500, nullable: true),
                    target = table.Column<string>(maxLength: 20, nullable: true),
                    content_id = table.Column<int>(nullable: true),
                    parent_menu_item_id = table.Column<int>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_items", x => x.menu_item_id);
                    table.ForeignKey(
                        name: "FK__menu_item__audit__019E3B86",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__menu_item__conte__7FB5F314",
                        column: x => x.content_id,
                        principalSchema: "website",
                        principalTable: "contents",
                        principalColumn: "content_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__menu_item__menu___7DCDAAA2",
                        column: x => x.menu_id,
                        principalSchema: "website",
                        principalTable: "menus",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__menu_item__paren__00AA174D",
                        column: x => x.parent_menu_item_id,
                        principalSchema: "website",
                        principalTable: "menu_items",
                        principalColumn: "menu_item_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "merchant_fee_setup",
                schema: "finance",
                columns: table => new
                {
                    merchant_fee_setup_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    merchant_account_id = table.Column<int>(nullable: false),
                    payment_card_id = table.Column<int>(nullable: false),
                    rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    customer_pays_fee = table.Column<bool>(nullable: false),
                    account_id = table.Column<int>(nullable: false),
                    statement_reference = table.Column<string>(maxLength: 2000, nullable: false, defaultValueSql: "('')"),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_merchant_fee_setup", x => x.merchant_fee_setup_id);
                    table.ForeignKey(
                        name: "FK__merchant___accou__3B95D2F1",
                        column: x => x.account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__merchant___audit__3D7E1B63",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__merchant___merch__38B96646",
                        column: x => x.merchant_account_id,
                        principalSchema: "finance",
                        principalTable: "bank_accounts",
                        principalColumn: "bank_account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__merchant___payme__39AD8A7F",
                        column: x => x.payment_card_id,
                        principalSchema: "finance",
                        principalTable: "payment_cards",
                        principalColumn: "payment_card_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "inventory",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    customer_code = table.Column<string>(maxLength: 24, nullable: false),
                    customer_name = table.Column<string>(maxLength: 500, nullable: false),
                    customer_type_id = table.Column<int>(nullable: false),
                    account_id = table.Column<int>(nullable: true),
                    email = table.Column<string>(maxLength: 128, nullable: true),
                    currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    company_name = table.Column<string>(maxLength: 1000, nullable: true),
                    company_address_line_1 = table.Column<string>(maxLength: 128, nullable: true),
                    company_address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    company_street = table.Column<string>(maxLength: 1000, nullable: true),
                    company_city = table.Column<string>(maxLength: 1000, nullable: true),
                    company_state = table.Column<string>(maxLength: 1000, nullable: true),
                    company_country = table.Column<string>(maxLength: 1000, nullable: true),
                    company_po_box = table.Column<string>(maxLength: 1000, nullable: true),
                    company_zip_code = table.Column<string>(maxLength: 1000, nullable: true),
                    company_phone_numbers = table.Column<string>(maxLength: 1000, nullable: true),
                    company_fax = table.Column<string>(maxLength: 100, nullable: true),
                    logo = table.Column<byte[]>(nullable: true),
                    contact_first_name = table.Column<string>(maxLength: 100, nullable: true),
                    contact_middle_name = table.Column<string>(maxLength: 100, nullable: true),
                    contact_last_name = table.Column<string>(maxLength: 100, nullable: true),
                    contact_address_line_1 = table.Column<string>(maxLength: 128, nullable: true),
                    contact_address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    contact_street = table.Column<string>(maxLength: 100, nullable: true),
                    contact_city = table.Column<string>(maxLength: 100, nullable: true),
                    contact_state = table.Column<string>(maxLength: 100, nullable: true),
                    contact_country = table.Column<string>(maxLength: 100, nullable: true),
                    contact_po_box = table.Column<string>(maxLength: 100, nullable: true),
                    contact_zip_code = table.Column<string>(maxLength: 100, nullable: true),
                    contact_phone_numbers = table.Column<string>(maxLength: 100, nullable: true),
                    contact_fax = table.Column<string>(maxLength: 100, nullable: true),
                    photo = table.Column<byte[]>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK__customers__accou__12B3B8EF",
                        column: x => x.account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customers__audit__149C0161",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customers__curre__13A7DD28",
                        column: x => x.currency_code,
                        principalSchema: "core",
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customers__custo__11BF94B6",
                        column: x => x.customer_type_id,
                        principalSchema: "inventory",
                        principalTable: "customer_types",
                        principalColumn: "customer_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "checkouts",
                schema: "inventory",
                columns: table => new
                {
                    checkout_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    book_date = table.Column<DateTime>(type: "date", nullable: false),
                    transaction_master_id = table.Column<long>(nullable: false),
                    transaction_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    transaction_book = table.Column<string>(maxLength: 100, nullable: false),
                    taxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: true, defaultValueSql: "((0))"),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true, defaultValueSql: "((0))"),
                    tax_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: true, defaultValueSql: "((0))"),
                    tax = table.Column<decimal>(type: "numeric(30, 6)", nullable: true, defaultValueSql: "((0))"),
                    nontaxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: true, defaultValueSql: "((0))"),
                    posted_by = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    cancelled = table.Column<bool>(nullable: false),
                    cancellation_reason = table.Column<string>(maxLength: 1000, nullable: true),
                    shipper_id = table.Column<int>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkouts", x => x.checkout_id);
                    table.ForeignKey(
                        name: "FK__checkouts__audit__711DBAFA",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__checkouts__offic__6E414E4F",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__checkouts__poste__6D4D2A16",
                        column: x => x.posted_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__checkouts__shipp__702996C1",
                        column: x => x.shipper_id,
                        principalSchema: "inventory",
                        principalTable: "shippers",
                        principalColumn: "shipper_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__checkouts__trans__66A02C87",
                        column: x => x.transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "counters",
                schema: "inventory",
                columns: table => new
                {
                    counter_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    counter_code = table.Column<string>(maxLength: 12, nullable: false),
                    counter_name = table.Column<string>(maxLength: 100, nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_counters", x => x.counter_id);
                    table.ForeignKey(
                        name: "FK__counters__audit___5C229E14",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__counters__store___5B2E79DB",
                        column: x => x.store_id,
                        principalSchema: "inventory",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_transfer_requests",
                schema: "inventory",
                columns: table => new
                {
                    inventory_transfer_request_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    office_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    request_date = table.Column<DateTime>(type: "date", nullable: false),
                    transaction_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    reference_number = table.Column<string>(maxLength: 24, nullable: true),
                    statement_reference = table.Column<string>(maxLength: 2000, nullable: true),
                    authorized = table.Column<bool>(nullable: false),
                    authorized_by_user_id = table.Column<int>(nullable: true),
                    authorized_on = table.Column<DateTimeOffset>(nullable: true),
                    authorization_reason = table.Column<string>(maxLength: 500, nullable: true),
                    rejected = table.Column<bool>(nullable: false),
                    rejected_by_user_id = table.Column<int>(nullable: true),
                    rejected_on = table.Column<DateTimeOffset>(nullable: true),
                    rejection_reason = table.Column<string>(maxLength: 500, nullable: true),
                    received = table.Column<bool>(nullable: false),
                    received_by_user_id = table.Column<int>(nullable: true),
                    received_on = table.Column<DateTimeOffset>(nullable: true),
                    receipt_memo = table.Column<string>(maxLength: 500, nullable: true),
                    delivered = table.Column<bool>(nullable: false),
                    delivered_by_user_id = table.Column<int>(nullable: true),
                    delivered_on = table.Column<DateTimeOffset>(nullable: true),
                    delivery_memo = table.Column<string>(maxLength: 500, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_transfer_requests", x => x.inventory_transfer_request_id);
                    table.ForeignKey(
                        name: "FK__inventory__audit__0EAE1DE1",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__autho__08012052",
                        column: x => x.authorized_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__deliv__0DB9F9A8",
                        column: x => x.delivered_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__offic__033C6B35",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__recei__0BD1B136",
                        column: x => x.received_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__rejec__09E968C4",
                        column: x => x.rejected_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__store__0524B3A7",
                        column: x => x.store_id,
                        principalSchema: "inventory",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__user___04308F6E",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                schema: "inventory",
                columns: table => new
                {
                    supplier_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    supplier_code = table.Column<string>(maxLength: 24, nullable: false),
                    supplier_name = table.Column<string>(maxLength: 500, nullable: false),
                    supplier_type_id = table.Column<int>(nullable: false),
                    account_id = table.Column<int>(nullable: true),
                    email = table.Column<string>(maxLength: 128, nullable: true),
                    currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    company_name = table.Column<string>(maxLength: 1000, nullable: true),
                    pan_number = table.Column<string>(maxLength: 100, nullable: true),
                    company_address_line_1 = table.Column<string>(maxLength: 128, nullable: true),
                    company_address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    company_street = table.Column<string>(maxLength: 1000, nullable: true),
                    company_city = table.Column<string>(maxLength: 1000, nullable: true),
                    company_state = table.Column<string>(maxLength: 1000, nullable: true),
                    company_country = table.Column<string>(maxLength: 1000, nullable: true),
                    company_po_box = table.Column<string>(maxLength: 1000, nullable: true),
                    company_zip_code = table.Column<string>(maxLength: 1000, nullable: true),
                    company_phone_numbers = table.Column<string>(maxLength: 1000, nullable: true),
                    company_fax = table.Column<string>(maxLength: 100, nullable: true),
                    logo = table.Column<byte[]>(nullable: true),
                    contact_first_name = table.Column<string>(maxLength: 100, nullable: true),
                    contact_middle_name = table.Column<string>(maxLength: 100, nullable: true),
                    contact_last_name = table.Column<string>(maxLength: 100, nullable: true),
                    contact_address_line_1 = table.Column<string>(maxLength: 128, nullable: true),
                    contact_address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    contact_street = table.Column<string>(maxLength: 100, nullable: true),
                    contact_city = table.Column<string>(maxLength: 100, nullable: true),
                    contact_state = table.Column<string>(maxLength: 100, nullable: true),
                    contact_country = table.Column<string>(maxLength: 100, nullable: true),
                    contact_po_box = table.Column<string>(maxLength: 100, nullable: true),
                    contact_zip_code = table.Column<string>(maxLength: 100, nullable: true),
                    contact_phone_numbers = table.Column<string>(maxLength: 100, nullable: true),
                    contact_fax = table.Column<string>(maxLength: 100, nullable: true),
                    photo = table.Column<byte[]>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.supplier_id);
                    table.ForeignKey(
                        name: "FK__suppliers__accou__0559BDD1",
                        column: x => x.account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__suppliers__audit__07420643",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__suppliers__curre__064DE20A",
                        column: x => x.currency_code,
                        principalSchema: "core",
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__suppliers__suppl__04659998",
                        column: x => x.supplier_type_id,
                        principalSchema: "inventory",
                        principalTable: "supplier_types",
                        principalColumn: "supplier_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payment_terms",
                schema: "sales",
                columns: table => new
                {
                    payment_term_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    payment_term_code = table.Column<string>(maxLength: 24, nullable: false),
                    payment_term_name = table.Column<string>(maxLength: 500, nullable: false),
                    due_on_date = table.Column<bool>(nullable: false),
                    due_days = table.Column<int>(nullable: false),
                    due_frequency_id = table.Column<int>(nullable: true),
                    grace_period = table.Column<int>(nullable: false),
                    late_fee_id = table.Column<int>(nullable: true),
                    late_fee_posting_frequency_id = table.Column<int>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_terms", x => x.payment_term_id);
                    table.ForeignKey(
                        name: "FK__payment_t__audit__41C3AD93",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__payment_t__due_f__3DF31CAF",
                        column: x => x.due_frequency_id,
                        principalSchema: "finance",
                        principalTable: "frequencies",
                        principalColumn: "frequency_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__payment_t__late___3FDB6521",
                        column: x => x.late_fee_id,
                        principalSchema: "sales",
                        principalTable: "late_fee",
                        principalColumn: "late_fee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__payment_t__late___40CF895A",
                        column: x => x.late_fee_posting_frequency_id,
                        principalSchema: "finance",
                        principalTable: "frequencies",
                        principalColumn: "frequency_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attendances",
                schema: "hrm",
                columns: table => new
                {
                    attendance_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    office_id = table.Column<int>(nullable: false),
                    employee_id = table.Column<int>(nullable: false),
                    attendance_date = table.Column<DateTime>(type: "date", nullable: false),
                    was_present = table.Column<bool>(nullable: false),
                    check_in_time = table.Column<TimeSpan>(nullable: true),
                    check_out_time = table.Column<TimeSpan>(nullable: true),
                    overtime_hours = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    was_absent = table.Column<bool>(nullable: false),
                    reason_for_absenteeism = table.Column<string>(maxLength: 1000, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendances", x => x.attendance_id);
                    table.ForeignKey(
                        name: "FK__attendanc__audit__569ECEE8",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__attendanc__emplo__54B68676",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__attendanc__offic__53C2623D",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                schema: "hrm",
                columns: table => new
                {
                    contract_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    department_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: true),
                    leave_benefit_id = table.Column<int>(nullable: true),
                    began_on = table.Column<DateTime>(type: "date", nullable: true),
                    ended_on = table.Column<DateTime>(type: "date", nullable: true),
                    employment_status_code_id = table.Column<int>(nullable: false),
                    verification_status_id = table.Column<short>(nullable: false),
                    verified_by_user_id = table.Column<int>(nullable: true),
                    verified_on = table.Column<DateTime>(type: "date", nullable: true),
                    verification_reason = table.Column<string>(maxLength: 128, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.contract_id);
                    table.ForeignKey(
                        name: "FK__contracts__audit__13DCE752",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contracts__depar__0E240DFC",
                        column: x => x.department_id,
                        principalSchema: "hrm",
                        principalTable: "departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contracts__emplo__0C3BC58A",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contracts__emplo__11007AA7",
                        column: x => x.employment_status_code_id,
                        principalSchema: "hrm",
                        principalTable: "employment_status_codes",
                        principalColumn: "employment_status_code_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contracts__leave__100C566E",
                        column: x => x.leave_benefit_id,
                        principalSchema: "hrm",
                        principalTable: "leave_benefits",
                        principalColumn: "leave_benefit_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contracts__offic__0D2FE9C3",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contracts__role___0F183235",
                        column: x => x.role_id,
                        principalSchema: "hrm",
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contracts__verif__11F49EE0",
                        column: x => x.verification_status_id,
                        principalSchema: "core",
                        principalTable: "verification_statuses",
                        principalColumn: "verification_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__contracts__verif__12E8C319",
                        column: x => x.verified_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employee_experiences",
                schema: "hrm",
                columns: table => new
                {
                    employee_experience_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(nullable: false),
                    organization_name = table.Column<string>(maxLength: 128, nullable: false),
                    title = table.Column<string>(maxLength: 128, nullable: false),
                    started_on = table.Column<DateTime>(type: "date", nullable: true),
                    ended_on = table.Column<DateTime>(type: "date", nullable: true),
                    details = table.Column<string>(maxLength: 1000, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_experiences", x => x.employee_experience_id);
                    table.ForeignKey(
                        name: "FK__employee___audit__1995C0A8",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employee___emplo__18A19C6F",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employee_identification_details",
                schema: "hrm",
                columns: table => new
                {
                    employee_identification_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(nullable: false),
                    identification_type_id = table.Column<int>(nullable: false),
                    identification_number = table.Column<string>(maxLength: 128, nullable: false),
                    expires_on = table.Column<DateTime>(type: "date", nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_identification_details", x => x.employee_identification_detail_id);
                    table.ForeignKey(
                        name: "FK__employee___audit__00CA12DE",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employee___emplo__7EE1CA6C",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employee___ident__7FD5EEA5",
                        column: x => x.identification_type_id,
                        principalSchema: "hrm",
                        principalTable: "identification_types",
                        principalColumn: "identification_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employee_qualifications",
                schema: "hrm",
                columns: table => new
                {
                    employee_qualification_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(nullable: false),
                    education_level_id = table.Column<int>(nullable: false),
                    institution = table.Column<string>(maxLength: 128, nullable: false),
                    majors = table.Column<string>(maxLength: 128, nullable: false),
                    total_years = table.Column<int>(nullable: true),
                    score = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    started_on = table.Column<DateTime>(type: "date", nullable: true),
                    completed_on = table.Column<DateTime>(type: "date", nullable: true),
                    details = table.Column<string>(maxLength: 1000, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_qualifications", x => x.employee_qualification_id);
                    table.ForeignKey(
                        name: "FK__employee___audit__2042BE37",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employee___educa__1F4E99FE",
                        column: x => x.education_level_id,
                        principalSchema: "hrm",
                        principalTable: "education_levels",
                        principalColumn: "education_level_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employee___emplo__1E5A75C5",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employee_social_network_details",
                schema: "hrm",
                columns: table => new
                {
                    employee_social_network_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(nullable: false),
                    social_network_id = table.Column<int>(nullable: false),
                    profile_link = table.Column<string>(maxLength: 1000, nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_social_network_details", x => x.employee_social_network_detail_id);
                    table.ForeignKey(
                        name: "FK__employee___audit__0777106D",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employee___emplo__058EC7FB",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__employee___socia__0682EC34",
                        column: x => x.social_network_id,
                        principalSchema: "hrm",
                        principalTable: "social_networks",
                        principalColumn: "social_network_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exits",
                schema: "hrm",
                columns: table => new
                {
                    exit_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(nullable: false),
                    forward_to = table.Column<int>(nullable: true),
                    change_status_to = table.Column<int>(nullable: false),
                    exit_type_id = table.Column<int>(nullable: false),
                    exit_interview_details = table.Column<string>(maxLength: 1000, nullable: true),
                    reason = table.Column<string>(maxLength: 128, nullable: false),
                    details = table.Column<string>(maxLength: 1000, nullable: true),
                    verification_status_id = table.Column<short>(nullable: false),
                    verified_by_user_id = table.Column<int>(nullable: true),
                    verified_on = table.Column<DateTime>(type: "date", nullable: true),
                    verification_reason = table.Column<string>(maxLength: 128, nullable: true),
                    service_end_date = table.Column<DateTime>(type: "date", nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exits", x => x.exit_id);
                    table.ForeignKey(
                        name: "FK__exits__audit_use__4EFDAD20",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__exits__change_st__4B2D1C3C",
                        column: x => x.change_status_to,
                        principalSchema: "hrm",
                        principalTable: "employment_statuses",
                        principalColumn: "employment_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__exits__employee___4944D3CA",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__exits__exit_type__4C214075",
                        column: x => x.exit_type_id,
                        principalSchema: "hrm",
                        principalTable: "exit_types",
                        principalColumn: "exit_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__exits__forward_t__4A38F803",
                        column: x => x.forward_to,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__exits__verificat__4D1564AE",
                        column: x => x.verification_status_id,
                        principalSchema: "core",
                        principalTable: "verification_statuses",
                        principalColumn: "verification_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__exits__verified___4E0988E7",
                        column: x => x.verified_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "leave_applications",
                schema: "hrm",
                columns: table => new
                {
                    leave_application_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    employee_id = table.Column<int>(nullable: false),
                    leave_type_id = table.Column<int>(nullable: false),
                    entered_by = table.Column<int>(nullable: false),
                    applied_on = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getutcdate())"),
                    reason = table.Column<string>(maxLength: 1000, nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    verification_status_id = table.Column<short>(nullable: false),
                    verified_by_user_id = table.Column<int>(nullable: true),
                    verified_on = table.Column<DateTime>(type: "date", nullable: true),
                    verification_reason = table.Column<string>(maxLength: 128, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leave_applications", x => x.leave_application_id);
                    table.ForeignKey(
                        name: "FK__leave_app__audit__2AC04CAA",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__leave_app__emplo__25077354",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__leave_app__enter__26EFBBC6",
                        column: x => x.entered_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__leave_app__leave__25FB978D",
                        column: x => x.leave_type_id,
                        principalSchema: "hrm",
                        principalTable: "leave_types",
                        principalColumn: "leave_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__leave_app__verif__28D80438",
                        column: x => x.verification_status_id,
                        principalSchema: "core",
                        principalTable: "verification_statuses",
                        principalColumn: "verification_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__leave_app__verif__29CC2871",
                        column: x => x.verified_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "resignations",
                schema: "hrm",
                columns: table => new
                {
                    resignation_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    entered_by = table.Column<int>(nullable: false),
                    notice_date = table.Column<DateTime>(type: "date", nullable: false),
                    desired_resign_date = table.Column<DateTime>(type: "date", nullable: false),
                    employee_id = table.Column<int>(nullable: false),
                    forward_to = table.Column<int>(nullable: true),
                    reason = table.Column<string>(maxLength: 128, nullable: false),
                    details = table.Column<string>(maxLength: 1000, nullable: true),
                    verification_status_id = table.Column<short>(nullable: false),
                    verified_by_user_id = table.Column<int>(nullable: true),
                    verified_on = table.Column<DateTime>(type: "date", nullable: true),
                    verification_reason = table.Column<string>(maxLength: 128, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resignations", x => x.resignation_id);
                    table.ForeignKey(
                        name: "FK__resignati__audit__3449B6E4",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__resignati__emplo__30792600",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__resignati__enter__2F8501C7",
                        column: x => x.entered_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__resignati__forwa__316D4A39",
                        column: x => x.forward_to,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__resignati__verif__32616E72",
                        column: x => x.verification_status_id,
                        principalSchema: "core",
                        principalTable: "verification_statuses",
                        principalColumn: "verification_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__resignati__verif__335592AB",
                        column: x => x.verified_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "terminations",
                schema: "hrm",
                columns: table => new
                {
                    termination_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    notice_date = table.Column<DateTime>(type: "date", nullable: false),
                    employee_id = table.Column<int>(nullable: false),
                    forward_to = table.Column<int>(nullable: true),
                    change_status_to = table.Column<int>(nullable: false),
                    reason = table.Column<string>(maxLength: 128, nullable: false),
                    details = table.Column<string>(maxLength: 1000, nullable: true),
                    service_end_date = table.Column<DateTime>(type: "date", nullable: false),
                    verification_status_id = table.Column<short>(nullable: false),
                    verified_by_user_id = table.Column<int>(nullable: true),
                    verified_on = table.Column<DateTime>(type: "date", nullable: true),
                    verification_reason = table.Column<string>(maxLength: 128, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terminations", x => x.termination_id);
                    table.ForeignKey(
                        name: "FK__terminati__audit__3EC74557",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__terminati__chang__3BEAD8AC",
                        column: x => x.change_status_to,
                        principalSchema: "hrm",
                        principalTable: "employment_statuses",
                        principalColumn: "employment_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__terminati__emplo__3A02903A",
                        column: x => x.employee_id,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__terminati__forwa__3AF6B473",
                        column: x => x.forward_to,
                        principalSchema: "hrm",
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__terminati__verif__3CDEFCE5",
                        column: x => x.verification_status_id,
                        principalSchema: "core",
                        principalTable: "verification_statuses",
                        principalColumn: "verification_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__terminati__verif__3DD3211E",
                        column: x => x.verified_by_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quotations",
                schema: "purchase",
                columns: table => new
                {
                    quotation_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    expected_delivery_date = table.Column<DateTime>(type: "date", nullable: false),
                    transaction_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    supplier_id = table.Column<int>(nullable: false),
                    price_type_id = table.Column<int>(nullable: false),
                    shipper_id = table.Column<int>(nullable: true),
                    user_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    reference_number = table.Column<string>(maxLength: 24, nullable: true),
                    terms = table.Column<string>(maxLength: 500, nullable: true),
                    internal_memo = table.Column<string>(maxLength: 500, nullable: true),
                    taxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    tax_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    tax = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    nontaxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    cancelled = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotations", x => x.quotation_id);
                    table.ForeignKey(
                        name: "FK__quotation__audit__513AFB4D",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__offic__4A8DFDBE",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__price__47B19113",
                        column: x => x.price_type_id,
                        principalSchema: "purchase",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__shipp__48A5B54C",
                        column: x => x.shipper_id,
                        principalSchema: "inventory",
                        principalTable: "shippers",
                        principalColumn: "shipper_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__suppl__46BD6CDA",
                        column: x => x.supplier_id,
                        principalSchema: "inventory",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__user___4999D985",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer_receipts",
                schema: "sales",
                columns: table => new
                {
                    receipt_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transaction_master_id = table.Column<long>(nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    er_debit = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    er_credit = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    cash_repository_id = table.Column<int>(nullable: true),
                    posted_date = table.Column<DateTime>(type: "date", nullable: true),
                    tender = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    change = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    collected_on_bank_id = table.Column<int>(nullable: true),
                    collected_bank_instrument_code = table.Column<string>(maxLength: 500, nullable: true),
                    collected_bank_transaction_code = table.Column<string>(maxLength: 500, nullable: true),
                    check_number = table.Column<string>(maxLength: 100, nullable: true),
                    check_date = table.Column<DateTime>(type: "date", nullable: true),
                    check_bank_name = table.Column<string>(maxLength: 1000, nullable: true),
                    check_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    check_cleared = table.Column<bool>(nullable: true),
                    check_clear_date = table.Column<DateTime>(type: "date", nullable: true),
                    check_clearing_memo = table.Column<string>(maxLength: 1000, nullable: true),
                    check_clearing_transaction_master_id = table.Column<long>(nullable: true),
                    gift_card_number = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_receipts", x => x.receipt_id);
                    table.ForeignKey(
                        name: "FK__customer___cash___2121D3D7",
                        column: x => x.cash_repository_id,
                        principalSchema: "finance",
                        principalTable: "cash_repositories",
                        principalColumn: "cash_repository_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customer___check__230A1C49",
                        column: x => x.check_clearing_transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customer___colle__2215F810",
                        column: x => x.collected_on_bank_id,
                        principalSchema: "finance",
                        principalTable: "bank_accounts",
                        principalColumn: "bank_account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customer___curre__202DAF9E",
                        column: x => x.currency_code,
                        principalSchema: "core",
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customer___custo__1F398B65",
                        column: x => x.customer_id,
                        principalSchema: "inventory",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customer___trans__1E45672C",
                        column: x => x.transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gift_cards",
                schema: "sales",
                columns: table => new
                {
                    gift_card_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    gift_card_number = table.Column<string>(maxLength: 100, nullable: false),
                    payable_account_id = table.Column<int>(nullable: false),
                    customer_id = table.Column<int>(nullable: true),
                    first_name = table.Column<string>(maxLength: 100, nullable: true),
                    middle_name = table.Column<string>(maxLength: 100, nullable: true),
                    last_name = table.Column<string>(maxLength: 100, nullable: true),
                    address_line_1 = table.Column<string>(maxLength: 128, nullable: true),
                    address_line_2 = table.Column<string>(maxLength: 128, nullable: true),
                    street = table.Column<string>(maxLength: 100, nullable: true),
                    city = table.Column<string>(maxLength: 100, nullable: true),
                    state = table.Column<string>(maxLength: 100, nullable: true),
                    country = table.Column<string>(maxLength: 100, nullable: true),
                    po_box = table.Column<string>(maxLength: 100, nullable: true),
                    zip_code = table.Column<string>(maxLength: 100, nullable: true),
                    phone_numbers = table.Column<string>(maxLength: 100, nullable: true),
                    fax = table.Column<string>(maxLength: 100, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gift_cards", x => x.gift_card_id);
                    table.ForeignKey(
                        name: "FK__gift_card__audit__11207638",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__gift_card__custo__102C51FF",
                        column: x => x.customer_id,
                        principalSchema: "inventory",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__gift_card__payab__0F382DC6",
                        column: x => x.payable_account_id,
                        principalSchema: "finance",
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "late_fee_postings",
                schema: "sales",
                columns: table => new
                {
                    transaction_master_id = table.Column<long>(nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    late_fee_tran_id = table.Column<long>(nullable: false),
                    amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_late_fee_postings", x => x.transaction_master_id);
                    table.ForeignKey(
                        name: "FK__late_fee___custo__224B023A",
                        column: x => x.customer_id,
                        principalSchema: "inventory",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__late_fee___late___233F2673",
                        column: x => x.late_fee_tran_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__late_fee___trans__2156DE01",
                        column: x => x.transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quotations",
                schema: "sales",
                columns: table => new
                {
                    quotation_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    expected_delivery_date = table.Column<DateTime>(type: "date", nullable: false),
                    transaction_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    customer_id = table.Column<int>(nullable: false),
                    price_type_id = table.Column<int>(nullable: false),
                    shipper_id = table.Column<int>(nullable: true),
                    user_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    reference_number = table.Column<string>(maxLength: 24, nullable: true),
                    terms = table.Column<string>(maxLength: 500, nullable: true),
                    internal_memo = table.Column<string>(maxLength: 500, nullable: true),
                    taxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    tax_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    tax = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    nontaxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    cancelled = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotations", x => x.quotation_id);
                    table.ForeignKey(
                        name: "FK__quotation__audit__62307D25",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__custo__57B2EEB2",
                        column: x => x.customer_id,
                        principalSchema: "inventory",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__offic__5B837F96",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__price__58A712EB",
                        column: x => x.price_type_id,
                        principalSchema: "sales",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__shipp__599B3724",
                        column: x => x.shipper_id,
                        principalSchema: "inventory",
                        principalTable: "shippers",
                        principalColumn: "shipper_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__user___5A8F5B5D",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cashiers",
                schema: "sales",
                columns: table => new
                {
                    cashier_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cashier_code = table.Column<string>(maxLength: 12, nullable: false),
                    pin_code = table.Column<string>(maxLength: 8, nullable: false),
                    associated_user_id = table.Column<int>(nullable: false),
                    counter_id = table.Column<int>(nullable: false),
                    valid_from = table.Column<DateTime>(type: "date", nullable: false),
                    valid_till = table.Column<DateTime>(type: "date", nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashiers", x => x.cashier_id);
                    table.ForeignKey(
                        name: "FK__cashiers__associ__468862B0",
                        column: x => x.associated_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__cashiers__audit___4964CF5B",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__cashiers__counte__477C86E9",
                        column: x => x.counter_id,
                        principalSchema: "inventory",
                        principalTable: "counters",
                        principalColumn: "counter_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_transfer_deliveries",
                schema: "inventory",
                columns: table => new
                {
                    inventory_transfer_delivery_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    inventory_transfer_request_id = table.Column<long>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    destination_store_id = table.Column<int>(nullable: false),
                    delivery_date = table.Column<DateTime>(type: "date", nullable: false),
                    transaction_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    reference_number = table.Column<string>(maxLength: 24, nullable: true),
                    statement_reference = table.Column<string>(maxLength: 2000, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_transfer_deliveries", x => x.inventory_transfer_delivery_id);
                    table.ForeignKey(
                        name: "FK__inventory__audit__1DF06171",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__desti__1C0818FF",
                        column: x => x.destination_store_id,
                        principalSchema: "inventory",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__inven__192BAC54",
                        column: x => x.inventory_transfer_request_id,
                        principalSchema: "inventory",
                        principalTable: "inventory_transfer_requests",
                        principalColumn: "inventory_transfer_request_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__offic__1A1FD08D",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__user___1B13F4C6",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "items",
                schema: "inventory",
                columns: table => new
                {
                    item_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_code = table.Column<string>(maxLength: 24, nullable: false),
                    item_name = table.Column<string>(maxLength: 500, nullable: false),
                    barcode = table.Column<string>(maxLength: 100, nullable: true),
                    item_group_id = table.Column<int>(nullable: false),
                    item_type_id = table.Column<int>(nullable: false),
                    brand_id = table.Column<int>(nullable: true),
                    preferred_supplier_id = table.Column<int>(nullable: true),
                    lead_time_in_days = table.Column<int>(nullable: true),
                    unit_id = table.Column<int>(nullable: false),
                    hot_item = table.Column<bool>(nullable: false),
                    is_taxable_item = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    cost_price = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    cost_price_includes_tax = table.Column<bool>(nullable: false),
                    selling_price = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    selling_price_includes_tax = table.Column<bool>(nullable: false),
                    reorder_level = table.Column<int>(nullable: false),
                    reorder_quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    reorder_unit_id = table.Column<int>(nullable: false),
                    maintain_inventory = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    photo = table.Column<byte[]>(nullable: true),
                    allow_sales = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    allow_purchase = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    is_variant_of = table.Column<int>(nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.item_id);
                    table.ForeignKey(
                        name: "FK__items__audit_use__416EA7D8",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__items__brand_id__3414ACBA",
                        column: x => x.brand_id,
                        principalSchema: "inventory",
                        principalTable: "brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__items__is_varian__407A839F",
                        column: x => x.is_variant_of,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__items__item_grou__322C6448",
                        column: x => x.item_group_id,
                        principalSchema: "inventory",
                        principalTable: "item_groups",
                        principalColumn: "item_group_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__items__item_type__33208881",
                        column: x => x.item_type_id,
                        principalSchema: "inventory",
                        principalTable: "item_types",
                        principalColumn: "item_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__items__preferred__3508D0F3",
                        column: x => x.preferred_supplier_id,
                        principalSchema: "inventory",
                        principalTable: "suppliers",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__items__reorder_u__3CA9F2BB",
                        column: x => x.reorder_unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__items__unit_id__35FCF52C",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                schema: "purchase",
                columns: table => new
                {
                    purchase_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    checkout_id = table.Column<long>(nullable: false),
                    supplier_id = table.Column<int>(nullable: false),
                    price_type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.purchase_id);
                    table.ForeignKey(
                        name: "FK__purchases__check__3C3FDE67",
                        column: x => x.checkout_id,
                        principalSchema: "inventory",
                        principalTable: "checkouts",
                        principalColumn: "checkout_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__purchases__price__3E2826D9",
                        column: x => x.price_type_id,
                        principalSchema: "purchase",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__purchases__suppl__3D3402A0",
                        column: x => x.supplier_id,
                        principalSchema: "inventory",
                        principalTable: "suppliers",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "supplier_payments",
                schema: "purchase",
                columns: table => new
                {
                    payment_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transaction_master_id = table.Column<long>(nullable: false),
                    supplier_id = table.Column<int>(nullable: false),
                    currency_code = table.Column<string>(maxLength: 12, nullable: false),
                    er_debit = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    er_credit = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    cash_repository_id = table.Column<int>(nullable: true),
                    posted_date = table.Column<DateTime>(type: "date", nullable: true),
                    tender = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    change = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    bank_id = table.Column<int>(nullable: true),
                    bank_instrument_code = table.Column<string>(maxLength: 500, nullable: true),
                    bank_transaction_code = table.Column<string>(maxLength: 500, nullable: true),
                    check_number = table.Column<string>(maxLength: 100, nullable: true),
                    check_date = table.Column<DateTime>(type: "date", nullable: true),
                    check_bank_name = table.Column<string>(maxLength: 1000, nullable: true),
                    check_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_payments", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK__supplier___bank___7A3D10E0",
                        column: x => x.bank_id,
                        principalSchema: "finance",
                        principalTable: "bank_accounts",
                        principalColumn: "bank_account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__supplier___cash___7948ECA7",
                        column: x => x.cash_repository_id,
                        principalSchema: "finance",
                        principalTable: "cash_repositories",
                        principalColumn: "cash_repository_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__supplier___curre__766C7FFC",
                        column: x => x.currency_code,
                        principalSchema: "core",
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__supplier___suppl__75785BC3",
                        column: x => x.supplier_id,
                        principalSchema: "inventory",
                        principalTable: "suppliers",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__supplier___trans__7484378A",
                        column: x => x.transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "purchase",
                columns: table => new
                {
                    order_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quotation_id = table.Column<long>(nullable: true),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    expected_delivery_date = table.Column<DateTime>(type: "date", nullable: false),
                    transaction_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    supplier_id = table.Column<int>(nullable: false),
                    price_type_id = table.Column<int>(nullable: false),
                    shipper_id = table.Column<int>(nullable: true),
                    user_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    reference_number = table.Column<string>(maxLength: 24, nullable: true),
                    terms = table.Column<string>(maxLength: 500, nullable: true),
                    internal_memo = table.Column<string>(maxLength: 500, nullable: true),
                    taxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    tax_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    tax = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    nontaxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    cancelled = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__orders__audit_us__691284DE",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__office_i__6265874F",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__price_ty__5F891AA4",
                        column: x => x.price_type_id,
                        principalSchema: "purchase",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__quotatio__5CACADF9",
                        column: x => x.quotation_id,
                        principalSchema: "purchase",
                        principalTable: "quotations",
                        principalColumn: "quotation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__shipper___607D3EDD",
                        column: x => x.shipper_id,
                        principalSchema: "inventory",
                        principalTable: "shippers",
                        principalColumn: "shipper_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__supplier__5E94F66B",
                        column: x => x.supplier_id,
                        principalSchema: "inventory",
                        principalTable: "suppliers",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__user_id__61716316",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gift_card_transactions",
                schema: "sales",
                columns: table => new
                {
                    transaction_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    gift_card_id = table.Column<int>(nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: true),
                    book_date = table.Column<DateTime>(type: "date", nullable: true),
                    transaction_master_id = table.Column<long>(nullable: false),
                    transaction_type = table.Column<string>(maxLength: 2, nullable: false),
                    amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gift_card_transactions", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK__gift_card__gift___15E52B55",
                        column: x => x.gift_card_id,
                        principalSchema: "sales",
                        principalTable: "gift_cards",
                        principalColumn: "gift_card_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__gift_card__trans__16D94F8E",
                        column: x => x.transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "sales",
                columns: table => new
                {
                    order_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quotation_id = table.Column<long>(nullable: true),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    expected_delivery_date = table.Column<DateTime>(type: "date", nullable: false),
                    transaction_timestamp = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "(getutcdate())"),
                    customer_id = table.Column<int>(nullable: false),
                    price_type_id = table.Column<int>(nullable: false),
                    shipper_id = table.Column<int>(nullable: true),
                    user_id = table.Column<int>(nullable: false),
                    office_id = table.Column<int>(nullable: false),
                    reference_number = table.Column<string>(maxLength: 24, nullable: true),
                    terms = table.Column<string>(maxLength: 500, nullable: true),
                    internal_memo = table.Column<string>(maxLength: 500, nullable: true),
                    taxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    tax_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    tax = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    nontaxable_total = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    cancelled = table.Column<bool>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__orders__audit_us__7A0806B6",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__customer__6F8A7843",
                        column: x => x.customer_id,
                        principalSchema: "inventory",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__office_i__735B0927",
                        column: x => x.office_id,
                        principalSchema: "core",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__price_ty__707E9C7C",
                        column: x => x.price_type_id,
                        principalSchema: "sales",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__quotatio__6DA22FD1",
                        column: x => x.quotation_id,
                        principalSchema: "sales",
                        principalTable: "quotations",
                        principalColumn: "quotation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__shipper___7172C0B5",
                        column: x => x.shipper_id,
                        principalSchema: "inventory",
                        principalTable: "shippers",
                        principalColumn: "shipper_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__user_id__7266E4EE",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cashier_login_info",
                schema: "sales",
                columns: table => new
                {
                    cashier_login_info_id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    counter_id = table.Column<int>(nullable: true),
                    cashier_id = table.Column<int>(nullable: true),
                    login_date = table.Column<DateTimeOffset>(nullable: false),
                    success = table.Column<bool>(nullable: false),
                    attempted_by = table.Column<int>(nullable: false),
                    browser = table.Column<string>(maxLength: 1000, nullable: true),
                    ip_address = table.Column<string>(maxLength: 1000, nullable: true),
                    user_agent = table.Column<string>(maxLength: 1000, nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashier_login_info", x => x.cashier_login_info_id);
                    table.ForeignKey(
                        name: "FK__cashier_l__attem__5105F123",
                        column: x => x.attempted_by,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__cashier_l__audit__51FA155C",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__cashier_l__cashi__5011CCEA",
                        column: x => x.cashier_id,
                        principalSchema: "sales",
                        principalTable: "cashiers",
                        principalColumn: "cashier_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__cashier_l__count__4F1DA8B1",
                        column: x => x.counter_id,
                        principalSchema: "inventory",
                        principalTable: "counters",
                        principalColumn: "counter_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "checkout_details",
                schema: "inventory",
                columns: table => new
                {
                    checkout_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    checkout_id = table.Column<long>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    book_date = table.Column<DateTime>(type: "date", nullable: false),
                    transaction_type = table.Column<string>(maxLength: 2, nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    cost_of_goods_sold = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    is_taxed = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    shipping_charge = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    base_unit_id = table.Column<int>(nullable: false),
                    base_quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkout_details", x => x.checkout_detail_id);
                    table.ForeignKey(
                        name: "FK__checkout___base___7F6BDA51",
                        column: x => x.base_unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__checkout___check__75E27017",
                        column: x => x.checkout_id,
                        principalSchema: "inventory",
                        principalTable: "checkouts",
                        principalColumn: "checkout_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__checkout___item___78BEDCC2",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__checkout___store__76D69450",
                        column: x => x.store_id,
                        principalSchema: "inventory",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__checkout___unit___7E77B618",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_transfer_delivery_details",
                schema: "inventory",
                columns: table => new
                {
                    inventory_transfer_delivery_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    inventory_transfer_delivery_id = table.Column<long>(nullable: false),
                    request_date = table.Column<DateTime>(type: "date", nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    base_unit_id = table.Column<int>(nullable: false),
                    base_quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_transfer_delivery_details", x => x.inventory_transfer_delivery_detail_id);
                    table.ForeignKey(
                        name: "FK__inventory__base___25918339",
                        column: x => x.base_unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__inven__22B5168E",
                        column: x => x.inventory_transfer_delivery_id,
                        principalSchema: "inventory",
                        principalTable: "inventory_transfer_deliveries",
                        principalColumn: "inventory_transfer_delivery_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__item___23A93AC7",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__unit___249D5F00",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_transfer_request_details",
                schema: "inventory",
                columns: table => new
                {
                    inventory_transfer_request_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    inventory_transfer_request_id = table.Column<long>(nullable: false),
                    request_date = table.Column<DateTime>(type: "date", nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    base_unit_id = table.Column<int>(nullable: false),
                    base_quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_transfer_request_details", x => x.inventory_transfer_request_detail_id);
                    table.ForeignKey(
                        name: "FK__inventory__base___164F3FA9",
                        column: x => x.base_unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__inven__1372D2FE",
                        column: x => x.inventory_transfer_request_id,
                        principalSchema: "inventory",
                        principalTable: "inventory_transfer_requests",
                        principalColumn: "inventory_transfer_request_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__item___1466F737",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__unit___155B1B70",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item_variants",
                schema: "inventory",
                columns: table => new
                {
                    item_variant_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(nullable: false),
                    variant_id = table.Column<int>(nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_variants", x => x.item_variant_id);
                    table.ForeignKey(
                        name: "FK__item_vari__audit__36BC0F3B",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_vari__item___34D3C6C9",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_vari__varia__35C7EB02",
                        column: x => x.variant_id,
                        principalSchema: "inventory",
                        principalTable: "variants",
                        principalColumn: "variant_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "serial_numbers",
                schema: "inventory",
                columns: table => new
                {
                    serial_number_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    transaction_type = table.Column<string>(maxLength: 2, nullable: false),
                    checkout_id = table.Column<long>(nullable: false),
                    batch_number = table.Column<string>(maxLength: 50, nullable: false),
                    serial_number = table.Column<string>(maxLength: 150, nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    sales_transaction_id = table.Column<long>(nullable: true),
                    deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serial_numbers", x => x.serial_number_id);
                    table.ForeignKey(
                        name: "FK__serial_nu__check__49CEE3AF",
                        column: x => x.checkout_id,
                        principalSchema: "inventory",
                        principalTable: "checkouts",
                        principalColumn: "checkout_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__serial_nu__item___46F27704",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__serial_nu__sales__4AC307E8",
                        column: x => x.sales_transaction_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__serial_nu__store__48DABF76",
                        column: x => x.store_id,
                        principalSchema: "inventory",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__serial_nu__unit___47E69B3D",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item_cost_prices",
                schema: "purchase",
                columns: table => new
                {
                    item_cost_price_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    supplier_id = table.Column<int>(nullable: true),
                    lead_time_in_days = table.Column<int>(nullable: false),
                    includes_tax = table.Column<bool>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_cost_prices", x => x.item_cost_price_id);
                    table.ForeignKey(
                        name: "FK__item_cost__audit__2FDA0782",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_cost__item___2B155265",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_cost__suppl__2CFD9AD7",
                        column: x => x.supplier_id,
                        principalSchema: "inventory",
                        principalTable: "suppliers",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_cost__unit___2C09769E",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quotation_details",
                schema: "purchase",
                columns: table => new
                {
                    quotation_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quotation_id = table.Column<long>(nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    is_taxed = table.Column<bool>(nullable: false),
                    shipping_charge = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation_details", x => x.quotation_detail_id);
                    table.ForeignKey(
                        name: "FK__quotation__item___56F3D4A3",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__quota__55FFB06A",
                        column: x => x.quotation_id,
                        principalSchema: "purchase",
                        principalTable: "quotations",
                        principalColumn: "quotation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__unit___59D0414E",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "supplierwise_cost_prices",
                schema: "purchase",
                columns: table => new
                {
                    cost_price_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(nullable: false),
                    supplier_id = table.Column<int>(nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplierwise_cost_prices", x => x.cost_price_id);
                    table.ForeignKey(
                        name: "FK__supplierw__audit__377B294A",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__supplierw__item___349EBC9F",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__supplierw__suppl__3592E0D8",
                        column: x => x.supplier_id,
                        principalSchema: "inventory",
                        principalTable: "suppliers",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__supplierw__unit___36870511",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customerwise_selling_prices",
                schema: "sales",
                columns: table => new
                {
                    selling_price_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerwise_selling_prices", x => x.selling_price_id);
                    table.ForeignKey(
                        name: "FK__customerw__audit__37461F20",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customerw__custo__355DD6AE",
                        column: x => x.customer_id,
                        principalSchema: "inventory",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customerw__item___3469B275",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__customerw__unit___3651FAE7",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item_selling_prices",
                schema: "sales",
                columns: table => new
                {
                    item_selling_price_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    customer_type_id = table.Column<int>(nullable: true),
                    price_type_id = table.Column<int>(nullable: true),
                    includes_tax = table.Column<bool>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    audit_user_id = table.Column<int>(nullable: true),
                    audit_ts = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_selling_prices", x => x.item_selling_price_id);
                    table.ForeignKey(
                        name: "FK__item_sell__audit__2FA4FD58",
                        column: x => x.audit_user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_sell__custo__2CC890AD",
                        column: x => x.customer_type_id,
                        principalSchema: "inventory",
                        principalTable: "customer_types",
                        principalColumn: "customer_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_sell__item___2AE0483B",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_sell__price__2DBCB4E6",
                        column: x => x.price_type_id,
                        principalSchema: "sales",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__item_sell__unit___2BD46C74",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quotation_details",
                schema: "sales",
                columns: table => new
                {
                    quotation_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quotation_id = table.Column<long>(nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    is_taxed = table.Column<bool>(nullable: false),
                    shipping_charge = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation_details", x => x.quotation_detail_id);
                    table.ForeignKey(
                        name: "FK__quotation__item___67E9567B",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__quota__66F53242",
                        column: x => x.quotation_id,
                        principalSchema: "sales",
                        principalTable: "quotations",
                        principalColumn: "quotation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__quotation__unit___6AC5C326",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchase_returns",
                schema: "purchase",
                columns: table => new
                {
                    purchase_return_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    purchase_id = table.Column<long>(nullable: false),
                    checkout_id = table.Column<long>(nullable: false),
                    supplier_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_returns", x => x.purchase_return_id);
                    table.ForeignKey(
                        name: "FK__purchase___check__41F8B7BD",
                        column: x => x.checkout_id,
                        principalSchema: "inventory",
                        principalTable: "checkouts",
                        principalColumn: "checkout_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__purchase___purch__41049384",
                        column: x => x.purchase_id,
                        principalSchema: "purchase",
                        principalTable: "purchases",
                        principalColumn: "purchase_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__purchase___suppl__42ECDBF6",
                        column: x => x.supplier_id,
                        principalSchema: "inventory",
                        principalTable: "suppliers",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                schema: "purchase",
                columns: table => new
                {
                    order_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<long>(nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    is_taxed = table.Column<bool>(nullable: false),
                    shipping_charge = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_details", x => x.order_detail_id);
                    table.ForeignKey(
                        name: "FK__order_det__item___6ECB5E34",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__order_det__order__6DD739FB",
                        column: x => x.order_id,
                        principalSchema: "purchase",
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__order_det__unit___71A7CADF",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                schema: "sales",
                columns: table => new
                {
                    order_detail_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<long>(nullable: false),
                    value_date = table.Column<DateTime>(type: "date", nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount_rate = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    is_taxed = table.Column<bool>(nullable: false),
                    shipping_charge = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    unit_id = table.Column<int>(nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(30, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_details", x => x.order_detail_id);
                    table.ForeignKey(
                        name: "FK__order_det__item___7FC0E00C",
                        column: x => x.item_id,
                        principalSchema: "inventory",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__order_det__order__7ECCBBD3",
                        column: x => x.order_id,
                        principalSchema: "sales",
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__order_det__unit___029D4CB7",
                        column: x => x.unit_id,
                        principalSchema: "inventory",
                        principalTable: "units",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                schema: "sales",
                columns: table => new
                {
                    sales_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    invoice_number = table.Column<long>(nullable: false),
                    fiscal_year_code = table.Column<string>(maxLength: 12, nullable: false),
                    cash_repository_id = table.Column<int>(nullable: true),
                    price_type_id = table.Column<int>(nullable: false),
                    sales_order_id = table.Column<long>(nullable: true),
                    sales_quotation_id = table.Column<long>(nullable: true),
                    receipt_transaction_master_id = table.Column<long>(nullable: true),
                    transaction_master_id = table.Column<long>(nullable: false),
                    checkout_id = table.Column<long>(nullable: false),
                    counter_id = table.Column<int>(nullable: false),
                    customer_id = table.Column<int>(nullable: true),
                    salesperson_id = table.Column<int>(nullable: true),
                    total_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    coupon_id = table.Column<int>(nullable: true),
                    is_flat_discount = table.Column<bool>(nullable: true),
                    discount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    total_discount_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    is_credit = table.Column<bool>(nullable: false),
                    credit_settled = table.Column<bool>(nullable: true),
                    payment_term_id = table.Column<int>(nullable: true),
                    tender = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    change = table.Column<decimal>(type: "numeric(30, 6)", nullable: false),
                    gift_card_id = table.Column<int>(nullable: true),
                    check_number = table.Column<string>(maxLength: 100, nullable: true),
                    check_date = table.Column<DateTime>(type: "date", nullable: true),
                    check_bank_name = table.Column<string>(maxLength: 1000, nullable: true),
                    check_amount = table.Column<decimal>(type: "numeric(30, 6)", nullable: true),
                    reward_points = table.Column<decimal>(type: "numeric(30, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.sales_id);
                    table.ForeignKey(
                        name: "FK__sales__cash_repo__0E0EFF63",
                        column: x => x.cash_repository_id,
                        principalSchema: "finance",
                        principalTable: "cash_repositories",
                        principalColumn: "cash_repository_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__checkout___13C7D8B9",
                        column: x => x.checkout_id,
                        principalSchema: "inventory",
                        principalTable: "checkouts",
                        principalColumn: "checkout_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__counter_i__14BBFCF2",
                        column: x => x.counter_id,
                        principalSchema: "inventory",
                        principalTable: "counters",
                        principalColumn: "counter_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__coupon_id__1798699D",
                        column: x => x.coupon_id,
                        principalSchema: "sales",
                        principalTable: "coupons",
                        principalColumn: "coupon_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__customer___15B0212B",
                        column: x => x.customer_id,
                        principalSchema: "inventory",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__fiscal_ye__0D1ADB2A",
                        column: x => x.fiscal_year_code,
                        principalSchema: "finance",
                        principalTable: "fiscal_year",
                        principalColumn: "fiscal_year_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__gift_card__1A74D648",
                        column: x => x.gift_card_id,
                        principalSchema: "sales",
                        principalTable: "gift_cards",
                        principalColumn: "gift_card_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__payment_t__1980B20F",
                        column: x => x.payment_term_id,
                        principalSchema: "sales",
                        principalTable: "payment_terms",
                        principalColumn: "payment_term_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__price_typ__0F03239C",
                        column: x => x.price_type_id,
                        principalSchema: "sales",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__receipt_t__11DF9047",
                        column: x => x.receipt_transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__sales_ord__0FF747D5",
                        column: x => x.sales_order_id,
                        principalSchema: "sales",
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__sales_quo__10EB6C0E",
                        column: x => x.sales_quotation_id,
                        principalSchema: "sales",
                        principalTable: "quotations",
                        principalColumn: "quotation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__salespers__16A44564",
                        column: x => x.salesperson_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__sales__transacti__12D3B480",
                        column: x => x.transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "returns",
                schema: "sales",
                columns: table => new
                {
                    return_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sales_id = table.Column<long>(nullable: false),
                    checkout_id = table.Column<long>(nullable: false),
                    transaction_master_id = table.Column<long>(nullable: false),
                    return_transaction_master_id = table.Column<long>(nullable: false),
                    counter_id = table.Column<int>(nullable: false),
                    customer_id = table.Column<int>(nullable: true),
                    price_type_id = table.Column<int>(nullable: false),
                    is_credit = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_returns", x => x.return_id);
                    table.ForeignKey(
                        name: "FK__returns__checkou__26DAAD2D",
                        column: x => x.checkout_id,
                        principalSchema: "inventory",
                        principalTable: "checkouts",
                        principalColumn: "checkout_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__returns__counter__29B719D8",
                        column: x => x.counter_id,
                        principalSchema: "inventory",
                        principalTable: "counters",
                        principalColumn: "counter_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__returns__custome__2AAB3E11",
                        column: x => x.customer_id,
                        principalSchema: "inventory",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__returns__price_t__2B9F624A",
                        column: x => x.price_type_id,
                        principalSchema: "sales",
                        principalTable: "price_types",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__returns__return___28C2F59F",
                        column: x => x.return_transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__returns__sales_i__25E688F4",
                        column: x => x.sales_id,
                        principalSchema: "sales",
                        principalTable: "sales",
                        principalColumn: "sales_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__returns__transac__27CED166",
                        column: x => x.transaction_master_id,
                        principalSchema: "finance",
                        principalTable: "transaction_master",
                        principalColumn: "transaction_master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_access_tokens_application_id",
                schema: "account",
                table: "access_tokens",
                column: "application_id");

            migrationBuilder.CreateIndex(
                name: "IX_access_tokens_audit_user_id",
                schema: "account",
                table: "access_tokens",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_access_tokens_login_id",
                schema: "account",
                table: "access_tokens",
                column: "login_id");

            migrationBuilder.CreateIndex(
                name: "IX_access_tokens_revoked_by",
                schema: "account",
                table: "access_tokens",
                column: "revoked_by");

            migrationBuilder.CreateIndex(
                name: "UQ__applicat__89A4E7765D484DF6",
                schema: "account",
                table: "applications",
                column: "app_secret",
                unique: true,
                filter: "[app_secret] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "applications_app_name_uix",
                schema: "account",
                table: "applications",
                column: "application_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_applications_audit_user_id",
                schema: "account",
                table: "applications",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_configuration_profiles_audit_user_id",
                schema: "account",
                table: "configuration_profiles",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "configuration_profile_uix",
                schema: "account",
                table: "configuration_profiles",
                column: "is_active",
                unique: true,
                filter: "([is_active]=(1) AND [deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "UQ__configur__0C85D9E128BA427A",
                schema: "account",
                table: "configuration_profiles",
                column: "profile_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_configuration_profiles_registration_office_id",
                schema: "account",
                table: "configuration_profiles",
                column: "registration_office_id");

            migrationBuilder.CreateIndex(
                name: "IX_configuration_profiles_registration_role_id",
                schema: "account",
                table: "configuration_profiles",
                column: "registration_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_fb_access_tokens_audit_user_id",
                schema: "account",
                table: "fb_access_tokens",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_google_access_tokens_audit_user_id",
                schema: "account",
                table: "google_access_tokens",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "installed_domains_domain_name_uix",
                schema: "account",
                table: "installed_domains",
                column: "domain_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_logins_audit_user_id",
                schema: "account",
                table: "logins",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_logins_office_id",
                schema: "account",
                table: "logins",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_logins_user_id",
                schema: "account",
                table: "logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "registrations_email_uix",
                schema: "account",
                table: "registrations",
                column: "email",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_reset_requests_audit_user_id",
                schema: "account",
                table: "reset_requests",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_reset_requests_user_id",
                schema: "account",
                table: "reset_requests",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_audit_user_id",
                schema: "account",
                table: "roles",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__roles__783254B1A0BC1C3C",
                schema: "account",
                table: "roles",
                column: "role_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_audit_user_id",
                schema: "account",
                table: "users",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "users_email_uix",
                schema: "account",
                table: "users",
                column: "email",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_users_office_id",
                schema: "account",
                table: "users",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                schema: "account",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_associated_user_id",
                schema: "addressbook",
                table: "contacts",
                column: "associated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_audit_user_id",
                schema: "addressbook",
                table: "contacts",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_created_by",
                schema: "addressbook",
                table: "contacts",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "access_types_uix",
                schema: "auth",
                table: "access_types",
                column: "access_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_access_types_audit_user_id",
                schema: "auth",
                table: "access_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_entity_access_policy_access_type_id",
                schema: "auth",
                table: "entity_access_policy",
                column: "access_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_entity_access_policy_audit_user_id",
                schema: "auth",
                table: "entity_access_policy",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_entity_access_policy_office_id",
                schema: "auth",
                table: "entity_access_policy",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_entity_access_policy_user_id",
                schema: "auth",
                table: "entity_access_policy",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_entity_access_policy_access_type_id",
                schema: "auth",
                table: "group_entity_access_policy",
                column: "access_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_entity_access_policy_audit_user_id",
                schema: "auth",
                table: "group_entity_access_policy",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_entity_access_policy_office_id",
                schema: "auth",
                table: "group_entity_access_policy",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_entity_access_policy_role_id",
                schema: "auth",
                table: "group_entity_access_policy",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_menu_access_policy_audit_user_id",
                schema: "auth",
                table: "group_menu_access_policy",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_menu_access_policy_menu_id",
                schema: "auth",
                table: "group_menu_access_policy",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_menu_access_policy_role_id",
                schema: "auth",
                table: "group_menu_access_policy",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "menu_access_uix",
                schema: "auth",
                table: "group_menu_access_policy",
                columns: new[] { "office_id", "menu_id", "role_id" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_menu_access_policy_audit_user_id",
                schema: "auth",
                table: "menu_access_policy",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_access_policy_menu_id",
                schema: "auth",
                table: "menu_access_policy",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_access_policy_user_id",
                schema: "auth",
                table: "menu_access_policy",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "menu_access_policy_uix",
                schema: "auth",
                table: "menu_access_policy",
                columns: new[] { "office_id", "menu_id", "user_id" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_categories_audit_user_id",
                schema: "calendar",
                table: "categories",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "categories_user_id_category_name_uix",
                schema: "calendar",
                table: "categories",
                columns: new[] { "user_id", "category_name" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_events_audit_user_id",
                schema: "calendar",
                table: "events",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_events_category_id",
                schema: "calendar",
                table: "events",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_events_user_id",
                schema: "calendar",
                table: "events",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_custom_field_data_types_audit_user_id",
                schema: "config",
                table: "custom_field_data_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_custom_field_forms_audit_user_id",
                schema: "config",
                table: "custom_field_forms",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__custom_f__B228A5BF4DE4C087",
                schema: "config",
                table: "custom_field_forms",
                column: "table_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_custom_field_setup_audit_user_id",
                schema: "config",
                table: "custom_field_setup",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_custom_field_setup_data_type",
                schema: "config",
                table: "custom_field_setup",
                column: "data_type");

            migrationBuilder.CreateIndex(
                name: "IX_custom_field_setup_form_name",
                schema: "config",
                table: "custom_field_setup",
                column: "form_name");

            migrationBuilder.CreateIndex(
                name: "IX_custom_fields_audit_user_id",
                schema: "config",
                table: "custom_fields",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_custom_fields_custom_field_setup_id",
                schema: "config",
                table: "custom_fields",
                column: "custom_field_setup_id");

            migrationBuilder.CreateIndex(
                name: "IX_email_queue_audit_user_id",
                schema: "config",
                table: "email_queue",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_filters_audit_user_id",
                schema: "config",
                table: "filters",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "filters_object_name_inx",
                schema: "config",
                table: "filters",
                column: "object_name",
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_kanban_details_audit_user_id",
                schema: "config",
                table: "kanban_details",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "kanban_details_kanban_id_resource_id_uix",
                schema: "config",
                table: "kanban_details",
                columns: new[] { "kanban_id", "resource_id" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_kanbans_audit_user_id",
                schema: "config",
                table: "kanbans",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_kanbans_user_id",
                schema: "config",
                table: "kanbans",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_sms_queue_audit_user_id",
                schema: "config",
                table: "sms_queue",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_smtp_configs_audit_user_id",
                schema: "config",
                table: "smtp_configs",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__smtp_con__8F784E0F0B1E5676",
                schema: "config",
                table: "smtp_configs",
                column: "configuration_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_app_dependencies_app_name",
                schema: "core",
                table: "app_dependencies",
                column: "app_name");

            migrationBuilder.CreateIndex(
                name: "IX_app_dependencies_depends_on",
                schema: "core",
                table: "app_dependencies",
                column: "depends_on");

            migrationBuilder.CreateIndex(
                name: "apps_app_name_uix",
                schema: "core",
                table: "apps",
                column: "app_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "UQ__currenci__EC6E104DA3081EAE",
                schema: "core",
                table: "currencies",
                column: "currency_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__genders__2FB51D273F89A0CA",
                schema: "core",
                table: "genders",
                column: "gender_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__marital___507BD4B59992DFB0",
                schema: "core",
                table: "marital_statuses",
                column: "marital_status_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menus_parent_menu_id",
                schema: "core",
                table: "menus",
                column: "parent_menu_id");

            migrationBuilder.CreateIndex(
                name: "menus_app_name_menu_name_uix",
                schema: "core",
                table: "menus",
                columns: new[] { "app_name", "menu_name" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_notification_statuses_notification_id",
                schema: "core",
                table: "notification_statuses",
                column: "notification_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_associated_app",
                schema: "core",
                table: "notifications",
                column: "associated_app");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_associated_menu_id",
                schema: "core",
                table: "notifications",
                column: "associated_menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_office_id",
                schema: "core",
                table: "notifications",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_offices_audit_user_id",
                schema: "core",
                table: "offices",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_offices_parent_office_id",
                schema: "core",
                table: "offices",
                column: "parent_office_id");

            migrationBuilder.CreateIndex(
                name: "UQ__week_day__2FE49F53C8CB710A",
                schema: "core",
                table: "week_days",
                column: "week_day_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__week_day__D111B99E661B0F31",
                schema: "core",
                table: "week_days",
                column: "week_day_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "account_master_code_uix",
                schema: "finance",
                table: "account_masters",
                column: "account_master_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "account_master_name_uix",
                schema: "finance",
                table: "account_masters",
                column: "account_master_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_account_masters_audit_user_id",
                schema: "finance",
                table: "account_masters",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "account_master_parent_account_master_id_inx",
                schema: "finance",
                table: "account_masters",
                column: "parent_account_master_id",
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_account_master_id",
                schema: "finance",
                table: "accounts",
                column: "account_master_id");

            migrationBuilder.CreateIndex(
                name: "accounts_name_uix",
                schema: "finance",
                table: "accounts",
                column: "account_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "accounts_account_number_uix",
                schema: "finance",
                table: "accounts",
                column: "account_number",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_audit_user_id",
                schema: "finance",
                table: "accounts",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_currency_code",
                schema: "finance",
                table: "accounts",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_parent_account_id",
                schema: "finance",
                table: "accounts",
                column: "parent_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_auto_verification_policy_audit_user_id",
                schema: "finance",
                table: "auto_verification_policy",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_auto_verification_policy_office_id",
                schema: "finance",
                table: "auto_verification_policy",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_auto_verification_policy_user_id",
                schema: "finance",
                table: "auto_verification_policy",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_bank_accounts_account_id",
                schema: "finance",
                table: "bank_accounts",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_bank_accounts_audit_user_id",
                schema: "finance",
                table: "bank_accounts",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_bank_accounts_bank_type_id",
                schema: "finance",
                table: "bank_accounts",
                column: "bank_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_bank_accounts_maintained_by_user_id",
                schema: "finance",
                table: "bank_accounts",
                column: "maintained_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_bank_accounts_office_id",
                schema: "finance",
                table: "bank_accounts",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_bank_types_audit_user_id",
                schema: "finance",
                table: "bank_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_card_types_audit_user_id",
                schema: "finance",
                table: "card_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "card_types_card_type_code_uix",
                schema: "finance",
                table: "card_types",
                column: "card_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "card_types_card_type_name_uix",
                schema: "finance",
                table: "card_types",
                column: "card_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_cash_flow_headings_audit_user_id",
                schema: "finance",
                table: "cash_flow_headings",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "cash_flow_headings_cash_flow_heading_name_uix",
                schema: "finance",
                table: "cash_flow_headings",
                column: "cash_flow_heading_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "cash_flow_setup_account_master_id_inx",
                schema: "finance",
                table: "cash_flow_setup",
                column: "account_master_id",
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_cash_flow_setup_audit_user_id",
                schema: "finance",
                table: "cash_flow_setup",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "cash_flow_setup_cash_flow_heading_id_inx",
                schema: "finance",
                table: "cash_flow_setup",
                column: "cash_flow_heading_id",
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_cash_repositories_audit_user_id",
                schema: "finance",
                table: "cash_repositories",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_cash_repositories_parent_cash_repository_id",
                schema: "finance",
                table: "cash_repositories",
                column: "parent_cash_repository_id");

            migrationBuilder.CreateIndex(
                name: "cash_repositories_cash_repository_code_uix",
                schema: "finance",
                table: "cash_repositories",
                columns: new[] { "office_id", "cash_repository_code" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "cash_repositories_cash_repository_name_uix",
                schema: "finance",
                table: "cash_repositories",
                columns: new[] { "office_id", "cash_repository_name" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_cost_centers_audit_user_id",
                schema: "finance",
                table: "cost_centers",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "cost_centers_cost_center_code_uix",
                schema: "finance",
                table: "cost_centers",
                column: "cost_center_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "cost_centers_cost_center_name_uix",
                schema: "finance",
                table: "cost_centers",
                column: "cost_center_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_day_operation_completed_by",
                schema: "finance",
                table: "day_operation",
                column: "completed_by");

            migrationBuilder.CreateIndex(
                name: "day_operation_completed_on_inx",
                schema: "finance",
                table: "day_operation",
                column: "completed_on");

            migrationBuilder.CreateIndex(
                name: "IX_day_operation_office_id",
                schema: "finance",
                table: "day_operation",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_day_operation_started_by",
                schema: "finance",
                table: "day_operation",
                column: "started_by");

            migrationBuilder.CreateIndex(
                name: "day_operation_value_date_uix",
                schema: "finance",
                table: "day_operation",
                column: "value_date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "day_operation_routines_completed_on_inx",
                schema: "finance",
                table: "day_operation_routines",
                column: "completed_on");

            migrationBuilder.CreateIndex(
                name: "IX_day_operation_routines_day_id",
                schema: "finance",
                table: "day_operation_routines",
                column: "day_id");

            migrationBuilder.CreateIndex(
                name: "IX_day_operation_routines_routine_id",
                schema: "finance",
                table: "day_operation_routines",
                column: "routine_id");

            migrationBuilder.CreateIndex(
                name: "day_operation_routines_started_on_inx",
                schema: "finance",
                table: "day_operation_routines",
                column: "started_on");

            migrationBuilder.CreateIndex(
                name: "IX_exchange_rate_details_exchange_rate_id",
                schema: "finance",
                table: "exchange_rate_details",
                column: "exchange_rate_id");

            migrationBuilder.CreateIndex(
                name: "IX_exchange_rate_details_foreign_currency_code",
                schema: "finance",
                table: "exchange_rate_details",
                column: "foreign_currency_code");

            migrationBuilder.CreateIndex(
                name: "IX_exchange_rate_details_local_currency_code",
                schema: "finance",
                table: "exchange_rate_details",
                column: "local_currency_code");

            migrationBuilder.CreateIndex(
                name: "IX_exchange_rates_office_id",
                schema: "finance",
                table: "exchange_rates",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_fiscal_year_audit_user_id",
                schema: "finance",
                table: "fiscal_year",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "fiscal_year_ends_on_uix",
                schema: "finance",
                table: "fiscal_year",
                column: "ends_on",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "UQ__fiscal_y__6F913C0CFAF278F6",
                schema: "finance",
                table: "fiscal_year",
                column: "fiscal_year_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fiscal_year_fiscal_year_name_uix",
                schema: "finance",
                table: "fiscal_year",
                column: "fiscal_year_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_fiscal_year_office_id",
                schema: "finance",
                table: "fiscal_year",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "fiscal_year_starts_from_uix",
                schema: "finance",
                table: "fiscal_year",
                column: "starts_from",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_frequencies_audit_user_id",
                schema: "finance",
                table: "frequencies",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "frequencies_frequency_code_uix",
                schema: "finance",
                table: "frequencies",
                column: "frequency_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "frequencies_frequency_name_uix",
                schema: "finance",
                table: "frequencies",
                column: "frequency_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_frequency_setups_audit_user_id",
                schema: "finance",
                table: "frequency_setups",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_frequency_setups_fiscal_year_code",
                schema: "finance",
                table: "frequency_setups",
                column: "fiscal_year_code");

            migrationBuilder.CreateIndex(
                name: "IX_frequency_setups_frequency_id",
                schema: "finance",
                table: "frequency_setups",
                column: "frequency_id");

            migrationBuilder.CreateIndex(
                name: "frequency_setups_frequency_setup_code_uix",
                schema: "finance",
                table: "frequency_setups",
                column: "frequency_setup_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_frequency_setups_office_id",
                schema: "finance",
                table: "frequency_setups",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "UQ__frequenc__43469440FE9D4604",
                schema: "finance",
                table: "frequency_setups",
                column: "value_date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_journal_verification_policy_audit_user_id",
                schema: "finance",
                table: "journal_verification_policy",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_journal_verification_policy_office_id",
                schema: "finance",
                table: "journal_verification_policy",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_journal_verification_policy_user_id",
                schema: "finance",
                table: "journal_verification_policy",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_merchant_fee_setup_account_id",
                schema: "finance",
                table: "merchant_fee_setup",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_merchant_fee_setup_audit_user_id",
                schema: "finance",
                table: "merchant_fee_setup",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_merchant_fee_setup_payment_card_id",
                schema: "finance",
                table: "merchant_fee_setup",
                column: "payment_card_id");

            migrationBuilder.CreateIndex(
                name: "merchant_fee_setup_merchant_account_id_payment_card_id_uix",
                schema: "finance",
                table: "merchant_fee_setup",
                columns: new[] { "merchant_account_id", "payment_card_id" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_payment_cards_audit_user_id",
                schema: "finance",
                table: "payment_cards",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_cards_card_type_id",
                schema: "finance",
                table: "payment_cards",
                column: "card_type_id");

            migrationBuilder.CreateIndex(
                name: "payment_cards_payment_card_code_uix",
                schema: "finance",
                table: "payment_cards",
                column: "payment_card_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "payment_cards_payment_card_name_uix",
                schema: "finance",
                table: "payment_cards",
                column: "payment_card_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "routines_routine_code_uix",
                schema: "finance",
                table: "routines",
                column: "routine_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__routines__380179507C05F3EA",
                schema: "finance",
                table: "routines",
                column: "routine_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tax_setups_audit_user_id",
                schema: "finance",
                table: "tax_setups",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tax_setups_income_tax_account_id",
                schema: "finance",
                table: "tax_setups",
                column: "income_tax_account_id");

            migrationBuilder.CreateIndex(
                name: "tax_setup_office_id_uix",
                schema: "finance",
                table: "tax_setups",
                column: "office_id",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_tax_setups_sales_tax_account_id",
                schema: "finance",
                table: "tax_setups",
                column: "sales_tax_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_details_account_id",
                schema: "finance",
                table: "transaction_details",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_details_audit_user_id",
                schema: "finance",
                table: "transaction_details",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_details_cash_repository_id",
                schema: "finance",
                table: "transaction_details",
                column: "cash_repository_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_details_currency_code",
                schema: "finance",
                table: "transaction_details",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_details_local_currency_code",
                schema: "finance",
                table: "transaction_details",
                column: "local_currency_code");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_details_office_id",
                schema: "finance",
                table: "transaction_details",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "transaction_details_tran_type_inx",
                schema: "finance",
                table: "transaction_details",
                columns: new[] { "transaction_master_id", "amount_in_local_currency", "tran_type" });

            migrationBuilder.CreateIndex(
                name: "transaction_details_account_id_inx",
                schema: "finance",
                table: "transaction_details",
                columns: new[] { "transaction_master_id", "tran_type", "amount_in_local_currency", "account_id" });

            migrationBuilder.CreateIndex(
                name: "transaction_details_book_date_inx",
                schema: "finance",
                table: "transaction_details",
                columns: new[] { "transaction_master_id", "tran_type", "amount_in_local_currency", "book_date" });

            migrationBuilder.CreateIndex(
                name: "transaction_details_cash_repository_id_inx",
                schema: "finance",
                table: "transaction_details",
                columns: new[] { "transaction_master_id", "tran_type", "amount_in_local_currency", "cash_repository_id" });

            migrationBuilder.CreateIndex(
                name: "transaction_details_office_id_inx",
                schema: "finance",
                table: "transaction_details",
                columns: new[] { "transaction_master_id", "tran_type", "amount_in_local_currency", "office_id" });

            migrationBuilder.CreateIndex(
                name: "transaction_details_value_date_inx",
                schema: "finance",
                table: "transaction_details",
                columns: new[] { "transaction_master_id", "tran_type", "amount_in_local_currency", "value_date" });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_documents_audit_user_id",
                schema: "finance",
                table: "transaction_documents",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_documents_transaction_master_id",
                schema: "finance",
                table: "transaction_documents",
                column: "transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_master_audit_user_id",
                schema: "finance",
                table: "transaction_master",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "transaction_master_book_date_inx",
                schema: "finance",
                table: "transaction_master",
                column: "book_date",
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "transaction_master_cascading_tran_id_inx",
                schema: "finance",
                table: "transaction_master",
                column: "cascading_tran_id",
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_master_cost_center_id",
                schema: "finance",
                table: "transaction_master",
                column: "cost_center_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_master_login_id",
                schema: "finance",
                table: "transaction_master",
                column: "login_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_master_office_id",
                schema: "finance",
                table: "transaction_master",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "transaction_master_transaction_code_uix",
                schema: "finance",
                table: "transaction_master",
                column: "transaction_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_master_user_id",
                schema: "finance",
                table: "transaction_master",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "transaction_master_value_date_inx",
                schema: "finance",
                table: "transaction_master",
                column: "value_date",
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_master_verification_status_id",
                schema: "finance",
                table: "transaction_master",
                column: "verification_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_master_verified_by_user_id",
                schema: "finance",
                table: "transaction_master",
                column: "verified_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_types_audit_user_id",
                schema: "finance",
                table: "transaction_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "transaction_types_transaction_type_code_uix",
                schema: "finance",
                table: "transaction_types",
                column: "transaction_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "transaction_types_transaction_type_name_uix",
                schema: "finance",
                table: "transaction_types",
                column: "transaction_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_attendances_audit_user_id",
                schema: "hrm",
                table: "attendances",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_attendances_employee_id",
                schema: "hrm",
                table: "attendances",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_attendances_office_id",
                schema: "hrm",
                table: "attendances",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "attendance_date_employee_id_uix",
                schema: "hrm",
                table: "attendances",
                columns: new[] { "attendance_date", "employee_id" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_audit_user_id",
                schema: "hrm",
                table: "contracts",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_department_id",
                schema: "hrm",
                table: "contracts",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_employee_id",
                schema: "hrm",
                table: "contracts",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_employment_status_code_id",
                schema: "hrm",
                table: "contracts",
                column: "employment_status_code_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_leave_benefit_id",
                schema: "hrm",
                table: "contracts",
                column: "leave_benefit_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_office_id",
                schema: "hrm",
                table: "contracts",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_role_id",
                schema: "hrm",
                table: "contracts",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_verification_status_id",
                schema: "hrm",
                table: "contracts",
                column: "verification_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_verified_by_user_id",
                schema: "hrm",
                table: "contracts",
                column: "verified_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_departments_audit_user_id",
                schema: "hrm",
                table: "departments",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "departments_department_code_uix",
                schema: "hrm",
                table: "departments",
                column: "department_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "departments_department_name_uix",
                schema: "hrm",
                table: "departments",
                column: "department_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_education_levels_audit_user_id",
                schema: "hrm",
                table: "education_levels",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "education_levels_education_level_name",
                schema: "hrm",
                table: "education_levels",
                column: "education_level_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_employee_experiences_audit_user_id",
                schema: "hrm",
                table: "employee_experiences",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_experiences_employee_id",
                schema: "hrm",
                table: "employee_experiences",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_identification_details_audit_user_id",
                schema: "hrm",
                table: "employee_identification_details",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_identification_details_identification_type_id",
                schema: "hrm",
                table: "employee_identification_details",
                column: "identification_type_id");

            migrationBuilder.CreateIndex(
                name: "employee_identification_details_employee_id_itc_uix",
                schema: "hrm",
                table: "employee_identification_details",
                columns: new[] { "employee_id", "identification_type_id" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_employee_qualifications_audit_user_id",
                schema: "hrm",
                table: "employee_qualifications",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_qualifications_education_level_id",
                schema: "hrm",
                table: "employee_qualifications",
                column: "education_level_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_qualifications_employee_id",
                schema: "hrm",
                table: "employee_qualifications",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_social_network_details_audit_user_id",
                schema: "hrm",
                table: "employee_social_network_details",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_social_network_details_employee_id",
                schema: "hrm",
                table: "employee_social_network_details",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_social_network_details_social_network_id",
                schema: "hrm",
                table: "employee_social_network_details",
                column: "social_network_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_types_audit_user_id",
                schema: "hrm",
                table: "employee_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "employee_types_employee_type_code_uix",
                schema: "hrm",
                table: "employee_types",
                column: "employee_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "employee_types_employee_type_name_uix",
                schema: "hrm",
                table: "employee_types",
                column: "employee_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_employees_audit_user_id",
                schema: "hrm",
                table: "employees",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_country_code",
                schema: "hrm",
                table: "employees",
                column: "country_code");

            migrationBuilder.CreateIndex(
                name: "IX_employees_current_department_id",
                schema: "hrm",
                table: "employees",
                column: "current_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_current_employment_status_id",
                schema: "hrm",
                table: "employees",
                column: "current_employment_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_current_job_title_id",
                schema: "hrm",
                table: "employees",
                column: "current_job_title_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_current_pay_grade_id",
                schema: "hrm",
                table: "employees",
                column: "current_pay_grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_current_role_id",
                schema: "hrm",
                table: "employees",
                column: "current_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_current_shift_id",
                schema: "hrm",
                table: "employees",
                column: "current_shift_id");

            migrationBuilder.CreateIndex(
                name: "employees_employee_code_uix",
                schema: "hrm",
                table: "employees",
                column: "employee_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_employees_employee_type_id",
                schema: "hrm",
                table: "employees",
                column: "employee_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_gender_code",
                schema: "hrm",
                table: "employees",
                column: "gender_code");

            migrationBuilder.CreateIndex(
                name: "IX_employees_marital_status_id",
                schema: "hrm",
                table: "employees",
                column: "marital_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_nationality_id",
                schema: "hrm",
                table: "employees",
                column: "nationality_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_office_id",
                schema: "hrm",
                table: "employees",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_user_id",
                schema: "hrm",
                table: "employees",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_employment_status_codes_audit_user_id",
                schema: "hrm",
                table: "employment_status_codes",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "employment_status_codes_status_code_uix",
                schema: "hrm",
                table: "employment_status_codes",
                column: "status_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "employment_status_codes_status_code_name_uix",
                schema: "hrm",
                table: "employment_status_codes",
                column: "status_code_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_employment_statuses_audit_user_id",
                schema: "hrm",
                table: "employment_statuses",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_employment_statuses_default_employment_status_code_id",
                schema: "hrm",
                table: "employment_statuses",
                column: "default_employment_status_code_id");

            migrationBuilder.CreateIndex(
                name: "employment_statuses_employment_status_code_uix",
                schema: "hrm",
                table: "employment_statuses",
                column: "employment_status_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "employment_statuses_employment_status_name_uix",
                schema: "hrm",
                table: "employment_statuses",
                column: "employment_status_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_exit_types_audit_user_id",
                schema: "hrm",
                table: "exit_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "exit_types_exit_type_code_uix",
                schema: "hrm",
                table: "exit_types",
                column: "exit_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "exit_types_exit_type_name_uix",
                schema: "hrm",
                table: "exit_types",
                column: "exit_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_exits_audit_user_id",
                schema: "hrm",
                table: "exits",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exits_change_status_to",
                schema: "hrm",
                table: "exits",
                column: "change_status_to");

            migrationBuilder.CreateIndex(
                name: "IX_exits_employee_id",
                schema: "hrm",
                table: "exits",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_exits_exit_type_id",
                schema: "hrm",
                table: "exits",
                column: "exit_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_exits_forward_to",
                schema: "hrm",
                table: "exits",
                column: "forward_to");

            migrationBuilder.CreateIndex(
                name: "IX_exits_verification_status_id",
                schema: "hrm",
                table: "exits",
                column: "verification_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_exits_verified_by_user_id",
                schema: "hrm",
                table: "exits",
                column: "verified_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_identification_types_audit_user_id",
                schema: "hrm",
                table: "identification_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "identification_types_identification_type_code_uix",
                schema: "hrm",
                table: "identification_types",
                column: "identification_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "identification_types_identification_type_name_uix",
                schema: "hrm",
                table: "identification_types",
                column: "identification_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_job_titles_audit_user_id",
                schema: "hrm",
                table: "job_titles",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "job_titles_job_title_code_uix",
                schema: "hrm",
                table: "job_titles",
                column: "job_title_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "job_titles_job_title_name_uix",
                schema: "hrm",
                table: "job_titles",
                column: "job_title_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_leave_applications_audit_user_id",
                schema: "hrm",
                table: "leave_applications",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_leave_applications_employee_id",
                schema: "hrm",
                table: "leave_applications",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_leave_applications_entered_by",
                schema: "hrm",
                table: "leave_applications",
                column: "entered_by");

            migrationBuilder.CreateIndex(
                name: "IX_leave_applications_leave_type_id",
                schema: "hrm",
                table: "leave_applications",
                column: "leave_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_leave_applications_verification_status_id",
                schema: "hrm",
                table: "leave_applications",
                column: "verification_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_leave_applications_verified_by_user_id",
                schema: "hrm",
                table: "leave_applications",
                column: "verified_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_leave_benefits_audit_user_id",
                schema: "hrm",
                table: "leave_benefits",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "leave_benefits_leave_benefit_code_uix",
                schema: "hrm",
                table: "leave_benefits",
                column: "leave_benefit_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "leave_benefits_leave_benefit_name_uix",
                schema: "hrm",
                table: "leave_benefits",
                column: "leave_benefit_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_leave_types_audit_user_id",
                schema: "hrm",
                table: "leave_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "leave_types_leave_type_code_uix",
                schema: "hrm",
                table: "leave_types",
                column: "leave_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "leave_types_leave_type_name_uix",
                schema: "hrm",
                table: "leave_types",
                column: "leave_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_nationalities_audit_user_id",
                schema: "hrm",
                table: "nationalities",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "nationalities_nationality_code_uix",
                schema: "hrm",
                table: "nationalities",
                column: "nationality_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "nationalities_nationality_name_uix",
                schema: "hrm",
                table: "nationalities",
                column: "nationality_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_office_hours_audit_user_id",
                schema: "hrm",
                table: "office_hours",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_office_hours_office_id",
                schema: "hrm",
                table: "office_hours",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_office_hours_shift_id",
                schema: "hrm",
                table: "office_hours",
                column: "shift_id");

            migrationBuilder.CreateIndex(
                name: "IX_office_hours_week_day_id",
                schema: "hrm",
                table: "office_hours",
                column: "week_day_id");

            migrationBuilder.CreateIndex(
                name: "IX_pay_grades_audit_user_id",
                schema: "hrm",
                table: "pay_grades",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "pay_grades_pay_grade_code_uix",
                schema: "hrm",
                table: "pay_grades",
                column: "pay_grade_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "pay_grades_pay_grade_name_uix",
                schema: "hrm",
                table: "pay_grades",
                column: "pay_grade_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_resignations_audit_user_id",
                schema: "hrm",
                table: "resignations",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_resignations_employee_id",
                schema: "hrm",
                table: "resignations",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_resignations_entered_by",
                schema: "hrm",
                table: "resignations",
                column: "entered_by");

            migrationBuilder.CreateIndex(
                name: "IX_resignations_forward_to",
                schema: "hrm",
                table: "resignations",
                column: "forward_to");

            migrationBuilder.CreateIndex(
                name: "IX_resignations_verification_status_id",
                schema: "hrm",
                table: "resignations",
                column: "verification_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_resignations_verified_by_user_id",
                schema: "hrm",
                table: "resignations",
                column: "verified_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_audit_user_id",
                schema: "hrm",
                table: "roles",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "roles_role_code_uix",
                schema: "hrm",
                table: "roles",
                column: "role_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "roles_role_name_uix",
                schema: "hrm",
                table: "roles",
                column: "role_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_shifts_audit_user_id",
                schema: "hrm",
                table: "shifts",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "shifts_shift_code_uix",
                schema: "hrm",
                table: "shifts",
                column: "shift_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "shifts_shift_name_uix",
                schema: "hrm",
                table: "shifts",
                column: "shift_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_social_networks_audit_user_id",
                schema: "hrm",
                table: "social_networks",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_terminations_audit_user_id",
                schema: "hrm",
                table: "terminations",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_terminations_change_status_to",
                schema: "hrm",
                table: "terminations",
                column: "change_status_to");

            migrationBuilder.CreateIndex(
                name: "UQ__terminat__C52E0BA9D4C44039",
                schema: "hrm",
                table: "terminations",
                column: "employee_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_terminations_forward_to",
                schema: "hrm",
                table: "terminations",
                column: "forward_to");

            migrationBuilder.CreateIndex(
                name: "IX_terminations_verification_status_id",
                schema: "hrm",
                table: "terminations",
                column: "verification_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_terminations_verified_by_user_id",
                schema: "hrm",
                table: "terminations",
                column: "verified_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_week_days_audit_user_id",
                schema: "hrm",
                table: "week_days",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "week_days_week_day_code_uix",
                schema: "hrm",
                table: "week_days",
                column: "week_day_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "week_days_week_day_name_uix",
                schema: "hrm",
                table: "week_days",
                column: "week_day_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "attributes_attribute_code_uix",
                schema: "inventory",
                table: "attributes",
                column: "attribute_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "attributes_attribute_name_uix",
                schema: "inventory",
                table: "attributes",
                column: "attribute_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_attributes_audit_user_id",
                schema: "inventory",
                table: "attributes",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_brands_audit_user_id",
                schema: "inventory",
                table: "brands",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "brands_brand_code_uix",
                schema: "inventory",
                table: "brands",
                column: "brand_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "brands_brand_name_uix",
                schema: "inventory",
                table: "brands",
                column: "brand_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_checkout_details_base_unit_id",
                schema: "inventory",
                table: "checkout_details",
                column: "base_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkout_details_checkout_id",
                schema: "inventory",
                table: "checkout_details",
                column: "checkout_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkout_details_item_id",
                schema: "inventory",
                table: "checkout_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkout_details_store_id",
                schema: "inventory",
                table: "checkout_details",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkout_details_unit_id",
                schema: "inventory",
                table: "checkout_details",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkouts_audit_user_id",
                schema: "inventory",
                table: "checkouts",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkouts_office_id",
                schema: "inventory",
                table: "checkouts",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkouts_posted_by",
                schema: "inventory",
                table: "checkouts",
                column: "posted_by");

            migrationBuilder.CreateIndex(
                name: "IX_checkouts_shipper_id",
                schema: "inventory",
                table: "checkouts",
                column: "shipper_id");

            migrationBuilder.CreateIndex(
                name: "checkouts_transaction_master_id_inx",
                schema: "inventory",
                table: "checkouts",
                column: "transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_compound_units_audit_user_id",
                schema: "inventory",
                table: "compound_units",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_compound_units_compare_unit_id",
                schema: "inventory",
                table: "compound_units",
                column: "compare_unit_id");

            migrationBuilder.CreateIndex(
                name: "compound_units_base_unit_id_value_uix",
                schema: "inventory",
                table: "compound_units",
                columns: new[] { "base_unit_id", "value" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_counters_audit_user_id",
                schema: "inventory",
                table: "counters",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "counters_counter_code_uix",
                schema: "inventory",
                table: "counters",
                column: "counter_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "counters_counter_name_uix",
                schema: "inventory",
                table: "counters",
                column: "counter_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_counters_store_id",
                schema: "inventory",
                table: "counters",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_types_account_id",
                schema: "inventory",
                table: "customer_types",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_types_audit_user_id",
                schema: "inventory",
                table: "customer_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "customer_types_customer_type_code_uix",
                schema: "inventory",
                table: "customer_types",
                column: "customer_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "customer_types_customer_type_name_uix",
                schema: "inventory",
                table: "customer_types",
                column: "customer_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "customers_account_id_uix",
                schema: "inventory",
                table: "customers",
                column: "account_id",
                unique: true,
                filter: "([deleted]=(0) AND [account_id] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_customers_audit_user_id",
                schema: "inventory",
                table: "customers",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_currency_code",
                schema: "inventory",
                table: "customers",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "customers_customer_code_uix",
                schema: "inventory",
                table: "customers",
                column: "customer_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_customers_customer_type_id",
                schema: "inventory",
                table: "customers",
                column: "customer_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_setup_default_discount_account_id",
                schema: "inventory",
                table: "inventory_setup",
                column: "default_discount_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_deliveries_audit_user_id",
                schema: "inventory",
                table: "inventory_transfer_deliveries",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_deliveries_destination_store_id",
                schema: "inventory",
                table: "inventory_transfer_deliveries",
                column: "destination_store_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_deliveries_inventory_transfer_request_id",
                schema: "inventory",
                table: "inventory_transfer_deliveries",
                column: "inventory_transfer_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_deliveries_office_id",
                schema: "inventory",
                table: "inventory_transfer_deliveries",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_deliveries_user_id",
                schema: "inventory",
                table: "inventory_transfer_deliveries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_delivery_details_base_unit_id",
                schema: "inventory",
                table: "inventory_transfer_delivery_details",
                column: "base_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_delivery_details_inventory_transfer_delivery_id",
                schema: "inventory",
                table: "inventory_transfer_delivery_details",
                column: "inventory_transfer_delivery_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_delivery_details_item_id",
                schema: "inventory",
                table: "inventory_transfer_delivery_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_delivery_details_unit_id",
                schema: "inventory",
                table: "inventory_transfer_delivery_details",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_request_details_base_unit_id",
                schema: "inventory",
                table: "inventory_transfer_request_details",
                column: "base_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_request_details_inventory_transfer_request_id",
                schema: "inventory",
                table: "inventory_transfer_request_details",
                column: "inventory_transfer_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_request_details_item_id",
                schema: "inventory",
                table: "inventory_transfer_request_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_request_details_unit_id",
                schema: "inventory",
                table: "inventory_transfer_request_details",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_requests_audit_user_id",
                schema: "inventory",
                table: "inventory_transfer_requests",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_requests_authorized_by_user_id",
                schema: "inventory",
                table: "inventory_transfer_requests",
                column: "authorized_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_requests_delivered_by_user_id",
                schema: "inventory",
                table: "inventory_transfer_requests",
                column: "delivered_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_requests_office_id",
                schema: "inventory",
                table: "inventory_transfer_requests",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_requests_received_by_user_id",
                schema: "inventory",
                table: "inventory_transfer_requests",
                column: "received_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_requests_rejected_by_user_id",
                schema: "inventory",
                table: "inventory_transfer_requests",
                column: "rejected_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_requests_store_id",
                schema: "inventory",
                table: "inventory_transfer_requests",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_transfer_requests_user_id",
                schema: "inventory",
                table: "inventory_transfer_requests",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_groups_audit_user_id",
                schema: "inventory",
                table: "item_groups",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_groups_cost_of_goods_sold_account_id",
                schema: "inventory",
                table: "item_groups",
                column: "cost_of_goods_sold_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_groups_inventory_account_id",
                schema: "inventory",
                table: "item_groups",
                column: "inventory_account_id");

            migrationBuilder.CreateIndex(
                name: "item_groups_item_group_code_uix",
                schema: "inventory",
                table: "item_groups",
                column: "item_group_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "item_groups_item_group_name_uix",
                schema: "inventory",
                table: "item_groups",
                column: "item_group_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_item_groups_parent_item_group_id",
                schema: "inventory",
                table: "item_groups",
                column: "parent_item_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_groups_purchase_account_id",
                schema: "inventory",
                table: "item_groups",
                column: "purchase_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_groups_purchase_discount_account_id",
                schema: "inventory",
                table: "item_groups",
                column: "purchase_discount_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_groups_sales_account_id",
                schema: "inventory",
                table: "item_groups",
                column: "sales_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_groups_sales_discount_account_id",
                schema: "inventory",
                table: "item_groups",
                column: "sales_discount_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_groups_sales_return_account_id",
                schema: "inventory",
                table: "item_groups",
                column: "sales_return_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_types_audit_user_id",
                schema: "inventory",
                table: "item_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "item_type_item_type_code_uix",
                schema: "inventory",
                table: "item_types",
                column: "item_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "item_type_item_type_name_uix",
                schema: "inventory",
                table: "item_types",
                column: "item_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_item_variants_audit_user_id",
                schema: "inventory",
                table: "item_variants",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_variants_item_id",
                schema: "inventory",
                table: "item_variants",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_variants_variant_id",
                schema: "inventory",
                table: "item_variants",
                column: "variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_audit_user_id",
                schema: "inventory",
                table: "items",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_brand_id",
                schema: "inventory",
                table: "items",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_is_variant_of",
                schema: "inventory",
                table: "items",
                column: "is_variant_of");

            migrationBuilder.CreateIndex(
                name: "items_item_code_uix",
                schema: "inventory",
                table: "items",
                column: "item_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_items_item_group_id",
                schema: "inventory",
                table: "items",
                column: "item_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_item_type_id",
                schema: "inventory",
                table: "items",
                column: "item_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_preferred_supplier_id",
                schema: "inventory",
                table: "items",
                column: "preferred_supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_reorder_unit_id",
                schema: "inventory",
                table: "items",
                column: "reorder_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_unit_id",
                schema: "inventory",
                table: "items",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_serial_numbers_checkout_id",
                schema: "inventory",
                table: "serial_numbers",
                column: "checkout_id");

            migrationBuilder.CreateIndex(
                name: "IX_serial_numbers_item_id",
                schema: "inventory",
                table: "serial_numbers",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_serial_numbers_sales_transaction_id",
                schema: "inventory",
                table: "serial_numbers",
                column: "sales_transaction_id");

            migrationBuilder.CreateIndex(
                name: "IX_serial_numbers_store_id",
                schema: "inventory",
                table: "serial_numbers",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_serial_numbers_unit_id",
                schema: "inventory",
                table: "serial_numbers",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_shippers_account_id",
                schema: "inventory",
                table: "shippers",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_shippers_audit_user_id",
                schema: "inventory",
                table: "shippers",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "shippers_shipper_code_uix",
                schema: "inventory",
                table: "shippers",
                column: "shipper_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "shippers_shipper_name_uix",
                schema: "inventory",
                table: "shippers",
                column: "shipper_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_store_types_audit_user_id",
                schema: "inventory",
                table: "store_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "store_types_store_type_code_uix",
                schema: "inventory",
                table: "store_types",
                column: "store_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "store_types_store_type_name_uix",
                schema: "inventory",
                table: "store_types",
                column: "store_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_stores_audit_user_id",
                schema: "inventory",
                table: "stores",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_stores_default_account_id_for_checks",
                schema: "inventory",
                table: "stores",
                column: "default_account_id_for_checks");

            migrationBuilder.CreateIndex(
                name: "IX_stores_default_cash_account_id",
                schema: "inventory",
                table: "stores",
                column: "default_cash_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_stores_default_cash_repository_id",
                schema: "inventory",
                table: "stores",
                column: "default_cash_repository_id");

            migrationBuilder.CreateIndex(
                name: "IX_stores_office_id",
                schema: "inventory",
                table: "stores",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_stores_PurchaseDiscountAccountId",
                schema: "inventory",
                table: "stores",
                column: "PurchaseDiscountAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_stores_SalesDiscountAccountId",
                schema: "inventory",
                table: "stores",
                column: "SalesDiscountAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_stores_ShippingExpenseAccountId",
                schema: "inventory",
                table: "stores",
                column: "ShippingExpenseAccountId");

            migrationBuilder.CreateIndex(
                name: "stores_store_code_uix",
                schema: "inventory",
                table: "stores",
                column: "store_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "stores_store_name_uix",
                schema: "inventory",
                table: "stores",
                column: "store_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_stores_store_type_id",
                schema: "inventory",
                table: "stores",
                column: "store_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_types_account_id",
                schema: "inventory",
                table: "supplier_types",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_types_audit_user_id",
                schema: "inventory",
                table: "supplier_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "supplier_types_supplier_type_code_uix",
                schema: "inventory",
                table: "supplier_types",
                column: "supplier_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "supplier_types_supplier_type_name_uix",
                schema: "inventory",
                table: "supplier_types",
                column: "supplier_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "suppliers_account_id_uix",
                schema: "inventory",
                table: "suppliers",
                column: "account_id",
                unique: true,
                filter: "([deleted]=(0) AND [account_id] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_audit_user_id",
                schema: "inventory",
                table: "suppliers",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_currency_code",
                schema: "inventory",
                table: "suppliers",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "suppliers_supplier_code_uix",
                schema: "inventory",
                table: "suppliers",
                column: "supplier_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_supplier_type_id",
                schema: "inventory",
                table: "suppliers",
                column: "supplier_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_units_audit_user_id",
                schema: "inventory",
                table: "units",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "units_unit_code_uix",
                schema: "inventory",
                table: "units",
                column: "unit_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "units_unit_name_uix",
                schema: "inventory",
                table: "units",
                column: "unit_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_variants_attribute_id",
                schema: "inventory",
                table: "variants",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_variants_audit_user_id",
                schema: "inventory",
                table: "variants",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "variants_variant_code_uix",
                schema: "inventory",
                table: "variants",
                column: "variant_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "variants_variant_name_uix",
                schema: "inventory",
                table: "variants",
                column: "variant_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_item_cost_prices_audit_user_id",
                schema: "purchase",
                table: "item_cost_prices",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_cost_prices_supplier_id",
                schema: "purchase",
                table: "item_cost_prices",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_cost_prices_unit_id",
                schema: "purchase",
                table: "item_cost_prices",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "item_cost_prices_item_id_unit_id_supplier_id",
                schema: "purchase",
                table: "item_cost_prices",
                columns: new[] { "item_id", "unit_id", "supplier_id" },
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_item_id",
                schema: "purchase",
                table: "order_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_order_id",
                schema: "purchase",
                table: "order_details",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_unit_id",
                schema: "purchase",
                table: "order_details",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_audit_user_id",
                schema: "purchase",
                table: "orders",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_office_id",
                schema: "purchase",
                table: "orders",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_price_type_id",
                schema: "purchase",
                table: "orders",
                column: "price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_quotation_id",
                schema: "purchase",
                table: "orders",
                column: "quotation_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_shipper_id",
                schema: "purchase",
                table: "orders",
                column: "shipper_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_supplier_id",
                schema: "purchase",
                table: "orders",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                schema: "purchase",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_price_types_audit_user_id",
                schema: "purchase",
                table: "price_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "price_types_price_type_code_uix",
                schema: "purchase",
                table: "price_types",
                column: "price_type_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "price_types_price_type_name_uix",
                schema: "purchase",
                table: "price_types",
                column: "price_type_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_returns_checkout_id",
                schema: "purchase",
                table: "purchase_returns",
                column: "checkout_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_returns_purchase_id",
                schema: "purchase",
                table: "purchase_returns",
                column: "purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_returns_supplier_id",
                schema: "purchase",
                table: "purchase_returns",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_checkout_id",
                schema: "purchase",
                table: "purchases",
                column: "checkout_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_price_type_id",
                schema: "purchase",
                table: "purchases",
                column: "price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_supplier_id",
                schema: "purchase",
                table: "purchases",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotation_details_item_id",
                schema: "purchase",
                table: "quotation_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotation_details_quotation_id",
                schema: "purchase",
                table: "quotation_details",
                column: "quotation_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotation_details_unit_id",
                schema: "purchase",
                table: "quotation_details",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_audit_user_id",
                schema: "purchase",
                table: "quotations",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_office_id",
                schema: "purchase",
                table: "quotations",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_price_type_id",
                schema: "purchase",
                table: "quotations",
                column: "price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_shipper_id",
                schema: "purchase",
                table: "quotations",
                column: "shipper_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_supplier_id",
                schema: "purchase",
                table: "quotations",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_user_id",
                schema: "purchase",
                table: "quotations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_payments_bank_id",
                schema: "purchase",
                table: "supplier_payments",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "supplier_payments_cash_repository_id_inx",
                schema: "purchase",
                table: "supplier_payments",
                column: "cash_repository_id");

            migrationBuilder.CreateIndex(
                name: "supplier_payments_currency_code_inx",
                schema: "purchase",
                table: "supplier_payments",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "supplier_payments_posted_date_inx",
                schema: "purchase",
                table: "supplier_payments",
                column: "posted_date");

            migrationBuilder.CreateIndex(
                name: "supplier_payments_supplier_id_inx",
                schema: "purchase",
                table: "supplier_payments",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "supplier_payments_transaction_master_id_inx",
                schema: "purchase",
                table: "supplier_payments",
                column: "transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplierwise_cost_prices_audit_user_id",
                schema: "purchase",
                table: "supplierwise_cost_prices",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplierwise_cost_prices_item_id",
                schema: "purchase",
                table: "supplierwise_cost_prices",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplierwise_cost_prices_supplier_id",
                schema: "purchase",
                table: "supplierwise_cost_prices",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplierwise_cost_prices_unit_id",
                schema: "purchase",
                table: "supplierwise_cost_prices",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_cashier_login_info_attempted_by",
                schema: "sales",
                table: "cashier_login_info",
                column: "attempted_by");

            migrationBuilder.CreateIndex(
                name: "IX_cashier_login_info_audit_user_id",
                schema: "sales",
                table: "cashier_login_info",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_cashier_login_info_cashier_id",
                schema: "sales",
                table: "cashier_login_info",
                column: "cashier_id");

            migrationBuilder.CreateIndex(
                name: "IX_cashier_login_info_counter_id",
                schema: "sales",
                table: "cashier_login_info",
                column: "counter_id");

            migrationBuilder.CreateIndex(
                name: "IX_cashiers_associated_user_id",
                schema: "sales",
                table: "cashiers",
                column: "associated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_cashiers_audit_user_id",
                schema: "sales",
                table: "cashiers",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "cashiers_cashier_code_uix",
                schema: "sales",
                table: "cashiers",
                column: "cashier_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_cashiers_counter_id",
                schema: "sales",
                table: "cashiers",
                column: "counter_id");

            migrationBuilder.CreateIndex(
                name: "IX_closing_cash_approved_by",
                schema: "sales",
                table: "closing_cash",
                column: "approved_by");

            migrationBuilder.CreateIndex(
                name: "IX_closing_cash_audit_user_id",
                schema: "sales",
                table: "closing_cash",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "closing_cash_transaction_date_user_id_uix",
                schema: "sales",
                table: "closing_cash",
                columns: new[] { "user_id", "transaction_date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_coupons_associated_price_type_id",
                schema: "sales",
                table: "coupons",
                column: "associated_price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_coupons_audit_user_id",
                schema: "sales",
                table: "coupons",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "coupons_coupon_code_uix",
                schema: "sales",
                table: "coupons",
                column: "coupon_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_coupons_for_ticket_of_price_type_id",
                schema: "sales",
                table: "coupons",
                column: "for_ticket_of_price_type_id");

            migrationBuilder.CreateIndex(
                name: "customer_receipts_cash_repository_id_inx",
                schema: "sales",
                table: "customer_receipts",
                column: "cash_repository_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_receipts_check_clearing_transaction_master_id",
                schema: "sales",
                table: "customer_receipts",
                column: "check_clearing_transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_receipts_collected_on_bank_id",
                schema: "sales",
                table: "customer_receipts",
                column: "collected_on_bank_id");

            migrationBuilder.CreateIndex(
                name: "customer_receipts_currency_code_inx",
                schema: "sales",
                table: "customer_receipts",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "customer_receipts_customer_id_inx",
                schema: "sales",
                table: "customer_receipts",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "customer_receipts_posted_date_inx",
                schema: "sales",
                table: "customer_receipts",
                column: "posted_date");

            migrationBuilder.CreateIndex(
                name: "customer_receipts_transaction_master_id_inx",
                schema: "sales",
                table: "customer_receipts",
                column: "transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_customerwise_selling_prices_audit_user_id",
                schema: "sales",
                table: "customerwise_selling_prices",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_customerwise_selling_prices_customer_id",
                schema: "sales",
                table: "customerwise_selling_prices",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customerwise_selling_prices_item_id",
                schema: "sales",
                table: "customerwise_selling_prices",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_customerwise_selling_prices_unit_id",
                schema: "sales",
                table: "customerwise_selling_prices",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_gift_card_transactions_gift_card_id",
                schema: "sales",
                table: "gift_card_transactions",
                column: "gift_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_gift_card_transactions_transaction_master_id",
                schema: "sales",
                table: "gift_card_transactions",
                column: "transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_gift_cards_audit_user_id",
                schema: "sales",
                table: "gift_cards",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_gift_cards_customer_id",
                schema: "sales",
                table: "gift_cards",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "gift_cards_gift_card_number_uix",
                schema: "sales",
                table: "gift_cards",
                column: "gift_card_number",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_gift_cards_payable_account_id",
                schema: "sales",
                table: "gift_cards",
                column: "payable_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_selling_prices_audit_user_id",
                schema: "sales",
                table: "item_selling_prices",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_selling_prices_customer_type_id",
                schema: "sales",
                table: "item_selling_prices",
                column: "customer_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_selling_prices_item_id",
                schema: "sales",
                table: "item_selling_prices",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_selling_prices_price_type_id",
                schema: "sales",
                table: "item_selling_prices",
                column: "price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_selling_prices_unit_id",
                schema: "sales",
                table: "item_selling_prices",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_late_fee_account_id",
                schema: "sales",
                table: "late_fee",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_late_fee_audit_user_id",
                schema: "sales",
                table: "late_fee",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_late_fee_postings_customer_id",
                schema: "sales",
                table: "late_fee_postings",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_late_fee_postings_late_fee_tran_id",
                schema: "sales",
                table: "late_fee_postings",
                column: "late_fee_tran_id");

            migrationBuilder.CreateIndex(
                name: "IX_opening_cash_audit_user_id",
                schema: "sales",
                table: "opening_cash",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "opening_cash_transaction_date_user_id_uix",
                schema: "sales",
                table: "opening_cash",
                columns: new[] { "user_id", "transaction_date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_details_item_id",
                schema: "sales",
                table: "order_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_order_id",
                schema: "sales",
                table: "order_details",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_unit_id",
                schema: "sales",
                table: "order_details",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_audit_user_id",
                schema: "sales",
                table: "orders",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                schema: "sales",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_office_id",
                schema: "sales",
                table: "orders",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_price_type_id",
                schema: "sales",
                table: "orders",
                column: "price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_quotation_id",
                schema: "sales",
                table: "orders",
                column: "quotation_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_shipper_id",
                schema: "sales",
                table: "orders",
                column: "shipper_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                schema: "sales",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_terms_audit_user_id",
                schema: "sales",
                table: "payment_terms",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_terms_due_frequency_id",
                schema: "sales",
                table: "payment_terms",
                column: "due_frequency_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_terms_late_fee_id",
                schema: "sales",
                table: "payment_terms",
                column: "late_fee_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_terms_late_fee_posting_frequency_id",
                schema: "sales",
                table: "payment_terms",
                column: "late_fee_posting_frequency_id");

            migrationBuilder.CreateIndex(
                name: "payment_terms_payment_term_code_uix",
                schema: "sales",
                table: "payment_terms",
                column: "payment_term_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "payment_terms_payment_term_name_uix",
                schema: "sales",
                table: "payment_terms",
                column: "payment_term_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_price_types_audit_user_id",
                schema: "sales",
                table: "price_types",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotation_details_item_id",
                schema: "sales",
                table: "quotation_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotation_details_quotation_id",
                schema: "sales",
                table: "quotation_details",
                column: "quotation_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotation_details_unit_id",
                schema: "sales",
                table: "quotation_details",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_audit_user_id",
                schema: "sales",
                table: "quotations",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_customer_id",
                schema: "sales",
                table: "quotations",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_office_id",
                schema: "sales",
                table: "quotations",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_price_type_id",
                schema: "sales",
                table: "quotations",
                column: "price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_shipper_id",
                schema: "sales",
                table: "quotations",
                column: "shipper_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotations_user_id",
                schema: "sales",
                table: "quotations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_returns_checkout_id",
                schema: "sales",
                table: "returns",
                column: "checkout_id");

            migrationBuilder.CreateIndex(
                name: "IX_returns_counter_id",
                schema: "sales",
                table: "returns",
                column: "counter_id");

            migrationBuilder.CreateIndex(
                name: "IX_returns_customer_id",
                schema: "sales",
                table: "returns",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_returns_price_type_id",
                schema: "sales",
                table: "returns",
                column: "price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_returns_return_transaction_master_id",
                schema: "sales",
                table: "returns",
                column: "return_transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_returns_sales_id",
                schema: "sales",
                table: "returns",
                column: "sales_id");

            migrationBuilder.CreateIndex(
                name: "IX_returns_transaction_master_id",
                schema: "sales",
                table: "returns",
                column: "transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_cash_repository_id",
                schema: "sales",
                table: "sales",
                column: "cash_repository_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_checkout_id",
                schema: "sales",
                table: "sales",
                column: "checkout_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_counter_id",
                schema: "sales",
                table: "sales",
                column: "counter_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_coupon_id",
                schema: "sales",
                table: "sales",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_customer_id",
                schema: "sales",
                table: "sales",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_gift_card_id",
                schema: "sales",
                table: "sales",
                column: "gift_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_payment_term_id",
                schema: "sales",
                table: "sales",
                column: "payment_term_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_price_type_id",
                schema: "sales",
                table: "sales",
                column: "price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_receipt_transaction_master_id",
                schema: "sales",
                table: "sales",
                column: "receipt_transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_sales_order_id",
                schema: "sales",
                table: "sales",
                column: "sales_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_sales_quotation_id",
                schema: "sales",
                table: "sales",
                column: "sales_quotation_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_salesperson_id",
                schema: "sales",
                table: "sales",
                column: "salesperson_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_transaction_master_id",
                schema: "sales",
                table: "sales",
                column: "transaction_master_id");

            migrationBuilder.CreateIndex(
                name: "sales_invoice_number_fiscal_year_uix",
                schema: "sales",
                table: "sales",
                columns: new[] { "fiscal_year_code", "invoice_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feeds_created_by",
                schema: "social",
                table: "feeds",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_feeds_deleted_by",
                schema: "social",
                table: "feeds",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_feeds_parent_feed_id",
                schema: "social",
                table: "feeds",
                column: "parent_feed_id");

            migrationBuilder.CreateIndex(
                name: "feeds_scope_inx",
                schema: "social",
                table: "feeds",
                column: "scope");

            migrationBuilder.CreateIndex(
                name: "UQ__categori__8C585C0470CD246F",
                schema: "website",
                table: "categories",
                column: "alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_audit_user_id",
                schema: "website",
                table: "categories",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_configurations_audit_user_id",
                schema: "website",
                table: "configurations",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "configuration_domain_name_uix",
                schema: "website",
                table: "configurations",
                column: "domain_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_audit_user_id",
                schema: "website",
                table: "contacts",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__contents__8C585C049FBBBAA4",
                schema: "website",
                table: "contents",
                column: "alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contents_audit_user_id",
                schema: "website",
                table: "contents",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_contents_author_id",
                schema: "website",
                table: "contents",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_contents_category_id",
                schema: "website",
                table: "contents",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_contents_last_editor_id",
                schema: "website",
                table: "contents",
                column: "last_editor_id");

            migrationBuilder.CreateIndex(
                name: "IX_email_subscriptions_audit_user_id",
                schema: "website",
                table: "email_subscriptions",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__email_su__AB6E6164CF62348B",
                schema: "website",
                table: "email_subscriptions",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_audit_user_id",
                schema: "website",
                table: "menu_items",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_content_id",
                schema: "website",
                table: "menu_items",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_menu_id",
                schema: "website",
                table: "menu_items",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_parent_menu_item_id",
                schema: "website",
                table: "menu_items",
                column: "parent_menu_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_menus_audit_user_id",
                schema: "website",
                table: "menus",
                column: "audit_user_id");

            migrationBuilder.CreateIndex(
                name: "menus_menu_name_uix",
                schema: "website",
                table: "menus",
                column: "menu_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.AddForeignKey(
                name: "FK__access_to__appli__2DE6D218",
                schema: "account",
                table: "access_tokens",
                column: "application_id",
                principalSchema: "account",
                principalTable: "applications",
                principalColumn: "application_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__access_to__audit__31B762FC",
                schema: "account",
                table: "access_tokens",
                column: "audit_user_id",
                principalSchema: "account",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__access_to__revok__30C33EC3",
                schema: "account",
                table: "access_tokens",
                column: "revoked_by",
                principalSchema: "account",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__access_to__login__2EDAF651",
                schema: "account",
                table: "access_tokens",
                column: "login_id",
                principalSchema: "account",
                principalTable: "logins",
                principalColumn: "login_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__transacti__audit__1940BAED",
                schema: "finance",
                table: "transaction_master",
                column: "audit_user_id",
                principalSchema: "account",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__transacti__user___119F9925",
                schema: "finance",
                table: "transaction_master",
                column: "user_id",
                principalSchema: "account",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__transacti__verif__147C05D0",
                schema: "finance",
                table: "transaction_master",
                column: "verified_by_user_id",
                principalSchema: "account",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__transacti__login__10AB74EC",
                schema: "finance",
                table: "transaction_master",
                column: "login_id",
                principalSchema: "account",
                principalTable: "logins",
                principalColumn: "login_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__transacti__offic__1293BD5E",
                schema: "finance",
                table: "transaction_master",
                column: "office_id",
                principalSchema: "core",
                principalTable: "offices",
                principalColumn: "office_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__transacti__cost___1387E197",
                schema: "finance",
                table: "transaction_master",
                column: "cost_center_id",
                principalSchema: "finance",
                principalTable: "cost_centers",
                principalColumn: "cost_center_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__configura__audit__04E4BC85",
                schema: "account",
                table: "configuration_profiles",
                column: "audit_user_id",
                principalSchema: "account",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__configura__regis__6FE99F9F",
                schema: "account",
                table: "configuration_profiles",
                column: "registration_office_id",
                principalSchema: "core",
                principalTable: "offices",
                principalColumn: "office_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__configura__regis__70DDC3D8",
                schema: "account",
                table: "configuration_profiles",
                column: "registration_role_id",
                principalSchema: "account",
                principalTable: "roles",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__users__office_id__7E37BEF6",
                schema: "account",
                table: "users",
                column: "office_id",
                principalSchema: "core",
                principalTable: "offices",
                principalColumn: "office_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__users__role_id__7F2BE32F",
                schema: "account",
                table: "users",
                column: "role_id",
                principalSchema: "account",
                principalTable: "roles",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__roles__audit_use__05D8E0BE",
                schema: "account",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK__offices__audit_u__4F47C5E3",
                schema: "core",
                table: "offices");

            migrationBuilder.DropTable(
                name: "access_tokens",
                schema: "account");

            migrationBuilder.DropTable(
                name: "configuration_profiles",
                schema: "account");

            migrationBuilder.DropTable(
                name: "fb_access_tokens",
                schema: "account");

            migrationBuilder.DropTable(
                name: "google_access_tokens",
                schema: "account");

            migrationBuilder.DropTable(
                name: "installed_domains",
                schema: "account");

            migrationBuilder.DropTable(
                name: "registrations",
                schema: "account");

            migrationBuilder.DropTable(
                name: "reset_requests",
                schema: "account");

            migrationBuilder.DropTable(
                name: "contacts",
                schema: "addressbook");

            migrationBuilder.DropTable(
                name: "entity_access_policy",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "group_entity_access_policy",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "group_menu_access_policy",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "menu_access_policy",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "events",
                schema: "calendar");

            migrationBuilder.DropTable(
                name: "custom_fields",
                schema: "config");

            migrationBuilder.DropTable(
                name: "email_queue",
                schema: "config");

            migrationBuilder.DropTable(
                name: "filters",
                schema: "config");

            migrationBuilder.DropTable(
                name: "kanban_details",
                schema: "config");

            migrationBuilder.DropTable(
                name: "sms_queue",
                schema: "config");

            migrationBuilder.DropTable(
                name: "smtp_configs",
                schema: "config");

            migrationBuilder.DropTable(
                name: "app_dependencies",
                schema: "core");

            migrationBuilder.DropTable(
                name: "notification_statuses",
                schema: "core");

            migrationBuilder.DropTable(
                name: "week_days",
                schema: "core");

            migrationBuilder.DropTable(
                name: "auto_verification_policy",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "cash_flow_setup",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "day_operation_routines",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "exchange_rate_details",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "frequency_setups",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "journal_verification_policy",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "merchant_fee_setup",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "tax_setups",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "transaction_details",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "transaction_documents",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "transaction_types",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "attendances",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "contracts",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "employee_experiences",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "employee_identification_details",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "employee_qualifications",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "employee_social_network_details",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "exits",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "leave_applications",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "office_hours",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "resignations",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "terminations",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "checkout_details",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "compound_units",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "inventory_setup",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "inventory_transfer_delivery_details",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "inventory_transfer_request_details",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "item_variants",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "serial_numbers",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "item_cost_prices",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "order_details",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "purchase_returns",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "quotation_details",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "supplier_payments",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "supplierwise_cost_prices",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "cashier_login_info",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "closing_cash",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "customer_receipts",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "customerwise_selling_prices",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "gift_card_transactions",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "item_selling_prices",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "late_fee_postings",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "opening_cash",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "order_details",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "quotation_details",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "returns",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "feeds",
                schema: "social");

            migrationBuilder.DropTable(
                name: "configurations",
                schema: "website");

            migrationBuilder.DropTable(
                name: "contacts",
                schema: "website");

            migrationBuilder.DropTable(
                name: "email_subscriptions",
                schema: "website");

            migrationBuilder.DropTable(
                name: "menu_items",
                schema: "website");

            migrationBuilder.DropTable(
                name: "applications",
                schema: "account");

            migrationBuilder.DropTable(
                name: "access_types",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "calendar");

            migrationBuilder.DropTable(
                name: "custom_field_setup",
                schema: "config");

            migrationBuilder.DropTable(
                name: "kanbans",
                schema: "config");

            migrationBuilder.DropTable(
                name: "notifications",
                schema: "core");

            migrationBuilder.DropTable(
                name: "cash_flow_headings",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "day_operation",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "routines",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "exchange_rates",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "payment_cards",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "leave_benefits",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "identification_types",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "education_levels",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "social_networks",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "exit_types",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "leave_types",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "week_days",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "inventory_transfer_deliveries",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "variants",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "purchases",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "cashiers",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "bank_accounts",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "items",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "sales",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "contents",
                schema: "website");

            migrationBuilder.DropTable(
                name: "menus",
                schema: "website");

            migrationBuilder.DropTable(
                name: "custom_field_data_types",
                schema: "config");

            migrationBuilder.DropTable(
                name: "custom_field_forms",
                schema: "config");

            migrationBuilder.DropTable(
                name: "menus",
                schema: "core");

            migrationBuilder.DropTable(
                name: "card_types",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "core");

            migrationBuilder.DropTable(
                name: "departments",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "employment_statuses",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "job_titles",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "pay_grades",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "shifts",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "employee_types",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "genders",
                schema: "core");

            migrationBuilder.DropTable(
                name: "marital_statuses",
                schema: "core");

            migrationBuilder.DropTable(
                name: "nationalities",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "inventory_transfer_requests",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "attributes",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "quotations",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "bank_types",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "item_groups",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "item_types",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "suppliers",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "units",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "checkouts",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "counters",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "coupons",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "fiscal_year",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "gift_cards",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "payment_terms",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "website");

            migrationBuilder.DropTable(
                name: "apps",
                schema: "core");

            migrationBuilder.DropTable(
                name: "employment_status_codes",
                schema: "hrm");

            migrationBuilder.DropTable(
                name: "price_types",
                schema: "purchase");

            migrationBuilder.DropTable(
                name: "supplier_types",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "transaction_master",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "frequencies",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "late_fee",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "quotations",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "cost_centers",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "logins",
                schema: "account");

            migrationBuilder.DropTable(
                name: "verification_statuses",
                schema: "core");

            migrationBuilder.DropTable(
                name: "cash_repositories",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "store_types",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "price_types",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "shippers",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "customer_types",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "account_masters",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "currencies",
                schema: "core");

            migrationBuilder.DropTable(
                name: "users",
                schema: "account");

            migrationBuilder.DropTable(
                name: "offices",
                schema: "core");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "account");
        }
    }
}
