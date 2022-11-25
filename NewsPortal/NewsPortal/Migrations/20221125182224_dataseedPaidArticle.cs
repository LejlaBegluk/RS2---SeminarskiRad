using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPortal.WebAPI.Migrations
{
    public partial class dataseedPaidArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                 table: "ArticlePayments",
                 columns: new[] { "Id", "Amount", "TansactionNumber", "TransactionDate", "UserId" },
                 values: new object[] { 1, 300.0, "pi_3M85JUByli9BoYmU0uLuKQa6", new DateTime(2022, 11, 25, 19, 22, 23, 795, DateTimeKind.Local).AddTicks(3178), 4 });

            migrationBuilder.InsertData(
                table: "PaidArticles",
                columns: new[] { "Id", "Active", "Content", "CreateOn", "PaidArticleStatusId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, true, "Reklama za sinmax akciju", new DateTime(2022, 11, 25, 19, 22, 23, 800, DateTimeKind.Local).AddTicks(9630), 2, "Sinmax black friday", 4 },
                    { 2, true, "Reklama za zimsku sezonu", new DateTime(2022, 11, 25, 19, 22, 23, 801, DateTimeKind.Local).AddTicks(1132), 2, "Apartmani Smuk na Bjelašnici", 4 },
                    { 3, true, "Reklama za blackfriday", new DateTime(2022, 11, 25, 19, 22, 23, 801, DateTimeKind.Local).AddTicks(1146), 5, "ITAcademy", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DeleteData(
               table: "ArticlePayments",
               keyColumn: "Id",
               keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaidArticles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaidArticles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaidArticles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
