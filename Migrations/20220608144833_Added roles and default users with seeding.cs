using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_test_01.Migrations
{
    public partial class Addedrolesanddefaultuserswithseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "542db827-0bb2-4abe-bad4-4baee3b986ea", "124c3e8e-16f0-4971-a892-2e36c1f272a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "afd222d5-461e-4c42-b8f0-dd12c3b19271", "c9c36d79-d8ae-467e-9e69-5df8c20a62c1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5c83c8e2-e74d-419f-9bf0-9692702409e0", 0, "50ae1f77-03a4-49df-b5c6-cee9b7d07c8f", new DateTime(2022, 6, 8, 16, 48, 33, 385, DateTimeKind.Local).AddTicks(3627), "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEK+DKjHq3oMYTKQ8ENUvvbbkphXhnKT8n1Re68AzMeG8o8RqbxoCJ+kzux9FJQgt9w==", null, false, "3fae05e3-4349-47de-8e00-e7488cee6da3", false, "Admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "5c83c8e2-e74d-419f-9bf0-9692702409e0", "542db827-0bb2-4abe-bad4-4baee3b986ea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afd222d5-461e-4c42-b8f0-dd12c3b19271");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5c83c8e2-e74d-419f-9bf0-9692702409e0", "542db827-0bb2-4abe-bad4-4baee3b986ea" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "542db827-0bb2-4abe-bad4-4baee3b986ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c83c8e2-e74d-419f-9bf0-9692702409e0");
        }
    }
}
