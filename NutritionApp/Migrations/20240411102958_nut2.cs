using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionApp.Migrations
{
    public partial class nut2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItemSets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItemSets",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    FoodSetId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemSets", x => new { x.FoodItemId, x.FoodSetId });
                });
        }
    }
}
