using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPortal.WebAPI.Migrations
{
    public partial class dataseedPoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "Polls",
             columns: new[] { "Id", "Active", "CreateOn", "Question", "UpdateOn", "UserId" },
             values: new object[] { 1, true, new DateTime(2022, 11, 25, 19, 14, 47, 81, DateTimeKind.Local).AddTicks(6474), "Da li vam se sviđa ova aplikacija?", null, 1 });

            migrationBuilder.InsertData(
                table: "Polls",
                columns: new[] { "Id", "Active", "CreateOn", "Question", "UpdateOn", "UserId" },
                values: new object[] { 2, true, new DateTime(2022, 11, 25, 19, 14, 47, 84, DateTimeKind.Local).AddTicks(3862), "Da li želite popuste na naše reklame?", null, 1 });

            migrationBuilder.InsertData(
                table: "Polls",
                columns: new[] { "Id", "Active", "CreateOn", "Question", "UpdateOn", "UserId" },
                values: new object[] { 3, true, new DateTime(2022, 11, 25, 19, 14, 47, 84, DateTimeKind.Local).AddTicks(3892), "Da li biste otišli iz BIH?", null, 1 });

            migrationBuilder.InsertData(
                table: "PollAnswer",
                columns: new[] { "Id", "Counter", "PollId", "Text" },
                values: new object[,]
                {
                    { 1, 42, 1, "Da" },
                    { 2, 15, 1, "Ne" },
                    { 3, 30, 2, "Da" },
                    { 4, 15, 2, "Ne" },
                    { 5, 36, 3, "Da" },
                    { 6, 22, 3, "Ne" },
                    { 7, 12, 3, "Možda" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.DeleteData(
                table: "PollAnswer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PollAnswer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PollAnswer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PollAnswer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PollAnswer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PollAnswer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PollAnswer",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
