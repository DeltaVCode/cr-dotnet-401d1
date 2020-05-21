using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class SeedOneStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keith", "Dahlby" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
