using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelMinded.Service.Migrations
{
    public partial class broughtInMoreExperienceMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "AddressInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pk = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    Headline = table.Column<string>(nullable: true),
                    DescriptionSafeHtml = table.Column<string>(nullable: true),
                    DescriptionText = table.Column<string>(nullable: true),
                    CancellationPolicy = table.Column<string>(nullable: true),
                    CancellationPolicySafeHtml = table.Column<string>(nullable: true),
                    ImageCdnUrl = table.Column<string>(nullable: true),
                    IsPickupEverOffered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPrototype",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pk = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false),
                    TravelMindedCustomerTypeId = table.Column<int>(nullable: false),
                    ExperienceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPrototype", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPrototype_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pk = table.Column<int>(nullable: false),
                    Gallery = table.Column<string>(nullable: true),
                    ImageCdnUrl = table.Column<string>(nullable: true),
                    ExperienceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageInfo_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pk = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    NoteSafeHtml = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    GooglePlaceId = table.Column<string>(nullable: true),
                    TripadvisorUrl = table.Column<string>(nullable: true),
                    ExperienceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationInfo_AddressInfo_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationInfo_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPrototype_ExperienceId",
                table: "CustomerPrototype",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CompanyId",
                table: "Experiences",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfo_ExperienceId",
                table: "ImageInfo",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationInfo_AddressId",
                table: "LocationInfo",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationInfo_ExperienceId",
                table: "LocationInfo",
                column: "ExperienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPrototype");

            migrationBuilder.DropTable(
                name: "ImageInfo");

            migrationBuilder.DropTable(
                name: "LocationInfo");

            migrationBuilder.DropTable(
                name: "AddressInfo");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId1",
                table: "Products",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId1",
                table: "Products",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
