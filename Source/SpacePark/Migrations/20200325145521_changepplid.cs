using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Migrations
{
    public partial class changepplid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_SpaceShips_SpaceShipID",
                table: "ParkingLots");

            migrationBuilder.DropForeignKey(
                name: "FK_People_SpaceShips_CurrentShipSpaceShipID",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CurrentShipSpaceShipID",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingLots",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "CurrentShipSpaceShipID",
                table: "People");

            migrationBuilder.RenameTable(
                name: "ParkingLots",
                newName: "ParkingLot");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingLots_SpaceShipID",
                table: "ParkingLot",
                newName: "IX_ParkingLot_SpaceShipID");

            migrationBuilder.AddColumn<int>(
                name: "SpaceShipID",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingLot",
                table: "ParkingLot",
                column: "ParkingLotID");

            migrationBuilder.CreateIndex(
                name: "IX_People_SpaceShipID",
                table: "People",
                column: "SpaceShipID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLot_SpaceShips_SpaceShipID",
                table: "ParkingLot",
                column: "SpaceShipID",
                principalTable: "SpaceShips",
                principalColumn: "SpaceShipID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_SpaceShips_SpaceShipID",
                table: "People",
                column: "SpaceShipID",
                principalTable: "SpaceShips",
                principalColumn: "SpaceShipID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLot_SpaceShips_SpaceShipID",
                table: "ParkingLot");

            migrationBuilder.DropForeignKey(
                name: "FK_People_SpaceShips_SpaceShipID",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_SpaceShipID",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingLot",
                table: "ParkingLot");

            migrationBuilder.DropColumn(
                name: "SpaceShipID",
                table: "People");

            migrationBuilder.RenameTable(
                name: "ParkingLot",
                newName: "ParkingLots");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingLot_SpaceShipID",
                table: "ParkingLots",
                newName: "IX_ParkingLots_SpaceShipID");

            migrationBuilder.AddColumn<int>(
                name: "CurrentShipSpaceShipID",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingLots",
                table: "ParkingLots",
                column: "ParkingLotID");

            migrationBuilder.CreateIndex(
                name: "IX_People_CurrentShipSpaceShipID",
                table: "People",
                column: "CurrentShipSpaceShipID");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_SpaceShips_SpaceShipID",
                table: "ParkingLots",
                column: "SpaceShipID",
                principalTable: "SpaceShips",
                principalColumn: "SpaceShipID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_SpaceShips_CurrentShipSpaceShipID",
                table: "People",
                column: "CurrentShipSpaceShipID",
                principalTable: "SpaceShips",
                principalColumn: "SpaceShipID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
