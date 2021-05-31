using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemMenaxhimitTeStudenteve.Migrations
{
    public partial class TabelaStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mbiemer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotaMesartare = table.Column<double>(type: "float", nullable: false),
                    ProfesioniDeshiruar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TedhenaTePergj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fjalkalimi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
