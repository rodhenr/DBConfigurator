using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configurator.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE TRAD_Account ALTER COLUMN PreviousIdAccount nvarchar(200) not null");
            migrationBuilder.Sql("ALTER TABLE TRAD_Company ALTER COLUMN PreviousIdCompany nvarchar(200) not null");
            migrationBuilder.Sql("ALTER TABLE TRAD_Employee ALTER COLUMN PreviousIdEmployee nvarchar(200) not null");
            
            migrationBuilder.Sql("ALTER TABLE TRAD_Account ADD CONSTRAINT PK_TRAD_Account PRIMARY KEY (AccountId,PreviousIdAccount)");
            migrationBuilder.Sql("ALTER TABLE TRAD_Company ADD CONSTRAINT PK_TRAD_Company PRIMARY KEY (CompanyId,PreviousIdCompany)");
            migrationBuilder.Sql("ALTER TABLE TRAD_Employee ADD CONSTRAINT PK_TRAD_Employee PRIMARY KEY (EmployeeId,PreviousIdEmployee)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE TRAD_Account DROP CONSTRAINT PK_TRAD_Account");
            migrationBuilder.Sql("ALTER TABLE TRAD_Company DROP CONSTRAINT PK_TRAD_Company");
            migrationBuilder.Sql("ALTER TABLE TRAD_Employee DROP CONSTRAINT PK_TRAD_Employee");
            
            migrationBuilder.Sql("ALTER TABLE TRAD_Account ALTER COLUMN PreviousIdAccount nvarchar(max) not null");
            migrationBuilder.Sql("ALTER TABLE TRAD_Company ALTER COLUMN PreviousIdCompany nvarchar(max) not null");
            migrationBuilder.Sql("ALTER TABLE TRAD_Employee ALTER COLUMN PreviousIdEmployee nvarchar(max) not null");
        }
    }
}
