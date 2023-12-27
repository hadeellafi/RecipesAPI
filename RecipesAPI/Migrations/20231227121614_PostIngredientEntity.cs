using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    /// <inheritdoc />
    public partial class PostIngredientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Posts_PostID",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_PostID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");

            migrationBuilder.CreateTable(
                name: "PostIngredient",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostIngredient", x => new { x.PostID, x.IngredientID });
                    table.ForeignKey(
                        name: "FK_PostIngredient_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostIngredient_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "416bc397-d287-4de7-ae6e-62b84a2647fc", "253be565-7f55-41bf-b5fe-46888e5bfd2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9d81ecf1-5403-4aa7-bdb8-525bc35061c1", "bfa5ad31-1244-4549-9e4f-e30688171243" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "43889759-2e07-4195-bc77-09051e5781fe", "d88c8f41-82e8-4c1d-a749-7c0b246a846f" });

            migrationBuilder.CreateIndex(
                name: "IX_PostIngredient_IngredientID",
                table: "PostIngredient",
                column: "IngredientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostIngredient");

            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "51a74b14-a2ce-438b-8c8a-c0fbb779ef4a", "d00692e8-c949-45de-b373-dc5355766a75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9acaf8d5-0eae-448a-9714-68dea1ac2a11", "31b31813-2f3d-4f04-9a20-63bce792940f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "818bcea9-f060-4c91-a3c3-d7a1e2568b43", "21d9b9bf-3abe-4b9e-8fac-267a49be688c" });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_PostID",
                table: "Ingredients",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Posts_PostID",
                table: "Ingredients",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
