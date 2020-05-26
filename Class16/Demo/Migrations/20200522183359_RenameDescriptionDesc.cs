using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class RenameDescriptionDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            // Option 1: Add, Copy, Drop
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Technologies",
                nullable: true);

            migrationBuilder.Sql("UPDATE Technologies SET Desc = Description");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Technologies");
            */

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Technologies",
                newName: "Desc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Technologies",
                newName: "Description");
        }
    }
}
