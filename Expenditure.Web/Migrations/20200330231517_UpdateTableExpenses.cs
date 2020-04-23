using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenditure.Web.Migrations
{
    public partial class UpdateTableExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Travels_City",
                table: "Travels");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Travels_City",
                table: "Travels",
                column: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Travels_City",
                table: "Travels");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Expenses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travels_City",
                table: "Travels",
                column: "City",
                unique: true,
                filter: "[City] IS NOT NULL");
        }
    }
}
