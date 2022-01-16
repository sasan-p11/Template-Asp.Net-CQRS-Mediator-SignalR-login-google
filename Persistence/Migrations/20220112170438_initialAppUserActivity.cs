using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initialAppUserActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appUserActivities",
                columns: table => new
                {
                    AppUSerId = table.Column<string>(type: "TEXT", nullable: false),
                    ActiviyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsHost = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appUserActivities", x => new { x.AppUSerId, x.ActiviyId });
                    table.ForeignKey(
                        name: "FK_appUserActivities_activities_ActiviyId",
                        column: x => x.ActiviyId,
                        principalTable: "activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appUserActivities_AspNetUsers_AppUSerId",
                        column: x => x.AppUSerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appUserActivities_ActiviyId",
                table: "appUserActivities",
                column: "ActiviyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appUserActivities");
        }
    }
}
