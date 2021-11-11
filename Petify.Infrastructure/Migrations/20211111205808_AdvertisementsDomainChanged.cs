using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class AdvertisementsDomainChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Pet_PetId",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_PetId",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                schema: "Pet",
                table: "Pet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PetAdvertisement",
                schema: "Advertisement",
                columns: table => new
                {
                    AdvertisementId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAdvertisement", x => new { x.AdvertisementId, x.PetId });
                    table.ForeignKey(
                        name: "FK_PetAdvertisement_Advertisement_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalSchema: "Advertisement",
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetAdvertisement_Pet_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pet",
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_AdvertisementId",
                schema: "Pet",
                table: "Pet",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_PetAdvertisement_PetId",
                schema: "Advertisement",
                table: "PetAdvertisement",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Advertisement_AdvertisementId",
                schema: "Pet",
                table: "Pet",
                column: "AdvertisementId",
                principalSchema: "Advertisement",
                principalTable: "Advertisement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Advertisement_AdvertisementId",
                schema: "Pet",
                table: "Pet");

            migrationBuilder.DropTable(
                name: "PetAdvertisement",
                schema: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Pet_AdvertisementId",
                schema: "Pet",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                schema: "Pet",
                table: "Pet");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_PetId",
                schema: "Advertisement",
                table: "Advertisement",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Pet_PetId",
                schema: "Advertisement",
                table: "Advertisement",
                column: "PetId",
                principalSchema: "Pet",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
