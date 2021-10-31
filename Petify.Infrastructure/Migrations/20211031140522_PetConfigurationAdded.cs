using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class PetConfigurationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_User_UserId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.EnsureSchema(
                name: "Pet");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet",
                newSchema: "Pet");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_UserId",
                schema: "Pet",
                table: "Pet",
                newName: "IX_Pet_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Pet",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Pet",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                schema: "Pet",
                table: "Pet",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_User_UserId",
                schema: "Pet",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                schema: "Pet",
                table: "Pet");

            migrationBuilder.RenameTable(
                name: "Pet",
                schema: "Pet",
                newName: "Pets");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_UserId",
                table: "Pets",
                newName: "IX_Pets_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_User_UserId",
                table: "Pets",
                column: "UserId",
                principalSchema: "Access",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
