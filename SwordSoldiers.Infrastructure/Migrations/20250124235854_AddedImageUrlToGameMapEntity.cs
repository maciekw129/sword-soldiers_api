using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwordSoldiers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageUrlToGameMapEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "GameMaps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "GameMaps");
        }
    }
}
