using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionApp.Migrations
{
    public partial class manytomany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodSet",
                table: "FoodSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemSet",
                table: "FoodItemSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItem",
                table: "FoodItem");

            migrationBuilder.RenameTable(
                name: "FoodSet",
                newName: "FoodSets");

            migrationBuilder.RenameTable(
                name: "FoodItemSet",
                newName: "FoodItemSets");

            migrationBuilder.RenameTable(
                name: "FoodItem",
                newName: "FoodItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodSets",
                table: "FoodSets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemSets",
                table: "FoodItemSets",
                columns: new[] { "FoodItemId", "FoodSetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItems",
                table: "FoodItems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodSets",
                table: "FoodSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemSets",
                table: "FoodItemSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItems",
                table: "FoodItems");

            migrationBuilder.RenameTable(
                name: "FoodSets",
                newName: "FoodSet");

            migrationBuilder.RenameTable(
                name: "FoodItemSets",
                newName: "FoodItemSet");

            migrationBuilder.RenameTable(
                name: "FoodItems",
                newName: "FoodItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodSet",
                table: "FoodSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemSet",
                table: "FoodItemSet",
                columns: new[] { "FoodItemId", "FoodSetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItem",
                table: "FoodItem",
                column: "Id");
        }
    }
}
