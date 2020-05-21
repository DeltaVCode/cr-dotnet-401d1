using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class SeedAnEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "Price", "TechnologyId" },
                values: new object[] { 1, "cr-dotnet-401d1", 1000000m, 1 });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1L });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
