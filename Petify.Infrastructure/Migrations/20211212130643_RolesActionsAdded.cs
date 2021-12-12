using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class RolesActionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                schema: "Advertisement",
                table: "Advertisement",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Access",
                table: "Action",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "ManageMyAdvertisements");

            migrationBuilder.UpdateData(
                schema: "Access",
                table: "Action",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ManageMyPets");

            migrationBuilder.InsertData(
                schema: "Access",
                table: "Action",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "ManageUsersAdvertisements" });

            migrationBuilder.InsertData(
                schema: "Access",
                table: "RoleAction",
                columns: new[] { "ActionId", "RoleId", "Level" },
                values: new object[,]
                {
                    { 1, 1, "F" },
                    { 2, 1, "F" }
                });

            migrationBuilder.InsertData(
                schema: "Access",
                table: "RoleAction",
                columns: new[] { "ActionId", "RoleId", "Level" },
                values: new object[] { 4, 1, "F" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Access",
                table: "RoleAction",
                keyColumns: new[] { "ActionId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "Access",
                table: "RoleAction",
                keyColumns: new[] { "ActionId", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                schema: "Access",
                table: "RoleAction",
                keyColumns: new[] { "ActionId", "RoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                schema: "Access",
                table: "Action",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                schema: "Advertisement",
                table: "Advertisement",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                schema: "Access",
                table: "Action",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Announcements");

            migrationBuilder.UpdateData(
                schema: "Access",
                table: "Action",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Reviews");
        }
    }
}
