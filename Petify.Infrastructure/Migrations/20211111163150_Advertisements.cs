using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class Advertisements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_User_UserId",
                schema: "Pet",
                table: "Pet");

            migrationBuilder.EnsureSchema(
                name: "Advertisement");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Pet",
                table: "Pet",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_UserId",
                schema: "Pet",
                table: "Pet",
                newName: "IX_Pet_OwnerId");

            migrationBuilder.CreateTable(
                name: "AdvertisementType",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                schema: "Advertisement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertisementTypeId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    Dates_StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dates_EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisement_AdvertisementType_AdvertisementTypeId",
                        column: x => x.AdvertisementTypeId,
                        principalSchema: "Lookup",
                        principalTable: "AdvertisementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisement_Pet_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pet",
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CyclicalAssistanceDay",
                schema: "Advertisement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyclicalAssistanceDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CyclicalAssistanceDay_Advertisement_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalSchema: "Advertisement",
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "AdvertisementType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adoption" },
                    { 2, "CyclicalAssistance" },
                    { 3, "OneTimeHelp" },
                    { 4, "TemporaryAdoption" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_AdvertisementTypeId",
                schema: "Advertisement",
                table: "Advertisement",
                column: "AdvertisementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_PetId",
                schema: "Advertisement",
                table: "Advertisement",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_CyclicalAssistanceDay_AdvertisementId",
                schema: "Advertisement",
                table: "CyclicalAssistanceDay",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_User_OwnerId",
                schema: "Pet",
                table: "Pet",
                column: "OwnerId",
                principalSchema: "Access",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_User_OwnerId",
                schema: "Pet",
                table: "Pet");

            migrationBuilder.DropTable(
                name: "CyclicalAssistanceDay",
                schema: "Advertisement");

            migrationBuilder.DropTable(
                name: "Advertisement",
                schema: "Advertisement");

            migrationBuilder.DropTable(
                name: "AdvertisementType",
                schema: "Lookup");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                schema: "Pet",
                table: "Pet",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_OwnerId",
                schema: "Pet",
                table: "Pet",
                newName: "IX_Pet_UserId");

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
    }
}
