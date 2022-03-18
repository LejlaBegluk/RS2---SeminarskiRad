using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsPortal.WebAPI.Migrations
{
    public partial class UpdatedOnField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateOn",
                table: "Articles",
                newName: "UpdatedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Articles",
                newName: "UpdateOn");
        }
    }
}
