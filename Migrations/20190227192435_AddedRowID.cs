using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeasAPI.Migrations
{
    public partial class AddedRowID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RowID",
                table: "Ideas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowID",
                table: "Ideas");
        }
    }
}
