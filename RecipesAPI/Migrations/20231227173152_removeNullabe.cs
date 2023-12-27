using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesAPI.Migrations
{
    /// <inheritdoc />
    public partial class removeNullabe : Migration
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
                values: new object[] { "55f9d076-0cb5-4c48-9fc7-33294f69e340", "2046ce85-cb20-46a3-99a7-2f339a68aa93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "91cfc474-0582-4103-aea2-3fe75140190c", "5b7eb704-848d-44a6-ad72-7a9b6d5b7097" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1fe1466e-62fd-44f3-9c5b-8036617081a6", "89825a71-9afb-45a4-93ff-81e21054ff74" });

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Posts_PostID",
                table: "Steps",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
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
    }
}
