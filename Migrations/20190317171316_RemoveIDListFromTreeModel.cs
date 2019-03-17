using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeasAPI.Migrations
{
    public partial class RemoveIDListFromTreeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Trees_IdeasIDs",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_IdeasIDs",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "IdeasIDs",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "IdeasIDs",
                table: "Ideas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "IdeasIDs",
                table: "Trees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdeasIDs",
                table: "Ideas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_IdeasIDs",
                table: "Ideas",
                column: "IdeasIDs");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Trees_IdeasIDs",
                table: "Ideas",
                column: "IdeasIDs",
                principalTable: "Trees",
                principalColumn: "TreeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
