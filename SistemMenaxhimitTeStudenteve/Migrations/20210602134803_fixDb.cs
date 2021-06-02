using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemMenaxhimitTeStudenteve.Migrations
{
    public partial class fixDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "StudentLends");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Lendet",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Lendet",
                keyColumn: "Id",
                keyValue: 1,
                column: "Info",
                value: "Test Test");

            migrationBuilder.UpdateData(
                table: "Lendet",
                keyColumn: "Id",
                keyValue: 2,
                column: "Info",
                value: "Test Test");

            migrationBuilder.UpdateData(
                table: "Lendet",
                keyColumn: "Id",
                keyValue: 3,
                column: "Info",
                value: "Test Test");

            migrationBuilder.UpdateData(
                table: "Lendet",
                keyColumn: "Id",
                keyValue: 4,
                column: "Info",
                value: "Test Test");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Lendet");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "StudentLends",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
