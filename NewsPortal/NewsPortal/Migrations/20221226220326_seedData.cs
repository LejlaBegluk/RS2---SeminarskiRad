using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using System.Reflection;
#nullable disable

namespace NewsPortal.WebAPI.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = typeof(seedData).Namespace + ".seedScript.sql";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string sqlResult = reader.ReadToEnd();
                    migrationBuilder.Sql(sqlResult);
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
