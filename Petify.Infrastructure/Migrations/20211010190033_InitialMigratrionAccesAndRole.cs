using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petify.Infrastructure.Migrations
{
    public partial class InitialMigratrionAccesAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Access");

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "Access",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Access",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Access",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleAction",
                schema: "Access",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAction", x => new { x.RoleId, x.ActionId });
                    table.ForeignKey(
                        name: "FK_RoleAction_Action_ActionId",
                        column: x => x.ActionId,
                        principalSchema: "Access",
                        principalTable: "Action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAction_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Access",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAction",
                schema: "Access",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAction", x => new { x.UserId, x.ActionId });
                    table.ForeignKey(
                        name: "FK_UserAction_Action_ActionId",
                        column: x => x.ActionId,
                        principalSchema: "Access",
                        principalTable: "Action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAction_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Access",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Access",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Access",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Access",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Access",
                table: "Action",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Announcements" },
                    { 2, "Reviews" },
                    { 3, "ManageUsers" }
                });

            migrationBuilder.InsertData(
                schema: "Access",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "RegularUser" }
                });

            migrationBuilder.InsertData(
                schema: "Access",
                table: "RoleAction",
                columns: new[] { "ActionId", "RoleId", "Level" },
                values: new object[] { 3, 1, "F" });

            migrationBuilder.InsertData(
                schema: "Access",
                table: "RoleAction",
                columns: new[] { "ActionId", "RoleId", "Level" },
                values: new object[] { 1, 2, "F" });

            migrationBuilder.InsertData(
                schema: "Access",
                table: "RoleAction",
                columns: new[] { "ActionId", "RoleId", "Level" },
                values: new object[] { 2, 2, "F" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAction_ActionId",
                schema: "Access",
                table: "RoleAction",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAction_ActionId",
                schema: "Access",
                table: "UserAction",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "Access",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAction",
                schema: "Access");

            migrationBuilder.DropTable(
                name: "UserAction",
                schema: "Access");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Access");

            migrationBuilder.DropTable(
                name: "Action",
                schema: "Access");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Access");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Access");
        }
    }
}
