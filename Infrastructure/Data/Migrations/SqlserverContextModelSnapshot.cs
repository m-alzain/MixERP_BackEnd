﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(SqlserverContext))]
    partial class SqlserverContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.Office", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("office_id");

                    b.Property<string>("AddressLine1")
                        .HasColumnName("address_line_1")
                        .HasMaxLength(128);

                    b.Property<string>("AddressLine2")
                        .HasColumnName("address_line_2")
                        .HasMaxLength(128);

                    b.Property<bool>("AllowTransactionPosting")
                        .HasColumnName("allow_transaction_posting");

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasColumnName("country")
                        .HasMaxLength(50);

                    b.Property<Guid?>("CreatedByUserId")
                        .HasColumnName("created_by_userId");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<string>("CurrencyCode")
                        .HasColumnName("currency_code")
                        .HasMaxLength(12);

                    b.Property<bool?>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("deleted")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(128);

                    b.Property<string>("Fax")
                        .HasColumnName("fax")
                        .HasMaxLength(24);

                    b.Property<byte[]>("Logo")
                        .HasColumnName("logo");

                    b.Property<string>("NickName")
                        .HasColumnName("nick_name")
                        .HasMaxLength(50);

                    b.Property<string>("OfficeCode")
                        .IsRequired()
                        .HasColumnName("office_code")
                        .HasMaxLength(12);

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnName("office_name")
                        .HasMaxLength(150);

                    b.Property<string>("PanNumber")
                        .HasColumnName("pan_number")
                        .HasMaxLength(100);

                    b.Property<Guid?>("ParentOfficeId")
                        .HasColumnName("parent_office_id");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(24);

                    b.Property<string>("PoBox")
                        .HasColumnName("po_box")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnName("registration_date")
                        .HasColumnType("date");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnName("registration_number")
                        .HasMaxLength(100);

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasMaxLength(50);

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasMaxLength(50);

                    b.Property<Guid>("TenantId")
                        .HasColumnName("tenant_id");

                    b.Property<Guid?>("UpdatedByUserId")
                        .HasColumnName("updated_by_userId");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("updated_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasMaxLength(50);

                    b.Property<string>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasMaxLength(24);

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("OfficeCode")
                        .IsUnique()
                        .HasName("offices_office_code_uix")
                        .HasFilter("([deleted]=(0))");

                    b.HasIndex("OfficeName")
                        .IsUnique()
                        .HasName("offices_office_name_uix")
                        .HasFilter("([deleted]=(0))");

                    b.HasIndex("ParentOfficeId");

                    b.HasIndex("TenantId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("offices","account");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.OfficeUser", b =>
                {
                    b.Property<Guid>("OfficeId")
                        .HasColumnName("office_id");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("OfficeId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("office_users","account");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("role_id");

                    b.Property<Guid?>("CreatedByUserId")
                        .HasColumnName("created_by_userId");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<bool?>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("deleted")
                        .HasDefaultValueSql("((0))");

                    b.Property<bool>("IsAdministrator")
                        .HasColumnName("is_administrator");

                    b.Property<Guid>("OfficeId")
                        .HasColumnName("office_id");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnName("role_name")
                        .HasMaxLength(100);

                    b.Property<Guid?>("TenantId");

                    b.Property<Guid?>("UpdatedByUserId")
                        .HasColumnName("updated_by_userId");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("updated_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("OfficeId");

                    b.HasIndex("RoleName")
                        .IsUnique()
                        .HasName("UQ__roles__783254B1A0BC1C3C");

                    b.HasIndex("TenantId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("roles","account");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.RoleUser", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("role_users","account");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("Tenant_id");

                    b.Property<string>("AddressLine1")
                        .HasColumnName("address_line_1")
                        .HasMaxLength(128);

                    b.Property<string>("AddressLine2")
                        .HasColumnName("address_line_2")
                        .HasMaxLength(128);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasColumnName("country")
                        .HasMaxLength(50);

                    b.Property<Guid?>("CreatedByUserId")
                        .HasColumnName("created_by_userId");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<string>("CurrencyCode")
                        .HasColumnName("currency_code")
                        .HasMaxLength(12);

                    b.Property<bool?>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("deleted")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(128);

                    b.Property<string>("Fax")
                        .HasColumnName("fax")
                        .HasMaxLength(24);

                    b.Property<byte[]>("Logo")
                        .HasColumnName("logo");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(24);

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnName("registration_date")
                        .HasColumnType("date");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnName("registration_number")
                        .HasMaxLength(100);

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasMaxLength(50);

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasMaxLength(50);

                    b.Property<string>("TenantCode")
                        .IsRequired()
                        .HasColumnName("tenant_code")
                        .HasMaxLength(12);

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnName("tenant_name")
                        .HasMaxLength(150);

                    b.Property<Guid?>("UpdatedByUserId")
                        .HasColumnName("updated_by_userId");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("updated_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasMaxLength(50);

                    b.Property<string>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasMaxLength(24);

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("tenants","account");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("user_id");

                    b.Property<Guid?>("CreatedByUserId")
                        .HasColumnName("created_by_userId");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<bool?>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("deleted")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("LastBrowser")
                        .HasColumnName("last_browser")
                        .HasMaxLength(500);

                    b.Property<string>("LastIp")
                        .HasColumnName("last_ip")
                        .HasMaxLength(500);

                    b.Property<DateTimeOffset?>("LastSeenOn")
                        .HasColumnName("last_seen_on");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(100);

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("status")
                        .HasDefaultValueSql("((1))");

                    b.Property<Guid?>("UpdatedByUserId")
                        .HasColumnName("updated_by_userId");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("updated_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("users_email_uix")
                        .HasFilter("([deleted]=(0))");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("users","account");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Auth.GroupEntityAccessPolicy", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("group_entity_access_policy_id");

                    b.Property<int>("AccessType");

                    b.Property<bool>("AllowAccess")
                        .HasColumnName("allow_access");

                    b.Property<Guid?>("CreatedByUserId")
                        .HasColumnName("created_by_userId");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<bool?>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("deleted")
                        .HasDefaultValueSql("((0))");

                    b.Property<Guid>("EntityTypeId")
                        .HasColumnName("entity_type_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<Guid?>("UpdatedByUserId")
                        .HasColumnName("updated_by_userId");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("updated_on")
                        .HasDefaultValueSql("(getutcdate())");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("EntityTypeId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("group_entity_access_policies","auth");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Core.EntityType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("entity_type_id");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnName("entity_name")
                        .HasMaxLength(100);

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnName("icon")
                        .HasMaxLength(100);

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnName("module_name")
                        .HasMaxLength(100);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnName("url")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("EntityName")
                        .IsUnique()
                        .HasName("UQ__entity_types__783254B1A0BC1C3C");

                    b.ToTable("entity_types","account");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.Office", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Accounts.User", "CreatedByUser")
                        .WithMany("CreatedOffices")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("FK__created_offices__createted_by_user");

                    b.HasOne("ApplicationCore.Entities.Accounts.Office", "ParentOffice")
                        .WithMany("InverseParentOffice")
                        .HasForeignKey("ParentOfficeId")
                        .HasConstraintName("FK__offices__parent___31EC6D26");

                    b.HasOne("ApplicationCore.Entities.Accounts.Tenant", "Tenant")
                        .WithMany("Offices")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("FK__offices__tenant");

                    b.HasOne("ApplicationCore.Entities.Accounts.User", "UpdatedByUser")
                        .WithMany("UpdatedOffices")
                        .HasForeignKey("UpdatedByUserId")
                        .HasConstraintName("FK__updated_offices__updated_by_user");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.OfficeUser", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Accounts.Office", "Office")
                        .WithMany("OfficeUsers")
                        .HasForeignKey("OfficeId")
                        .HasConstraintName("FK__office_users__office")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCore.Entities.Accounts.User", "User")
                        .WithMany("OfficeUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__office_users__user")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.Role", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Accounts.User", "CreatedByUser")
                        .WithMany("CreatedRoles")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("FK__created_roles__createted_by_user");

                    b.HasOne("ApplicationCore.Entities.Accounts.Office", "Office")
                        .WithMany("Roles")
                        .HasForeignKey("OfficeId")
                        .HasConstraintName("FK__rolds__office___31EC6D26");

                    b.HasOne("ApplicationCore.Entities.Accounts.Tenant")
                        .WithMany("Roles")
                        .HasForeignKey("TenantId");

                    b.HasOne("ApplicationCore.Entities.Accounts.User", "UpdatedByUser")
                        .WithMany("UpdatedRoles")
                        .HasForeignKey("UpdatedByUserId")
                        .HasConstraintName("FK__updated_roles__updated_by_user");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.RoleUser", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Accounts.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__role_users__role")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCore.Entities.Accounts.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__role_users__user")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.Tenant", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Accounts.User", "CreatedByUser")
                        .WithMany("CreatedTenants")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("FK__created_tenants__createted_by_user");

                    b.HasOne("ApplicationCore.Entities.Accounts.User", "UpdatedByUser")
                        .WithMany("UpdatedTenants")
                        .HasForeignKey("UpdatedByUserId")
                        .HasConstraintName("FK__updated_tenants__updated_by_user");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Accounts.User", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Accounts.User", "CreatedByUser")
                        .WithMany("InverseCreatedUsers")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("FK__created_users__createted_by_user");

                    b.HasOne("ApplicationCore.Entities.Accounts.User", "UpdatedByUser")
                        .WithMany("InverseUpdatedUsers")
                        .HasForeignKey("UpdatedByUserId")
                        .HasConstraintName("FK__updated_users__updated_by_user");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Auth.GroupEntityAccessPolicy", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Accounts.User", "CreatedByUser")
                        .WithMany("CreatedGroupEntityAccessPolicies")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("FK__created_group_entity_access_policies__createted_by_user");

                    b.HasOne("ApplicationCore.Entities.Core.EntityType", "EntityType")
                        .WithMany("GroupEntityAccessPolicies")
                        .HasForeignKey("EntityTypeId")
                        .HasConstraintName("FK__group_entity__acces__polciy_entity_type")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCore.Entities.Accounts.Role", "Role")
                        .WithMany("GroupEntityAccessPolicies")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__group_entity__acces__polciy_role")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCore.Entities.Accounts.User", "UpdatedByUser")
                        .WithMany("UpdatedGroupEntityAccessPolicies")
                        .HasForeignKey("UpdatedByUserId")
                        .HasConstraintName("FK__updated_group_entity_access_policies__updated_by_user");
                });
#pragma warning restore 612, 618
        }
    }
}
