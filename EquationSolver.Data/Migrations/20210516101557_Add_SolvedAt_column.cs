using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EquationSolver.Data.Migrations
{
    public partial class Add_SolvedAt_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SolvedAt",
                table: "EquationData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SolvedAt",
                table: "EquationData");
        }
    }
}
