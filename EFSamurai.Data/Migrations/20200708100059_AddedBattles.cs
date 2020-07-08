using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSamurai.Data.Migrations
{
    public partial class AddedBattles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleLogs_Battle_BattleID",
                table: "BattleLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattles_Battle_BattleID",
                table: "SamuraiBattles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battle",
                table: "Battle");

            migrationBuilder.RenameTable(
                name: "Battle",
                newName: "Battles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleLogs_Battles_BattleID",
                table: "BattleLogs",
                column: "BattleID",
                principalTable: "Battles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattles_Battles_BattleID",
                table: "SamuraiBattles",
                column: "BattleID",
                principalTable: "Battles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleLogs_Battles_BattleID",
                table: "BattleLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattles_Battles_BattleID",
                table: "SamuraiBattles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.RenameTable(
                name: "Battles",
                newName: "Battle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battle",
                table: "Battle",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleLogs_Battle_BattleID",
                table: "BattleLogs",
                column: "BattleID",
                principalTable: "Battle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattles_Battle_BattleID",
                table: "SamuraiBattles",
                column: "BattleID",
                principalTable: "Battle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
