using System;
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
                name: "auth");

            migrationBuilder.CreateTable(
                name: "entity_types",
                schema: "account",
                columns: table => new
                {
                    entity_type_id = table.Column<Guid>(nullable: false),
                    module_name = table.Column<string>(maxLength: 100, nullable: false),
                    entity_name = table.Column<string>(maxLength: 100, nullable: false),
                    url = table.Column<string>(maxLength: 500, nullable: false),
                    icon = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity_types", x => x.entity_type_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "account",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    phone = table.Column<string>(maxLength: 100, nullable: true),
                    status = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    last_seen_on = table.Column<DateTimeOffset>(nullable: true),
                    last_ip = table.Column<string>(maxLength: 500, nullable: true),
                    last_browser = table.Column<string>(maxLength: 500, nullable: true),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    created_by_userId = table.Column<Guid>(nullable: true),
                    created_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    updated_by_userId = table.Column<Guid>(nullable: true),
                    updated_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__created_users__createted_by_user",
                        column: x => x.created_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__updated_users__updated_by_user",
                        column: x => x.updated_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tenants",
                schema: "account",
                columns: table => new
                {
                    Tenant_id = table.Column<Guid>(nullable: false),
                    tenant_code = table.Column<string>(maxLength: 12, nullable: false),
                    tenant_name = table.Column<string>(maxLength: 150, nullable: false),
                    registration_date = table.Column<DateTime>(type: "date", nullable: true),
                    currency_code = table.Column<string>(maxLength: 12, nullable: true),
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
                    registration_number = table.Column<string>(maxLength: 100, nullable: true),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    created_by_userId = table.Column<Guid>(nullable: true),
                    created_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    updated_by_userId = table.Column<Guid>(nullable: true),
                    updated_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenants", x => x.Tenant_id);
                    table.ForeignKey(
                        name: "FK__created_tenants__createted_by_user",
                        column: x => x.created_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__updated_tenants__updated_by_user",
                        column: x => x.updated_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "offices",
                schema: "account",
                columns: table => new
                {
                    office_id = table.Column<Guid>(nullable: false),
                    tenant_id = table.Column<Guid>(nullable: false),
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
                    parent_office_id = table.Column<Guid>(nullable: true),
                    registration_number = table.Column<string>(maxLength: 100, nullable: true),
                    pan_number = table.Column<string>(maxLength: 100, nullable: true),
                    allow_transaction_posting = table.Column<bool>(nullable: false),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    created_by_userId = table.Column<Guid>(nullable: true),
                    created_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    updated_by_userId = table.Column<Guid>(nullable: true),
                    updated_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offices", x => x.office_id);
                    table.ForeignKey(
                        name: "FK__created_offices__createted_by_user",
                        column: x => x.created_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__offices__parent___31EC6D26",
                        column: x => x.parent_office_id,
                        principalSchema: "account",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__offices__tenant",
                        column: x => x.tenant_id,
                        principalSchema: "account",
                        principalTable: "tenants",
                        principalColumn: "Tenant_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__updated_offices__updated_by_user",
                        column: x => x.updated_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "office_users",
                schema: "account",
                columns: table => new
                {
                    office_id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office_users", x => new { x.office_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__office_users__office",
                        column: x => x.office_id,
                        principalSchema: "account",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__office_users__user",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "account",
                columns: table => new
                {
                    role_id = table.Column<Guid>(nullable: false),
                    office_id = table.Column<Guid>(nullable: false),
                    role_name = table.Column<string>(maxLength: 100, nullable: false),
                    is_administrator = table.Column<bool>(nullable: false),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    created_by_userId = table.Column<Guid>(nullable: true),
                    created_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    updated_by_userId = table.Column<Guid>(nullable: true),
                    updated_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                    table.ForeignKey(
                        name: "FK__created_roles__createted_by_user",
                        column: x => x.created_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__rolds__office___31EC6D26",
                        column: x => x.office_id,
                        principalSchema: "account",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_roles_tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "account",
                        principalTable: "tenants",
                        principalColumn: "Tenant_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__updated_roles__updated_by_user",
                        column: x => x.updated_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_users",
                schema: "account",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_users", x => new { x.role_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__role_users__role",
                        column: x => x.role_id,
                        principalSchema: "account",
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__role_users__user",
                        column: x => x.user_id,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group_entity_access_policies",
                schema: "auth",
                columns: table => new
                {
                    group_entity_access_policy_id = table.Column<Guid>(nullable: false),
                    entity_type_id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false),
                    AccessType = table.Column<int>(nullable: false),
                    allow_access = table.Column<bool>(nullable: false),
                    deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    created_by_userId = table.Column<Guid>(nullable: true),
                    created_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())"),
                    updated_by_userId = table.Column<Guid>(nullable: true),
                    updated_on = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_entity_access_policies", x => x.group_entity_access_policy_id);
                    table.ForeignKey(
                        name: "FK__created_group_entity_access_policies__createted_by_user",
                        column: x => x.created_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__group_entity__acces__polciy_entity_type",
                        column: x => x.entity_type_id,
                        principalSchema: "account",
                        principalTable: "entity_types",
                        principalColumn: "entity_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__group_entity__acces__polciy_role",
                        column: x => x.role_id,
                        principalSchema: "account",
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__updated_group_entity_access_policies__updated_by_user",
                        column: x => x.updated_by_userId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__entity_types__783254B1A0BC1C3C",
                schema: "account",
                table: "entity_types",
                column: "entity_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_office_users_user_id",
                schema: "account",
                table: "office_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_offices_created_by_userId",
                schema: "account",
                table: "offices",
                column: "created_by_userId");

            migrationBuilder.CreateIndex(
                name: "offices_office_code_uix",
                schema: "account",
                table: "offices",
                column: "office_code",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "offices_office_name_uix",
                schema: "account",
                table: "offices",
                column: "office_name",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_offices_parent_office_id",
                schema: "account",
                table: "offices",
                column: "parent_office_id");

            migrationBuilder.CreateIndex(
                name: "IX_offices_tenant_id",
                schema: "account",
                table: "offices",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_offices_updated_by_userId",
                schema: "account",
                table: "offices",
                column: "updated_by_userId");

            migrationBuilder.CreateIndex(
                name: "IX_role_users_user_id",
                schema: "account",
                table: "role_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_created_by_userId",
                schema: "account",
                table: "roles",
                column: "created_by_userId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_office_id",
                schema: "account",
                table: "roles",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "UQ__roles__783254B1A0BC1C3C",
                schema: "account",
                table: "roles",
                column: "role_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_roles_TenantId",
                schema: "account",
                table: "roles",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_updated_by_userId",
                schema: "account",
                table: "roles",
                column: "updated_by_userId");

            migrationBuilder.CreateIndex(
                name: "IX_tenants_created_by_userId",
                schema: "account",
                table: "tenants",
                column: "created_by_userId");

            migrationBuilder.CreateIndex(
                name: "IX_tenants_updated_by_userId",
                schema: "account",
                table: "tenants",
                column: "updated_by_userId");

            migrationBuilder.CreateIndex(
                name: "IX_users_created_by_userId",
                schema: "account",
                table: "users",
                column: "created_by_userId");

            migrationBuilder.CreateIndex(
                name: "users_email_uix",
                schema: "account",
                table: "users",
                column: "email",
                unique: true,
                filter: "([deleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_users_updated_by_userId",
                schema: "account",
                table: "users",
                column: "updated_by_userId");

            migrationBuilder.CreateIndex(
                name: "IX_group_entity_access_policies_created_by_userId",
                schema: "auth",
                table: "group_entity_access_policies",
                column: "created_by_userId");

            migrationBuilder.CreateIndex(
                name: "IX_group_entity_access_policies_entity_type_id",
                schema: "auth",
                table: "group_entity_access_policies",
                column: "entity_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_entity_access_policies_role_id",
                schema: "auth",
                table: "group_entity_access_policies",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_entity_access_policies_updated_by_userId",
                schema: "auth",
                table: "group_entity_access_policies",
                column: "updated_by_userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "office_users",
                schema: "account");

            migrationBuilder.DropTable(
                name: "role_users",
                schema: "account");

            migrationBuilder.DropTable(
                name: "group_entity_access_policies",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "entity_types",
                schema: "account");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "account");

            migrationBuilder.DropTable(
                name: "offices",
                schema: "account");

            migrationBuilder.DropTable(
                name: "tenants",
                schema: "account");

            migrationBuilder.DropTable(
                name: "users",
                schema: "account");
        }
    }
}
