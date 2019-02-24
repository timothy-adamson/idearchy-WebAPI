using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeasAPI.Migrations
{
    public partial class nullableParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Ideas_ParentID",
                table: "Ideas");

            migrationBuilder.AlterColumn<int>(
                name: "ParentID",
                table: "Ideas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Ideas_ParentID",
                table: "Ideas",
                column: "ParentID",
                principalTable: "Ideas",
                principalColumn: "IdeaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Ideas_ParentID",
                table: "Ideas");

            migrationBuilder.AlterColumn<int>(
                name: "ParentID",
                table: "Ideas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Ideas_ParentID",
                table: "Ideas",
                column: "ParentID",
                principalTable: "Ideas",
                principalColumn: "IdeaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
