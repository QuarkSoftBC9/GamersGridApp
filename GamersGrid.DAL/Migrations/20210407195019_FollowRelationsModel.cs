using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamersGrid.DAL.Migrations
{
    public partial class FollowRelationsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FollowRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FollowerId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowRelations_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FollowRelations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowRelations_FollowerId",
                table: "FollowRelations",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowRelations_UserId_FollowerId",
                table: "FollowRelations",
                columns: new[] { "UserId", "FollowerId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowRelations");
        }
    }
}
