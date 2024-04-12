using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionApp.Migrations
{
    public partial class t5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodCollectionItem");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "FoodCollection");

            migrationBuilder.DropTable(
                name: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodCollectionItem",
                columns: table => new
                {
                    CollectionsId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCollectionItem", x => new { x.CollectionsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_FoodCollectionItem_FoodCollection_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "FoodCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodCollectionItem_Item_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_FoodCollectionItem_ItemsId",
                table: "FoodCollectionItem",
                column: "ItemsId");
        }
    }
}
