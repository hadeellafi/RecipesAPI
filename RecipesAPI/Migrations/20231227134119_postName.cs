using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    /// <inheritdoc />
    public partial class postName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "Name");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Posts",
                newName: "Title");

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
        }
    }
}
