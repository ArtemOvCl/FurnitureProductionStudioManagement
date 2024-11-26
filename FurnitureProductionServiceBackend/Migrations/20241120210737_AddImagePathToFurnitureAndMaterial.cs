using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureProductionServiceBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathToFurnitureAndMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Furnitures",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Furnitures");
        }
    }
}
