using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionApp.Migrations
{
    public partial class populating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Calories", "Name" },
                values: new object[] { 1, 340, "White Rice 100g" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Calories", "Name" },
                values: new object[] { 2, 357, "Beluga Lentils 100g" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Calories", "Name" },
                values: new object[] { 3, 412, "Soybeans 100g" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
