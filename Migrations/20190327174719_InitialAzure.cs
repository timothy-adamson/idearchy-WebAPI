using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeasAPI.Migrations
{
    public partial class InitialAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    TreeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentID = table.Column<int>(nullable: true),
                    TreeID = table.Column<int>(nullable: false),
                    IsConundrum = table.Column<bool>(nullable: false),
                    IdeaText = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FromCountry = table.Column<string>(nullable: true),
                    Colour = table.Column<int>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.IdeaID);
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
