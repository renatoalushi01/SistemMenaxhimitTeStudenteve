using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemMenaxhimitTeStudenteve.Migrations
{
    public partial class TabelaLendet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lendet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emer = table.Column<string>(nullable: true),
                    Subscribe = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lendet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lendet_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Lendet",
                columns: new[] { "Id", "Data", "Emer", "Info", "StudentId", "Subscribe" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lenda1", null, null, false },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lenda2", null, null, false },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lenda3", null, null, false },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lenda4", null, null, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lendet_StudentId",
                table: "Lendet",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lendet");
        }
    }
}
