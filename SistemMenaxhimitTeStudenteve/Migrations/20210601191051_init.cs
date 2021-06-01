using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemMenaxhimitTeStudenteve.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lendet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lendet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NID = table.Column<string>(nullable: true),
                    Emer = table.Column<string>(nullable: true),
                    Mbiemer = table.Column<string>(nullable: true),
                    NotaMesartare = table.Column<double>(nullable: false),
                    ProfesioniDeshiruar = table.Column<string>(nullable: true),
                    TedhenaTePergj = table.Column<string>(nullable: true),
                    Fjalkalimi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Lendet",
                columns: new[] { "Id", "Emer" },
                values: new object[,]
                {
                    { 1, "Lenda1" },
                    { 2, "Lenda2" },
                    { 3, "Lenda3" },
                    { 4, "Lenda4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lendet");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
