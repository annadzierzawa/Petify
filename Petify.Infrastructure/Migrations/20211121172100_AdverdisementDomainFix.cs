using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class AdverdisementDomainFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetId",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.AddColumn<int>(
                name: "CyclicalAssistanceFrequency",
                schema: "Advertisement",
                table: "Advertisement",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CyclicalAssistanceFrequency",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                schema: "Advertisement",
                table: "Advertisement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
