using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionApp.Migrations
{
    public partial class nut4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemSet_JOIN_FoodItems_FoodItemId",
                table: "FoodItemSet_JOIN");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItems",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FoodItems");

            migrationBuilder.RenameColumn(
                name: "FdId",
                table: "FoodItems",
                newName: "fdcId");

            migrationBuilder.AlterColumn<int>(
                name: "fdcId",
                table: "FoodItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItems",
                table: "FoodItems",
                column: "fdcId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemSet_JOIN_FoodItems_FoodItemId",
                table: "FoodItemSet_JOIN",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "fdcId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemSet_JOIN_FoodItems_FoodItemId",
                table: "FoodItemSet_JOIN");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItems",
                table: "FoodItems");

            migrationBuilder.RenameColumn(
                name: "fdcId",
                table: "FoodItems",
                newName: "FdId");

            migrationBuilder.AlterColumn<int>(
                name: "FdId",
                table: "FoodItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FoodItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItems",
                table: "FoodItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemSet_JOIN_FoodItems_FoodItemId",
                table: "FoodItemSet_JOIN",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
