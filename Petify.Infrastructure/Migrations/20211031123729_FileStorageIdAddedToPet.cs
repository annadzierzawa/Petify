using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class FileStorageIdAddedToPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileStorageId",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileStorageId",
                table: "Pets");
        }
    }
}
