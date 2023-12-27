using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    /// <inheritdoc />
    public partial class addNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Posts_PostID",
                table: "Steps");

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "Steps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "90b68383-f555-4340-9121-566aabe74914", "fc8d1dc3-d7a0-4077-8879-8226973ee9d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "825767ed-fbe3-4b13-b6cc-7a9bb7d014cf", "a7e3d126-132d-4c0f-924c-fc70603ea378" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "57933ef9-3c35-4c6a-8d17-f230c78291a6", "dee752e4-229a-44d3-8278-9e5404cccc64" });

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Posts_PostID",
                table: "Steps",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Posts_PostID",
                table: "Steps");

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "Steps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_Steps_Posts_PostID",
                table: "Steps",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
