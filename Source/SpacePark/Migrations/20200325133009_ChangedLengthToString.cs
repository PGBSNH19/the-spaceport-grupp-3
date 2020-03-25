using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Migrations
{
    public partial class ChangedLengthToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipLength",
                table: "SpaceShips");

            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "SpaceShips",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "SpaceShips");

            migrationBuilder.AddColumn<int>(
                name: "ShipLength",
                table: "SpaceShips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
