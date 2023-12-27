using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    /// <inheritdoc />
    public partial class addJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostIngredient_Ingredients_IngredientID",
                table: "PostIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_PostIngredient_Posts_PostID",
                table: "PostIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostIngredient",
                table: "PostIngredient");

            migrationBuilder.DropColumn(
                name: "StepNumber",
                table: "Steps");

            migrationBuilder.RenameTable(
                name: "PostIngredient",
                newName: "PostIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_PostIngredient_IngredientID",
                table: "PostIngredients",
                newName: "IX_PostIngredients_IngredientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostIngredients",
                table: "PostIngredients",
                columns: new[] { "PostID", "IngredientID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "702c46b1-7de0-4cc9-8fc1-2c3c340244b8", "c9822eb5-bf4c-4077-88a5-3d0a520f4ef1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a6bf9bd3-f9b6-48e3-b5b6-3b3b3b0ded9b", "68373d67-a0ba-44ed-9dce-85fc32dafc1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ea3ab494-31c5-4c60-8f7d-d24c7890c3a7", "0cea98e6-9804-445b-a054-48ff34924510" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostIngredients_Ingredients_IngredientID",
                table: "PostIngredients",
                column: "IngredientID",
                principalTable: "Ingredients",
                principalColumn: "IngredientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostIngredients_Posts_PostID",
                table: "PostIngredients",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostIngredients_Ingredients_IngredientID",
                table: "PostIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_PostIngredients_Posts_PostID",
                table: "PostIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostIngredients",
                table: "PostIngredients");

            migrationBuilder.RenameTable(
                name: "PostIngredients",
                newName: "PostIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_PostIngredients_IngredientID",
                table: "PostIngredient",
                newName: "IX_PostIngredient_IngredientID");

            migrationBuilder.AddColumn<int>(
                name: "StepNumber",
                table: "Steps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostIngredient",
                table: "PostIngredient",
                columns: new[] { "PostID", "IngredientID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d2404d23-0e89-4707-9aa6-fbbc3011fc46", "353ae7d5-bed9-40b2-a581-260a88a26e11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d603cb8f-37f0-4014-8efa-7be025e8b902", "1d714664-944e-409f-83d1-6c7d9d311704" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ca5fcd9-9ca7-4625-95b3-5c7e2c8a1ad4", "a792bc95-3d67-442e-a586-5165d42762e1" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostIngredient_Ingredients_IngredientID",
                table: "PostIngredient",
                column: "IngredientID",
                principalTable: "Ingredients",
                principalColumn: "IngredientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostIngredient_Posts_PostID",
                table: "PostIngredient",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
