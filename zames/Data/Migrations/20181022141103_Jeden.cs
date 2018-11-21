using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zames.Data.Migrations
{
    public partial class Jeden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zamestnanec",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Meno = table.Column<string>(nullable: true),
                    Priezvisko = table.Column<string>(nullable: true),
                    Január = table.Column<string>(nullable: true),
                    Február = table.Column<string>(nullable: true),
                    Marec = table.Column<string>(nullable: true),
                    Apríl = table.Column<string>(nullable: true),
                    Máj = table.Column<string>(nullable: true),
                    Jún = table.Column<string>(nullable: true),
                    Júl = table.Column<string>(nullable: true),
                    August = table.Column<string>(nullable: true),
                    September = table.Column<string>(nullable: true),
                    Október = table.Column<string>(nullable: true),
                    November = table.Column<string>(nullable: true),
                    December = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamestnanec", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamestnanec");
        }
    }
}
