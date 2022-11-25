using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPortal.WebAPI.Migrations
{
    public partial class dataseedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Users",
               columns: new[] { "Id", "BirthDate", "CreateOn", "EditorId", "Email", "FirstName", "IsActive", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Photo", "PhotoThumb", "RoleId", "Username" },
               values: new object[,]
               {
                    { 1, new DateTime(1995, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 25, 19, 6, 30, 109, DateTimeKind.Local).AddTicks(6307), null, "Admin@example.com", "Admin", true, "Admin", "BiFQziSguLiNQnIgDA8Hh0D9s8s=", "3m7k8dY34r2gvB3S6XAP1Q==", "0632554", null, null, 1, "Admin" },
                    { 2, new DateTime(1995, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 25, 19, 6, 30, 113, DateTimeKind.Local).AddTicks(8730), null, "Editor@example.com", "Editor", true, "Editor", "6tgxI1jRYcir8hlaO81GQOdlzss=", "gQK6WHIQ5AaWZYpd+8h1Ww==", "0632554", null, null, 2, "Editor" },
                    { 3, new DateTime(1995, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 25, 19, 6, 30, 113, DateTimeKind.Local).AddTicks(8845), null, "Journalist@example.com", "Journalist", true, "Journalist", "akhX0Pg61z5FrjdMD9R4C6g/AMo=", "GYOksWp66W7fccw7dmlOzA==", "0632554", null, null, 3, "Journalist" },
                    { 4, new DateTime(1995, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 25, 19, 6, 30, 113, DateTimeKind.Local).AddTicks(8849), null, "Amel@fit.ba", "Amel", true, "Music", "zEgSDPW0BtR1+i78IaKZqDjeFKU=", "YhPmF9Gr6xVDs2W77GYP7w==", "0632554", null, null, 4, "Amel" }
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.DeleteData(
              table: "Users",
              keyColumn: "Id",
              keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
