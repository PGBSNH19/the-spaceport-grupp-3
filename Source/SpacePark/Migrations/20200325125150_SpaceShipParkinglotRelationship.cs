using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Migrations
{
    public partial class SpaceShipParkinglotRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpaceShipId",
                table: "ParkingLots",
                newName: "SpaceShipID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_SpaceShipID",
                table: "ParkingLots",
                column: "SpaceShipID");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_SpaceShips_SpaceShipID",
                table: "ParkingLots",
                column: "SpaceShipID",
                principalTable: "SpaceShips",
                principalColumn: "SpaceShipID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_SpaceShips_SpaceShipID",
                table: "ParkingLots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_SpaceShipID",
                table: "ParkingLots");

            migrationBuilder.RenameColumn(
                name: "SpaceShipID",
                table: "ParkingLots",
                newName: "SpaceShipId");
        }
    }
}
