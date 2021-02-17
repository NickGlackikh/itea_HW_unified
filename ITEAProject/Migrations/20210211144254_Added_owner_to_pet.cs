using Microsoft.EntityFrameworkCore.Migrations;

namespace ITEAProject.Migrations
{
    public partial class Added_owner_to_pet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "OwnerId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "OwnerId",
                value: null);
        }
    }
}
