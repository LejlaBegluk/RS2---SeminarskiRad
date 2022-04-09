using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsPortal.WebAPI.Migrations
{
    public partial class UserPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Users",
                newName: "PhotoThumb");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoThumb",
                table: "Articles",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhotoThumb",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "PhotoThumb",
                table: "Users",
                newName: "Image");
        }
    }
}
