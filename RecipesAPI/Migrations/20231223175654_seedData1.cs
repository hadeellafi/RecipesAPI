using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipesAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "51a74b14-a2ce-438b-8c8a-c0fbb779ef4a", null, "user1@gmail.com", false, "User One", false, null, null, null, null, null, false, "pic1.jpg", "d00692e8-c949-45de-b373-dc5355766a75", false, "User1" },
                    { "2", 0, "9acaf8d5-0eae-448a-9714-68dea1ac2a11", null, "user2@gmail.com", false, "User Two", false, null, null, null, null, null, false, "pic2.jpg", "31b31813-2f3d-4f04-9a20-63bce792940f", false, "User2" },
                    { "3", 0, "818bcea9-f060-4c91-a3c3-d7a1e2568b43", null, "user3@gmail.com", false, "User Three", false, null, null, null, null, null, false, "pic3.jpg", "21d9b9bf-3abe-4b9e-8fac-267a49be688c", false, "User3" }
                });

            migrationBuilder.InsertData(
                table: "Follows",
                columns: new[] { "FollowerID", "UserID" },
                values: new object[,]
                {
                    { "2", "1" },
                    { "3", "1" },
                    { "3", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Follows",
                keyColumns: new[] { "FollowerID", "UserID" },
                keyValues: new object[] { "2", "1" });

            migrationBuilder.DeleteData(
                table: "Follows",
                keyColumns: new[] { "FollowerID", "UserID" },
                keyValues: new object[] { "3", "1" });

            migrationBuilder.DeleteData(
                table: "Follows",
                keyColumns: new[] { "FollowerID", "UserID" },
                keyValues: new object[] { "3", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}
