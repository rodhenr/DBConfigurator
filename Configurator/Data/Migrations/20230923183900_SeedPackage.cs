using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Configurator.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageGroupId", "TableName", "Id" },
                values: new object[,]
                {
                    { 3, "TRAD_Aluno", 1 },
                    { 3, "TRAD_Escola", 2 },
                    { 3, "TRAD_Professor", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumns: new[] { "PackageGroupId", "TableName" },
                keyValues: new object[] { 3, "TRAD_Aluno" });

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumns: new[] { "PackageGroupId", "TableName" },
                keyValues: new object[] { 3, "TRAD_Escola" });

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumns: new[] { "PackageGroupId", "TableName" },
                keyValues: new object[] { 3, "TRAD_Professor" });
        }
    }
}
