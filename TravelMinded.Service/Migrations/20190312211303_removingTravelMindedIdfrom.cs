using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelMinded.Service.Migrations
{
    public partial class removingTravelMindedIdfrom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelMindedCustomerTypeId",
                table: "CustomerPrototype");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelMindedCustomerTypeId",
                table: "CustomerPrototype",
                nullable: false,
                defaultValue: 0);
        }
    }
}
