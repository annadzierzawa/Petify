using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class PetAdvertisementRelationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AdvertisementPet",
                columns: table => new
                {
                    AdvertisementsId = table.Column<int>(type: "int", nullable: false),
                    PetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementPet", x => new { x.AdvertisementsId, x.PetsId });
                    table.ForeignKey(
                        name: "FK_AdvertisementPet_Advertisement_AdvertisementsId",
                        column: x => x.AdvertisementsId,
                        principalSchema: "Advertisement",
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementPet_Pet_PetsId",
                        column: x => x.PetsId,
                        principalSchema: "Pet",
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementPet_PetsId",
                table: "AdvertisementPet",
                column: "PetsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementPet");

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
    }
}
