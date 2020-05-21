using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class RenameTechnologyDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Option 1: manually copy the data
            /*
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Technologies",
                nullable: true);

            migrationBuilder.Sql("UPDATE Technologies SET Description = Desc");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Technologies");
            */

            // Option 2
            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Technologies",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Technologies",
                newName: "Desc");
        }
    }
}
