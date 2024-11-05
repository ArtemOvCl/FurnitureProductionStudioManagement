using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureProductionServiceBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsInFurnituree_Furnitures_FurnituresId",
                table: "MaterialsInFurnituree");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsInFurnituree_Materials_MaterialsId",
                table: "MaterialsInFurnituree");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialsInFurnituree",
                table: "MaterialsInFurnituree");

            migrationBuilder.RenameTable(
                name: "MaterialsInFurnituree",
                newName: "MaterialsInFurniture");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialsInFurnituree_MaterialsId",
                table: "MaterialsInFurniture",
                newName: "IX_MaterialsInFurniture_MaterialsId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialsInFurniture",
                table: "MaterialsInFurniture",
                columns: new[] { "FurnituresId", "MaterialsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsInFurniture_Furnitures_FurnituresId",
                table: "MaterialsInFurniture",
                column: "FurnituresId",
                principalTable: "Furnitures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsInFurniture_Materials_MaterialsId",
                table: "MaterialsInFurniture",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsInFurniture_Furnitures_FurnituresId",
                table: "MaterialsInFurniture");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsInFurniture_Materials_MaterialsId",
                table: "MaterialsInFurniture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialsInFurniture",
                table: "MaterialsInFurniture");

            migrationBuilder.RenameTable(
                name: "MaterialsInFurniture",
                newName: "MaterialsInFurnituree");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialsInFurniture_MaterialsId",
                table: "MaterialsInFurnituree",
                newName: "IX_MaterialsInFurnituree_MaterialsId");

            migrationBuilder.AlterColumn<int>(
                name: "Password",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialsInFurnituree",
                table: "MaterialsInFurnituree",
                columns: new[] { "FurnituresId", "MaterialsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsInFurnituree_Furnitures_FurnituresId",
                table: "MaterialsInFurnituree",
                column: "FurnituresId",
                principalTable: "Furnitures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsInFurnituree_Materials_MaterialsId",
                table: "MaterialsInFurnituree",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
