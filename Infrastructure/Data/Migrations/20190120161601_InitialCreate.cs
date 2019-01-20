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
                name: "tenant_office_users",
                schema: "account",
                columns: table => new
                {
                    OfficeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant_office_users", x => new { x.OfficeId, x.UserId });
                    table.ForeignKey(
                        name: "FK__office_users__office",
                        column: x => x.OfficeId,
                        principalSchema: "account",
                        principalTable: "offices",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__tenant_office_users__user",
                        column: x => x.UserId,
                        principalSchema: "account",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_tenant_office_users_UserId",
                schema: "account",
                table: "tenant_office_users",
                column: "UserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenant_office_users",
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
