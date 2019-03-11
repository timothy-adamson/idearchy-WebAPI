using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeasAPI.Migrations
{
    public partial class RemoveRowID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowID",
                table: "Ideas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RowID",
                table: "Ideas",
                nullable: false,
                defaultValue: 0);
        }
    }
}
