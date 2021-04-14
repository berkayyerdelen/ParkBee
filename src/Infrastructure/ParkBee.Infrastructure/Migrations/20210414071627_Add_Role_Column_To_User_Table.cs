using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkBee.Infrastructure.Migrations
{
    public partial class Add_Role_Column_To_User_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "parkbee",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                schema: "parkbee",
                table: "Users");
        }
    }
}
