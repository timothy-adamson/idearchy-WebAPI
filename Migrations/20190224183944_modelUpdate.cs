using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IdeasAPI.Migrations
{
    public partial class modelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeCreated",
                table: "Ideas",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<string>(
                name: "IdeaText",
                table: "Ideas",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdeaID",
                table: "Ideas",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "Colour",
                table: "Ideas",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConundrum",
                table: "Ideas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Ideas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ParentID",
                table: "Ideas",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Ideas_ParentID",
                table: "Ideas",
                column: "ParentID",
                principalTable: "Ideas",
                principalColumn: "IdeaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Ideas_ParentID",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_ParentID",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "IsConundrum",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Ideas");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Ideas",
                newName: "TimeCreated");

            migrationBuilder.AlterColumn<string>(
                name: "IdeaText",
                table: "Ideas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IdeaID",
                table: "Ideas",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
