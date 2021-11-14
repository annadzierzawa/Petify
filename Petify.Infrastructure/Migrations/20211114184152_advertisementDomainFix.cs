using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class advertisementDomainFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dates_StartDate",
                schema: "Advertisement",
                table: "Advertisement",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Dates_EndDate",
                schema: "Advertisement",
                table: "Advertisement",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                schema: "Advertisement",
                table: "Advertisement",
                newName: "Dates_StartDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                schema: "Advertisement",
                table: "Advertisement",
                newName: "Dates_EndDate");
        }
    }
}
