using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityDemo.Migrations
{
    public partial class AddModifiedByAndTimestamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedByTimestamp",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedByTimestamp",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByTimestamp",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ModifiedByTimestamp",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Posts");
        }
    }
}
