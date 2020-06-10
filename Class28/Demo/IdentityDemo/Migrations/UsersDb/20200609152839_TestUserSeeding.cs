using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityDemo.Migrations.UsersDb
{
    public partial class TestUserSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "17722115-21fd-4451-8db4-e99f5c602421");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "moderator",
                column: "ConcurrencyStamp",
                value: "77ab348b-69d4-4e9a-9515-0a5c60bbf840");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6021be4-a1fb-4265-9a99-69353b243cee", "AQAAAAEAACcQAAAAEJcltf7DARNNFfCIS4Uz9uf6vjNJW9HqoFtUiIpymvzqxov24vihIVTVbBmJHkgqvw==", "dee200a6-c80a-4328-9f32-8be7c268f114" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d4b7189-803f-4c62-a5e9-bbbce2f08c36", "AQAAAAEAACcQAAAAEMfJn2xgswkLTOY0V861KjTNPhVPpD6+y9Q5NdMpFsZhNEM6kDdZFQUSCT39p+u4AA==", "7a67ae14-e7dc-403a-9556-ba3ae5859429" });
        }
    }
}
