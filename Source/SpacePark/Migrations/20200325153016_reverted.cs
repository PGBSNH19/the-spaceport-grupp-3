using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Migrations
{
    public partial class reverted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_SpaceShips_SpaceShipID",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_SpaceShipID",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "SpaceShipID",
                table: "People",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_SpaceShipID",
                table: "People",
                column: "SpaceShipID",
                unique: true);

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
                name: "FK_People_SpaceShips_SpaceShipID",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_SpaceShipID",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "SpaceShipID",
                table: "People",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_People_SpaceShipID",
                table: "People",
                column: "SpaceShipID",
                unique: true,
                filter: "[SpaceShipID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_People_SpaceShips_SpaceShipID",
                table: "People",
                column: "SpaceShipID",
                principalTable: "SpaceShips",
                principalColumn: "SpaceShipID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
