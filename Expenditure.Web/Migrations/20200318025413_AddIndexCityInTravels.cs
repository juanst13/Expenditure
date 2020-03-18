using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenditure.Web.Migrations
{
    public partial class AddIndexCityInTravels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Travels_City",
                table: "Travels");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_City",
                table: "Travels",
                column: "City",
                unique: true,
                filter: "[City] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Travels_City",
                table: "Travels");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_City",
                table: "Travels",
                column: "City");
        }
    }
}
