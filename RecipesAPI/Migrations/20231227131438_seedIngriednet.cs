using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipesAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedIngriednet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "47c90eb6-1184-4946-b235-3587b84b0f72", "5b8c1d6e-9ae3-4f72-b1fc-190a17f72286" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "130b87a5-95cd-49aa-b0a8-9eefda5ced78", "2f464fb9-6b98-4d93-a36d-1721c1fcef01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3675ed37-443a-4f8c-80d1-1af2e613be82", "39cb606d-9cc8-4603-b31f-12fbec34c72f" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientID", "IngredientName" },
                values: new object[,]
                {
                    { 1, "Beef " },
                    { 2, "Chicken " },
                    { 3, "Cherry Tomatoes " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f5aca6c0-4319-4447-a831-915acfaaa22d", "a059cbaa-d2e7-4777-9657-5b9fdae0bf40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c73f89c9-06c6-47ad-b41a-e35a6b868124", "26f6555a-4902-4e6f-8734-fd985b286a24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9e2d46a5-d3b6-4ea3-8e32-2a9174543321", "7fa5e5aa-3595-4970-88c5-4948d5f3d22e" });
        }
    }
}
