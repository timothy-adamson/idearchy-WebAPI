using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IdeasAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    TreeID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    IdeasIDs = table.Column<List<int>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.TreeID);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    IdeaID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ParentID = table.Column<int>(nullable: true),
                    TreeID = table.Column<int>(nullable: false),
                    IsConundrum = table.Column<bool>(nullable: false),
                    IdeaText = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FromCountry = table.Column<string>(nullable: true),
                    Colour = table.Column<int>(nullable: true),
                    IdeasIDs = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.IdeaID);
                    table.ForeignKey(
                        name: "FK_Ideas_Trees_IdeasIDs",
                        column: x => x.IdeasIDs,
                        principalTable: "Trees",
                        principalColumn: "TreeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ideas_Ideas_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Ideas",
                        principalColumn: "IdeaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ideas_Trees_TreeID",
                        column: x => x.TreeID,
                        principalTable: "Trees",
                        principalColumn: "TreeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_IdeasIDs",
                table: "Ideas",
                column: "IdeasIDs");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ParentID",
                table: "Ideas",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_TreeID",
                table: "Ideas",
                column: "TreeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "Trees");
        }
    }
}
