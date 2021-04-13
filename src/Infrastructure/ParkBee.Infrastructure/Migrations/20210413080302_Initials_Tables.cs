using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkBee.Infrastructure.Migrations
{
    public partial class Initials_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "parkbee");

            migrationBuilder.CreateTable(
                name: "Garage",
                schema: "parkbee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "parkbee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GarageDetails",
                schema: "parkbee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<int>(type: "int", nullable: true),
                    Longitude = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GarageDetails_Garage_GarageId",
                        column: x => x.GarageId,
                        principalSchema: "parkbee",
                        principalTable: "Garage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                schema: "parkbee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoorType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GarageDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doors_GarageDetails_GarageDetailId",
                        column: x => x.GarageDetailId,
                        principalSchema: "parkbee",
                        principalTable: "GarageDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doors_GarageDetailId",
                schema: "parkbee",
                table: "Doors",
                column: "GarageDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_GarageDetails_GarageId",
                schema: "parkbee",
                table: "GarageDetails",
                column: "GarageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doors",
                schema: "parkbee");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "parkbee");

            migrationBuilder.DropTable(
                name: "GarageDetails",
                schema: "parkbee");

            migrationBuilder.DropTable(
                name: "Garage",
                schema: "parkbee");
        }
    }
}
