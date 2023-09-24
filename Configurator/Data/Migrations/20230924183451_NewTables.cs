using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configurator.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account_c",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountAcronym = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_c", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "Company_c",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAcronym = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_c", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "Employee_c",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeAcronym = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_c", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "TRAD_Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    PreviousIdAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                });
            
            migrationBuilder.CreateTable(
                name: "TRAD_Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PreviousIdCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                });
            
            migrationBuilder.CreateTable(
                name: "TRAD_Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PreviousIdEmployee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                });
            
            migrationBuilder.CreateTable(
                name: "TRAD_CompanyAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAD_CompanyAccount", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Employee_c");
            migrationBuilder.DropTable("Company_c");
            migrationBuilder.DropTable("Account_c");
            migrationBuilder.DropTable("TRAD_Employee");
            migrationBuilder.DropTable("TRAD_Company");
            migrationBuilder.DropTable("TRAD_Account");
            migrationBuilder.DropTable("TRAD_CompanyAccount");
        }
    }
}
