using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class CoursesTechnologyIsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Technologies_TechnologyId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "TechnologyId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Technologies_TechnologyId",
                table: "Courses",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Technologies_TechnologyId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "TechnologyId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Technologies_TechnologyId",
                table: "Courses",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
