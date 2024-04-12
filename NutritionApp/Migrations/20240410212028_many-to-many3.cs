using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionApp.Migrations
{
    public partial class manytomany3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "FoodItemSets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "FoodItemSets");
        }
    }
}
