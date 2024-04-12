using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionApp.Migrations
{
    public partial class nut3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItemSet_JOIN",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    FoodSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemSet_JOIN", x => new { x.FoodItemId, x.FoodSetId });
                    table.ForeignKey(
                        name: "FK_FoodItemSet_JOIN_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodItemSet_JOIN_FoodSets_FoodSetId",
                        column: x => x.FoodSetId,
                        principalTable: "FoodSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemSet_JOIN_FoodSetId",
                table: "FoodItemSet_JOIN",
                column: "FoodSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItemSet_JOIN");
        }
    }
}
