using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityDemo.Migrations
{
    public partial class PleaseToBeHasPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Contents = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Contents", "Title" },
                values: new object[] { 1, "Hello, World was created by Brian Kernighan. This term also refers to a simple introductory program for beginners. ", "Hello World" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Contents", "Title" },
                values: new object[] { 2, "C# is a programming language created by Microsoft in 2000. It is widely used for many different applications. we love C#", "Intro to C#" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Contents", "Title" },
                values: new object[] { 3, "How much wood could a woodchuck chuck, if a woodchuck could chuck wood?", "A simple riddle" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
