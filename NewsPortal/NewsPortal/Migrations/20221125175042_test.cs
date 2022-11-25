using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPortal.WebAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                 table: "Categories",
                 columns: new[] { "Id", "Active", "CreateOn", "Name", "UpdatedOn" },
                 values: new object[,]
                 {
                    { 1, true, new DateTime(2022, 11, 25, 18, 50, 42, 7, DateTimeKind.Local).AddTicks(7805), "News", null },
                    { 2, true, new DateTime(2022, 11, 25, 18, 50, 42, 10, DateTimeKind.Local).AddTicks(7916), "Sport", null },
                    { 3, true, new DateTime(2022, 11, 25, 18, 50, 42, 10, DateTimeKind.Local).AddTicks(7942), "Buisness", null },
                    { 4, true, new DateTime(2022, 11, 25, 18, 50, 42, 10, DateTimeKind.Local).AddTicks(7945), "Sponsored", null }
                 });

            migrationBuilder.InsertData(
                table: "PaidArticleStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Approved" },
                    { 3, "Declined" },
                    { 4, "Paid" },
                    { 5, "Published" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Admin" },
                    { 2, null, "Editor" },
                    { 3, null, "Journalist" },
                    { 4, null, "Registerd" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            


            migrationBuilder.DeleteData(
               table: "Categories",
               keyColumn: "Id",
               keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaidArticleStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaidArticleStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaidArticleStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaidArticleStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaidArticleStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
