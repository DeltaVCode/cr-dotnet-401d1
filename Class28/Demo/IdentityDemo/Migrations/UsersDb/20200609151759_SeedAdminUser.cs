using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityDemo.Migrations.UsersDb
{
    public partial class SeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "7264fdfd-5422-4cad-a12c-356a4694ef01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "moderator",
                column: "ConcurrencyStamp",
                value: "79b16ad0-71fc-4d45-851a-c8c0544adf1d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19", 0, null, "8d4b7189-803f-4c62-a5e9-bbbce2f08c36", null, false, "Keith", "Dahlby", false, null, null, null, "AQAAAAEAACcQAAAAEMfJn2xgswkLTOY0V861KjTNPhVPpD6+y9Q5NdMpFsZhNEM6kDdZFQUSCT39p+u4AA==", null, false, "7a67ae14-e7dc-403a-9556-ba3ae5859429", false, "keith" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19", "admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "2787097d-cfb1-4e95-9e6f-130061bc1cc4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "moderator",
                column: "ConcurrencyStamp",
                value: "8b70fbfa-1cdc-4c38-91ac-25878bfb4e9c");
        }
    }
}
