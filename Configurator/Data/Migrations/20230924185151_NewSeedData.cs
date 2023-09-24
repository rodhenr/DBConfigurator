using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configurator.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Account_c(Account,AccountAcronym) VALUES('Account1','Account 1')");
            migrationBuilder.Sql(@"INSERT INTO Account_c(Account,AccountAcronym) VALUES('Account2','Account 2')");
            migrationBuilder.Sql(@"INSERT INTO Account_c(Account,AccountAcronym) VALUES('Account3','Account 3')");
            
            migrationBuilder.Sql(@"INSERT INTO Company_c(Company,CompanyAcronym) VALUES('Company1','Company 1')");
            migrationBuilder.Sql(@"INSERT INTO Company_c(Company,CompanyAcronym) VALUES('Company2','Company 2')");
            migrationBuilder.Sql(@"INSERT INTO Company_c(Company,CompanyAcronym) VALUES('Company3','Company 3')");
            
            migrationBuilder.Sql(@"INSERT INTO Employee_c(Employee,EmployeeAcronym) VALUES('Employee1','Employee 1')");
            migrationBuilder.Sql(@"INSERT INTO Employee_c(Employee,EmployeeAcronym) VALUES('Employee2','Employee 2')");
            migrationBuilder.Sql(@"INSERT INTO Employee_c(Employee,EmployeeAcronym) VALUES('Employee3','Employee 3')");

            migrationBuilder.Sql(@"INSERT INTO TRAD_Account(AccountId, PreviousIdAccount, Description) VALUES(1, '10', 'TRAD_ACCOUNT 1')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Account_c");
            migrationBuilder.Sql("DELETE FROM Company_c");
            migrationBuilder.Sql("DELETE FROM Employee_c");
            migrationBuilder.Sql("DELETE FROM TRAD_Account");
        }
    }
}
