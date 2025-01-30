using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwordSoldiers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedGameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameMaps_MapId",
                        column: x => x.MapId,
                        principalTable: "GameMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_MapId",
                table: "Games",
                column: "MapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
