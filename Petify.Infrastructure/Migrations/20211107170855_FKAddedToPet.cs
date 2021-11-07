using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class FKAddedToPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_User_UserId",
                schema: "Pet",
                table: "Pet");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Pet",
                table: "Pet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_User_UserId",
                schema: "Pet",
                table: "Pet",
                column: "UserId",
                principalSchema: "Access",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_User_UserId",
                schema: "Pet",
                table: "Pet");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Pet",
                table: "Pet",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_User_UserId",
                schema: "Pet",
                table: "Pet",
                column: "UserId",
                principalSchema: "Access",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
