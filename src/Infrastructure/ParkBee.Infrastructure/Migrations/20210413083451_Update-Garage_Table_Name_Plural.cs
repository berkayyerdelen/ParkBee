using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkBee.Infrastructure.Migrations
{
    public partial class UpdateGarage_Table_Name_Plural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GarageDetails_Garage_GarageId",
                schema: "parkbee",
                table: "GarageDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Garage",
                schema: "parkbee",
                table: "Garage");

            migrationBuilder.RenameTable(
                name: "Garage",
                schema: "parkbee",
                newName: "Garages",
                newSchema: "parkbee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Garages",
                schema: "parkbee",
                table: "Garages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GarageDetails_Garages_GarageId",
                schema: "parkbee",
                table: "GarageDetails",
                column: "GarageId",
                principalSchema: "parkbee",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GarageDetails_Garages_GarageId",
                schema: "parkbee",
                table: "GarageDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Garages",
                schema: "parkbee",
                table: "Garages");

            migrationBuilder.RenameTable(
                name: "Garages",
                schema: "parkbee",
                newName: "Garage",
                newSchema: "parkbee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Garage",
                schema: "parkbee",
                table: "Garage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GarageDetails_Garage_GarageId",
                schema: "parkbee",
                table: "GarageDetails",
                column: "GarageId",
                principalSchema: "parkbee",
                principalTable: "Garage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
