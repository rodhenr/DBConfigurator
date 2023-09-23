using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configurator.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurationChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PackageGroupId",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "Packages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                columns: new[] { "PackageGroupId", "TableName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PackageGroupId",
                table: "Packages",
                column: "PackageGroupId");
        }
    }
}
