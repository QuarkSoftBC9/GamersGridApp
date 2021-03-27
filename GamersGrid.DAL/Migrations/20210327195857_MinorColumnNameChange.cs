using Microsoft.EntityFrameworkCore.Migrations;

namespace GamersGrid.DAL.Migrations
{
    public partial class MinorColumnNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersGamesRelations_VideoGames_GameID",
                table: "UsersGamesRelations");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "UsersGamesRelations",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersGamesRelations_UserId_GameID",
                table: "UsersGamesRelations",
                newName: "IX_UsersGamesRelations_UserId_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersGamesRelations_GameID",
                table: "UsersGamesRelations",
                newName: "IX_UsersGamesRelations_GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGamesRelations_VideoGames_GameId",
                table: "UsersGamesRelations",
                column: "GameId",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersGamesRelations_VideoGames_GameId",
                table: "UsersGamesRelations");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "UsersGamesRelations",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_UsersGamesRelations_UserId_GameId",
                table: "UsersGamesRelations",
                newName: "IX_UsersGamesRelations_UserId_GameID");

            migrationBuilder.RenameIndex(
                name: "IX_UsersGamesRelations_GameId",
                table: "UsersGamesRelations",
                newName: "IX_UsersGamesRelations_GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGamesRelations_VideoGames_GameID",
                table: "UsersGamesRelations",
                column: "GameID",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
