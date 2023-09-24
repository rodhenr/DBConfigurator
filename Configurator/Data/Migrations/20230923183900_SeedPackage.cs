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
                    { 3, "TRAD_Account", 1 },
                    { 3, "TRAD_Company", 2 },
                    { 3, "TRAD_Employee", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumns: new[] { "PackageGroupId", "TableName" },
                keyValues: new object[] { 3, "TRAD_Account" });

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumns: new[] { "PackageGroupId", "TableName" },
                keyValues: new object[] { 3, "TRAD_Company" });

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumns: new[] { "PackageGroupId", "TableName" },
                keyValues: new object[] { 3, "TRAD_Employee" });
        }
    }
}
