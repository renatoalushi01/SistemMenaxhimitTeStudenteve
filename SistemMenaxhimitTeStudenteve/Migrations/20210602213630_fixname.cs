using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemMenaxhimitTeStudenteve.Migrations
{
    public partial class fixname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentLends_Lendet_LendetId",
                table: "StudentLends");

            migrationBuilder.DropIndex(
                name: "IX_StudentLends_LendetId",
                table: "StudentLends");

            migrationBuilder.DropColumn(
                name: "LendetId",
                table: "StudentLends");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLends_LendId",
                table: "StudentLends",
                column: "LendId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLends_Lendet_LendId",
                table: "StudentLends",
                column: "LendId",
                principalTable: "Lendet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentLends_Lendet_LendId",
                table: "StudentLends");

            migrationBuilder.DropIndex(
                name: "IX_StudentLends_LendId",
                table: "StudentLends");

            migrationBuilder.AddColumn<int>(
                name: "LendetId",
                table: "StudentLends",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentLends_LendetId",
                table: "StudentLends",
                column: "LendetId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLends_Lendet_LendetId",
                table: "StudentLends",
                column: "LendetId",
                principalTable: "Lendet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
