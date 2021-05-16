using Microsoft.EntityFrameworkCore.Migrations;

namespace EquationSolver.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquationData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoefficientA = table.Column<double>(type: "float", nullable: false),
                    CoefficientB = table.Column<double>(type: "float", nullable: false),
                    CoefficientC = table.Column<double>(type: "float", nullable: false),
                    Discriminant = table.Column<double>(type: "float", nullable: false),
                    FirstRoot = table.Column<double>(type: "float", nullable: true),
                    SecondRoot = table.Column<double>(type: "float", nullable: true),
                    IsValidEquation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquationData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquationData");
        }
    }
}
