using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    /// <inheritdoc />
    public partial class addPrpertiesToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RecipeDescription",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RecipeDescription",
                table: "Posts");

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
        }
    }
}
