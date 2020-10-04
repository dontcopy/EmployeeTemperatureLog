using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTemperatureLog.Migrations
{
    public partial class FixedTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastNumber",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "LastNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
