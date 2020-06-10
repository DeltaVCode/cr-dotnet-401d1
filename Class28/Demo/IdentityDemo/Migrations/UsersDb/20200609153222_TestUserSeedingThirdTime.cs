using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityDemo.Migrations.UsersDb
{
    public partial class TestUserSeedingThirdTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Leave Brittney alone! (Don't delete our seeded user!)

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "UserId", "RoleId" },
            //    keyValues: new object[] { "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19", "admin" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19", 0, null, "8d4b7189-803f-4c62-a5e9-bbbce2f08c36", null, false, "Keith", "Dahlby", false, null, null, null, "AQAAAAEAACcQAAAAELiNJw2iFK6pWQpburq0KrFdTZQUxs+KMVnCf+9Rd9KaVKVr/4HnK8/FIdOdQrxweg==", null, false, "37e2d6d8-035f-4712-a2f7-0902520ce702", false, "keith" });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "UserId", "RoleId" },
            //    values: new object[] { "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19", "admin" });
        }
    }
}
