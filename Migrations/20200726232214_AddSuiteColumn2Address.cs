using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.SPA.Migrations
{
    public partial class AddSuiteColumn2Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "suite",
                table: "addresses",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "suite",
                table: "addresses");
        }
    }
}
