using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelMinded.Service.Migrations
{
    public partial class taxPctAddToExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercentage",
                table: "Experiences",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "Experiences");
        }
    }
}
