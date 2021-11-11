using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class AdvertisementsImprovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                schema: "Advertisement",
                table: "Advertisement",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_OwnerId",
                schema: "Advertisement",
                table: "Advertisement",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_User_OwnerId",
                schema: "Advertisement",
                table: "Advertisement",
                column: "OwnerId",
                principalSchema: "Access",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_User_OwnerId",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_OwnerId",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "Advertisement",
                table: "Advertisement");
        }
    }
}
