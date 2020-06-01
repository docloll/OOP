using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolOlympiads.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Olympiads",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olympiads", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Olympiads",
                columns: new[] { "Id", "Class", "Name", "Subject", "Type", "Year" },
                values: new object[] { 1L, "7 - 11", "Всероссийская олимпиада по технологии", "Технология ", "Всероссийская олимпиада", 2015 });

            migrationBuilder.InsertData(
                table: "Olympiads",
                columns: new[] { "Id", "Class", "Name", "Subject", "Type", "Year" },
                values: new object[] { 2L, "6 - 7", "Математический праздник", "Математика", "Московская олимпиада", 2016 });

            migrationBuilder.InsertData(
                table: "Olympiads",
                columns: new[] { "Id", "Class", "Name", "Subject", "Type", "Year" },
                values: new object[] { 3L, "5 - 11", "Московская астрономическая олимпиада", "Астрономия", "Московская олимпиада", 2016 });

            migrationBuilder.InsertData(
                table: "Olympiads",
                columns: new[] { "Id", "Class", "Name", "Subject", "Type", "Year" },
                values: new object[] { 4L, "5 - 11", "Московская математическая олимпиада", "Математика", "Московская олимпиада", 2016 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Olympiads");
        }
    }
}
