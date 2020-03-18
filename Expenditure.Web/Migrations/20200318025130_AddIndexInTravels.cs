using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenditure.Web.Migrations
{
    public partial class AddIndexInTravels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Travels",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
                name: "City",
                table: "Travels",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
