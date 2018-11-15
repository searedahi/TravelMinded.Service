using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelMinded.Service.Migrations
{
    public partial class Availabilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pk = table.Column<int>(nullable: false),
                    StartAt = table.Column<string>(nullable: true),
                    EndAt = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    ExperienceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pk = table.Column<int>(nullable: false),
                    singular = table.Column<string>(nullable: true),
                    plural = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypeRate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pk = table.Column<int>(nullable: false),
                    total = table.Column<int>(nullable: false),
                    capacity = table.Column<int>(nullable: false),
                    customer_prototypeId = table.Column<int>(nullable: true),
                    customer_typeId = table.Column<int>(nullable: true),
                    AvailabilityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypeRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerTypeRate_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTypeRate_CustomerPrototype_customer_prototypeId",
                        column: x => x.customer_prototypeId,
                        principalTable: "CustomerPrototype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTypeRate_CustomerType_customer_typeId",
                        column: x => x.customer_typeId,
                        principalTable: "CustomerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_ExperienceId",
                table: "Availabilities",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypeRate_AvailabilityId",
                table: "CustomerTypeRate",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypeRate_customer_prototypeId",
                table: "CustomerTypeRate",
                column: "customer_prototypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypeRate_customer_typeId",
                table: "CustomerTypeRate",
                column: "customer_typeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTypeRate");

            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "CustomerType");
        }
    }
}
