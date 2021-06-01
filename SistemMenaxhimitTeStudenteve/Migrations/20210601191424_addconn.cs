using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemMenaxhimitTeStudenteve.Migrations
{
    public partial class addconn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentLends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    LendId = table.Column<int>(nullable: false),
                    Subscribe = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    LendetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLends_Lendet_LendetId",
                        column: x => x.LendetId,
                        principalTable: "Lendet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLends_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentLends_LendetId",
                table: "StudentLends",
                column: "LendetId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLends_StudentId",
                table: "StudentLends",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentLends");
        }
    }
}
